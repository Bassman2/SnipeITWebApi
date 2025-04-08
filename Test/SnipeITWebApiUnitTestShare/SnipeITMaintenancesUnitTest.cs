namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITMaintenancesUnitTest : SnipeITBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetMaintenancesAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetMaintenancesAsync();

        var list = await asyncList.ToListAsync();


        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == maintenanceId);
        Assert.IsNotNull(item);
        Assert.AreEqual(maintenanceId, item.Id, "item.Id");
//        Assert.AreEqual(maintenanceName, item.Name, "item.Name");
    }

    [TestMethod]
    public async Task TestMethodGetMaintenanceAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetMaintenanceAsync(maintenanceId);
                
        Assert.IsNotNull(item);
        Assert.AreEqual(maintenanceId, item.Id, "item.Id");
  //      Assert.AreEqual(maintenanceName, item.Name, "item.Name");
    }

    [TestMethod]
    public async Task TestMethodCreateMaintenanceAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        string createName = Guid.NewGuid().ToString();
        string updateName = Guid.NewGuid().ToString();
        string patchName = Guid.NewGuid().ToString();

        var create = await snipeIT.CreateMaintenanceAsync(new()
        {
            //Name = createName,
            //Image = imageCreate,    
            Asset = hardwareId,
            Supplier = companyId,
            AssetMaintenanceType = "1",
            Title = createName,
            Notes = notesCreate,
            StartDate = DateTime.UtcNow,
        });
        Assert.IsNotNull(create);
        Assert.IsTrue(create.Id > 0, "create.Id");
        int id = create.Id;

        var update = await snipeIT.UpdateMaintenanceAsync(id, new()
        {
            //Name = updateName,
            //Image = imageUpdate,
            Notes = notesUpdate,

        });
        Assert.IsNotNull(update);

        var patch = await snipeIT.PatchMaintenanceAsync(id, new()
        {
        //    Name = patchName,
            //Image = imagePatch,
            Notes = notesPatch,

        });
        Assert.IsNotNull(patch);

        var del = await snipeIT.DeleteMaintenanceAsync(id);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetMaintenanceAsync(id));

        Assert.AreEqual(id, create.Id, "create.Id");
        //Assert.AreEqual(createName, create.Name, "create.Name");
        //Assert.AreEqual(imageCreate, create.Image, "create.Image");
        Assert.AreEqual(notesCreate, create.Notes, "create.Notes");

        Assert.AreEqual(id, update.Id, "update.Id");
        //Assert.AreEqual(updateName, update.Name, "update.Name");
        //Assert.AreEqual(imageUpdate, update.Image, "update.Image");
        Assert.AreEqual(notesUpdate, update.Notes, "update.Notes");

        Assert.AreEqual(id, patch.Id, "patch.Id");
        //Assert.AreEqual(patchName, patch.Name, "patch.Name");
        //Assert.AreEqual(imagePatch, patch.Image, "patch.Image");
        Assert.AreEqual(notesPatch, patch.Notes, "patch.Notes");
    }

    [TestMethod]
    public async Task TestMethodCreateDuplicateMaintenanceAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.CreateMaintenanceAsync(new() {
            Asset = hardwareId,
            Supplier = companyId,
            AssetMaintenanceType = "1",
            Title = maintenanceName,
            Notes = notesCreate,
            StartDate = DateTime.UtcNow,
        }));
    }

    [TestMethod]
    public async Task TestMethodGetNotExistingMaintenanceAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetMaintenanceAsync(notExistingId));
    }

    [TestMethod]
    public async Task TestMethodDeleteNotExistingMaintenanceAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.DeleteMaintenanceAsync(notExistingId));
    }
}
