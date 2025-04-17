namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITDepartmentsUnitTest : SnipeITBaseUnitTest<Department>
{
    public SnipeITDepartmentsUnitTest()
    {
        userCanCheckout = true;
        availableActions = Actions.Update | Actions.Delete;

        TestCreate = new()
        {
            Phone = phoneCreate,
            Fax = faxCreate,
            Notes = createNotes,

            // test
        };

        TestUpdate = new()
        {
            Name = CreateName(),
            Phone = phoneUpdate,
            Fax = faxUpdate,
            Notes = updateNotes,

            // test
        };

        TestPatch = new()
        {
            Name = CreateName(),
            Phone = phonePatch,
            Fax = faxPatch,
            Notes = patchNotes,

            // test
        };
    }

    public override void AreEqual(Department expected, Department actual, string message)
    {
        Assert.AreEqual(expected.Phone, actual.Phone, $"{message}.Phone");
        Assert.AreEqual(expected.Fax, actual.Fax, $"{message}.Fax");
        Assert.AreEqual(expected.Company, actual.Company, $"{message}.Company");
        Assert.AreEqual(expected.Manager, actual.Manager, $"{message}.Manager");
        Assert.AreEqual(expected.Location, actual.Location, $"{message}.Location");
        Assert.AreEqual(expected.UsersCount, actual.UsersCount, $"{message}.UsersCount");
    }

    public override IAsyncEnumerable<Department> GetAsync(SnipeIT snipeIT)
        => snipeIT.GetDepartmentsAsync();

    public override async Task<Department?> GetAsync(SnipeIT snipeIT, int id)
        => await snipeIT.GetDepartmentAsync(id);

    public override async Task<int> CreateAsync(SnipeIT snipeIT, Department value)
        => await snipeIT.CreateDepartmentAsync(value);

    public override async Task UpdateAsync(SnipeIT snipeIT, int id, Department value)
        => await snipeIT.UpdateDepartmentAsync(id, value);

    public override async Task PatchAsync(SnipeIT snipeIT, int id, Department value)
        => await snipeIT.PatchDepartmentAsync(id, value);

    public override async Task DeleteAsync(SnipeIT snipeIT, int id)
        => await snipeIT.DeleteDepartmentAsync(id);
}
