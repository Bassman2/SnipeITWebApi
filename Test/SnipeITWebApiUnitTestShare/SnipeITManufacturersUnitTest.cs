namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITManufacturersUnitTest : SnipeITBaseUnitTest
{

    [TestMethod]
    public async Task TestMethodGetManufacturersAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetManufacturersAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(i => i.Id == manufacturerId);
        Assert.IsNotNull(item);
        Assert.AreEqual(manufacturerId, item.Id, "item.Id");
        Assert.AreEqual(manufacturerName, item.Name, "item.Name");
        Assert.AreEqual("https://apple.com", item.Url, "item.Url");
        Assert.AreEqual("https://develop.snipeitapp.com/uploads/manufacturers/apple.jpg", item.Image, "item.Image");
        Assert.AreEqual("https://support.apple.com", item.SupportUrl, "item.SupportUrl");
        Assert.AreEqual("https://checkcoverage.apple.com", item.WarrantyLookupUrl, "item.WarrantyLookupUrl");
        Assert.AreEqual("+19864240208", item.SupportPhone, "item.SupportPhone");
        Assert.AreEqual("carey.sanford@example.net", item.SupportEmail, "item.SupportEmail");

        Assert.AreNotEqual(0, item.AssetsCount, "item.AssetsCount");
        Assert.IsNotNull(item.LicensesCount, "item.LicensesCount");
        Assert.AreEqual(0, item.ConsumablesCount, "item.ConsumablesCount");
        Assert.AreEqual(3, item.AccessoriesCount, "item.AccessoriesCount");
        Assert.AreEqual(0, item.ComponentsCount, "item.ComponentsCount");
        Assert.AreEqual("Created by DB seeder", item.Notes, "item.Notes");
        Assert.AreEqual(adminUser, item.CreatedBy, "item.CreatedBy");
        DateAssert.AreEqual(lastUpdate, item.CreatedAt, "item.CreatedAt");
        DateAssert.AreEqual(lastUpdate, item.UpdatedAt, "item.UpdatedAt");
        DateAssert.IsNull(item.DeletedAt, "item.DeletedAt");

        Assert.IsNotNull(item.AvailableActions, "item.AvailableActions");
        Assert.AreEqual(true, item.AvailableActions.Update, "item.AvailableActions.Update");
        Assert.AreEqual(false, item.AvailableActions.Restore, "item.AvailableActions.Restore");
        Assert.AreEqual(false, item.AvailableActions.Delete, "item.AvailableActions.Delete");

    }

    [TestMethod]
    public async Task TestMethodGetManufacturerAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetManufacturerAsync(manufacturerId);

        Assert.IsNotNull(item);
        Assert.AreEqual(manufacturerId, item.Id, "item.Id");
        Assert.AreEqual(manufacturerName, item.Name, "item.Name");
        Assert.AreEqual("https://apple.com", item.Url, "item.Url");
        Assert.AreEqual("https://develop.snipeitapp.com/uploads/manufacturers/apple.jpg", item.Image, "item.Image");
        Assert.AreEqual("https://support.apple.com", item.SupportUrl, "item.SupportUrl");
        Assert.AreEqual("https://checkcoverage.apple.com", item.WarrantyLookupUrl, "item.WarrantyLookupUrl");
        Assert.AreEqual("+19864240208", item.SupportPhone, "item.SupportPhon");
        Assert.AreEqual("carey.sanford@example.net", item.SupportEmail, "item.SupportEmail");

        Assert.AreNotEqual(0, item.AssetsCount, "item.AssetsCount");
        Assert.IsNotNull(item.LicensesCount, "item.LicensesCount");
        Assert.AreEqual(0, item.ConsumablesCount, "item.ConsumablesCount");
        Assert.AreEqual(3, item.AccessoriesCount, "item.AccessoriesCount");
        Assert.AreEqual(0, item.ComponentsCount, "item.ComponentsCount");
        Assert.AreEqual(notes, item.Notes, "item.Notes");

        Assert.AreEqual(adminUser, item.CreatedBy, "item.CreatedBy");
        DateAssert.AreEqual(lastUpdate, item.CreatedAt, "item.CreatedAt");
        DateAssert.AreEqual(lastUpdate, item.UpdatedAt, "item.UpdatedAt");
        DateAssert.IsNull(item.DeletedAt, "item.DeletedAt");

        Assert.IsNotNull(item.AvailableActions, "item.AvailableActions");
        Assert.AreEqual(true, item.AvailableActions.Update, "item.AvailableActions.Update");
        Assert.AreEqual(false, item.AvailableActions.Restore, "item.AvailableActions.Restore");
        Assert.AreEqual(false, item.AvailableActions.Delete, "item.AvailableActions.Delete");
    }

    //[TestMethod]
    //public async Task TestMethodCreateManufacturerAsync()
    //{
    //    using var snipeIT = new SnipeIT(developStoreKey, appName);

    //    string createName = Guid.NewGuid().ToString();
    //    string updateName = Guid.NewGuid().ToString();
    //    string patchName = Guid.NewGuid().ToString();

    //    var create = await snipeIT.CreateManufacturerAsync(new()
    //    {
    //        Name = createName,
    //        Url = "https://test.com",
    //        //Image = "https://develop.snipeitapp.com/uploads/manufacturers/apple.jpg",        // https://raw.githubusercontent.com/Bassman2/SnipeITWebApi/master/.github/images/donate.gif
    //        SupportUrl = "https://support.test.com",
    //        WarrantyLookupUrl = "https://checkcoverage.test.com",
    //        SupportPhone = "+12725858512",
    //        SupportEmail = "unknown@microsoft.com",
    //        Notes = "Dummy Note"
    //    });
    //    Assert.IsNotNull(create);
    //    Assert.IsTrue(create.Id > 0, "create.Id");
    //    int id = create.Id;


    //    var update = await snipeIT.UpdateManufacturerAsync(id, new()
    //    {
    //        Name = updateName
    //    });
    //    Assert.IsNotNull(update);

    //    var patch = await snipeIT.PatchManufacturerAsync(id, new() 
    //    {
    //        Name = patchName
    //    });
    //    Assert.IsNotNull(patch);

    //    var del = await snipeIT.DeleteManufacturerAsync(id);

    //    await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetManufacturerAsync(id));

    //    Assert.AreNotEqual(0, create.Id, "create.Id");
    //    Assert.AreEqual(createName, create.Name, "create.Name");
    //    Assert.AreEqual("https://test.com", create.Url, "create.Url");
    //    //Assert.AreEqual("https://develop.snipeitapp.com/uploads/manufacturers/apple.jpg", create.Image, nameof(create.Image));
    //    Assert.AreEqual("https://support.test.com", create.SupportUrl, "create.SupportUrl");
    //    Assert.AreEqual("https://checkcoverage.test.com", create.WarrantyLookupUrl, "create.WarrantyLookupUrl");
    //    Assert.AreEqual("+12725858512", create.SupportPhone, "create.SupportPhone");
    //    Assert.AreEqual("unknown@microsoft.com", create.SupportEmail, "create.SupportEmail");
    //    Assert.AreEqual("Dummy Note", create.Notes, "create.Notes");

    //    Assert.AreNotEqual(0, update.Id, "create.Id");
    //    Assert.AreEqual(updateName, update.Name, "update.Name");
    //    Assert.AreEqual("https://test.com", update.Url, "update.Url");
    //    //Assert.AreEqual("https://develop.snipeitapp.com/uploads/manufacturers/apple.jpg", update.Image, nameof(update.Image));
    //    Assert.AreEqual("https://support.test.com", update.SupportUrl, "update.SupportUrl");
    //    Assert.AreEqual("https://checkcoverage.test.com", update.WarrantyLookupUrl, "update.WarrantyLookupUrl");
    //    Assert.AreEqual("+12725858512", update.SupportPhone, "update.SupportPhone");
    //    Assert.AreEqual("unknown@microsoft.com", update.SupportEmail, "update.SupportEmail");
    //    Assert.AreEqual("Dummy Note", update.Notes, "update.Notes");

    //    Assert.AreNotEqual(0, patch.Id, "patch.Id");
    //    Assert.AreEqual(patchName, patch.Name, "patch.Name");
    //    Assert.AreEqual("https://test.com", patch.Url, "patch.Url");
    //    //Assert.AreEqual("https://develop.snipeitapp.com/uploads/manufacturers/apple.jpg", patch.Image, nameof(patch.Image));
    //    Assert.AreEqual("https://support.test.com", patch.SupportUrl, "patch.SupportUrl");
    //    Assert.AreEqual("https://checkcoverage.test.com", patch.WarrantyLookupUrl, "patch.WarrantyLookupUrl");
    //    Assert.AreEqual("+12725858512", patch.SupportPhone, "patch.SupportPhone");
    //    Assert.AreEqual("unknown@microsoft.com", patch.SupportEmail, "patch.SupportEmail");
    //    Assert.AreEqual("Dummy Note", patch.Notes, "patch.Notes");
    //}

    [TestMethod]
    public async Task TestMethodCreateDuplicateManufacturerAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.CreateManufacturerAsync(new () { Name = manufacturerName }));
    }

    [TestMethod]
    public async Task TestMethodGetNotExistingManufacturerAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetManufacturerAsync(notExistingId));
    }

    [TestMethod]
    public async Task TestMethodDeleteNotExistingManufacturerAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.DeleteManufacturerAsync(notExistingId));
    }
}