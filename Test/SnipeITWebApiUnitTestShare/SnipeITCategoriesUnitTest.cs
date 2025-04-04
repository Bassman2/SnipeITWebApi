namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITCategoriesUnitTest : SnipeITBaseUnitTest
{

    [TestMethod]
    public async Task TestMethodGetCategoriesAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetCategoriesAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(i => i.Id == categoryId);
        Assert.IsNotNull(item);
        Assert.AreEqual(categoryId, item.Id, nameof(item.Id));
        Assert.AreEqual(categoryName, item.Name, nameof(item.Name));


    }
}
