namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITConsumablesUnitTest : SnipeITBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetConsumablesAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetConsumablesAsync();

        var list = await asyncList.ToListAsync();

        var sort = list.OrderBy(i => i.Id).ToList();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == consumableId);
        Assert.IsNotNull(item);
        Assert.AreEqual(consumableId, item.Id, "item.Id");
        Assert.AreEqual(consumableName, item.Name, "item.Name");
    }
}
