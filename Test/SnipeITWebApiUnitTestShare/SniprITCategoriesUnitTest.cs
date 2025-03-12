namespace SnipeITWebApiUnitTest;

[TestClass]
public class SniprITCategoriesUnitTest : SnipeITBaseUnitTest
{

    [TestMethod]
    public async Task TestMethodGetCategoriesAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetCategoriesAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault();
        Assert.IsNotNull(item);
        Assert.AreEqual(1, item.Id, nameof(item.Id));
        Assert.AreEqual("Laptops", item.Name, nameof(item.Name));


    }
}
