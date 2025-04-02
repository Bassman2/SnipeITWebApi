namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITHardwareUnitTest : SnipeITBaseUnitTest
{

    [TestMethod]
    public async Task TestMethodGetHardwareListAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetHardwareListAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == hardwareId);
        Assert.IsNotNull(item);
        Assert.AreEqual(departmentId, item.Id, "item.Id");
        Assert.AreEqual(departmentName, item.Name, "item.Name");
        //Assert.IsNull(item.Phone, "item.Phone");
        //Assert.IsNull(item.Fax, "item.Fax");
        //Assert.IsNull(item.Image, "item.Image");
        //Assert.IsNull(item.Company, "item.Company");
        //Assert.IsNull(item.Manager, "item.Manager");
        //Assert.IsNull(item.Location, "item.Location");
        //Assert.IsTrue(item.UsersCount > 10, "item.UsersCount");
        //Assert.AreEqual("Created by DB seeder", item.Notes, "item.Notes");
        //DateTimeAssert.AreEqual("2025-02-20", item.CreatedAt, "item.CreatedAt");
        //DateTimeAssert.AreEqual("2025-02-20", item.UpdatedAt, "item.UpdatedAt");
        //Assert.IsNotNull(item.AvailableActions, "item.AvailableActions");
        //Assert.IsTrue(item.AvailableActions.Update, "item.AvailableActions.Update");
        //Assert.IsFalse(item.AvailableActions.Delete, "item.AvailableActions.Delete");
 
    }

    [TestMethod]
    public async Task TestMethodGetHardwareListByCategoryAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetHardwareListByCategoryAsync(2);

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

    }
}
