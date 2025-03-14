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


    }
}
