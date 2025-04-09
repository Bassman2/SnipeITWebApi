using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITAccessoriesUnitTest : SnipeITBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetAccessoriesAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetAccessoriesAsync();

        var list = await asyncList.ToListAsync();

        var sort = list.OrderBy(i => i.Id).ToList();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == accessoryId);
        Assert.IsNotNull(item);
        Assert.AreEqual(accessoryId, item.Id, "item.Id");
        Assert.AreEqual(accessoryName, item.Name, "item.Name");
    }

    [TestMethod]
    public async Task TestMethodGetAccessoryAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetAccessoryAsync(accessoryId);
                
        Assert.IsNotNull(item);
        Assert.AreEqual(accessoryId, item.Id, "item.Id");
        Assert.AreEqual(accessoryName, item.Name, "item.Name");
    }

    [TestMethod]
    public async Task TestMethodCreateAccessoryAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        string createName = Guid.NewGuid().ToString();
        string updateName = Guid.NewGuid().ToString();
        string patchName = Guid.NewGuid().ToString();

        var create = new Accessory()
        {
            Name = createName,
            Qty = 1,
            Category = 8,
            //Image = imageCreate,    
            Notes = "create",
        };
        var created = await snipeIT.CreateAccessoryAsync(create);
        Assert.IsNotNull(created);
        int id = created.Id;

        var retrieved = await snipeIT.GetAccessoryAsync(id);
        Assert.IsNotNull(retrieved);

        var update = new Accessory()
        {
            Name = updateName,
            //Image = imageUpdate,
            Notes = notesUpdate,

        };
        var updated = await snipeIT.UpdateAccessoryAsync(id, update);
        Assert.IsNotNull(updated);

        var patch = new Accessory()
        {
            Name = patchName,
            //Image = imageUpdate,
            Notes = notesPatch,
        };
        var patched = await snipeIT.PatchAccessoryAsync(id, patch);
        Assert.IsNotNull(patched);

        var deleted = await snipeIT.DeleteAccessoryAsync(id);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetAccessoryAsync(id));

        AreEqual(id, create, created, "created");
        AreEqual(id, create, retrieved, "retrieved");
        AreEqual(id, update, updated, "updated");
        AreEqual(id, patch, patched, "patched");
        //AreEqual(id, patch, deleted, "deleted");


        //Assert.AreEqual(id, create.Id, "create.Id");
        //Assert.AreEqual(createName, create.Name, "create.Name");
        ////Assert.AreEqual(imageCreate, create.Image, "create.Image");
        //Assert.AreEqual(notesCreate, create.Notes, "create.Notes");

        //Assert.AreEqual(id, update.Id, "update.Id");
        //Assert.AreEqual(updateName, update.Name, "update.Name");
        ////Assert.AreEqual(imageUpdate, update.Image, "update.Image");
        //Assert.AreEqual(notesUpdate, update.Notes, "update.Notes");

        //Assert.AreEqual(id, patch.Id, "patch.Id");
        //Assert.AreEqual(patchName, patch.Name, "patch.Name");
        ////Assert.AreEqual(imagePatch, patch.Image, "patch.Image");
        //Assert.AreEqual(notesPatch, patch.Notes, "patch.Notes");
    }


    // Can be duplicate 

    //[TestMethod]
    //public async Task TestMethodCreateDuplicateAccessoryAsync()
    //{
    //    using var snipeIT = new SnipeIT(developStoreKey, appName);

    //    await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.CreateAccessoryAsync(new() { Name = accessoryName, Qty = 1, Category = 8 }));
    //}

    [TestMethod]
    public async Task TestMethodGetNotExistingAccessoryAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetAccessoryAsync(notExistingId));
    }

    [TestMethod]
    public async Task TestMethodDeleteNotExistingAccessoryAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.DeleteAccessoryAsync(notExistingId));
    }

    private void AreEqual(int id, Accessory expected, Accessory actual, string message)
    {
        Assert.AreEqual(id, actual.Id, $"{message}.Id");
        Assert.AreEqual(expected.Name, actual.Name, $"{message}.Name");
        //Assert.AreEqual(expected.Type, actual.Type, $"{message}.Type");
        //Assert.AreEqual(expected.Color, actual.Color, $"{message}.Color");
        //Assert.AreEqual(expected.ShowInNav ?? false, actual.ShowInNav, $"{message}.ShowInNav");
        //Assert.AreEqual(expected.DefaultLabel ?? false, actual.DefaultLabel, $"{message}.DefaultLabel");
        //Assert.AreEqual(0, actual.AssetsCount ?? 0, $"{message}.AssetsCount");
        Assert.AreEqual(expected.Notes, actual.Notes, $"{message}.Notes");
        Assert.AreEqual(null, actual.CreatedBy, $"{message}.CreatedBy");
        DateTimeAssert.AreEqual(today, actual.CreatedAt, $"{message}.CreatedAt");
        DateTimeAssert.AreEqual(today, actual.UpdatedAt, $"{message}.UpdatedAt");
    }
}
