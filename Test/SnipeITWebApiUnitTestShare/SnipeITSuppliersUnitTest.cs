namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITSuppliersUnitTest : SnipeITBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetSuppliersAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetSuppliersAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == hardwareId);
        Assert.IsNotNull(item);
        Assert.AreEqual(hardwareId, item.Id, "item.Id");
        Assert.AreEqual(hardwareName, item.Name, "item.Name");
    }
}
