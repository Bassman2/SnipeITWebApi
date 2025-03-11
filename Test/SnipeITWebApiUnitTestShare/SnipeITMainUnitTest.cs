namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITMainUnitTest : SnipeITBaseUnitTest
{

    [TestMethod]
    public async Task TestMethodGetHardwareListAsync()
    {
        using var snipeIT = new SnipeIT(storeKey, appName);

        var asyncList = snipeIT.GetHardwareListAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);
        

    }

    [TestMethod]
    public async Task TestMethodGetHardwareListByCategoryAsync()
    {
        using var snipeIT = new SnipeIT(storeKey, appName);

        var asyncList = snipeIT.GetHardwareListByCategoryAsync(2);

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

    }
}
