namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITConsumablesUnitTest : SnipeITBaseUnitTest<Consumable>
{
    public readonly NamedItem consumableCategory = (10, "Printer Paper");

    public SnipeITConsumablesUnitTest()
    {
        userCanCheckout = true;
        availableActions = Actions.Checkout | Actions.Checkin | Actions.Clone | Actions.Delete | Actions.Update;

        TestCreate = new()
        {
            // required
            Qty = 1,
            Category = consumableCategory,

            // optional
            Company = createCompany,
            Manufacturer = createManufacturer,
            Location = createLocation,
            OrderNumber = "1",
            Requestable = true,
            PurchaseDate = createDate,
            MinAmt = 8,
            ModelNumber = "1111567890",
            ItemNo = "11111",

            // test
            Remaining = 1,
        };

        TestUpdate = new()
        {
            // required
            Qty = 1,
            Category = consumableCategory,

            // optional
            Company = updateCompany,
            Manufacturer = updateManufacturer,
            Location = updateLocation,
            OrderNumber = "1",
            Requestable = true,
            PurchaseDate = updateDate,
            MinAmt = 8,
            ModelNumber = "22222567890",
            ItemNo = "22222",

            // test
            Remaining = 1,
        };

        TestPatch = new()
        {
            // required
            Qty = 1,
            Category = consumableCategory,

            // optional
            Company = patchCompany,
            Manufacturer = patchManufacturer,
            Location = patchLocation,
            OrderNumber = "1",
            Requestable = true,
            PurchaseDate = patchDate,
            MinAmt = 8,
            ModelNumber = "333367890",
            ItemNo = "3333",

            // test
            Remaining = 1,
        };
    }
    
    public override void AreEqual(Consumable expected, Consumable actual, string message)
    {
        Assert.AreEqual(expected.Category, actual.Category, $"{message}.Category");
        Assert.AreEqual(expected.Company, actual.Company, $"{message}.Company");
        Assert.AreEqual(expected.ItemNo, actual.ItemNo, $"{message}.ItemNo");
        Assert.AreEqual(expected.Location, actual.Location, $"{message}.Location");
        Assert.AreEqual(expected.Manufacturer, actual.Manufacturer, $"{message}.Manufacturer");
        Assert.AreEqual(expected.Supplier, actual.Supplier, $"{message}.Supplier");
        Assert.AreEqual(expected.MinAmt, actual.MinAmt, $"{message}.MinAmt");
        Assert.AreEqual(expected.ModelNumber, actual.ModelNumber, $"{message}.ModelNumber");
        Assert.AreEqual(expected.Remaining, actual.Remaining, $"{message}.Remaining");
        Assert.AreEqual(expected.OrderNumber, actual.OrderNumber, $"{message}.OrderNumber");
        Assert.AreEqual(expected.PurchaseCost, actual.PurchaseCost, $"{message}.PurchaseCost");
        DateAssert.AreEqual(expected.PurchaseDate, actual.PurchaseDate, $"{message}.PurchaseDate");
        Assert.AreEqual(expected.Qty, actual.Qty, $"{message}.Qty");
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
