namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITComponentsUnitTest : SnipeITBaseUnitTest<Component>
{
    [TestMethod]
    public async Task TestMethodGetComponentsAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetComponentsAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == componentId);
        Assert.IsNotNull(item);
        Assert.AreEqual(componentId, item.Id, "item.Id");
        Assert.AreEqual(componentName, item.Name, "item.Name");
        Assert.AreEqual(null, item.Image, "item.Image");
        Assert.AreEqual("9a659795-2c29-31a8-a066-60da4cf28b53", item.Serial, "item.Serial");
        Assert.AreEqual(new NamedItem(3, "Jarrellport"), item.Location, "item.Location");
        Assert.AreEqual(10, item.Qty, "item.Qty");
        Assert.AreEqual(2, item.MinAmt, "item.MinAmt");
        Assert.AreEqual(new NamedItem(13, "RAM"), item.Category, "item.Category");
        Assert.AreEqual(new NamedItem(6, "Schulist-Daugherty"), item.Supplier, "item.Supplier");
        Assert.AreEqual(new NamedItem(11, "Crucial"), item.Manufacturer, "item.Manufacturer");
        Assert.AreEqual("11525744", item.ModelNumber, "item.ModelNumber");
        Assert.AreEqual("49148111", item.OrderNumber, "item.OrderNumber");
        DateAssert.IsNull(item.PurchaseDate, "item.PurchaseDate");
        Assert.AreEqual("2,40", item.PurchaseCost, "item.PurchaseCost");
        Assert.AreEqual(9, item.Remaining, "item.Remaining");
        Assert.AreEqual(new NamedItem(1, "Quigley-Luettgen"), item.Company, "item.Company");
        Assert.AreEqual(null, item.Notes, "item.Notes");
        Assert.AreEqual(null, item.CreatedBy, "item.CreatedBy");
        DateAssert.AreEqual(lastUpdate, item.CreatedAt, "item.CreatedAt");
        DateAssert.AreEqual(lastUpdate, item.UpdatedAt, "item.UpdatedAt");
        Assert.AreEqual(1, item.UserCanCheckout, "item.UserCanCheckout");
        Assert.IsNotNull(item.AvailableActions, "item.AvailableActions");
        Assert.IsTrue(item.AvailableActions.Checkout, "item.AvailableActions.Checkout");
        Assert.IsTrue(item.AvailableActions.Checkin, "item.AvailableActions.Checkin");
        Assert.IsTrue(item.AvailableActions.Update, "item.AvailableActions.Update");
        Assert.IsFalse(item.AvailableActions.Delete, "item.AvailableActions.Delete");
    }

    [TestMethod]
    public async Task TestMethodGetComponentsQueryAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        int numAll = await snipeIT.GetComponentsAsync(CancellationToken.None).CountAsync();

        int numName = await snipeIT.GetComponentsAsync(name: "Crucial 4GB DDR3L-1600 SODIMM").CountAsync();

        int numSearch = await snipeIT.GetComponentsAsync(search: "Laptops").CountAsync();

        int numOrderNumber = await snipeIT.GetComponentsAsync(orderNumber: "30959123").CountAsync();
        
        RangeAssert.IsInRange(1, 9, numAll, "numAll");
        RangeAssert.IsInRange(1, 9, numName, "numName");
        RangeAssert.IsInRange(0, 9, numSearch, "numSearch");
        RangeAssert.IsInRange(1, 9, numOrderNumber, "numOrderNumber");
    }

    [TestMethod]
    public async Task TestMethodGetComponentAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetComponentAsync(componentId);
        
        Assert.IsNotNull(item);
        Assert.AreEqual(componentId, item.Id, "item.Id");
        Assert.AreEqual(componentName, item.Name, "item.Name");
        Assert.AreEqual(null, item.Image, "item.Image");
        Assert.AreEqual("9a659795-2c29-31a8-a066-60da4cf28b53", item.Serial, "item.Serial");
        Assert.AreEqual(new NamedItem(3, "Jarrellport"), item.Location, "item.Location");
        Assert.AreEqual(10, item.Qty, "item.Qty");
        Assert.AreEqual(2, item.MinAmt, "item.MinAmt");
        Assert.AreEqual(new NamedItem(13, "RAM"), item.Category, "item.Category");
        Assert.AreEqual(new NamedItem(6, "Schulist-Daugherty"), item.Supplier, "item.Supplier");
        Assert.AreEqual(new NamedItem(11, "Crucial"), item.Manufacturer, "item.Manufacturer");
        Assert.AreEqual("11525744", item.ModelNumber, "item.ModelNumber");
        Assert.AreEqual("49148111", item.OrderNumber, "item.OrderNumber");
        DateAssert.IsNull(item.PurchaseDate, "item.PurchaseDate");
        Assert.AreEqual("2,40", item.PurchaseCost, "item.PurchaseCost");
        Assert.AreEqual(9, item.Remaining, "item.Remaining");
        Assert.AreEqual(new NamedItem(1, "Quigley-Luettgen"), item.Company, "item.Company");
        Assert.AreEqual(null, item.Notes, "item.Notes");
        Assert.AreEqual(null, item.CreatedBy, "item.CreatedBy");
        DateAssert.AreEqual(lastUpdate, item.CreatedAt, "item.CreatedAt");
        DateAssert.AreEqual(lastUpdate, item.UpdatedAt, "item.UpdatedAt");
        Assert.AreEqual(1, item.UserCanCheckout, "item.UserCanCheckout");
        Assert.IsNotNull(item.AvailableActions, "item.AvailableActions");
        Assert.IsTrue(item.AvailableActions.Checkout, "item.AvailableActions.Checkout");
        Assert.IsTrue(item.AvailableActions.Checkin, "item.AvailableActions.Checkin");
        Assert.IsTrue(item.AvailableActions.Update, "item.AvailableActions.Update");
        Assert.IsFalse(item.AvailableActions.Delete, "item.AvailableActions.Delete");
    }

    //[TestMethod]
    //public async Task TestMethodCreateComponentAsync()
    //{
    //    using var snipeIT = new SnipeIT(developStoreKey, appName);

    //    string createName = Guid.NewGuid().ToString();
    //    string updateName = Guid.NewGuid().ToString();
    //    string patchName = Guid.NewGuid().ToString();

    //    var create = await snipeIT.CreateComponentAsync(new()
    //    {
    //        Name = createName,
    //        Qty = 5,
    //        Category = categoryId,

    //        //Notes = notesCreate,
    //    });
    //    Assert.IsNotNull(create);
    //    Assert.IsTrue(create.Id > 0, "create.Id");
    //    int id = create.Id;

    //    var update = await snipeIT.UpdateComponentAsync(id, new()
    //    {
    //        Name = updateName,
    //        //Image = imageUpdate,
    //        //Notes = notesUpdate,

    //    });
    //    Assert.IsNotNull(update);

    //    var patch = await snipeIT.PatchComponentAsync(id, new()
    //    {
    //        Name = patchName,
    //        //Image = imagePatch,
    //        //Notes = notesPatch,

    //    });
    //    Assert.IsNotNull(patch);

    //    var del = await snipeIT.DeleteComponentAsync(id);

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

    [TestMethod]
    public async Task TestMethodCreateUpdateDeleteComponentAsync()
    {
        var create = new Component()
        {
            // update
            Name = CreateName(),
            Qty = 5,
            Category = (categoryId, categoryName),

            // check
            OrderNumber = "",
        };

        var update = new Component()
        {
            // update
            Name = CreateName(),
        };

        var patch = new Component()
        {
            // update
            Name = CreateName(),
        };

        await TestMethodAllAsync(create, update, patch);
    }

    // Duplicate component name allowed

    //[TestMethod]
    //public async Task TestMethodCreateDuplicateComponentAsync()
    //{
    //    using var snipeIT = new SnipeIT(developStoreKey, appName);

    //    await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.CreateComponentAsync(new() { Name = componentName, Qty = 5, Category = categoryId }));
    //}

    [TestMethod]
    public async Task TestMethodGetNotExistingComponentAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetComponentAsync(notExistingId));
    }

    [TestMethod]
    public async Task TestMethodDeleteNotExistingComponentAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.DeleteComponentAsync(notExistingId));
    }

    public override void AreEqual(int id, Component expected, Component? actual, string message)
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
        //Assert.AreEqual(expected.MinQty, actual.MinQty, $"{message}.MinQty");
        Assert.AreEqual(expected.MinAmt, actual.MinAmt, $"{message}.MinAmt");
        //Assert.AreEqual(expected.RemainingQty, actual.RemainingQty, $"{message}.RemainingQty");
        Assert.AreEqual(expected.Remaining, actual.Remaining, $"{message}.Remaining");
        //RangeAssert.IsInRange(0, 9, actual.CheckoutsCount, $"{message}.CheckoutsCount");

        Assert.AreEqual(null, actual.CreatedBy, $"{message}.CreatedBy");
        DateAssert.AreEqual(today, actual.CreatedAt, $"{message}.CreatedAt");
        DateAssert.AreEqual(today, actual.UpdatedAt, $"{message}.UpdatedAt");

        Assert.IsNotNull(actual.AvailableActions, $"{message}.AvailableActions");
        Assert.IsTrue(actual.AvailableActions.Checkout, $"{message}.AvailableActions.Checkout");
        Assert.IsFalse(actual.AvailableActions.Checkin, $"{message}.AvailableActions.Checkin");
        Assert.IsTrue(actual.AvailableActions.Update, $"{message}.AvailableActions.Update");
        Assert.IsTrue(actual.AvailableActions.Delete, $"{message}.AvailableActions.Delete");
        Assert.IsTrue(actual.AvailableActions.Clone, $"{message}.AvailableActions.Clone");
    }

    public override async Task<Component?> GetAsync(SnipeIT snipeIT, int id)
        => await snipeIT.GetComponentAsync(id);

    public override async Task<int> CreateAsync(SnipeIT snipeIT, Component value)
        => await snipeIT.CreateComponentAsync(value);

    public override async Task UpdateAsync(SnipeIT snipeIT, int id, Component value)
        => await snipeIT.UpdateComponentAsync(id, value);

    public override async Task PatchAsync(SnipeIT snipeIT, int id, Component value)
        => await snipeIT.PatchComponentAsync(id, value);

    public override async Task DeleteAsync(SnipeIT snipeIT, int id)
        => await snipeIT.DeleteComponentAsync(id);
}
