namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITLocationsUnitTest : SnipeITBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetLocationsAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetLocationsAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == locationId);
        Assert.IsNotNull(item);
        Assert.AreEqual(locationId, item.Id, "item.Id");
        Assert.AreEqual(locationName, item.Name, "item.Name");
    }

    [TestMethod]
    public async Task TestMethodGetLocationAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetLocationAsync(locationId);

        Assert.IsNotNull(item);
        Assert.AreEqual(locationId, item.Id, "item.Id");
        Assert.AreEqual(locationName, item.Name, "item.Name");
    }

    [TestMethod]
    public async Task TestMethodCreateLocationAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        string createName = Guid.NewGuid().ToString();
        string updateName = Guid.NewGuid().ToString();
        string patchName = Guid.NewGuid().ToString();

        var create = await snipeIT.CreateLocationAsync(new()
        {
            Name = createName,
            Phone = phoneCreate,
            Fax = faxCreate,
            //Image = imageCreate,    
            Notes = notesCreate,
        });
        Assert.IsNotNull(create);
        Assert.IsTrue(create.Id > 0, "create.Id");
        int id = create.Id;

        var update = await snipeIT.UpdateLocationAsync(id, new()
        {
            Name = updateName,
            Phone = phoneUpdate,
            Fax = faxUpdate,
            //Image = imageUpdate,
            Notes = notesUpdate,

        });
        Assert.IsNotNull(update);

        var patch = await snipeIT.PatchLocationAsync(id, new()
        {
            Name = patchName,
            Phone = phonePatch,
            Fax = faxPatch,
            //Image = imagePatch,
            Notes = notesPatch,

        });
        Assert.IsNotNull(patch);

        await snipeIT.DeleteLocationAsync(id);

        var del = await snipeIT.GetLocationAsync(id);

        Assert.AreEqual(id, create.Id, "create.Id");
        Assert.AreEqual(createName, create.Name, "create.Name");
        Assert.AreEqual(phoneCreate, create.Phone, "create.Phone");
        Assert.AreEqual(faxCreate, create.Fax, "create.Fax");
        //Assert.AreEqual(imageCreate, create.Image, "create.Image");
        Assert.AreEqual(notesCreate, create.Notes, "create.Notes");

        Assert.AreEqual(id, update.Id, "update.Id");
        Assert.AreEqual(updateName, update.Name, "update.Name");
        Assert.AreEqual(phoneUpdate, update.Phone, "update.Phone");
        Assert.AreEqual(faxUpdate, update.Fax, "update.Fax");
        //Assert.AreEqual(imageUpdate, update.Image, "update.Image");
        Assert.AreEqual(notesUpdate, update.Notes, "update.Notes");

        Assert.AreEqual(id, patch.Id, "patch.Id");
        Assert.AreEqual(patchName, patch.Name, "patch.Name");
        Assert.AreEqual(phonePatch, patch.Phone, "patch.Phone");
        Assert.AreEqual(faxPatch, patch.Fax, "patch.Fax");
        //Assert.AreEqual(imagePatch, patch.Image, "patch.Image");
        Assert.AreEqual(notesPatch, patch.Notes, "patch.Notes");
    }

    [TestMethod]
    public async Task TestMethodCreateDuplicateLocationAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.CreateLocationAsync(new() { Name = locationName }));
    }

    [TestMethod]
    public async Task TestMethodDeleteNotExistingLocationAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.DeleteLocationAsync(notExistingId));
    }
}
