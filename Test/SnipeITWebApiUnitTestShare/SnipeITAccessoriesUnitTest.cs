namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITAccessoriesUnitTest : SnipeITBaseUnitTest<Accessory>
{
    public SnipeITAccessoriesUnitTest()
    {
        userCanCheckout = true;
        availableActions = Actions.Update | Actions.Delete | Actions.Checkout | Actions.Clone;

        TestCreate = new()
        {
            // required
            Qty = 1,
            Category = createAccessoryCategory,

            // optional
            OrderNumber = "5",
            PurchaseCost = 15000.0f,
            PurchaseDate = createDate,
            ModelNumber = "111156789",
            Company = createCompany,
            Location = createLocation,
            Manufacturer = createManufacturer,
            Supplier = createSupplier,

            // test
            RemainingQty = 1,
            Remaining = 1,
        };

        TestUpdate = new()
        {
            // required
            Qty = 2,
            Category = updateAccessoryCategory,

            // optional
            OrderNumber = "6",
            PurchaseCost = 30000.0f,
            PurchaseDate = updateDate,
            ModelNumber = "222256789",
            Company = updateCompany,
            Location = updateLocation,
            Manufacturer = updateManufacturer,
            Supplier = updateSupplier,

            // check
            RemainingQty = 2,
            Remaining = 2,
        };

        TestPatch = new()
        {
            // required
            // no

            // optional
            Qty = 3,
            OrderNumber = "7",
            PurchaseCost = 60000.0f,
            PurchaseDate = patchDate,
            ModelNumber = "333356789",
            Category = patchAccessoryCategory,
            Company = patchCompany,
            Location = patchLocation,
            Manufacturer = patchManufacturer,
            Supplier = patchSupplier,

            // check
            RemainingQty = 3,
            Remaining = 3,
        };
    }

    public override void AreEqual(Accessory expected, Accessory actual, string message)
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
        Assert.AreEqual(expected.OrderNumber, actual.OrderNumber, $"{message}.OrderNumber");
        Assert.AreEqual(expected.MinQty, actual.MinQty, $"{message}.MinQty");
        Assert.AreEqual(expected.MinAmt, actual.MinAmt, $"{message}.MinAmt");
        Assert.AreEqual(expected.RemainingQty, actual.RemainingQty, $"{message}.RemainingQty");
        Assert.AreEqual(expected.Remaining, actual.Remaining, $"{message}.Remaining");
        RangeAssert.IsInRange(0, 9, actual.CheckoutsCount, $"{message}.CheckoutsCount");
    }

    public override IAsyncEnumerable<Accessory> GetAsync(SnipeIT snipeIT) 
        => snipeIT.GetAccessoriesAsync();

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

