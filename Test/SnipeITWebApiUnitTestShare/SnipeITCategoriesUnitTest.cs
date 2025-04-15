namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITCategoriesUnitTest : SnipeITBaseUnitTest<Category>
{
    public SnipeITCategoriesUnitTest()
    {
        create = new Category()
        {
            Name = CreateName(),
            CategoryType = CategoryType.Asset,
            //Image = imageCreate,    
            Notes = notesCreate,
        };

        update = new Category()
        {
            Name = CreateName(),
            //Image = imageUpdate,
            Notes = notesUpdate,

        };

        patch = new Category()
        {
            Name = CreateName(),
            //Image = imageUpdate,
            Notes = notesUpdate,

        };
    }

    public override void AreEqual(Category expected, Category actual, string message)
    {
        //Assert.AreEqual(expected.Company, actual.Company, $"{message}.Company");
        //Assert.AreEqual(expected.Manufacturer, actual.Manufacturer, $"{message}.Manufacturer");
        //Assert.AreEqual(expected.Supplier, actual.Supplier, $"{message}.Supplier");
        //Assert.AreEqual(expected.ModelNumber, actual.ModelNumber, $"{message}.ModelNumber");
        //Assert.AreEqual(expected.Category, actual.Category, $"{message}.Category");
        //Assert.AreEqual(expected.Location, actual.Location, $"{message}.Location");
        //Assert.AreEqual(expected.Qty, actual.Qty, $"{message}.Qty");
        //DateAssert.AreEqual(expected.PurchaseDate, actual.PurchaseDate, $"{message}.PurchaseDate");
        //Assert.AreEqual(expected.PurchaseCost, actual.PurchaseCost, $"{message}.PurchaseCost");
        //Assert.AreEqual(expected.OrderNumber, actual.OrderNumber, $"{message}.OrderNumber");
        //Assert.AreEqual(expected.MinQty, actual.MinQty, $"{message}.MinQty");
        //Assert.AreEqual(expected.MinAmt, actual.MinAmt, $"{message}.MinAmt");
        //Assert.AreEqual(expected.RemainingQty, actual.RemainingQty, $"{message}.RemainingQty");
        //Assert.AreEqual(expected.Remaining, actual.Remaining, $"{message}.Remaining");
        //RangeAssert.IsInRange(0, 9, actual.CheckoutsCount, $"{message}.CheckoutsCount");
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
