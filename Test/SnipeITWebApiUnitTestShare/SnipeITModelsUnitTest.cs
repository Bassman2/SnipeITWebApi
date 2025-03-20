namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITModelsUnitTest : SnipeITBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetModelsAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetModelsAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(i => i.Name == "Surface");
        Assert.IsNotNull(item);
        Assert.AreEqual(3, item.Id, nameof(item.Id));
        Assert.AreEqual("Surface", item.Name, nameof(item.Name));

        Assert.IsNotNull(item.Manufacturer);
        Assert.AreEqual(2, item.Manufacturer.Id, "Manufacturer.Id");
        Assert.AreEqual("Microsoft", item.Manufacturer.Name, "Manufacturer.Name");

        Assert.AreEqual("https://develop.snipeitapp.com/uploads/models/surface.jpg", item.Image, nameof(item.Image));

        //Assert.AreEqual("https://support.apple.com", item.SupportUrl, nameof(item.SupportUrl));
        //Assert.AreEqual("https://checkcoverage.apple.com", item.WarrantyLookupUrl, nameof(item.WarrantyLookupUrl));
        //Assert.AreEqual("+12725858512", item.SupportPhone, nameof(item.SupportPhone));
        //Assert.AreEqual("marlee46@example.com", item.SupportEmail, nameof(item.SupportEmail));

        //Assert.AreNotEqual(0, item.AssetsCount, nameof(item.AssetsCount));
        //Assert.AreEqual(0, item.LicensesCount, nameof(item.LicensesCount));
        //Assert.AreEqual(0, item.ConsumablesCount, nameof(item.ConsumablesCount));
        //Assert.AreEqual(0, item.AccessoriesCount, nameof(item.AccessoriesCount));
        //Assert.AreEqual(0, item.ComponentsCount, nameof(item.ComponentsCount));
        //Assert.AreEqual("Created by DB seeder", item.Notes, nameof(item.Notes));

        ////Assert.IsNotNull(item.CreatedBy, nameof(item.CreatedBy));
        ////Assert.AreEqual(1, item.CreatedBy.Id, "CreatedBy.Id");
        ////Assert.AreEqual("Alf Shumway", item.CreatedBy.Name, "CreatedBy.Name");

        ////Assert.IsNotNull(item.CreatedAt, nameof(item.CreatedAt));
        ////Assert.IsNull(item.CreatedAt.Date, "CreatedAt.Date");
        ////Assert.AreEqual("Thu Feb 20, 2025 11:59AM", item.CreatedAt.Formatted, "CreatedAt.Formatted");

        ////Assert.IsNotNull(item.UpdatedAt);
        ////Assert.IsNull(item.UpdatedAt.Date, "UpdatedAt.Date");
        ////Assert.AreEqual("Thu Feb 20, 2025 11:59AM", item.UpdatedAt.Formatted, "UpdatedAt.Formatted");

        //Assert.IsNull(item.DeletedAt, nameof(item.DeletedAt));
        ////Assert.AreEqual("2021-09-29 00:00:00", item.DeletedAt.Date, "DeletedAt.Date");
        ////Assert.AreEqual("2021-09-29 00:00:00", item.DeletedAt.Formatted, "DeletedAt.Formatted");

        //Assert.IsNotNull(item.AvailableActions, nameof(item.AvailableActions));
        //Assert.AreEqual(true, item.AvailableActions.Update, "AvailableActions.Update");
        //Assert.AreEqual(false, item.AvailableActions.Restore, "AvailableActions.Restore");
        //Assert.AreEqual(false, item.AvailableActions.Delete, "AvailableActions.Delete");

    }

    [TestMethod]
    public async Task TestMethodGetModelAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetModelAsync(3);

        Assert.IsNotNull(item);
        Assert.AreEqual(3, item.Id, nameof(item.Id));
        Assert.AreEqual("Surface", item.Name, nameof(item.Name));

        Assert.IsNotNull(item.Manufacturer);
        Assert.AreEqual(2, item.Manufacturer.Id, "Manufacturer.Id");
        Assert.AreEqual("Microsoft", item.Manufacturer.Name, "Manufacturer.Name");

        Assert.AreEqual("https://develop.snipeitapp.com/uploads/models/surface.jpg", item.Image, nameof(item.Image));

        //Assert.AreEqual("https://support.apple.com", item.SupportUrl, nameof(item.SupportUrl));
        //Assert.AreEqual("https://checkcoverage.apple.com", item.WarrantyLookupUrl, nameof(item.WarrantyLookupUrl));
        //Assert.AreEqual("+12725858512", item.SupportPhone, nameof(item.SupportPhone));
        //Assert.AreEqual("marlee46@example.com", item.SupportEmail, nameof(item.SupportEmail));

        //Assert.AreNotEqual(0, item.AssetsCount, nameof(item.AssetsCount));
        //Assert.AreEqual(0, item.LicensesCount, nameof(item.LicensesCount));
        //Assert.AreEqual(0, item.ConsumablesCount, nameof(item.ConsumablesCount));
        //Assert.AreEqual(0, item.AccessoriesCount, nameof(item.AccessoriesCount));
        //Assert.AreEqual(0, item.ComponentsCount, nameof(item.ComponentsCount));
        //Assert.AreEqual("Created by DB seeder", item.Notes, nameof(item.Notes));

        //Assert.IsNull(item.CreatedBy, nameof(item.CreatedBy));
        //Assert.AreEqual(1, item.CreatedBy.Id, "CreatedBy.Id");
        //Assert.AreEqual("Alf Shumway", item.CreatedBy.Name, "CreatedBy.Name");

        //Assert.IsNull(item.CreatedAt, nameof(item.CreatedAt));
        //Assert.IsNull(item.CreatedAt.Date, "CreatedAt.Date");
        //Assert.AreEqual("Thu Feb 20, 2025 11:59AM", item.CreatedAt.Formatted, "CreatedAt.Formatted");

        //Assert.IsNotNull(item.UpdatedAt);
        //Assert.IsNull(item.UpdatedAt.Date, "UpdatedAt.Date");
        //Assert.AreEqual("Thu Feb 20, 2025 11:59AM", item.UpdatedAt.Formatted, "UpdatedAt.Formatted");

        //Assert.IsNull(item.DeletedAt, nameof(item.DeletedAt));
        //Assert.AreEqual("2021-09-29 00:00:00", item.DeletedAt.Date, "DeletedAt.Date");
        //Assert.AreEqual("2021-09-29 00:00:00", item.DeletedAt.Formatted, "DeletedAt.Formatted");

        //Assert.IsNotNull(item.AvailableActions, nameof(item.AvailableActions));
        //Assert.AreEqual(true, item.AvailableActions.Update, "AvailableActions.Update");
        //Assert.AreEqual(false, item.AvailableActions.Restore, "AvailableActions.Restore");
        //Assert.AreEqual(false, item.AvailableActions.Delete, "AvailableActions.Delete");

    }

    [TestMethod]
    public async Task TestMethodCreateModelAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        string name = Guid.NewGuid().ToString();
        var create = new Model()
        {
            Name = name,
            //Url = "https://test.com",
            //Image = "https://develop.snipeitapp.com/uploads/manufacturers/apple.jpg",        // https://raw.githubusercontent.com/Bassman2/SnipeITWebApi/master/.github/images/donate.gif
            //SupportUrl = "https://support.test.com",
            //WarrantyLookupUrl = "https://checkcoverage.test.com",
            //SupportPhone = "+12725858512",
            //SupportEmail = "unknown@microsoft.com",
            //Notes = "Dummy Note"
        };


        var item = await snipeIT.CreateModelAsync(create);
        Assert.IsNotNull(item);

        await snipeIT.DeleteModelAsync(item.Id);


        var del = await snipeIT.GetModelAsync(item.Id);

        Assert.AreNotEqual(0, item.Id, nameof(item.Id));
        Assert.AreEqual(name, item.Name, nameof(item.Name));

        Assert.IsNotNull(item.Manufacturer);
        Assert.AreEqual(2, item.Manufacturer.Id, "Manufacturer.Id");
        Assert.AreEqual("", item.Manufacturer.Name, "Manufacturer.Name");

        Assert.AreEqual("https://develop.snipeitapp.com/uploads/manufacturers/apple.jpg", item.Image, nameof(item.Image));


        //Assert.AreEqual("https://test.com", item.Url, nameof(item.Url));
        ////Assert.AreEqual("https://develop.snipeitapp.com/uploads/manufacturers/apple.jpg", item.Image, nameof(item.Image));
        //Assert.AreEqual("https://support.test.com", item.SupportUrl, nameof(item.SupportUrl));
        //Assert.AreEqual("https://checkcoverage.test.com", item.WarrantyLookupUrl, nameof(item.WarrantyLookupUrl));
        //Assert.AreEqual("+12725858512", item.SupportPhone, nameof(item.SupportPhone));
        //Assert.AreEqual("unknown@microsoft.com", item.SupportEmail, nameof(item.SupportEmail));
        //Assert.AreEqual("Dummy Note", item.Notes, nameof(item.Notes));
    }

    [TestMethod]
    public async Task TestMethodCreateDuplicateModelAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);


        var create = new Model()
        {
            Name = "Surface",
        };

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.CreateModelAsync(create));
    }

    [TestMethod]
    public async Task TestMethodDeleteNotExistingModelAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.DeleteModelAsync(65000));
    }
}
