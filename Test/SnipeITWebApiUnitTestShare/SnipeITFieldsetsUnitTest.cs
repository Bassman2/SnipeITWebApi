namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITFieldsetsUnitTest : SnipeITBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetFieldsetsAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetFieldsetsAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == fieldsetId);
        Assert.IsNotNull(item);
        Assert.AreEqual(fieldsetId, item.Id, "item.Id");
        Assert.AreEqual(fieldsetName, item.Name, "item.Name");
    }

    [TestMethod]
    public async Task TestMethodGetFieldsetAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetFieldsetAsync(fieldsetId);

        Assert.IsNotNull(item);
        Assert.AreEqual(fieldsetId, item.Id, "item.Id");
        Assert.AreEqual(fieldsetName, item.Name, "item.Name");
    }

    [TestMethod]
    public async Task TestMethodCreateFieldsetAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        string createName = Guid.NewGuid().ToString();
        string updateName = Guid.NewGuid().ToString();
        string patchName = Guid.NewGuid().ToString();

        var create = await snipeIT.CreateFieldsetAsync(new()
        {
            Name = createName,
            
            //Image = imageCreate,    
            //Notes = notesCreate,
        });
        Assert.IsNotNull(create);
        Assert.IsTrue(create.Id > 0, "create.Id");
        int id = create.Id;

        var update = await snipeIT.UpdateFieldsetAsync(id, new()
        {
            Name = updateName,
            
            //Image = imageUpdate,
            //Notes = notesUpdate,

        });
        Assert.IsNotNull(update);

        var patch = await snipeIT.PatchFieldsetAsync(id, new()
        {
            Name = patchName,
            
            //Image = imagePatch,
            //Notes = notesPatch,

        });
        Assert.IsNotNull(patch);

        await snipeIT.DeleteFieldsetAsync(id);

        var del = await snipeIT.GetFieldsetAsync(id);

        Assert.AreEqual(id, create.Id, "create.Id");
        Assert.AreEqual(createName, create.Name, "create.Name");
        
        //Assert.AreEqual(imageCreate, create.Image, "create.Image");
        //Assert.AreEqual(notesCreate, create.Notes, "create.Notes");

        Assert.AreEqual(id, update.Id, "update.Id");
        Assert.AreEqual(updateName, update.Name, "update.Name");
        //Assert.AreEqual(imageUpdate, update.Image, "update.Image");
        //Assert.AreEqual(notesUpdate, update.Notes, "update.Notes");

        Assert.AreEqual(id, patch.Id, "patch.Id");
        Assert.AreEqual(patchName, patch.Name, "patch.Name");
        //Assert.AreEqual(imagePatch, patch.Image, "patch.Image");
        //Assert.AreEqual(notesPatch, patch.Notes, "patch.Notes");
    }

    [TestMethod]
    public async Task TestMethodCreateDuplicateCompanyAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.CreateFieldsetAsync(new() { Name = fieldsetName }));
    }

    [TestMethod]
    public async Task TestMethodDeleteNotExistingCompanyAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.DeleteFieldsetAsync(notExistingId));
    }
}
