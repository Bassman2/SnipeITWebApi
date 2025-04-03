namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITFieldsUnitTest : SnipeITBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetFieldsAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetFieldsAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == hardwareId);
        Assert.IsNotNull(item);
        Assert.AreEqual(hardwareId, item.Id, "item.Id");
        Assert.AreEqual(hardwareName, item.Name, "item.Name");
    }
}
