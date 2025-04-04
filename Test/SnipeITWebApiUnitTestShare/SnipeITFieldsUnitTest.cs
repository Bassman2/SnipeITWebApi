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

        var item = list.FirstOrDefault(d => d.Id == fieldId);
        Assert.IsNotNull(item);
        Assert.AreEqual(fieldId, item.Id, "item.Id");
        Assert.AreEqual(fieldName, item.Name, "item.Name");
    }
}
