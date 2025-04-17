namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITComponentsUnitTest : SnipeITBaseUnitTest<Component>
{
    public SnipeITComponentsUnitTest()
    {
        userCanCheckout = true;
        availableActions = Actions.Update | Actions.Delete | Actions.Checkout | Actions.Checkin;

        TestCreate = new()
        {
            // required
            Qty = 5,
            Category = createComponentCategory,

            // optional
            Location = createLocation,
            Company = createCompany,
            OrderNumber = "1",
            PurchaseDate = createDate,
            PurchaseCost = 180.30f,
            MinAmt = 8,
            Serial = "1111567890",

            // test
            Remaining = 5,
        };

        TestUpdate = new()
        {
            // required
            Qty = 6,
            Category = updateComponentCategory,

            // optional
            Location = updateLocation,
            Company = updateCompany,
            OrderNumber = "1",
            PurchaseDate = updateDate,
            PurchaseCost = 180.30f,
            MinAmt = 8,
            Serial = "2222567890",

            // test
            Remaining = 6,
        };

        TestPatch = new()
        {
            // required
            Qty = 7,
            Category = patchComponentCategory,

            // optional
            Location = patchLocation,
            Company = patchCompany,
            OrderNumber = "1",
            PurchaseDate = patchDate,
            PurchaseCost = 180.30f,
            MinAmt = 8,
            Serial = "3333567890",

            // test
            Remaining = 7,
        };

    }

    public override void AreEqual(Component expected, Component actual, string message)
    {
        Assert.AreEqual(expected.Serial, actual.Serial, $"{message}.Serial");
        Assert.AreEqual(expected.Location, actual.Location, $"{message}.Location");
        Assert.AreEqual(expected.Qty, actual.Qty, $"{message}.Qty");
        Assert.AreEqual(expected.MinAmt, actual.MinAmt, $"{message}.MinAmt");
        Assert.AreEqual(expected.Category, actual.Category, $"{message}.Category");
        Assert.AreEqual(expected.Supplier, actual.Supplier, $"{message}.Supplier");
        Assert.AreEqual(expected.Manufacturer, actual.Manufacturer, $"{message}.Manufacturer");
        Assert.AreEqual(expected.ModelNumber, actual.ModelNumber, $"{message}.ModelNumber");
        Assert.AreEqual(expected.OrderNumber, actual.OrderNumber, $"{message}.OrderNumber");
        DateAssert.AreEqual(expected.PurchaseDate, actual.PurchaseDate, $"{message}.PurchaseDate");
        Assert.AreEqual(expected.PurchaseCost, actual.PurchaseCost, $"{message}.PurchaseCost");
        Assert.AreEqual(expected.Remaining, actual.Remaining, $"{message}.Remaining");
        Assert.AreEqual(expected.Company, actual.Company, $"{message}.Company");
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
