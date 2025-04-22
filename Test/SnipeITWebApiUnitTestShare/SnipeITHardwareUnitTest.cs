namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITHardwareUnitTest : SnipeITBaseUnitTest<Hardware>
{
    public SnipeITHardwareUnitTest()
    {
        userCanCheckout = false;
        availableActions = Actions.Checkout | Actions.Checkin | Actions.Update | Actions.Delete | Actions.Clone;

        TestCreate = new()
        {
            // required
            AssetTag = CreateName(),
            StatusLabel = (2, "Pending"),
            Model = (modelCreateId, modelCreateName),

            // optional
            //Image = "https://develop.snipeitapp.com/uploads/models/mbp.jpg",    // "data:@[mime];base64,[base64encodeddata]"
            Serial = CreateName(),
            PurchaseDate = DateTime.Now,
            //PurchaseCost = 500.0,
            OrderNumber = CreateName(),
            //Archived = false,
            //WarrantyMonths = 12,
            //Depreciate = false,
            Supplier = createSupplier,
            Requestable = false,
            RtdLocation = createLocation,
            LastAuditDate = DateTime.Now,
            Location = createLocation,
            Byod = false,
            AssetEolDate = DateTime.Now.AddYears(3),

            // test
            Manufacturer = modelCreateManufacturer,
            ModelNumber = modelCreateNumber,
            Category = (modelCreateCategoryId, modelCreateCategoryName),
        };

        TestUpdate = new()
        {
            // required
            AssetTag = CreateName(),
            StatusLabel = (2, "Pending"),
            Model = (modelUpdateId, modelUpdateName),

            // optional
            Image = null,    // "data:@[mime];base64,[base64encodeddata]"
            Serial = CreateName(),
            PurchaseDate = DateTime.Now,
            //PurchaseCost = 500.0,
            OrderNumber = CreateName(),
            //Archived = false,
            //WarrantyMonths = 12,
            //Depreciate = false,
            Supplier = updateSupplier,
            Requestable = false,
            RtdLocation = updateLocation,
            LastAuditDate = DateTime.Now,
            Location = updateLocation,
            Byod = false,
            AssetEolDate = DateTime.Now.AddYears(3),
            // test
            Manufacturer = modelUpdateManufacturer,
            ModelNumber = modelUpdateNumber,
            Category = (modelUpdateCategoryId, modelUpdateCategoryName),
        };

        TestPatch = new Hardware()
        {
            // required
            Model = (modelPatchId, modelPatchName),

            // optional
            AssetTag = CreateName(),
            StatusLabel = (2, "Pending"),

            Serial = CreateName(),
            PurchaseDate = DateTime.Now,
            //PurchaseCost = 500.0,
            OrderNumber = CreateName(),
            Notes = createNotes,
            //Archived = false,
            //WarrantyMonths = 12,
            //Depreciate = false,
            Supplier = patchSupplier,
            Requestable = false,
            RtdLocation = patchLocation,
            LastAuditDate = DateTime.Now,
            Location = patchLocation,
            Byod = false,
            AssetEolDate = DateTime.Now.AddYears(3),

            // test
            Manufacturer = modelPatchManufacturer,
            ModelNumber = modelPatchNumber,
            Category = (modelPatchCategoryId, modelPatchCategoryName),
         };
    }

    [TestMethod]
    public async Task TestMethodGetHardwaresByCategoryAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetHardwaresByCategoryAsync(2);

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);
    }

    public override void AreEqual(Hardware expected, Hardware actual, string message)
    {
        Assert.AreEqual(expected.AssetTag, actual.AssetTag, $"{message}.AssetTag");
        Assert.AreEqual(expected.Serial, actual.Serial, $"{message}.Serial");
        Assert.AreEqual(expected.Model, actual.Model, $"{message}.Model");
        Assert.AreEqual(expected.Byod, actual.Byod, $"{message}.Byod");
        Assert.AreEqual(expected.Requestable, actual.Requestable, $"{message}.Requestable");
        Assert.AreEqual(expected.ModelNumber, actual.ModelNumber, $"{message}.ModelNumber");
        //Assert.AreEqual(expected.Eol, actual.Eol, $"{message}.Eol");
        DateAssert.AreEqual(expected.AssetEolDate, actual.AssetEolDate, $"{message}.AssetEolDate");
        Assert.AreEqual(expected.StatusLabel, actual.StatusLabel, $"{message}.StatusLabel");
        Assert.AreEqual(expected.Category, actual.Category, $"{message}.Category");
        Assert.AreEqual(expected.Manufacturer, actual.Manufacturer, $"{message}.Manufacturer");
        Assert.AreEqual(expected.Supplier, actual.Supplier, $"{message}.Supplier");
        Assert.AreEqual(expected.OrderNumber, actual.OrderNumber, $"{message}.OrderNumber");
        Assert.AreEqual(expected.Company, actual.Company, $"{message}.Company");
        Assert.AreEqual(expected.Location, actual.Location, $"{message}.Location");
        Assert.AreEqual(expected.RtdLocation, actual.RtdLocation, $"{message}.RtdLocation");
        //Assert.AreEqual(expected.Image, actual.Image, $"{message}.Image");
        Assert.AreEqual(expected.Qr, actual.Qr, $"{message}.Qr");
        Assert.AreEqual(expected.AltBarcode, actual.AltBarcode, $"{message}.AltBarcode");
        Assert.AreEqual(expected.AssignedTo, actual.AssignedTo, $"{message}.AssignedTo");
        Assert.AreEqual(expected.WarrantyMonths, actual.WarrantyMonths, $"{message}.WarrantyMonths");
        Assert.AreEqual(expected.WarrantyExpires, actual.WarrantyExpires, $"{message}.WarrantyExpires");

        DateAssert.AreEqual(expected.LastAuditDate, actual.LastAuditDate, $"{message}.LastAuditDate");
        DateAssert.AreEqual(expected.NextAuditDate, actual.NextAuditDate, $"{message}.NextAuditDate");

        //DateAssert.AreEqual(expected.PurchaseDate, actual.PurchaseDate, $"{message}.PurchaseDate");
        //Assert.AreEqual(expected.Age, actual.Age, $"{message}.Age");
        DateAssert.AreEqual(expected.LastCheckout, actual.LastCheckout, $"{message}.LastCheckout");
        DateAssert.AreEqual(expected.LastCheckin, actual.LastCheckin, $"{message}.LastCheckin");
        //Assert.AreEqual(expected.RequestsCounter, actual.RequestsCounter, $"{message}.RequestsCounter");
        //Assert.AreEqual(expected.UserCanCheckout, actual.UserCanCheckout, $"{message}.UserCanCheckout");
        //Assert.AreEqual(expected.BookValue, actual.BookValue, $"{message}.BookValue");

        // custom fields
    }

    public override IAsyncEnumerable<Hardware> GetAsync(SnipeIT snipeIT)
        => snipeIT.GetHardwaresAsync();

    public override async Task<Hardware?> GetAsync(SnipeIT snipeIT, int id)
        => await snipeIT.GetHardwareAsync(id);

    public override async Task<int> CreateAsync(SnipeIT snipeIT, Hardware value)
        => await snipeIT.CreateHardwareAsync(value);

    public override async Task UpdateAsync(SnipeIT snipeIT, int id, Hardware value)
        => await snipeIT.UpdateHardwareAsync(id, value);

    public override async Task PatchAsync(SnipeIT snipeIT, int id, Hardware value)
        => await snipeIT.PatchHardwareAsync(id, value);

    public override async Task DeleteAsync(SnipeIT snipeIT, int id)
        => await snipeIT.DeleteHardwareAsync(id);
}
