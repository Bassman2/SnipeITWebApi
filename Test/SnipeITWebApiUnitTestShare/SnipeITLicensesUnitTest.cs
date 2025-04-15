namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITLicensesUnitTest : SnipeITBaseUnitTest<License>
{
    public  SnipeITLicensesUnitTest()
    {
        create = new()
        {
            // required
            Name = CreateName(),
            Seats = 10,
            Category = new NamedItem(categoryId, categoryName),

            // optional 
            Notes = notesCreate,

            // Image = imageCreate,    
        };

        update = new()
        {
            // optional
            Name = CreateName(),
            Notes = notesUpdate,

            // Image = imageUpdate,
        };

        patch = new()
        {
            // optional 
            Name = CreateName(),
            Notes = notesPatch,

            // Image = imagePatch,
        };
    }

    public override void AreEqual(License expected, License actual, string message)
    {
        //Assert.AreEqual(null, item.Company, "item.Company");
        //Assert.AreEqual(new NamedItem(9, "Adobe"), item.Manufacturer, "item.Manufacturer");
        //Assert.AreEqual("f267bf5d-f8dd-35fd-a43a-a657b20be330", item.ProductKey, "item.ProductKey");
        //Assert.AreEqual("11504574", item.OrderNumber, "item.OrderNumber");
        //Assert.AreEqual("13503Q", item.PurchaseOrder, "item.PurchaseOrder");
        //DateAssert.IsNull(item.PurchaseDate, "item.PurchaseDate");
        //DateAssert.IsNull(item.TerminationDate, "item.TerminationDate");
        //Assert.AreEqual(null, item.Depreciation, "item.Depreciation");
        //Assert.AreEqual("29.999,00", item.PurchaseCost, "item.PurchaseCost");
        //Assert.AreEqual("29999.00", item.PurchaseCostNumeric, "item.PurchaseCostNumeric");
        //Assert.AreEqual(notes, item.Notes, "item.Notes");
        //DateAssert.IsNull(item.ExpirationDate, "item.ExpirationDate");
        //Assert.AreEqual(10, item.Seats, "item.Seats");
        //RangeAssert.IsInRange(4, 6, item.FreeSeatsCount, "item.FreeSeatsCount");
        //RangeAssert.IsInRange(4, 6, item.Remaining, "item.Remaining");
        //Assert.AreEqual(null, item.MinAmt, "item.MinAmt");
        //Assert.AreEqual(null, item.LicenseName, "item.LicenseName");
        //Assert.AreEqual("zbatz@example.net", item.LicenseEmail, "item.LicenseEmail");
        //Assert.AreEqual(true, item.Reassignable, "item.Reassignable");
        //Assert.AreEqual(true, item.Maintained, "item.Maintained");
        //Assert.AreEqual(new NamedItem(2, "Collier, Dibbert and Cronin"), item.Supplier, "item.Supplier");
        //Assert.AreEqual(new NamedItem(14, "Graphics Software"), item.Category, "item.Category");

    }

    public override IAsyncEnumerable<License> GetAsync(SnipeIT snipeIT)
        => snipeIT.GetLicensesAsync();

    public override async Task<License?> GetAsync(SnipeIT snipeIT, int id)
        => await snipeIT.GetLicenseAsync(id);

    public override async Task<int> CreateAsync(SnipeIT snipeIT, License value)
        => await snipeIT.CreateLicenseAsync(value);

    public override async Task UpdateAsync(SnipeIT snipeIT, int id, License value)
        => await snipeIT.UpdateLicenseAsync(id, value);

    public override async Task PatchAsync(SnipeIT snipeIT, int id, License value)
        => await snipeIT.PatchLicenseAsync(id, value);

    public override async Task DeleteAsync(SnipeIT snipeIT, int id)
        => await snipeIT.DeleteLicenseAsync(id);
}
