namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITUsersUnitTest : SnipeITBaseUnitTest<User>
{
    public SnipeITUsersUnitTest()
    {
        userCanCheckout = true;
        availableActions = Actions.Clone | Actions.Update | Actions.Delete;

        TestCreate = new()
        {
            FirstName = firstNameCreate,
            LastName = lastNameCreate,
            Name = $"{lastNameCreate} {firstNameCreate}",
            Username = CreateName(),
            Password = passwordCreate,
            Phone = phoneCreate,
            Email = emailCreate,
        };

        TestUpdate = new()
        {
            FirstName = firstNameUpdate,
            LastName = lastNameUpdate,
            Name = $"{lastNameUpdate} {firstNameUpdate}",
            Username = CreateName(),
            Password = passwordUpdate,
            Phone = phoneUpdate,
            Email = emailUpdate,
        };

        TestPatch = new()
        {
            FirstName = firstNamePatch,
            LastName = lastNamePatch,
            Name = $"{lastNamePatch} {firstNamePatch}",
            Username = CreateName(),
            Password = passwordPatch,
            Phone = phonePatch,
            Email = emailPatch,
        };
    }

    [TestMethod]
    public async Task TestMethodGetUserMeAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetUserMeAsync();

        Assert.IsNotNull(item);
        Assert.AreEqual(userId, item.Id, "item.Id");
        Assert.AreEqual(adminAvatar, item.Avatar, "item.Avatar");
        Assert.AreEqual(userName, item.Name, "item.Name");
        Assert.AreEqual("Admin", item.FirstName, "item.FirstName");
        Assert.AreEqual("User", item.LastName, "item.LastName");
        Assert.AreEqual("admin", item.Username, "item.Username");
        Assert.AreEqual(false, item.Remote, "item.Remote");
        Assert.AreEqual("en-US", item.Locale, "item.Locale");
        Assert.AreEqual("7308", item.EmployeeNum, "item.EmployeeNum");
        Assert.IsNull(item.Manager, "item.Manager");
        Assert.AreEqual("Sociologist", item.Jobtitle, "item.Jobtitle");
        Assert.AreEqual(false, item.Vip, "item.Vip");
        Assert.AreEqual("1-718-848-7397", item.Phone, "item.Phone");
        Assert.IsNull(item.Website, "item.Website");
        Assert.AreEqual(adminAddress, item.Address, "item.Address");
        Assert.AreEqual(adminCity, item.City, "item.City");
        Assert.AreEqual(adminState, item.State, "item.State");
        Assert.AreEqual(adminCountry, item.Country, "item.Country");
        Assert.AreEqual(adminZip, item.Zip, "item.Zip");
        Assert.AreEqual(adminEmail, item.Email, "item.Email");
        Assert.AreEqual(new NamedItem(4, "Client Services"), item.Department, "item.Department");
        Assert.IsNull(item.Location, "item.Location");
        Assert.AreEqual("Created by DB seeder", item.Notes, "item.Notes");
    }

    public override void AreEqual(User expected, User actual, string message)
    {
        Assert.AreEqual(expected.FirstName, actual.FirstName, $"{message}.FirstName");
        Assert.AreEqual(expected.LastName, actual.LastName, $"{message}.LastName");
        Assert.AreEqual(expected.Username, actual.Username, $"{message}.Username");
        //Assert.AreEqual(expected.Password, actual.Password, $"{message}.Password");
        Assert.AreEqual(expected.Phone, actual.Phone, $"{message}.Phone");
        Assert.AreEqual(expected.Email, actual.Email, $"{message}.Email");

        //Assert.AreEqual(adminAvatar, item.Avatar, "item.Avatar");
        //Assert.AreEqual(userName, item.Name, "item.Name");
        //Assert.AreEqual("Admin", item.FirstName, "item.FirstName");
        //Assert.AreEqual("User", item.LastName, "item.LastName");
        //Assert.AreEqual("admin", item.Username, "item.Username");
        //Assert.AreEqual(false, item.Remote, "item.Remote");
        //Assert.AreEqual("en-US", item.Locale, "item.Locale");
        //Assert.AreEqual("7308", item.EmployeeNum, "item.EmployeeNum");
        //Assert.IsNull(item.Manager, "item.Manager");
        //Assert.AreEqual("Sociologist", item.Jobtitle, "item.Jobtitle");
        //Assert.AreEqual(false, item.Vip, "item.Vip");
        //Assert.AreEqual("1-718-848-7397", item.Phone, "item.Phone");
        //Assert.IsNull(item.Website, "item.Website");
        //Assert.AreEqual(adminAddress, item.Address, "item.Address");
        //Assert.AreEqual(adminCity, item.City, "item.City");
        //Assert.AreEqual(adminState, item.State, "item.State");
        //Assert.AreEqual(adminCountry, item.Country, "item.Country");
        //Assert.AreEqual(adminZip, item.Zip, "item.Zip");
        //Assert.AreEqual(adminEmail, item.Email, "item.Email");
        //Assert.AreEqual(new NamedItem(4, "Client Services"), item.Department, "item.Department");
        //Assert.IsNull(item.Location, "item.Location");
        //Assert.AreEqual("Created by DB seeder", item.Notes, "item.Notes");
    }

    public override IAsyncEnumerable<User> GetAsync(SnipeIT snipeIT)
       => snipeIT.GetUsersAsync();

    public override async Task<User?> GetAsync(SnipeIT snipeIT, int id)
        => await snipeIT.GetUserAsync(id);

    public override async Task<int> CreateAsync(SnipeIT snipeIT, User value)
        => await snipeIT.CreateUserAsync(value);

    public override async Task UpdateAsync(SnipeIT snipeIT, int id, User value)
        => await snipeIT.UpdateUserAsync(id, value);

    public override async Task PatchAsync(SnipeIT snipeIT, int id, User value)
        => await snipeIT.PatchUserAsync(id, value);

    public override async Task DeleteAsync(SnipeIT snipeIT, int id)
        => await snipeIT.DeleteUserAsync(id);
}
