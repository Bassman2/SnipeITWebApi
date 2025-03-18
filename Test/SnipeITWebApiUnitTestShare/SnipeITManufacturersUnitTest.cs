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

        Assert.AreEqual(180, item.AssetsCount, nameof(item.AssetsCount));
        Assert.AreEqual(0, item.LicensesCount, nameof(item.LicensesCount));
        Assert.AreEqual(0, item.ConsumablesCount, nameof(item.ConsumablesCount));
        Assert.AreEqual(0, item.AccessoriesCount, nameof(item.AccessoriesCount));
        Assert.AreEqual(0, item.ComponentsCount, nameof(item.ComponentsCount));
        Assert.AreEqual("Created by DB seeder", item.Notes, nameof(item.Notes));

        Assert.IsNotNull(item.CreatedBy, nameof(item.CreatedBy));
        Assert.AreEqual(1, item.CreatedBy.Id, "CreatedBy.Id");
        Assert.AreEqual("Alf Shumway", item.CreatedBy.Name, "CreatedBy.Name");

        Assert.IsNotNull(item.CreatedAt, nameof(item.CreatedAt));
        Assert.IsNull(item.CreatedAt.Date, "CreatedAt.Date");
        Assert.AreEqual("Thu Feb 20, 2025 11:59AM", item.CreatedAt.Formatted, "CreatedAt.Formatted");

        Assert.IsNotNull(item.UpdatedAt);
        Assert.IsNull(item.UpdatedAt.Date, "UpdatedAt.Date");
        Assert.AreEqual("Thu Feb 20, 2025 11:59AM", item.UpdatedAt.Formatted, "UpdatedAt.Formatted");

        Assert.IsNull(item.DeletedAt, nameof(item.DeletedAt));
        //Assert.AreEqual("2021-09-29 00:00:00", item.DeletedAt.Date, "DeletedAt.Date");
        //Assert.AreEqual("2021-09-29 00:00:00", item.DeletedAt.Formatted, "DeletedAt.Formatted");

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

        Assert.AreEqual(180, item.AssetsCount, nameof(item.AssetsCount));
        Assert.AreEqual(0, item.LicensesCount, nameof(item.LicensesCount));
        Assert.AreEqual(0, item.ConsumablesCount, nameof(item.ConsumablesCount));
        Assert.AreEqual(0, item.AccessoriesCount, nameof(item.AccessoriesCount));
        Assert.AreEqual(0, item.ComponentsCount, nameof(item.ComponentsCount));
        Assert.AreEqual("Created by DB seeder", item.Notes, nameof(item.Notes));

        Assert.IsNotNull(item.CreatedBy, nameof(item.CreatedBy));
        Assert.AreEqual(1, item.CreatedBy.Id, "CreatedBy.Id");
        Assert.AreEqual("Alf Shumway", item.CreatedBy.Name, "CreatedBy.Name");

        Assert.IsNotNull(item.CreatedAt, nameof(item.CreatedAt));
        Assert.IsNull(item.CreatedAt.Date, "CreatedAt.Date");
        Assert.AreEqual("Thu Feb 20, 2025 11:59AM", item.CreatedAt.Formatted, "CreatedAt.Formatted");

        Assert.IsNotNull(item.UpdatedAt);
        Assert.IsNull(item.UpdatedAt.Date, "UpdatedAt.Date");
        Assert.AreEqual("Thu Feb 20, 2025 11:59AM", item.UpdatedAt.Formatted, "UpdatedAt.Formatted");

        Assert.IsNull(item.DeletedAt, nameof(item.DeletedAt));
        //Assert.AreEqual("2021-09-29 00:00:00", item.DeletedAt.Date, "DeletedAt.Date");
        //Assert.AreEqual("2021-09-29 00:00:00", item.DeletedAt.Formatted, "DeletedAt.Formatted");

        Assert.IsNotNull(item.AvailableActions, nameof(item.AvailableActions));
        Assert.AreEqual(true, item.AvailableActions.Update, "AvailableActions.Update");
        Assert.AreEqual(false, item.AvailableActions.Restore, "AvailableActions.Restore");
        Assert.AreEqual(false, item.AvailableActions.Delete, "AvailableActions.Delete");

    }

    [TestMethod]
    public async Task TestMethodCreateManufacturerAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var create = new Manufacturer()
        {
            Name = "Test Manufacturer",
            Url = "https://test.com",
            //Image = "https://develop.snipeitapp.com/uploads/manufacturers/apple.jpg",        // https://raw.githubusercontent.com/Bassman2/SnipeITWebApi/master/.github/images/donate.gif
            SupportUrl = "https://support.test.com",
            WarrantyLookupUrl = "https://checkcoverage.test.com",
            SupportPhone = "+12725858512",
            SupportEmail = "unknown@mictosoft.com"
        };


        var item = await snipeIT.CreateManufacturerAsync(create);
        Assert.IsNotNull(item);

        await snipeIT.DeleteManufacturerAsync(item.Id);


        var del = await snipeIT.GetManufacturerAsync(item.Id);

        Assert.AreEqual(1, item.Id, nameof(item.Id));
        Assert.AreEqual("Apple", item.Name, nameof(item.Name));
        Assert.AreEqual("https://apple.com", item.Url, nameof(item.Url));
        Assert.AreEqual("https://develop.snipeitapp.com/uploads/manufacturers/apple.jpg", item.Image, nameof(item.Image));
        Assert.AreEqual("https://support.apple.com", item.SupportUrl, nameof(item.SupportUrl));
        Assert.AreEqual("https://checkcoverage.apple.com", item.WarrantyLookupUrl, nameof(item.WarrantyLookupUrl));
        Assert.AreEqual("+12725858512", item.SupportPhone, nameof(item.SupportPhone));
        Assert.AreEqual("marlee46@example.com", item.SupportEmail, nameof(item.SupportEmail));


    }
}