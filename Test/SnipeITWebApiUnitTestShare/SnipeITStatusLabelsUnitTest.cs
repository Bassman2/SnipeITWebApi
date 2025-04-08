namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITStatusLabelsUnitTest : SnipeITBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetStatusLabelsAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetStatusLabelsAsync();

        var list = await asyncList.ToListAsync();
        
        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == statusLabelId);
        Assert.IsNotNull(item);
        Assert.AreEqual(statusLabelId, item.Id, "item.Id");
        Assert.AreEqual(statusLabelName, item.Name, "item.Name");
      
    }

    [TestMethod]
    public async Task TestMethodGetStatusLabelAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetStatusLabelAsync(statusLabelId);

        Assert.IsNotNull(item);
        Assert.AreEqual(statusLabelId, item.Id, "item.Id");
        Assert.AreEqual(statusLabelName, item.Name, "item.Name");
    }

    [TestMethod]
    public async Task TestMethodCreateStatusLabelAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        string createName = Guid.NewGuid().ToString();
        string updateName = Guid.NewGuid().ToString();
        string patchName = Guid.NewGuid().ToString();

        var create = await snipeIT.CreateStatusLabelAsync(new()
        {
            Name = createName,
            Type = StatusType.Pending,
            //Image = imageCreate,    
            Notes = notesCreate,
        });
        Assert.IsNotNull(create);
        Assert.IsTrue(create.Id > 0, "create.Id");
        int id = create.Id;

        var update = await snipeIT.UpdateStatusLabelAsync(id, new()
        {
            Name = updateName,
            Type = StatusType.Archived,
            //Image = imageUpdate,
            Notes = notesUpdate,

        });
        Assert.IsNotNull(update);

        var patch = await snipeIT.PatchStatusLabelAsync(id, new()
        {
            Name = patchName,
            Type = StatusType.Undeployable,
            //Image = imagePatch,
            Notes = notesPatch,

        });
        Assert.IsNotNull(patch);

        var del = await snipeIT.DeleteStatusLabelAsync(id);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetStatusLabelAsync(id));

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
    public async Task TestMethodCreateDuplicateStatusLabelAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.CreateStatusLabelAsync(new() { Name = statusLabelName }));
    }

    [TestMethod]
    public async Task TestMethodGetNotExistingStatusLabelAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetStatusLabelAsync(notExistingId));
    }

    [TestMethod]
    public async Task TestMethodDeleteNotExistingCompanyAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.DeleteStatusLabelAsync(notExistingId));
    }
}
