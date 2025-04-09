namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITGroupsUnitTest : SnipeITBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetGroupsAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetGroupsAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == groupId);
        Assert.IsNotNull(item);
        Assert.AreEqual(groupId, item.Id, "item.Id");
        Assert.AreEqual(groupName, item.Name, "item.Name");
        Assert.IsNotNull(item.Permissions, "item.Permissions");
        Assert.AreEqual(0, item.UsersCount, "item.UsersCount");
        Assert.IsNull(item.Notes, "item.Notes");
        Assert.AreEqual(adminUser, item.CreatedBy, "item.CreatedBy");
        DateAssert.AreEqual("2025-02-25", item.CreatedAt, "item.CreatedAt");
        DateAssert.AreEqual("2025-02-25", item.UpdatedAt, "item.UpdatedAt");
        Assert.IsNotNull(item.AvailableActions, "item.AvailableActions");
        Assert.IsTrue(item.AvailableActions.Update, "item.AvailableActions.Update");
        Assert.IsTrue(item.AvailableActions.Delete, "item.AvailableActions.Delete");
    }

    [TestMethod]
    public async Task TestMethodGetGroupAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetGroupAsync(groupId);

        Assert.IsNotNull(item);
        Assert.AreEqual(groupId, item.Id, "item.Id");
        Assert.AreEqual(groupName, item.Name, "item.Name");
        Assert.IsNotNull(item.Permissions, "item.Permissions");
        Assert.AreEqual(0, item.UsersCount, "item.UsersCount");
        Assert.IsNull(item.Notes, "item.Notes");
        Assert.AreEqual(adminUser, item.CreatedBy, "item.CreatedBy");
        DateAssert.AreEqual("2025-02-25", item.CreatedAt, "item.CreatedAt");
        DateAssert.AreEqual("2025-02-25", item.UpdatedAt, "item.UpdatedAt");
        Assert.IsNotNull(item.AvailableActions, "item.AvailableActions");
        Assert.IsTrue(item.AvailableActions.Update, "item.AvailableActions.Update");
        Assert.IsTrue(item.AvailableActions.Delete, "item.AvailableActions.Delete");
    }

    [TestMethod]
    public async Task TestMethodCreateGroupAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        string createName = Guid.NewGuid().ToString();
        string updateName = Guid.NewGuid().ToString();
        string patchName = Guid.NewGuid().ToString();

        var create = await snipeIT.CreateGroupAsync(new()
        {
            Name = createName,
            //Image = imageCreate,    
            Notes = notesCreate,
        });
        Assert.IsNotNull(create);
        Assert.IsTrue(create.Id > 0, "create.Id");
        int id = create.Id;

        var update = await snipeIT.UpdateGroupAsync(id, new()
        {
            Name = updateName,
            //Image = imageUpdate,
            Notes = notesUpdate,

        });
        Assert.IsNotNull(update);

        var patch = await snipeIT.PatchGroupAsync(id, new()
        {
            Name = patchName,
            //Image = imagePatch,
            Notes = notesPatch,

        });
        Assert.IsNotNull(patch);

        var del = await snipeIT.DeleteGroupAsync(id);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetGroupAsync(id));

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
    public async Task TestMethodCreateDuplicateGroupAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.CreateGroupAsync(new() { Name = groupName }));
    }

    [TestMethod]
    public async Task TestMethodGetNotExistingGroupAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetGroupAsync(notExistingId));
    }

    [TestMethod]
    public async Task TestMethodDeleteNotExistingGroupAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.DeleteGroupAsync(notExistingId));
    }
}
