namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITMaintenancesUnitTest : SnipeITBaseUnitTest<Maintenance>
{
    public SnipeITMaintenancesUnitTest()
    {
        userCanCheckout = true;
        availableActions = Actions.Delete;

        TestCreate = new()
        {
            Asset = hardwareId,
            Supplier = companyId,
            AssetMaintenanceType = "1",
            Title = CreateName(),
            StartDate = DateTime.UtcNow,
        };

        TestUpdate = new()
        {
        };

        TestPatch = new()
        {
        };
    }

    public override void AreEqual(Maintenance expected, Maintenance actual, string message)
    {


    }

    public override IAsyncEnumerable<Maintenance> GetAsync(SnipeIT snipeIT)
        => snipeIT.GetMaintenancesAsync();

    public override async Task<Maintenance?> GetAsync(SnipeIT snipeIT, int id)
        => await snipeIT.GetMaintenanceAsync(id);

    public override async Task<int> CreateAsync(SnipeIT snipeIT, Maintenance value)
        => await snipeIT.CreateMaintenanceAsync(value);

    public override async Task UpdateAsync(SnipeIT snipeIT, int id, Maintenance value)
        => await snipeIT.UpdateMaintenanceAsync(id, value);

    public override async Task PatchAsync(SnipeIT snipeIT, int id, Maintenance value)
        => await snipeIT.PatchMaintenanceAsync(id, value);

    public override async Task DeleteAsync(SnipeIT snipeIT, int id)
        => await snipeIT.DeleteMaintenanceAsync(id);
}
