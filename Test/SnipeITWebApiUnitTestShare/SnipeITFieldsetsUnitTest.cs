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

        var item = list.FirstOrDefault(d => d.Id == fieldsetId);
        Assert.IsNotNull(item);
        Assert.AreEqual(fieldsetId, item.Id, "item.Id");
        Assert.AreEqual(fieldsetName, item.Name, "item.Name");
    }
}
