namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITGroupsUnitTest : SnipeITBaseUnitTest<Group>
{
    public SnipeITGroupsUnitTest()
    {
        create = new()
        {
            Name = CreateName(),
            //Image = imageCreate,    
            Notes = notesCreate,

            // test
            AvailableActions = Actions.Delete | Actions.Update,
        };

        update = new()
        {
            Name = CreateName(),
            //Image = imageUpdate,
            Notes = notesUpdate,

            // test
            AvailableActions = Actions.Delete | Actions.Update,
        };

        patch = new()
        {
            Name = CreateName(),
            //Image = imagePatch,
            Notes = notesPatch,

            // test
            AvailableActions = Actions.Delete | Actions.Update,
        };
    }

    public override void AreEqual(Group expected, Group actual, string message)
    {
        //Assert.AreEqual(expected.UsersCount, actual.UsersCount, $"{message}.UsersCount");

        //Assert.IsNotNull(item.Permissions, "item.Permissions");
        //Assert.AreEqual(0, item.UsersCount, "item.UsersCount");
        //Assert.IsNull(item.Notes, "item.Notes");
        //Assert.AreEqual(adminUser, item.CreatedBy, "item.CreatedBy");
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
