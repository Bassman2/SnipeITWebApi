namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITConsumablesUnitTest : SnipeITBaseUnitTest<Consumable>
{
    public readonly NamedItem consumableCategory = (10, "Printer Paper");

    public SnipeITConsumablesUnitTest()
    {
        create = new Consumable()
        {
            Name = CreateName(),
            //Image = imageCreate,    
            //Notes = createNotes,
            Qty = 1,
            Category = consumableCategory,

            AvailableActions = Actions.Checkout | Actions.Checkin | Actions.Clone | Actions.Delete | Actions.Update, 
        };

        update = new Consumable()
        {
            Name = CreateName(),
            //Image = imageUpdate,
            //Notes = updateNotes,
            Qty = 1,
            Category = consumableCategory,

            AvailableActions = Actions.Checkout | Actions.Checkin | Actions.Clone | Actions.Delete | Actions.Update,
        };

        patch = new Consumable()
        {
            Name = CreateName(),
            //Image = imageUpdate,
            //Notes = updateNotes,
            Qty = 1,
            Category = consumableCategory,

            AvailableActions = Actions.Checkout | Actions.Checkin | Actions.Clone | Actions.Delete | Actions.Update,
        };
    }
    
    public override void AreEqual(Consumable expected, Consumable actual, string message)
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

    public override IAsyncEnumerable<Consumable> GetAsync(SnipeIT snipeIT)
            => snipeIT.GetConsumablesAsync();

    public override async Task<Consumable?> GetAsync(SnipeIT snipeIT, int id)
        => await snipeIT.GetConsumableAsync(id);

    public override async Task<int> CreateAsync(SnipeIT snipeIT, Consumable value)
        => await snipeIT.CreateConsumableAsync(value);

    public override async Task UpdateAsync(SnipeIT snipeIT, int id, Consumable value)
        => await snipeIT.UpdateConsumableAsync(id, value);

    public override async Task PatchAsync(SnipeIT snipeIT, int id, Consumable value)
        => await snipeIT.PatchConsumableAsync(id, value);

    public override async Task DeleteAsync(SnipeIT snipeIT, int id)
        => await snipeIT.DeleteConsumableAsync(id);
}
