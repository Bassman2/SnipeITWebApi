namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITFieldsetsUnitTest : SnipeITBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetFieldsetsAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetFieldsetsAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == hardwareId);
        Assert.IsNotNull(item);
        Assert.AreEqual(hardwareId, item.Id, "item.Id");
        Assert.AreEqual(hardwareName, item.Name, "item.Name");
    }
}
