namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITDepartmentsUnitTest : SnipeITBaseUnitTest
{

    [TestMethod]
    public async Task TestMethodGetDepartmentsAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetDepartmentsAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == departmentId);
        Assert.IsNotNull(item);
        Assert.AreEqual(departmentId, item.Id, "item.Id");
        Assert.AreEqual(departmentName, item.Name, "item.Name");
        Assert.IsNull(item.Phone, "item.Phone");
        Assert.IsNull(item.Fax, "item.Fax");
        Assert.IsNull(item.Image, "item.Image");
        Assert.IsNull(item.Company, "item.Company");
        Assert.IsNull(item.Manager, "item.Manager");
        Assert.AreEqual(new NamedItem(9, "South Braden"), item.Location, "item.Location");
        Assert.IsTrue(item.UsersCount > 1, "item.UsersCount");
        Assert.AreEqual("Created by DB seeder", item.Notes, "item.Notes");
        DateTimeAssert.AreEqual(lastUpdate, item.CreatedAt, "item.CreatedAt");
        DateTimeAssert.AreEqual(lastUpdate, item.UpdatedAt, "item.UpdatedAt");
        Assert.IsNotNull(item.AvailableActions, "item.AvailableActions");
        Assert.IsTrue(item.AvailableActions.Update, "item.AvailableActions.Update");
        Assert.IsFalse(item.AvailableActions.Delete, "item.AvailableActions.Delete");
    }

    [TestMethod]
    public async Task TestMethodGetDepartmentAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetDepartmentAsync(departmentId);

        Assert.IsNotNull(item);
        Assert.AreEqual(departmentId, item.Id, "item.Id");
        Assert.AreEqual(departmentName, item.Name, "item.Name");
        Assert.IsNull(item.Phone, "item.Phone");
        Assert.IsNull(item.Fax, "item.Fax");
        Assert.IsNull(item.Image, "item.Image");
        Assert.IsNull(item.Company, "item.Company");
        Assert.IsNull(item.Manager, "item.Manager");
        Assert.AreEqual(new NamedItem(9, "South Braden"), item.Location, "item.Location");
        Assert.IsNull(item.UsersCount, "item.UsersCount");
        Assert.AreEqual("Created by DB seeder", item.Notes, "item.Notes");
        DateTimeAssert.AreEqual(lastUpdate, item.CreatedAt, "item.CreatedAt");
        DateTimeAssert.AreEqual(lastUpdate, item.UpdatedAt, "item.UpdatedAt");
        Assert.IsNotNull(item.AvailableActions, "item.AvailableActions");
        Assert.IsTrue(item.AvailableActions.Update, "item.AvailableActions.Update");
        Assert.IsTrue(item.AvailableActions.Delete, "item.AvailableActions.Delete");
    }

    [TestMethod]
    public async Task TestMethodCreateDepartmentAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        string createName = Guid.NewGuid().ToString();
        string updateName = Guid.NewGuid().ToString();
        string patchName = Guid.NewGuid().ToString();

        var create = await snipeIT.CreateDepartmentAsync(new()
        {
            Name = createName,
            Phone = phoneCreate,
            Fax = faxCreate,
            Notes = notesCreate,
        });
        Assert.IsNotNull(create);
        Assert.IsTrue(create.Id > 0, "create.Id");
        int id = create.Id;

        var update = await snipeIT.UpdateDepartmentAsync(id, new()
        {
            Name = updateName,
            Phone = phoneUpdate,
            Fax = faxUpdate,
            Notes = notesUpdate,

        });
        Assert.IsNotNull(update);

        var patch = await snipeIT.PatchDepartmentAsync(id, new()
        {
            Name = patchName,
            Phone = phonePatch,
            Fax = faxPatch,
            Notes = notesPatch,

        });
        Assert.IsNotNull(patch);

        await snipeIT.DeleteDepartmentAsync(id);

        var del = await snipeIT.GetDepartmentAsync(id);

        Assert.AreEqual(id, create.Id, "create.Id");
        Assert.AreEqual(createName, create.Name, "create.Name");
        Assert.AreEqual(phoneCreate, create.Phone, "create.Phone");
        Assert.AreEqual(faxCreate, create.Fax, "create.Fax");
        Assert.AreEqual(notesCreate, create.Notes, "create.Notes");

        Assert.AreEqual(id, update.Id, "update.Id");
        Assert.AreEqual(updateName, update.Name, "update.Name");
        Assert.AreEqual(phoneUpdate, update.Phone, "update.Phone");
        Assert.AreEqual(faxUpdate, update.Fax, "update.Fax");
        Assert.AreEqual(notesUpdate, update.Notes, "update.Notes");

        Assert.AreEqual(id, patch.Id, "patch.Id");
        Assert.AreEqual(patchName, patch.Name, "patch.Name");
        Assert.AreEqual(phonePatch, patch.Phone, "patch.Phone");
        Assert.AreEqual(faxPatch, patch.Fax, "patch.Fax");
        Assert.AreEqual(notesPatch, patch.Notes, "patch.Notes");
    }

    // Department name can be duplicate

    //[TestMethod]
    //public async Task TestMethodCreateDuplicateDepartmentAsync()
    //{
    //    using var snipeIT = new SnipeIT(developStoreKey, appName);

    //    var create = new Department() { Name = departmentName };

    //    await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.CreateDepartmentAsync(create));
    //}

    [TestMethod]
    public async Task TestMethodGetNotExistingDepartmentAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetDepartmentAsync(notExistingId));
    }

    [TestMethod]
    public async Task TestMethodDeleteNotExistingDepartmentAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.DeleteDepartmentAsync(notExistingId));
    }
}
