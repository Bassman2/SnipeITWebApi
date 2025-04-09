namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITCompaniesUnitTest : SnipeITBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetCompaniesAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetCompaniesAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == companyId);

        Assert.IsNotNull(item);
        Assert.AreEqual(companyId, item.Id, "item.Id");
        Assert.AreEqual(companyName, item.Name, "item.Name");
        Assert.AreEqual(null, item.Phone, "item.Phone");
        Assert.IsNull(item.Fax, "item.Fax");
        Assert.AreEqual(null, item.Email, "item.Email");
        Assert.IsNull(item.Image, "item.Image");
        Assert.AreEqual(0, item.AssetsCount, "item.AssetsCount");
        Assert.AreEqual(0, item.AccessoriesCount, "item.AccessoriesCount");
        Assert.AreEqual(0, item.ConsumablesCount, "item.ConsumablesCount");
        Assert.IsNotNull(item.ComponentsCount, "item.ComponentsCount");
        Assert.IsNotNull(item.UsersCount, "item.UsersCount");
        Assert.AreEqual(adminUser, item.CreatedBy, "item.CreatedBy");
        Assert.AreEqual(notes, item.Notes, "item.Notes");
        DateAssert.AreEqual(lastUpdate, item.CreatedAt, "item.CreatedAt");
        DateAssert.AreEqual(lastUpdate, item.UpdatedAt, "item.UpdatedAt");
        Assert.IsNotNull(item.AvailableActions, "item.AvailableActions");
        Assert.IsTrue(item.AvailableActions.Update, "item.AvailableActions.Update");
        Assert.IsFalse(item.AvailableActions.Delete, "item.AvailableActions.Delete");
    }

    [TestMethod]
    public async Task TestMethodGetCompanyAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetCompanyAsync(companyId);

        Assert.IsNotNull(item);
        Assert.AreEqual(companyId, item.Id, "item.Id");
        Assert.AreEqual(companyName, item.Name, "item.Name");
        Assert.AreEqual(null, item.Phone, "item.Phone");
        Assert.IsNull(item.Fax, "item.Fax");
        Assert.AreEqual(null, item.Email, "item.Email");
        Assert.IsNull(item.Image, "item.Image");
        Assert.AreEqual(0, item.AssetsCount, "item.AssetsCount");
        Assert.AreEqual(0, item.AccessoriesCount, "item.AccessoriesCount");
        Assert.AreEqual(0, item.ConsumablesCount, "item.ConsumablesCount");
        Assert.AreEqual(0, item.ComponentsCount, "item.ComponentsCount");
        Assert.AreEqual(0, item.UsersCount, "item.UsersCount");
        Assert.AreEqual(adminUser, item.CreatedBy, "item.CreatedBy");
        Assert.AreEqual(notes, item.Notes, "item.Notes");
        DateAssert.AreEqual(lastUpdate, item.CreatedAt, "item.CreatedAt");
        DateAssert.AreEqual(lastUpdate, item.UpdatedAt, "item.UpdatedAt");
        Assert.IsNotNull(item.AvailableActions, "item.AvailableActions");
        Assert.IsTrue(item.AvailableActions.Update, "item.AvailableActions.Update");
        Assert.IsFalse(item.AvailableActions.Delete, "item.AvailableActions.Delete");
    }

    [TestMethod]
    public async Task TestMethodCreateCompanyAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        string createName = Guid.NewGuid().ToString();
        string updateName = Guid.NewGuid().ToString();
        string patchName = Guid.NewGuid().ToString();

        var create = await snipeIT.CreateCompanyAsync(new()
        {
            Name = createName,
            Phone = phoneCreate,
            Fax = faxCreate,
            Email = emailCreate,
            //Image = imageCreate,    
            Notes = notesCreate,
        });
        Assert.IsNotNull(create);
        Assert.IsTrue(create.Id > 0, "create.Id");
        int id = create.Id;

        var update = await snipeIT.UpdateCompanyAsync(id, new()
        {
            Name = updateName,
            Phone = phoneUpdate,
            Fax = faxUpdate,
            Email = emailUpdate,
            //Image = imageUpdate,
            Notes = notesUpdate,

        });
        Assert.IsNotNull(update);

        var patch = await snipeIT.PatchCompanyAsync(id, new()
        {
            Name = patchName,
            Phone = phonePatch,
            Fax = faxPatch,
            Email = emailPatch,
            //Image = imagePatch,
            Notes = notesPatch,

        });
        Assert.IsNotNull(patch);

        var del = await snipeIT.DeleteCompanyAsync(id);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetCompanyAsync(id));

        Assert.AreEqual(id, create.Id, "create.Id");
        Assert.AreEqual(createName, create.Name, "create.Name");
        Assert.AreEqual(phoneCreate, create.Phone, "create.Phone");
        Assert.AreEqual(faxCreate, create.Fax, "create.Fax");
        Assert.AreEqual(emailCreate, create.Email, "create.Email");
        //Assert.AreEqual(imageCreate, create.Image, "create.Image");
        Assert.AreEqual(notesCreate, create.Notes, "create.Notes");

        Assert.AreEqual(id, update.Id, "update.Id");
        Assert.AreEqual(updateName, update.Name, "update.Name");
        Assert.AreEqual(phoneUpdate, update.Phone, "update.Phone");
        Assert.AreEqual(faxUpdate, update.Fax, "update.Fax");
        Assert.AreEqual(emailUpdate, update.Email, "update.Email");
        //Assert.AreEqual(imageUpdate, update.Image, "update.Image");
        Assert.AreEqual(notesUpdate, update.Notes, "update.Notes");

        Assert.AreEqual(id, patch.Id, "patch.Id");
        Assert.AreEqual(patchName, patch.Name, "patch.Name");
        Assert.AreEqual(phonePatch, patch.Phone, "patch.Phone");
        Assert.AreEqual(faxPatch, patch.Fax, "patch.Fax");
        Assert.AreEqual(emailPatch, patch.Email, "patch.Email");
        //Assert.AreEqual(imagePatch, patch.Image, "patch.Image");
        Assert.AreEqual(notesPatch, patch.Notes, "patch.Notes");
    }

    [TestMethod]
    public async Task TestMethodCreateDuplicateCompanyAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.CreateCompanyAsync(new () { Name = companyName }));
    }

    [TestMethod]
    public async Task TestMethodGetNotExistingCompanyAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetCompanyAsync(notExistingId));
    }

    [TestMethod]
    public async Task TestMethodDeleteNotExistingCompanyAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.DeleteCompanyAsync(notExistingId));
    }
}
