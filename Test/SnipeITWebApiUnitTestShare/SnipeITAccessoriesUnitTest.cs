﻿namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITAccessoriesUnitTest : SnipeITBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetAccessoriesAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetAccessoriesAsync();

        var list = await asyncList.ToListAsync();

        var sort = list.OrderBy(i => i.Id).ToList();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == accessorId);
        Assert.IsNotNull(item);
        Assert.AreEqual(accessorId, item.Id, "item.Id");
        Assert.AreEqual(accessorName, item.Name, "item.Name");
    }
}
