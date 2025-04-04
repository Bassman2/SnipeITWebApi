namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITLicensesUnitTest : SnipeITBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetLicensesAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetLicensesAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == licenseId);
        Assert.IsNotNull(item);
        Assert.AreEqual(licenseId, item.Id, "item.Id");
        Assert.AreEqual(licenseName, item.Name, "item.Name");
    }
}
