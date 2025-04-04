namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITGroupsUnitTest : SnipeITBaseUnitTest
{

    [TestMethod]
    public async Task TestMethodGetGroupsAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetGroupsAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == groupId);
        Assert.IsNotNull(item);
        Assert.AreEqual(groupId, item.Id, "item.Id");
        Assert.AreEqual(groupName, item.Name, "item.Name");
    }
}
