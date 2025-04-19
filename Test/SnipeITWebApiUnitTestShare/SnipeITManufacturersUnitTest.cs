namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITManufacturersUnitTest : SnipeITBaseUnitTest<Manufacturer>
{
    public SnipeITManufacturersUnitTest()
    {
        userCanCheckout = null;
        availableActions = Actions.Delete | Actions.Update;

        TestCreate = new()
        {
            // update
            
            // test
            Url = "",
            SupportUrl = "",
            WarrantyLookupUrl = "",
            SupportPhone = "",
            SupportEmail = "",
        };

        TestUpdate = new()
        {
            // update

            // test
            Url = "",
            SupportUrl = "",
            WarrantyLookupUrl = "",
            SupportPhone = "",
            SupportEmail = "",
        };

        TestPatch = new()
        {
            // update


            // test
            Url = "",
            SupportUrl = "",
            WarrantyLookupUrl = "",
            SupportPhone = "",
            SupportEmail = "",
        };
    }

    public override void AreEqual(Manufacturer expected, Manufacturer actual, string message)
    {
        Assert.AreEqual(expected.Url, actual.Url, $"{message}.Url");
        Assert.AreEqual(expected.SupportUrl, actual.SupportUrl, $"{message}.SupportUrl");
        Assert.AreEqual(expected.WarrantyLookupUrl, actual.WarrantyLookupUrl, $"{message}.WarrantyLookupUrl");
        Assert.AreEqual(expected.SupportPhone, actual.SupportPhone, $"{message}.SupportPhone");
        Assert.AreEqual(expected.SupportEmail, actual.SupportEmail, $"{message}.SupportEmail");
        Assert.AreEqual(expected.AssetsCount, actual.AssetsCount, $"{message}.AssetsCount");
        Assert.AreEqual(expected.LicensesCount, actual.LicensesCount, $"{message}.LicensesCount");
        Assert.AreEqual(expected.ConsumablesCount, actual.ConsumablesCount, $"{message}.ConsumablesCount");
        Assert.AreEqual(expected.AccessoriesCount, actual.AccessoriesCount, $"{message}.AccessoriesCount");
        Assert.AreEqual(expected.ComponentsCount, actual.ComponentsCount, $"{message}.ConsumaComponentsCountblesCount");
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