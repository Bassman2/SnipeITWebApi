namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITConsumablesUnitTest : SnipeITBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetConsumablesAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetConsumablesAsync();

        var list = await asyncList.ToListAsync();

        var sort = list.OrderBy(i => i.Id).ToList();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == consumableId);
        Assert.IsNotNull(item);
        Assert.AreEqual(consumableId, item.Id, "item.Id");
        Assert.AreEqual(consumableName, item.Name, "item.Name");
        Assert.AreEqual(null, item.Image, "item.Image");
        Assert.AreEqual(new NamedItem(10, "Printer Paper"), item.Category, "item.Category");
        Assert.AreEqual(new NamedItem(5, "Heidenreich, Russel and McClure"), item.Company, "item.Company");
        Assert.AreEqual("20459216", item.ItemNo, "item.ItemNo");
        Assert.AreEqual(null, item.Location, "item.Location");
        Assert.AreEqual(new NamedItem(10, "Avery"), item.Manufacturer, "item.Manufacturer");
        Assert.AreEqual(new NamedItem(10, "Larson-Mitchell"), item.Supplier, "item.Supplier");
        Assert.AreEqual(2, item.MinAmt, "item.MinAmt");
        Assert.AreEqual(null, item.ModelNumber, "item.ModelNumber");
        Assert.AreEqual(10, item.Remaining, "item.Remaining");
        Assert.AreEqual("10318081", item.OrderNumber, "item.OrderNumber");
        Assert.AreEqual("6,95", item.PurchaseCost, "item.PurchaseCost");
        DateAssert.IsNull(item.PurchaseDate, "item.PurchaseDate");
        Assert.AreEqual(10, item.Qty, "item.Qty");
        Assert.AreEqual(null, item.Notes, "item.Notes");
        Assert.AreEqual(adminUser, item.CreatedBy, "item.CreatedBy");
        DateAssert.AreEqual(lastUpdate, item.CreatedAt, "item.CreatedAt");
        DateAssert.AreEqual(lastUpdate, item.UpdatedAt, "item.UpdatedAt");
        Assert.IsTrue(item.UserCanCheckout, "item.UserCanCheckout");
        Assert.IsNotNull(item.AvailableActions, "item.AvailableActions");
        Assert.IsTrue(item.AvailableActions.Checkout, "item.AvailableActions.Checkout");
        Assert.IsTrue(item.AvailableActions.Checkin, "item.AvailableActions.Checkin");
        Assert.IsTrue(item.AvailableActions.Update, "item.AvailableActions.Update");
        Assert.IsTrue(item.AvailableActions.Delete, "item.AvailableActions.Delete");
        Assert.IsTrue(item.AvailableActions.Clone, "item.AvailableActions.Clone");
    }

    [TestMethod]
    public async Task TestMethodGetConsumableAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetConsumableAsync(consumableId);

        Assert.IsNotNull(item);
        Assert.AreEqual(consumableId, item.Id, "item.Id");
        Assert.AreEqual(consumableName, item.Name, "item.Name");
        Assert.AreEqual(null, item.Image, "item.Image");
        Assert.AreEqual(new NamedItem(10, "Printer Paper"), item.Category, "item.Category");
        Assert.AreEqual(new NamedItem(5, "Heidenreich, Russel and McClure"), item.Company, "item.Company");
        Assert.AreEqual("20459216", item.ItemNo, "item.ItemNo");
        Assert.AreEqual(null, item.Location, "item.Location");
        Assert.AreEqual(new NamedItem(10, "Avery"), item.Manufacturer, "item.Manufacturer");
        Assert.AreEqual(new NamedItem(10, "Larson-Mitchell"), item.Supplier, "item.Supplier");
        Assert.AreEqual(2, item.MinAmt, "item.MinAmt");
        Assert.AreEqual(null, item.ModelNumber, "item.ModelNumber");
        Assert.AreEqual(10, item.Remaining, "item.Remaining");
        Assert.AreEqual("10318081", item.OrderNumber, "item.OrderNumber");
        Assert.AreEqual("6,95", item.PurchaseCost, "item.PurchaseCost");
        DateAssert.IsNull(item.PurchaseDate, "item.PurchaseDate");
        Assert.AreEqual(10, item.Qty, "item.Qty");
        Assert.AreEqual(null, item.Notes, "item.Notes");
        Assert.AreEqual(adminUser, item.CreatedBy, "item.CreatedBy");
        DateAssert.AreEqual(lastUpdate, item.CreatedAt, "item.CreatedAt");
        DateAssert.AreEqual(lastUpdate, item.UpdatedAt, "item.UpdatedAt");
        Assert.IsTrue(item.UserCanCheckout, "item.UserCanCheckout");
        Assert.IsNotNull(item.AvailableActions, "item.AvailableActions");
        Assert.IsTrue(item.AvailableActions.Checkout, "item.AvailableActions.Checkout");
        Assert.IsTrue(item.AvailableActions.Checkin, "item.AvailableActions.Checkin");
        Assert.IsTrue(item.AvailableActions.Update, "item.AvailableActions.Update");
        Assert.IsTrue(item.AvailableActions.Delete, "item.AvailableActions.Delete");
        Assert.IsTrue(item.AvailableActions.Clone, "item.AvailableActions.Clone");
    }

    //[TestMethod]
    //public async Task TestMethodCreateConsumableAsync()
    //{
    //    using var snipeIT = new SnipeIT(developStoreKey, appName);

    //    string createName = Guid.NewGuid().ToString();
    //    string updateName = Guid.NewGuid().ToString();
    //    string patchName = Guid.NewGuid().ToString();

    //    var create = await snipeIT.CreateConsumableAsync(new()
    //    {
    //        Name = createName,
    //        Qty = 5,
    //        Category = 10,

    //        //Image = imageCreate,    
    //        //Notes = notesCreate,
    //    });
    //    Assert.IsNotNull(create);
    //    Assert.IsTrue(create.Id > 0, "create.Id");
    //    int id = create.Id;

    //    var update = await snipeIT.UpdateConsumableAsync(id, new()
    //    {
    //        Name = updateName,
    //        //Image = imageUpdate,
    //        //Notes = notesUpdate,

    //    });
    //    Assert.IsNotNull(update);

    //    var patch = await snipeIT.PatchConsumableAsync(id, new()
    //    {
    //        Name = patchName,
    //        //Image = imagePatch,
    //        //Notes = notesPatch,

    //    });
    //    Assert.IsNotNull(patch);

    //    var del = await snipeIT.DeleteConsumableAsync(id);

    //    await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetConsumableAsync(id));

    //    Assert.AreEqual(id, create.Id, "create.Id");
    //    Assert.AreEqual(createName, create.Name, "create.Name");
    //    //Assert.AreEqual(imageCreate, create.Image, "create.Image");
    //    //Assert.AreEqual(notesCreate, create.Notes, "create.Notes");

    //    Assert.AreEqual(id, update.Id, "update.Id");
    //    Assert.AreEqual(updateName, update.Name, "update.Name");
    //    //Assert.AreEqual(imageUpdate, update.Image, "update.Image");
    //    //Assert.AreEqual(notesUpdate, update.Notes, "update.Notes");

    //    Assert.AreEqual(id, patch.Id, "patch.Id");
    //    Assert.AreEqual(patchName, patch.Name, "patch.Name");
    //    //Assert.AreEqual(imagePatch, patch.Image, "patch.Image");
    //    //Assert.AreEqual(notesPatch, patch.Notes, "patch.Notes");
    //}

    // Duplicate consumable name allowed

    //[TestMethod]
    //public async Task TestMethodCreateDuplicateConsumableAsync()
    //{
    //    using var snipeIT = new SnipeIT(developStoreKey, appName);

    //    await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.CreateConsumableAsync(new() { Name = consumableName, Qty = 5, Category = 10 }));
    //}

    [TestMethod]
    public async Task TestMethodGetNotExistingConsumableAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetConsumableAsync(notExistingId));
    }

    [TestMethod]
    public async Task TestMethodDeleteNotExistingConsumableAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.DeleteConsumableAsync(notExistingId));
    }
}
