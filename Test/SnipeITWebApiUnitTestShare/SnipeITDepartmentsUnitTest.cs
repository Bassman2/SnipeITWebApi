namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITDepartmentsUnitTest : SnipeITBaseUnitTest
{

    [TestMethod]
    public async Task TestMethodGetDepartmentsAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetDepartmentsAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault();
        Assert.IsNotNull(item);
        Assert.AreEqual(1, item.Id, nameof(item.Id));
        Assert.AreEqual("Laptops", item.Name, nameof(item.Name));


    }
}
