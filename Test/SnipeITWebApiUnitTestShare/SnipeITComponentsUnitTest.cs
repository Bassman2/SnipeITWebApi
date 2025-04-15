namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITComponentsUnitTest : SnipeITBaseUnitTest<Component>
{
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

    public override IAsyncEnumerable<Component> GetAsync(SnipeIT snipeIT)
       => snipeIT.GetComponentsAsync();

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
