namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITSuppliersUnitTest : SnipeITBaseUnitTest<Supplier>
{
    public SnipeITSuppliersUnitTest()
    {
        userCanCheckout = null;
        availableActions = Actions.Update | Actions.Delete;

        TestCreate = new()
        {
            Phone = createPhone,
            Fax = createFax,
            Email = emailCreate,

            Url = "",
            Address = "",
            Address2 = "",
            City = "",
            State = "",
            Country = "",
            Zip = "",
            Contact = "",
        };

        TestUpdate = new()
        {
            Phone = updatePhone,
            Fax = updateFax,
            Email = emailUpdate,

            Url = "",
            Address = "",
            Address2 = "",
            City = "",
            State = "",
            Country = "",
            Zip = "",
            Contact = "",
        };

        TestPatch = new()
        {
            Phone = patchPhone,
            Fax = patchFax,
            Email = emailPatch,

            Url = "",
            Address = "",
            Address2 = "",
            City = "",
            State = "",
            Country = "",
            Zip = "",
            Contact = "",
        };
    }

    public override void AreEqual(Supplier expected, Supplier actual, string message)
    {
        Assert.AreEqual(expected.Url, actual.Url, $"{message}.Url");
        Assert.AreEqual(expected.Address, actual.Address, $"{message}.Address");
        Assert.AreEqual(expected.Address2, actual.Address2, $"{message}.Address2");
        Assert.AreEqual(expected.City, actual.City, $"{message}.City");
        Assert.AreEqual(expected.State, actual.State, $"{message}.State");
        Assert.AreEqual(expected.Country, actual.Country, $"{message}.Country");
        Assert.AreEqual(expected.Zip, actual.Zip, $"{message}.Zip");
        Assert.AreEqual(expected.Fax, actual.Fax, $"{message}.Fax");
        Assert.AreEqual(expected.Phone, actual.Phone, $"{message}.Phone");
        Assert.AreEqual(expected.Email, actual.Email, $"{message}.Email");
        Assert.AreEqual(expected.Contact, actual.Contact, $"{message}.Contact");
    }

    public override IAsyncEnumerable<Supplier> GetAsync(SnipeIT snipeIT)
       => snipeIT.GetSuppliersAsync();

    public override async Task<Supplier?> GetAsync(SnipeIT snipeIT, int id)
        => await snipeIT.GetSupplierAsync(id);

    public override async Task<int> CreateAsync(SnipeIT snipeIT, Supplier value)
        => await snipeIT.CreateSupplierAsync(value);

    public override async Task UpdateAsync(SnipeIT snipeIT, int id, Supplier value)
        => await snipeIT.UpdateSupplierAsync(id, value);

    public override async Task PatchAsync(SnipeIT snipeIT, int id, Supplier value)
        => await snipeIT.PatchSupplierAsync(id, value);

    public override async Task DeleteAsync(SnipeIT snipeIT, int id)
        => await snipeIT.DeleteSupplierAsync(id);
}
