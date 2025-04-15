namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITCategoriesUnitTest : SnipeITBaseUnitTest<Category>
{
    [TestMethod]
    public async Task TestMethodCreateUpdateDeleteCategoryAsync()
    {
        var create = new Category()
        {
            Name = CreateName(),
            CategoryType = CategoryType.Asset,
            //Image = imageCreate,    
            Notes = notesCreate,
        };

        var update = new Category()
        {
            Name = CreateName(),
            //Image = imageUpdate,
            Notes = notesUpdate,

        };

        var patch = new Category()
        {
            Name = CreateName(),
            //Image = imageUpdate,
            Notes = notesUpdate,

        };

        await TestMethodAllAsync(create, update, patch);
    }

    [TestMethod]
    public async Task TestMethodCreateDuplicateCategoryAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.CreateCategoryAsync(new () { Name = categoryName, CategoryType = CategoryType.Asset }));
    }

    [TestMethod]
    public async Task TestMethodGetNotExistingCategoryAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetCategoryAsync(notExistingId));
    }

    [TestMethod]
    public async Task TestMethodDeleteNotExistingCompanyAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.DeleteCompanyAsync(notExistingId));
    }

    public override void AreEqual(int id, Category expected, Category? actual, string message)
    {
        Assert.IsNotNull(actual, $"{message}.actual");

        Assert.AreEqual(id, actual.Id, $"{message}.Id");
        Assert.AreEqual(expected.Name, actual.Name, $"{message}.Name");
        Assert.AreEqual(expected.Image, actual.Image, $"{message}.Image");
        //Assert.AreEqual(expected.Company, actual.Company, $"{message}.Company");
        //Assert.AreEqual(expected.Manufacturer, actual.Manufacturer, $"{message}.Manufacturer");
        //Assert.AreEqual(expected.Supplier, actual.Supplier, $"{message}.Supplier");
        //Assert.AreEqual(expected.ModelNumber, actual.ModelNumber, $"{message}.ModelNumber");
        //Assert.AreEqual(expected.Category, actual.Category, $"{message}.Category");
        //Assert.AreEqual(expected.Location, actual.Location, $"{message}.Location");
        //Assert.AreEqual(expected.Notes, actual.Notes, $"{message}.Notes");
        //Assert.AreEqual(expected.Qty, actual.Qty, $"{message}.Qty");
        //DateAssert.AreEqual(expected.PurchaseDate, actual.PurchaseDate, $"{message}.PurchaseDate");
        //Assert.AreEqual(expected.PurchaseCost, actual.PurchaseCost, $"{message}.PurchaseCost");
        //Assert.AreEqual(expected.OrderNumber, actual.OrderNumber, $"{message}.OrderNumber");
        //Assert.AreEqual(expected.MinQty, actual.MinQty, $"{message}.MinQty");
        //Assert.AreEqual(expected.MinAmt, actual.MinAmt, $"{message}.MinAmt");
        //Assert.AreEqual(expected.RemainingQty, actual.RemainingQty, $"{message}.RemainingQty");
        //Assert.AreEqual(expected.Remaining, actual.Remaining, $"{message}.Remaining");
        //RangeAssert.IsInRange(0, 9, actual.CheckoutsCount, $"{message}.CheckoutsCount");

        Assert.AreEqual(null, actual.CreatedBy, $"{message}.CreatedBy");
        DateAssert.AreEqual(today, actual.CreatedAt, $"{message}.CreatedAt");
        DateAssert.AreEqual(today, actual.UpdatedAt, $"{message}.UpdatedAt");

        Assert.IsNotNull(actual.AvailableActions, $"{message}.AvailableActions");
        Assert.IsFalse(actual.AvailableActions.Checkout, $"{message}.AvailableActions.Checkout");
        Assert.IsFalse(actual.AvailableActions.Checkin, $"{message}.AvailableActions.Checkin");
        Assert.IsTrue(actual.AvailableActions.Update, $"{message}.AvailableActions.Update");
        Assert.IsTrue(actual.AvailableActions.Delete, $"{message}.AvailableActions.Delete");
        Assert.IsFalse(actual.AvailableActions.Clone, $"{message}.AvailableActions.Clone");
    }

    public override IAsyncEnumerable<Category> GetAsync(SnipeIT snipeIT)
            => snipeIT.GetCategoriesAsync();

    public override async Task<Category?> GetAsync(SnipeIT snipeIT, int id)
        => await snipeIT.GetCategoryAsync(id);

    public override async Task<int> CreateAsync(SnipeIT snipeIT, Category value)
        => await snipeIT.CreateCategoryAsync(value);

    public override async Task UpdateAsync(SnipeIT snipeIT, int id, Category value)
        => await snipeIT.UpdateCategoryAsync(id, value);

    public override async Task PatchAsync(SnipeIT snipeIT, int id, Category value)
        => await snipeIT.PatchCategoryAsync(id, value);

    public override async Task DeleteAsync(SnipeIT snipeIT, int id)
        => await snipeIT.DeleteCategoryAsync(id);
}
