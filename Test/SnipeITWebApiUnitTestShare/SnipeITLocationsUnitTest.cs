namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITLocationsUnitTest : SnipeITBaseUnitTest<Location>
{
    public SnipeITLocationsUnitTest()
    {
        userCanCheckout = true;
        availableActions = Actions.Update | Actions.Delete | Actions.Clone;

        TestCreate = new()
        {
            Phone = phoneCreate,
            Fax = faxCreate,
        };

        TestUpdate = new()
        {
            Phone = phoneUpdate,
            Fax = faxUpdate,
        };

        TestPatch = new()
        {
            Phone = phonePatch,
            Fax = faxPatch,
        };
    }

    public override void AreEqual(Location expected, Location actual, string message)
    {
        //Assert.AreEqual(expected.Phone, actual.Phone, $"{message}.Phone");
        //Assert.AreEqual(expected.Fax, actual.Fax, $"{message}.Fax");
        Assert.AreEqual(0, actual.AssetsCount ?? 0, $"{message}.AssetsCount");
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
