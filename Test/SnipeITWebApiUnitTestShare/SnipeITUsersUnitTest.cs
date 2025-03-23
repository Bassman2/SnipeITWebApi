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

        var item = list.FirstOrDefault();
        Assert.IsNotNull(item);
        Assert.AreEqual(1, item.Id, nameof(item.Id));
        Assert.AreEqual("Laptops", item.Name, nameof(item.Name));


    }

    [TestMethod]
    public async Task TestMethodGetUserMeAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetUserMeAsync();

        Assert.IsNotNull(item);
        Assert.AreEqual(1, item.Id, nameof(item.Id));
        Assert.AreEqual("Account Demo", item.Name, nameof(item.Name));


    }
}
