namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITMaintenancesUnitTest : SnipeITBaseUnitTest
{

    [TestMethod]
    public async Task TestMethodGetMaintenancesAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetMaintenancesAsync();

        var list = await asyncList.ToListAsync();


        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == maintenanceId);
        Assert.IsNotNull(item);
        Assert.AreEqual(maintenanceId, item.Id, "item.Id");
        Assert.AreEqual(maintenanceName, item.Name, "item.Name");
    }
}
