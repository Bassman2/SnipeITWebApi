namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITComponentsUnitTest : SnipeITBaseUnitTest<Component>
{
    public SnipeITComponentsUnitTest()
    {
        create = new Component()
        {
            // required
            Name = CreateName(),
            Qty = 5,
            Category = (categoryId, categoryName),

            // optional
            Location = (locationId, locationName),
            Company = (companyId, companyName),
            OrderNumber = "1",
            PurchaseDate = DateTime.Now.AddYears(5),
            PurchaseCost = 180.30f,
            MinAmt = 8,
            Serial = "1111567890",

            // default
            Notes = createNotes,
            Image = createImage,

            // test
            AvailableActions = Actions.Update | Actions.Delete |  Actions.Checkout | Actions.Checkin
        };

        update = new Component()
        {
            // required
            Name = CreateName(),
            Qty = 6,
            Category = (categoryId, categoryName),

            // optional
            Location = (locationId, locationName),
            Company = (companyId, companyName),
            OrderNumber = "1",
            PurchaseDate = DateTime.Now.AddYears(5),
            PurchaseCost = 180.30f,
            MinAmt = 8,
            Serial = "2222567890",

            // default
            Notes = updateNotes,
            Image = updateImage,

            // test
            AvailableActions = Actions.Update | Actions.Delete | Actions.Checkout | Actions.Checkin
        };


        patch = new Component()
        {
            // required
            Name = CreateName(),
            Qty = 7,
            Category = (categoryId, categoryName),


            // optional
            Location = (locationId, locationName),
            Company = (companyId, companyName),
            OrderNumber = "1",
            PurchaseDate = DateTime.Now.AddYears(5),
            PurchaseCost = 180.30f,
            MinAmt = 8,
            Serial = "3333567890",


            // default
            Notes = patchNotes,
            Image = patchImage,

            // test
            AvailableActions = Actions.Update | Actions.Delete | Actions.Checkout | Actions.Checkin
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
        Assert.AreEqual(expected.UserCanCheckout, actual.UserCanCheckout, $"{message}.UserCanCheckout");
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
