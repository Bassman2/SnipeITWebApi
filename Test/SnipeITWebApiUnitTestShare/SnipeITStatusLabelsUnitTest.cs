namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITStatusLabelsUnitTest : SnipeITBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetStatusLabelsAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetStatusLabelsAsync();

        var list = await asyncList.ToListAsync();
        
        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == statusLabelId);
        Assert.IsNotNull(item);
        Assert.AreEqual(statusLabelId, item.Id, "item.Id");
        Assert.AreEqual(statusLabelName, item.Name, "item.Name");
      
    }
}
