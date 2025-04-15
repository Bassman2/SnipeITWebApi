namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITComponentsUnitTest : SnipeITBaseUnitTest<Component>
{
    public SnipeITComponentsUnitTest()
    {
        create = new Component()
        {
            // update
            Name = CreateName(),
            Qty = 5,
            Category = (categoryId, categoryName),

            // check
            OrderNumber = "",

            // test
            AvailableActions = Actions.Update | Actions.Delete |  Actions.Checkout | Actions.Checkin
        };

        update = new Component()
        {
            // update
            Name = CreateName(),
            Qty = 5,
            Category = (categoryId, categoryName),

            // test
            AvailableActions = Actions.Update | Actions.Delete | Actions.Checkout | Actions.Checkin
        };


        patch = new Component()
        {
            // update
            Name = CreateName(),
            Qty = 5,
            Category = (categoryId, categoryName),

            // test
            AvailableActions = Actions.Update | Actions.Delete | Actions.Checkout | Actions.Checkin
        };

    }

    public override void AreEqual(Component expected, Component actual, string message)
    {
        Assert.AreEqual(expected.Company, actual.Company, $"{message}.Company");
        Assert.AreEqual(expected.Manufacturer, actual.Manufacturer, $"{message}.Manufacturer");
        Assert.AreEqual(expected.Supplier, actual.Supplier, $"{message}.Supplier");
        Assert.AreEqual(expected.ModelNumber, actual.ModelNumber, $"{message}.ModelNumber");
        Assert.AreEqual(expected.Category, actual.Category, $"{message}.Category");
        Assert.AreEqual(expected.Location, actual.Location, $"{message}.Location");
        Assert.AreEqual(expected.Qty, actual.Qty, $"{message}.Qty");
        DateAssert.AreEqual(expected.PurchaseDate, actual.PurchaseDate, $"{message}.PurchaseDate");
        Assert.AreEqual(expected.PurchaseCost, actual.PurchaseCost, $"{message}.PurchaseCost");
        //Assert.AreEqual(expected.OrderNumber, actual.OrderNumber, $"{message}.OrderNumber");
        //Assert.AreEqual(expected.MinQty, actual.MinQty, $"{message}.MinQty");
        Assert.AreEqual(expected.MinAmt, actual.MinAmt, $"{message}.MinAmt");
        //Assert.AreEqual(expected.RemainingQty, actual.RemainingQty, $"{message}.RemainingQty");
        //Assert.AreEqual(expected.Remaining, actual.Remaining, $"{message}.Remaining");
        //RangeAssert.IsInRange(0, 9, actual.CheckoutsCount, $"{message}.CheckoutsCount");
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
