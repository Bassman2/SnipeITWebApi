namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITLocationsUnitTest : SnipeITBaseUnitTest<Location>
{
    public SnipeITLocationsUnitTest()
    {
        create = new()
        {
            Name = CreateName(),
            Phone = phoneCreate,
            Fax = faxCreate,
            //Image = imageCreate,    
            Notes = notesCreate,
        };

        update = new()
        {
            Name = CreateName(),
            Phone = phoneUpdate,
            Fax = faxUpdate,
            //Image = imageUpdate,
            Notes = notesUpdate,
        };

        patch = new()
        {
            Name = CreateName(),
            Phone = phonePatch,
            Fax = faxPatch,
            //Image = imagePatch,
            Notes = notesPatch,
        };
    }

    public override void AreEqual(Location expected, Location actual, string message)
    {
        Assert.AreEqual(expected.Phone, actual.Phone, $"{message}.Phone");
        Assert.AreEqual(expected.Fax, actual.Fax, $"{message}.Fax");
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
