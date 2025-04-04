namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITLocationsUnitTest : SnipeITBaseUnitTest
{

    [TestMethod]
    public async Task TestMethodGetLocationsAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetLocationsAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == locationId);
        Assert.IsNotNull(item);
        Assert.AreEqual(locationId, item.Id, "item.Id");
        Assert.AreEqual(locationName, item.Name, "item.Name");
    }
}
