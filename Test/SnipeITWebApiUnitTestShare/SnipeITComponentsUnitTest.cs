namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITComponentsUnitTest : SnipeITBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetComponentsAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetComponentsAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == componentId);
        Assert.IsNotNull(item);
        Assert.AreEqual(componentId, item.Id, "item.Id");
        Assert.AreEqual(componentName, item.Name, "item.Name");
    }

    [TestMethod]
    public async Task TestMethodGetComponentAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetComponentAsync(componentId);
        
        Assert.IsNotNull(item);
        Assert.AreEqual(componentId, item.Id, "item.Id");
        Assert.AreEqual(componentName, item.Name, "item.Name");
    }

    [TestMethod]
    public async Task TestMethodCreateComponentAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        string createName = Guid.NewGuid().ToString();
        string updateName = Guid.NewGuid().ToString();
        string patchName = Guid.NewGuid().ToString();

        var create = await snipeIT.CreateComponentAsync(new()
        {
            Name = createName,
            //Image = imageCreate,    
            //Notes = notesCreate,
        });
        Assert.IsNotNull(create);
        Assert.IsTrue(create.Id > 0, "create.Id");
        int id = create.Id;

        var update = await snipeIT.UpdateComponentAsync(id, new()
        {
            Name = updateName,
            //Image = imageUpdate,
            //Notes = notesUpdate,

        });
        Assert.IsNotNull(update);

        var patch = await snipeIT.PatchComponentAsync(id, new()
        {
            Name = patchName,
            //Image = imagePatch,
            //Notes = notesPatch,

        });
        Assert.IsNotNull(patch);

        await snipeIT.DeleteComponentAsync(id);

        var del = await snipeIT.GetComponentAsync(id);

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
    public async Task TestMethodCreateDuplicateComponentAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.CreateComponentAsync(new() { Name = componentName }));
    }

    [TestMethod]
    public async Task TestMethodDeleteNotExistingComponentAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.DeleteComponentAsync(notExistingId));
    }
}
