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

        var create = new StatusLabel()
        {
            Name = createName,
            Type = StatusType.pending,
            //Image = imageCreate,    
            Notes = "create",
        };
        var created = await snipeIT.CreateStatusLabelAsync(create);
        Assert.IsNotNull(created);
        create.Id = created.Id;

        var retrieved = await snipeIT.GetStatusLabelAsync(created.Id);
        Assert.IsNotNull(retrieved);

        var update = new StatusLabel()
        {
            Id = created.Id,
            Name = updateName,
            Type = StatusType.archived,
            //Image = imageUpdate,
            Notes = notesUpdate,
        };
        var updated = await snipeIT.UpdateStatusLabelAsync(created.Id, update);
        Assert.IsNotNull(updated);

        var patch = new StatusLabel()
        {
            Id = created.Id,
            Name = patchName,
            Type = StatusType.deployable,
            //Image = imageUpdate,
            Notes = notesPatch,
        };
        var patched = await snipeIT.PatchStatusLabelAsync(created.Id, patch);
        Assert.IsNotNull(patched);

        var deleted = await snipeIT.DeleteStatusLabelAsync(created.Id);
        //Assert.IsNotNull(deleted);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetStatusLabelAsync(created.Id));

        AreEqual(create, created, "created");
        AreEqual(create, retrieved, "retrieved");
        AreEqual(update, updated, "updated");
        AreEqual(patch, patched, "patched");
        //AreEqual(patch, deleted, "deleted");

    //    Assert.AreEqual(id, create.Id, "create.Id");
    //    Assert.AreEqual(createName, create.Name, "create.Name");
    //    //Assert.AreEqual(imageCreate, create.Image, "create.Image");
    //    Assert.AreEqual(notesCreate, create.Notes, "create.Notes");

    //    Assert.AreEqual(id, update.Id, "update.Id");
    //    Assert.AreEqual(updateName, update.Name, "update.Name");
    //    //Assert.AreEqual(imageUpdate, update.Image, "update.Image");
    //    Assert.AreEqual(notesUpdate, update.Notes, "update.Notes");

    //    Assert.AreEqual(id, patch.Id, "patch.Id");
    //    Assert.AreEqual(patchName, patch.Name, "patch.Name");
    //    //Assert.AreEqual(imagePatch, patch.Image, "patch.Image");
    //    Assert.AreEqual(notesPatch, patch.Notes, "patch.Notes");
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

    private void AreEqual(StatusLabel expected, StatusLabel actual, string message)
    {
        Assert.AreEqual(expected.Id, actual.Id, $"{message}.Id");
        Assert.AreEqual(expected.Name, actual.Name, $"{message}.Name");
        //Assert.AreEqual(expected.Type, actual.Type, $"{message}.Type");
        Assert.AreEqual(expected.Color, actual.Color, $"{message}.Color");
        Assert.AreEqual(expected.ShowInNav ?? false, actual.ShowInNav, $"{message}.ShowInNav");
        Assert.AreEqual(expected.DefaultLabel ?? false, actual.DefaultLabel, $"{message}.DefaultLabel");
        Assert.AreEqual(0, actual.AssetsCount ?? 0, $"{message}.AssetsCount");
        Assert.AreEqual(expected.Notes, actual.Notes, $"{message}.Notes");
        Assert.AreEqual(null, actual.CreatedBy, $"{message}.CreatedBy");
        DateTimeAssert.AreEqual(today, actual.CreatedAt, $"{message}.CreatedAt");
        DateTimeAssert.AreEqual(today, actual.UpdatedAt, $"{message}.UpdatedAt");
    }
}
