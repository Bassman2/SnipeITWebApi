namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITAccessoriesUnitTest : SnipeITBaseUnitTest<Accessory>
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

        var item = list.FirstOrDefault(d => d.Id == accessoryId);
        Assert.IsNotNull(item);
        Assert.AreEqual(accessoryId, item.Id, "item.Id");
        Assert.AreEqual(accessoryName, item.Name, "item.Name");
    }

    [TestMethod]
    public async Task TestMethodGetAccessoryAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetAccessoryAsync(accessoryId);
                
        Assert.IsNotNull(item);
        Assert.AreEqual(accessoryId, item.Id, "item.Id");
        Assert.AreEqual(accessoryName, item.Name, "item.Name");
    }

    [TestMethod]
    public async Task TestMethodCreateAccessoryAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        string createName = Guid.NewGuid().ToString();
        string updateName = Guid.NewGuid().ToString();
        string patchName = Guid.NewGuid().ToString();

        var create = new Accessory()
        {
            Name = createName,
            Qty = 1,
            Category = 8,
            //Image = imageCreate,    
            Notes = "create",
        };
        int id = await snipeIT.CreateAccessoryAsync(create);
        var created = await snipeIT.GetAccessoryAsync(id);
        
        var update = new Accessory()
        {
            Name = updateName,
            //Image = imageUpdate,
            Notes = notesUpdate,

        };
        await snipeIT.UpdateAccessoryAsync(id, update);
        var updated = await snipeIT.GetAccessoryAsync(id);

        var patch = new Accessory()
        {
            Name = patchName,
            //Image = imageUpdate,
            Notes = notesPatch,
        };
        await snipeIT.PatchAccessoryAsync(id, patch);
        var patched = await snipeIT.GetAccessoryAsync(id);
        

        var deleted = await snipeIT.DeleteAccessoryAsync(id);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetAccessoryAsync(id));

        AreEqual(id, create, created, "created");
        AreEqual(id, update, updated, "updated");
        AreEqual(id, patch, patched, "patched");
        //AreEqual(id, patch, deleted, "deleted");
    }


    // Can be duplicate 

    //[TestMethod]
    //public async Task TestMethodCreateDuplicateAccessoryAsync()
    //{
    //    using var snipeIT = new SnipeIT(developStoreKey, appName);

    //    await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.CreateAccessoryAsync(new() { Name = accessoryName, Qty = 1, Category = 8 }));
    //}

    [TestMethod]
    public async Task TestMethodGetNotExistingAccessoryAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetAccessoryAsync(notExistingId));
    }

    [TestMethod]
    public async Task TestMethodDeleteNotExistingAccessoryAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.DeleteAccessoryAsync(notExistingId));
    }

    public override void AreEqual(int id, Accessory expected, Accessory? actual, string message)
    {
        Assert.IsNotNull(actual, $"{message}.actual");

        Assert.AreEqual(id, actual.Id, $"{message}.Id");
        Assert.AreEqual(expected.Name, actual.Name, $"{message}.Name");
        Assert.AreEqual(expected.Image, actual.Image, $"{message}.Image");
        Assert.AreEqual(expected.Company, actual.Company, $"{message}.Company");
        Assert.AreEqual(expected.Manufacturer, actual.Manufacturer, $"{message}.Manufacturer");
        Assert.AreEqual(expected.Supplier, actual.Supplier, $"{message}.Supplier");
        Assert.AreEqual(expected.ModelNumber, actual.ModelNumber, $"{message}.ModelNumber");
        Assert.AreEqual(expected.Category, actual.Category, $"{message}.Category");
        Assert.AreEqual(expected.Location, actual.Location, $"{message}.Location");
        Assert.AreEqual(expected.Notes, actual.Notes, $"{message}.Notes");
        Assert.AreEqual(expected.Qty, actual.Qty, $"{message}.Qty");
        DateAssert.AreEqual(expected.PurchaseDate, actual.PurchaseDate, $"{message}.PurchaseDate");
        Assert.AreEqual(expected.PurchaseCost, actual.PurchaseCost, $"{message}.PurchaseCost");
        Assert.AreEqual(expected.OrderNumber, actual.OrderNumber, $"{message}.OrderNumber");
        Assert.AreEqual(expected.MinQty, actual.MinQty, $"{message}.MinQty");
        Assert.AreEqual(expected.MinAmt, actual.MinAmt, $"{message}.MinAmt");
        Assert.AreEqual(expected.RemainingQty, actual.RemainingQty, $"{message}.RemainingQty");
        Assert.AreEqual(expected.Remaining, actual.Remaining, $"{message}.Remaining");
        //RangeAssert.IsInRange(0, 9, actual.CheckoutsCount, $"{message}.CheckoutsCount");

        Assert.AreEqual(null, actual.CreatedBy, $"{message}.CreatedBy");
        DateAssert.AreEqual(today, actual.CreatedAt, $"{message}.CreatedAt");
        DateAssert.AreEqual(today, actual.UpdatedAt, $"{message}.UpdatedAt");
        
        Assert.IsNotNull(actual.AvailableActions, $"{message}.AvailableActions");
        Assert.IsTrue(actual.AvailableActions.Checkout, $"{message}.AvailableActions.Checkout");
        Assert.IsTrue(actual.AvailableActions.Checkin, $"{message}.AvailableActions.Checkin");
        Assert.IsTrue(actual.AvailableActions.Update, $"{message}.AvailableActions.Update");
        Assert.IsTrue(actual.AvailableActions.Delete, $"{message}.AvailableActions.Delete");
        Assert.IsTrue(actual.AvailableActions.Clone, $"{message}.AvailableActions.Clone");
    }

    public override async Task<Accessory?> GetAsync(SnipeIT snipeIT, int id)
        => await snipeIT.GetAccessoryAsync(id);

    public override async Task<int> CreateAsync(SnipeIT snipeIT, Accessory value)
        => await snipeIT.CreateAccessoryAsync(value);
    
    public override async Task UpdateAsync(SnipeIT snipeIT, int id, Accessory value)
        => await snipeIT.UpdateAccessoryAsync(id, value);
    
    public override async Task PatchAsync(SnipeIT snipeIT, int id, Accessory value)
        => await snipeIT.PatchAccessoryAsync(id, value);

    public override async Task DeleteAsync(SnipeIT snipeIT, int id)
        => await snipeIT.DeleteAccessoryAsync(id);
}

