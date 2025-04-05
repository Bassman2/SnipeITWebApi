namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITLicensesUnitTest : SnipeITBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetLicensesAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetLicensesAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == licenseId);
        Assert.IsNotNull(item);
        Assert.AreEqual(licenseId, item.Id, "item.Id");
        Assert.AreEqual(licenseName, item.Name, "item.Name");
    }

    [TestMethod]
    public async Task TestMethodGetLicenseAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetLicenseAsync(licenseId);

        Assert.IsNotNull(item);
        Assert.AreEqual(licenseId, item.Id, "item.Id");
        Assert.AreEqual(licenseName, item.Name, "item.Name");
    }

    [TestMethod]
    public async Task TestMethodCreateLicenseAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        string createName = Guid.NewGuid().ToString();
        string updateName = Guid.NewGuid().ToString();
        string patchName = Guid.NewGuid().ToString();

        var create = await snipeIT.CreateLicenseAsync(new()
        {
            Name = createName,
            //Image = imageCreate,    
            Notes = notesCreate,
        });
        Assert.IsNotNull(create);
        Assert.IsTrue(create.Id > 0, "create.Id");
        int id = create.Id;

        var update = await snipeIT.UpdateLicenseAsync(id, new()
        {
            Name = updateName,
            //Image = imageUpdate,
            Notes = notesUpdate,

        });
        Assert.IsNotNull(update);

        var patch = await snipeIT.PatchLicenseAsync(id, new()
        {
            Name = patchName,
            //Image = imagePatch,
            Notes = notesPatch,

        });
        Assert.IsNotNull(patch);

        var del =  await snipeIT.DeleteLicenseAsync(id);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetLicenseAsync(id));

        Assert.AreEqual(id, create.Id, "create.Id");
        Assert.AreEqual(createName, create.Name, "create.Name");
        //Assert.AreEqual(imageCreate, create.Image, "create.Image");
        Assert.AreEqual(notesCreate, create.Notes, "create.Notes");

        Assert.AreEqual(id, update.Id, "update.Id");
        Assert.AreEqual(updateName, update.Name, "update.Name");
        //Assert.AreEqual(imageUpdate, update.Image, "update.Image");
        Assert.AreEqual(notesUpdate, update.Notes, "update.Notes");

        Assert.AreEqual(id, patch.Id, "patch.Id");
        Assert.AreEqual(patchName, patch.Name, "patch.Name");
        //Assert.AreEqual(imagePatch, patch.Image, "patch.Image");
        Assert.AreEqual(notesPatch, patch.Notes, "patch.Notes");
    }

    [TestMethod]
    public async Task TestMethodCreateDuplicateLicenseAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.CreateLicenseAsync(new() { Name = licenseName }));
    }

    [TestMethod]
    public async Task TestMethodGetNotExistingLicenseAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetLicenseAsync(notExistingId));
    }

    [TestMethod]
    public async Task TestMethodDeleteNotExistingLicenseAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.DeleteLicenseAsync(notExistingId));
    }
}
