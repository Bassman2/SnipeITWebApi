namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITComponentsUnitTest : SnipeITBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetComponentsAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetComponentsAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == componentId);
        Assert.IsNotNull(item);
        Assert.AreEqual(componentId, item.Id, "item.Id");
        Assert.AreEqual(componentName, item.Name, "item.Name");
    }
}
