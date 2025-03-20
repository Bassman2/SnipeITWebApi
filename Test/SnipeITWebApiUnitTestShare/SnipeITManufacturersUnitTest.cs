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

        var item = list.FirstOrDefault(i => i.Name == "Apple");
        Assert.IsNotNull(item);
        Assert.AreEqual(1, item.Id, nameof(item.Id));
        Assert.AreEqual("Apple", item.Name, nameof(item.Name));
        Assert.AreEqual("https://apple.com", item.Url, nameof(item.Url));
        Assert.AreEqual("https://develop.snipeitapp.com/uploads/manufacturers/apple.jpg", item.Image, nameof(item.Image));
        Assert.AreEqual("https://support.apple.com", item.SupportUrl, nameof(item.SupportUrl));
        Assert.AreEqual("https://checkcoverage.apple.com", item.WarrantyLookupUrl, nameof(item.WarrantyLookupUrl));
        Assert.AreEqual("+12725858512", item.SupportPhone, nameof(item.SupportPhone));
        Assert.AreEqual("marlee46@example.com", item.SupportEmail, nameof(item.SupportEmail));

        Assert.AreNotEqual(0, item.AssetsCount, nameof(item.AssetsCount));
        Assert.AreEqual(0, item.LicensesCount, nameof(item.LicensesCount));
        Assert.AreEqual(0, item.ConsumablesCount, nameof(item.ConsumablesCount));
        Assert.AreEqual(0, item.AccessoriesCount, nameof(item.AccessoriesCount));
        Assert.AreEqual(0, item.ComponentsCount, nameof(item.ComponentsCount));
        Assert.AreEqual("Created by DB seeder", item.Notes, nameof(item.Notes));

        //Assert.IsNotNull(create.CreatedBy, nameof(create.CreatedBy));
        //Assert.AreEqual(1, create.CreatedBy.Id, "CreatedBy.Id");
        //Assert.AreEqual("Alf Shumway", create.CreatedBy.Name, "CreatedBy.Name");

        //Assert.IsNotNull(create.CreatedAt, nameof(create.CreatedAt));
        //Assert.IsNull(create.CreatedAt.Date, "CreatedAt.Date");
        //Assert.AreEqual("Thu Feb 20, 2025 11:59AM", create.CreatedAt.Formatted, "CreatedAt.Formatted");

        //Assert.IsNotNull(create.UpdatedAt);
        //Assert.IsNull(create.UpdatedAt.Date, "UpdatedAt.Date");
        //Assert.AreEqual("Thu Feb 20, 2025 11:59AM", create.UpdatedAt.Formatted, "UpdatedAt.Formatted");

        Assert.IsNull(item.DeletedAt, nameof(item.DeletedAt));
        //Assert.AreEqual("2021-09-29 00:00:00", create.DeletedAt.Date, "DeletedAt.Date");
        //Assert.AreEqual("2021-09-29 00:00:00", create.DeletedAt.Formatted, "DeletedAt.Formatted");

        Assert.IsNotNull(item.AvailableActions, nameof(item.AvailableActions));
        Assert.AreEqual(true, item.AvailableActions.Update, "AvailableActions.Update");
        Assert.AreEqual(false, item.AvailableActions.Restore, "AvailableActions.Restore");
        Assert.AreEqual(false, item.AvailableActions.Delete, "AvailableActions.Delete");

    }

    [TestMethod]
    public async Task TestMethodGetManufacturerAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetManufacturerAsync(1);

        Assert.IsNotNull(item);
        Assert.AreEqual(1, item.Id, nameof(item.Id));
        Assert.AreEqual("Apple", item.Name, nameof(item.Name));
        Assert.AreEqual("https://apple.com", item.Url, nameof(item.Url));
        Assert.AreEqual("https://develop.snipeitapp.com/uploads/manufacturers/apple.jpg", item.Image, nameof(item.Image));
        Assert.AreEqual("https://support.apple.com", item.SupportUrl, nameof(item.SupportUrl));
        Assert.AreEqual("https://checkcoverage.apple.com", item.WarrantyLookupUrl, nameof(item.WarrantyLookupUrl));
        Assert.AreEqual("+12725858512", item.SupportPhone, nameof(item.SupportPhone));
        Assert.AreEqual("marlee46@example.com", item.SupportEmail, nameof(item.SupportEmail));

        Assert.AreNotEqual(0, item.AssetsCount, nameof(item.AssetsCount));
        Assert.AreEqual(0, item.LicensesCount, nameof(item.LicensesCount));
        Assert.AreEqual(0, item.ConsumablesCount, nameof(item.ConsumablesCount));
        Assert.AreEqual(0, item.AccessoriesCount, nameof(item.AccessoriesCount));
        Assert.AreEqual(0, item.ComponentsCount, nameof(item.ComponentsCount));
        Assert.AreEqual("Created by DB seeder", item.Notes, nameof(item.Notes));

        //Assert.IsNull(create.CreatedBy, nameof(create.CreatedBy));
        //Assert.AreEqual(1, create.CreatedBy.Id, "CreatedBy.Id");
        //Assert.AreEqual("Alf Shumway", create.CreatedBy.Name, "CreatedBy.Name");

        //Assert.IsNull(create.CreatedAt, nameof(create.CreatedAt));
        //Assert.IsNull(create.CreatedAt.Date, "CreatedAt.Date");
        //Assert.AreEqual("Thu Feb 20, 2025 11:59AM", create.CreatedAt.Formatted, "CreatedAt.Formatted");

        //Assert.IsNotNull(create.UpdatedAt);
        //Assert.IsNull(create.UpdatedAt.Date, "UpdatedAt.Date");
        //Assert.AreEqual("Thu Feb 20, 2025 11:59AM", create.UpdatedAt.Formatted, "UpdatedAt.Formatted");

        Assert.IsNull(item.DeletedAt, nameof(item.DeletedAt));
        //Assert.AreEqual("2021-09-29 00:00:00", create.DeletedAt.Date, "DeletedAt.Date");
        //Assert.AreEqual("2021-09-29 00:00:00", create.DeletedAt.Formatted, "DeletedAt.Formatted");

        Assert.IsNotNull(item.AvailableActions, nameof(item.AvailableActions));
        Assert.AreEqual(true, item.AvailableActions.Update, "AvailableActions.Update");
        Assert.AreEqual(false, item.AvailableActions.Restore, "AvailableActions.Restore");
        Assert.AreEqual(false, item.AvailableActions.Delete, "AvailableActions.Delete");

    }

    [TestMethod]
    public async Task TestMethodCreateManufacturerAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        string name = Guid.NewGuid().ToString();
        
        var create = await snipeIT.CreateManufacturerAsync(new()
        {
            Name = name,
            Url = "https://test.com",
            //Image = "https://develop.snipeitapp.com/uploads/manufacturers/apple.jpg",        // https://raw.githubusercontent.com/Bassman2/SnipeITWebApi/master/.github/images/donate.gif
            SupportUrl = "https://support.test.com",
            WarrantyLookupUrl = "https://checkcoverage.test.com",
            SupportPhone = "+12725858512",
            SupportEmail = "unknown@microsoft.com",
            Notes = "Dummy Note"
        });
        Assert.IsNotNull(create);
        
        var update = await snipeIT.UpdateManufacturerAsync(new()
        {
            Name = Guid.NewGuid().ToString()
        });
        Assert.IsNotNull(update);

        var patch = await snipeIT.PatchManufacturerAsync(new() 
        {
            Name = Guid.NewGuid().ToString()
        });
        Assert.IsNotNull(patch);

        await snipeIT.DeleteManufacturerAsync(create.Id);

        var del = await snipeIT.GetManufacturerAsync(create.Id);

        Assert.AreNotEqual(0, create.Id, "create.Id");
        Assert.AreEqual(name, create.Name, "create.Name");
        Assert.AreEqual("https://test.com", create.Url, "create.Url");
        //Assert.AreEqual("https://develop.snipeitapp.com/uploads/manufacturers/apple.jpg", create.Image, nameof(create.Image));
        Assert.AreEqual("https://support.test.com", create.SupportUrl, "create.SupportUrl");
        Assert.AreEqual("https://checkcoverage.test.com", create.WarrantyLookupUrl, "create.WarrantyLookupUrl");
        Assert.AreEqual("+12725858512", create.SupportPhone, "create.SupportPhone");
        Assert.AreEqual("unknown@microsoft.com", create.SupportEmail, "create.SupportEmail");
        Assert.AreEqual("Dummy Note", create.Notes, "create.Notes");

        Assert.AreNotEqual(0, update.Id, "create.Id");
        Assert.AreEqual(name, update.Name, "update.Name");
        Assert.AreEqual("https://test.com", update.Url, "update.Url");
        //Assert.AreEqual("https://develop.snipeitapp.com/uploads/manufacturers/apple.jpg", update.Image, nameof(update.Image));
        Assert.AreEqual("https://support.test.com", update.SupportUrl, "update.SupportUrl");
        Assert.AreEqual("https://checkcoverage.test.com", update.WarrantyLookupUrl, "update.WarrantyLookupUrl");
        Assert.AreEqual("+12725858512", update.SupportPhone, "update.SupportPhone");
        Assert.AreEqual("unknown@microsoft.com", update.SupportEmail, "update.SupportEmail");
        Assert.AreEqual("Dummy Note", update.Notes, "update.Notes");

        Assert.AreNotEqual(0, patch.Id, "patch.Id");
        Assert.AreEqual(name, patch.Name, "patch.Name");
        Assert.AreEqual("https://test.com", patch.Url, "patch.Url");
        //Assert.AreEqual("https://develop.snipeitapp.com/uploads/manufacturers/apple.jpg", patch.Image, nameof(patch.Image));
        Assert.AreEqual("https://support.test.com", patch.SupportUrl, "patch.SupportUrl");
        Assert.AreEqual("https://checkcoverage.test.com", patch.WarrantyLookupUrl, "patch.WarrantyLookupUrl");
        Assert.AreEqual("+12725858512", patch.SupportPhone, "patch.SupportPhone");
        Assert.AreEqual("unknown@microsoft.com", patch.SupportEmail, "patch.SupportEmail");
        Assert.AreEqual("Dummy Note", patch.Notes, "patch.Notes");
    }

    [TestMethod]
    public async Task TestMethodCreateDuplicateManufacturerAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);


        var create = new Manufacturer()
        {
            Name = "Apple",
        };

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.CreateManufacturerAsync(create));
    }

    [TestMethod]
    public async Task TestMethodDeleteNotExistingManufacturerAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.DeleteManufacturerAsync(65000));
    }
}