namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITMaintenancesUnitTest : SnipeITBaseUnitTest<Maintenance>
{
    public SnipeITMaintenancesUnitTest()
    {
        handleName = false;
        userCanCheckout = null;

        TestCreate = new()
        {
            // required
            Title = CreateName(),
            Asset = createHardware,
            Supplier = createSupplier,
            AssetMaintenanceType = MaintenanceType.Maintenance,
            StartDate = createDate,

            // option
            IsWarranty = true,
            Cost = createCost,
            CompletionDate = createDate,

            // test
            Model= (1, "Macbook Pro 13\""),
            StatusLabel = (5, "Out for Repair"),
            Location = null, //createHardwareLocation,   // location from createHardware
            RtdLocation = null, //createHardwareLocation,

            UserId = adminUser,
            AvailableActions = Actions.Delete
        };

        TestUpdate = new()
        {
            // required
            Title = CreateName(),
            Asset = updateHardware,
            Supplier = updateSupplier,
            AssetMaintenanceType = MaintenanceType.Repair,
            StartDate = updateDate,

            // option
            IsWarranty = true,
            Cost = updateCost,
            CompletionDate = updateDate,

            // test
            Model = (1, "Macbook Pro 13\""),
            StatusLabel = (1, "Ready to Deploy"),
            Location = updateHardwareLocation,   // location from updateHardware,
            RtdLocation = updateHardwareLocation, 
            UserId = adminUser,
            AvailableActions = Actions.Delete | Actions.Update,

        }; 

        TestPatch = new()
        {
            // required
            AssetMaintenanceType = MaintenanceType.HardwareSupport,

            // option
            Title = CreateName(),
            Asset = patchHardware,
            Supplier = patchSupplier,
            StartDate = patchDate,
            IsWarranty = true,
            Cost = patchCost,
            CompletionDate = patchDate,

            // test
            Model = (1, "Macbook Pro 13\""),
            StatusLabel = (1, "Ready to Deploy"),
            Location = null, //patchHardwareLocation,   // location from patchHardware
            RtdLocation = patchHardwareLocation,
            UserId = adminUser,
            AvailableActions = Actions.Delete,

        };
    }

    public override void AreEqual(Maintenance expected, Maintenance actual, string message)
    {
        Assert.AreEqual(expected.Asset, actual.Asset, $"{message}.Asset");
        Assert.AreEqual(expected.Model?.Id, actual.Model?.Id, $"{message}.Model.Id");    // bug in SnipeIT model name not correct
        Assert.AreEqual(expected.StatusLabel, actual.StatusLabel, $"{message}.StatusLabel");
        Assert.AreEqual(expected.Company, actual.Company, $"{message}.Company");
        Assert.AreEqual(expected.Title, actual.Title, $"{message}.Title");
        Assert.AreEqual(expected.Location, actual.Location, $"{message}.Location");
        Assert.AreEqual(expected.RtdLocation, actual.RtdLocation, $"{message}.RtdLocation");
        Assert.AreEqual(expected.Supplier, actual.Supplier, $"{message}.Supplier");
        Assert.AreEqual(expected.Cost, actual.Cost, $"{message}.Cost");
        Assert.AreEqual(expected.AssetMaintenanceType, actual.AssetMaintenanceType, $"{message}.AssetMaintenanceType");
        DateAssert.AreEqual(expected.StartDate, actual.StartDate, $"{message}.StartDate");
        Assert.AreEqual(expected.AssetMaintenanceTime, actual.AssetMaintenanceTime, $"{message}.AssetMaintenanceTime");
        DateAssert.AreEqual(expected.CompletionDate, actual.CompletionDate, $"{message}.CompletionDate");
        Assert.AreEqual(expected.UserId, actual.UserId, $"{message}.UserId");
        Assert.AreEqual(expected.IsWarranty, actual.IsWarranty, $"{message}.IsWarranty");
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
