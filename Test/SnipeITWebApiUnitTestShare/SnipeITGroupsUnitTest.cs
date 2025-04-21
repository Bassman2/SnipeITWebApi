namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITGroupsUnitTest : SnipeITBaseUnitTest<Group>
{
    public SnipeITGroupsUnitTest()
    {
        userCanCheckout = null;
        availableActions = Actions.Update | Actions.Delete;

        TestCreate = new()
        {
            Permissions = new Permissions(),

            // test
            UsersCount = 0
        };

        TestUpdate = new()
        {
            Permissions = new Permissions(),

            // test
            UsersCount = 0
        };

        TestPatch = new()
        {
            Permissions = new Permissions(),

            // test
            UsersCount = 0
        };
    }

    public override void AreEqual(Group expected, Group actual, string message)
    {
        //Assert.AreEqual(expected.Permissions, actual.Permissions, $"{message}.Permissions");
        Assert.AreEqual(expected.UsersCount, actual.UsersCount, $"{message}.UsersCount");
    }

    public override IAsyncEnumerable<Group> GetAsync(SnipeIT snipeIT)
        => snipeIT.GetGroupsAsync();

    public override async Task<Group?> GetAsync(SnipeIT snipeIT, int id)
        => await snipeIT.GetGroupAsync(id);

    public override async Task<int> CreateAsync(SnipeIT snipeIT, Group value)
        => await snipeIT.CreateGroupAsync(value);

    public override async Task UpdateAsync(SnipeIT snipeIT, int id, Group value)
        => await snipeIT.UpdateGroupAsync(id, value);

    public override async Task PatchAsync(SnipeIT snipeIT, int id, Group value)
        => await snipeIT.PatchGroupAsync(id, value);

    public override async Task DeleteAsync(SnipeIT snipeIT, int id)
        => await snipeIT.DeleteGroupAsync(id);

}
