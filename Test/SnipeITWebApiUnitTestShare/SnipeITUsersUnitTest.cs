namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITUsersUnitTest : SnipeITBaseUnitTest
{

    [TestMethod]
    public async Task TestMethodGetUsersAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetUsersAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(i => i.Id == 1);
        Assert.IsNotNull(item);
        Assert.AreEqual(1, item.Id, "item.Id");
        Assert.AreEqual("Account Demo", item.Name, "item.Name");
        Assert.AreEqual("Demo", item.FirstName, "item.FirstName");
        Assert.AreEqual("Account", item.LastName, "item.LastName");
        Assert.AreEqual("admin", item.Username, "item.Username");


    }

    [TestMethod]
    public async Task TestMethodGetUserMeAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetUserMeAsync();

        Assert.IsNotNull(item);
        Assert.AreEqual(1, item.Id, "item.Id");
        Assert.AreEqual("Account Demo", item.Name, "item.Name");
        Assert.AreEqual("Demo", item.FirstName, "item.FirstName");
        Assert.AreEqual("Account", item.LastName, "item.LastName");
        Assert.AreEqual("admin", item.Username, "item.Username");



    }
}
