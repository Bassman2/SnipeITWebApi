namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITLocationsUnitTest : SnipeITBaseUnitTest<Location>
{
    public SnipeITLocationsUnitTest()
    {
        userCanCheckout = null;
        availableActions = Actions.Update | Actions.Delete | Actions.Clone;

        TestCreate = new()
        {
            // optional
            Address = createAddress,
            Address2 = createAddress2,
            City = createCity,
            State = createState,
            Country = createCountry,
            Zip = createZip,
            LdapOu = null,
            Parent = createLocation,
            Currency = "cur1",
            Manager = createUser,

            // test
            Phone = createPhone,
            Fax = createFax,
            AccessoriesCount = 0,
            AssignedAccessoriesCount = 0,
            AssignedAssetsCount = 0,
            AssetsCount = 0,
            RtdAssetsCount = 0,
            UsersCount = 0,
        };

        TestUpdate = new()
        {
            // optional
            Address = updateAddress,
            Address2 = updateAddress2,
            City = updateCity,
            State = updateState,
            Country = updateCountry,
            Zip = updateZip,
            LdapOu = null,
            Parent = updateLocation,
            Currency = "cur2",
            Manager = updateUser,

            // test
            Phone = updatePhone,
            Fax = updateFax,
            AccessoriesCount = 0,
            AssignedAccessoriesCount = 0,
            AssignedAssetsCount = 0,
            AssetsCount = 0,
            RtdAssetsCount = 0,
            UsersCount = 0,
        };

        TestPatch = new()
        {
            // optional
            Address = patchAddress,
            Address2 = patchAddress2,
            City = patchCity,
            State = patchState,
            Country = patchCountry,
            Zip = patchZip,
            LdapOu = null,
            Parent = patchLocation,
            Currency = "cur3",
            Manager = patchUser,

            // test
            Phone = updatePhone,
            Fax = updateFax,
            AccessoriesCount = 0,
            AssignedAccessoriesCount = 0,
            AssignedAssetsCount = 0,
            AssetsCount = 0,
            RtdAssetsCount = 0,
            UsersCount = 0,
        };
    }

    public override void AreEqual(Location expected, Location actual, string message)
    {
        Assert.AreEqual(expected.Address, actual.Address, $"{message}.Address");
        Assert.AreEqual(expected.Address2, actual.Address2, $"{message}.Address2");
        Assert.AreEqual(expected.City, actual.City, $"{message}.City");
        Assert.AreEqual(expected.State, actual.State, $"{message}.State");
        Assert.AreEqual(expected.Country, actual.Country, $"{message}.Country");
        Assert.AreEqual(expected.Zip, actual.Zip, $"{message}.Zip");
        //Assert.AreEqual(expected.Phone, actual.Phone, $"{message}.Phone");
        //Assert.AreEqual(expected.Fax, actual.Fax, $"{message}.Fax");
        Assert.AreEqual(expected.AccessoriesCount, actual.AccessoriesCount, $"{message}.AccessoriesCount");
        Assert.AreEqual(expected.AssignedAccessoriesCount, actual.AssignedAccessoriesCount, $"{message}.AssignedAccessoriesCount");
        Assert.AreEqual(expected.AssignedAssetsCount, actual.AssignedAssetsCount ?? 0, $"{message}.AssignedAssetsCount");
        Assert.AreEqual(expected.AssetsCount, actual.AssetsCount ?? 0, $"{message}.AssetsCount");
        Assert.AreEqual(expected.RtdAssetsCount, actual.RtdAssetsCount ?? 0, $"{message}.RtdAssetsCount");
        Assert.AreEqual(expected.UsersCount, actual.UsersCount ?? 0, $"{message}.UsersCount");
        Assert.AreEqual(expected.Currency, actual.Currency, $"{message}.Currency");
        Assert.AreEqual(expected.LdapOu, actual.LdapOu, $"{message}.LdapOu");
        Assert.AreEqual(expected.Parent, actual.Parent, $"{message}.Parent");
        Assert.AreEqual(expected.Manager, actual.Manager, $"{message}.Manager");
        Assert.AreEqual(expected.Company, actual.Company, $"{message}.Company");
        //Assert.AreEqual(expected.Children, actual.Children, $"{message}.Children");

    }

    public override IAsyncEnumerable<Location> GetAsync(SnipeIT snipeIT)
        => snipeIT.GetLocationsAsync();

    public override async Task<Location?> GetAsync(SnipeIT snipeIT, int id)
        => await snipeIT.GetLocationAsync(id);

    public override async Task<int> CreateAsync(SnipeIT snipeIT, Location value)
        => await snipeIT.CreateLocationAsync(value);

    public override async Task UpdateAsync(SnipeIT snipeIT, int id, Location value)
        => await snipeIT.UpdateLocationAsync(id, value);

    public override async Task PatchAsync(SnipeIT snipeIT, int id, Location value)
        => await snipeIT.PatchLocationAsync(id, value);

    public override async Task DeleteAsync(SnipeIT snipeIT, int id)
        => await snipeIT.DeleteLocationAsync(id);
}
