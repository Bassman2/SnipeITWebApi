namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITAccessoriesUnitTest : SnipeITBaseUnitTest<Accessory>
{
    public SnipeITAccessoriesUnitTest()
    {
        create = new Accessory()
        {
            // update
            Name = CreateName(),
            Qty = 1,
            Category = createAccessoryCategory,
            //Image = imageCreate,    
            Notes = "create",

            // check
            RemainingQty = 1,
            Remaining = 1,
        };

        update = new Accessory()
        {
            // update
            Name = CreateName(),
            Qty = 2,
            Category = updateAccessoryCategory,
            //Image = imageUpdate,
            Notes = notesUpdate,

            // check
            RemainingQty = 2,
            Remaining = 2,

        };

        patch = new Accessory()
        {
            // update
            Name = CreateName(),
            Qty = 3,
            Category = patchAccessoryCategory,
            //Image = imageUpdate,
            Notes = notesPatch,

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
        //RangeAssert.IsInRange(0, 9, actual.CheckoutsCount, $"{message}.CheckoutsCount");
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

