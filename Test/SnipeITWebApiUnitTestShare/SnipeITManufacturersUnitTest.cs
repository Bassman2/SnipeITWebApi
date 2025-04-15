namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITManufacturersUnitTest : SnipeITBaseUnitTest<Manufacturer>
{
    public SnipeITManufacturersUnitTest()
    {
        create = new Manufacturer()
        {
            // update
            Name = CreateName(),
            Url = "https://test.com",
            //Image = "https://develop.snipeitapp.com/uploads/manufacturers/apple.jpg",        // https://raw.githubusercontent.com/Bassman2/SnipeITWebApi/master/.github/images/donate.gif
            SupportUrl = "https://support.test.com",
            WarrantyLookupUrl = "https://checkcoverage.test.com",
            SupportPhone = "+12725858512",
            SupportEmail = "unknown@microsoft.com",
            Notes = "Dummy Note"

        };

        update = new Manufacturer()
        {
            // update
            Name = CreateName(),
           

        };

        patch = new Manufacturer()
        {
            // update
            Name = CreateName(),
           
        };
    }

    public override void AreEqual(Manufacturer expected, Manufacturer actual, string message)
    {
        Assert.AreEqual(expected.Url, actual.Url, $"{message}.Url");
        Assert.AreEqual(expected.SupportUrl, actual.SupportUrl, $"{message}.SupportUrl");
        Assert.AreEqual(expected.WarrantyLookupUrl, actual.WarrantyLookupUrl, $"{message}.WarrantyLookupUrl");
        Assert.AreEqual(expected.SupportPhone, actual.SupportPhone, $"{message}.SupportPhone");
        Assert.AreEqual(expected.SupportEmail, actual.SupportEmail, $"{message}.SupportEmail");

        //Assert.AreEqual("https://apple.com", item.Url, "item.Url");
        //Assert.AreEqual("https://develop.snipeitapp.com/uploads/manufacturers/apple.jpg", item.Image, "item.Image");
        //Assert.AreEqual("https://support.apple.com", item.SupportUrl, "item.SupportUrl");
        //Assert.AreEqual("https://checkcoverage.apple.com", item.WarrantyLookupUrl, "item.WarrantyLookupUrl");
        //Assert.AreEqual("+19864240208", item.SupportPhone, "item.SupportPhon");
        //Assert.AreEqual("carey.sanford@example.net", item.SupportEmail, "item.SupportEmail");

        //Assert.AreNotEqual(0, item.AssetsCount, "item.AssetsCount");
        //Assert.IsNotNull(item.LicensesCount, "item.LicensesCount");
        //Assert.AreEqual(0, item.ConsumablesCount, "item.ConsumablesCount");
        //RangeAssert.IsInRange(3, 4, item.AccessoriesCount, "item.AccessoriesCount");
        //Assert.AreEqual(0, item.ComponentsCount, "item.ComponentsCount");
        //Assert.AreEqual(notes, item.Notes, "item.Notes");


    }

    public override IAsyncEnumerable<Manufacturer> GetAsync(SnipeIT snipeIT)
        => snipeIT.GetManufacturersAsync();

    public override async Task<Manufacturer?> GetAsync(SnipeIT snipeIT, int id)
        => await snipeIT.GetManufacturerAsync(id);

    public override async Task<int> CreateAsync(SnipeIT snipeIT, Manufacturer value)
        => await snipeIT.CreateManufacturerAsync(value);

    public override async Task UpdateAsync(SnipeIT snipeIT, int id, Manufacturer value)
        => await snipeIT.UpdateManufacturerAsync(id, value);

    public override async Task PatchAsync(SnipeIT snipeIT, int id, Manufacturer value)
        => await snipeIT.PatchManufacturerAsync(id, value);

    public override async Task DeleteAsync(SnipeIT snipeIT, int id)
        => await snipeIT.DeleteManufacturerAsync(id);
}