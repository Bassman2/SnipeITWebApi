namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITUsersUnitTest : SnipeITBaseUnitTest<User>
{
    public SnipeITUsersUnitTest()
    {
        userCanCheckout = null;
        availableActions = Actions.Clone | Actions.Update | Actions.Delete;

        TestCreate = new()
        {
            // required
            FirstName = firstNameCreate,
            Username = CreateName(),
            Password = passwordCreate,

            // optional
            LastName = lastNameCreate,
            Email = emailCreate,
            Permissions = null,
            Activated = true,
            Phone = createPhone,
            Jobtitle = "Sociologist",
            Manager = createUserSwitched,
            EmployeeNum = "7308",
            Company = createCompany,
            TwoFactorEnrolled = false,
            TwoFactorOptin = false,
            Department = createDepartment,
            Location = createLocation,
            Remote = false,
            Groups = [ createGroup ],
            AutoassignLicenses = false,
            Vip = false,
            StartDate = DateTime.Now.AddYears(-6),
            EndDate = createDate,

            // test
            Name = $"{lastNameCreate} {firstNameCreate}",
            Avatar = "https://develop.snipeitapp.com/uploads/default.png",
            Image = "https://develop.snipeitapp.com/uploads/default.png",
            Locale = "en-US",
            LdapImport = false

        };

        TestUpdate = new()
        {
            // optional
            FirstName = firstNameUpdate,
            LastName = lastNameUpdate,
            Username = CreateName(),
            Password = passwordUpdate,
            Email = emailUpdate,
            Permissions = null,
            Activated = false,
            Phone = updatePhone,
            Jobtitle = "Manager",
            Manager = updateUserSwitched,
            EmployeeNum = "7309",
            Company = updateCompany,
            TwoFactorEnrolled = false,
            TwoFactorOptin = false,
            Department = updateDepartment,
            Location = updateLocation,
            Remote = true,
            Groups = [updateGroup],
            Vip = false,
            StartDate = DateTime.Now.AddYears(-5),
            EndDate = createDate,

            // test
            Name = $"{lastNameUpdate} {firstNameUpdate}",
            Avatar = "https://develop.snipeitapp.com/uploads/default.png",
            Image = "https://develop.snipeitapp.com/uploads/default.png",
            Locale = "en-US",
            LdapImport = false,
            AutoassignLicenses = false
        };

        TestPatch = new()
        {
            // optional
            FirstName = firstNamePatch,
            LastName = lastNamePatch,
            Username = CreateName(),
            Password = passwordPatch,
            Email = emailPatch,
            Permissions = null,
            Activated = false,
            Phone = patchPhone,
            Jobtitle = "Manager",
            Manager = patchUserSwitched,
            EmployeeNum = "7309",
            Company = patchCompany,
            TwoFactorEnrolled = false,
            TwoFactorOptin = false,
            Department = patchDepartment,
            Location = patchLocation,
            Remote = true,
            Groups = [patchGroup],
            Vip = false,
            StartDate = DateTime.Now.AddYears(-4),
            EndDate = createDate,

            // test
            Name = $"{lastNamePatch} {firstNamePatch}",
            Avatar = "https://develop.snipeitapp.com/uploads/default.png",
            Image = "https://develop.snipeitapp.com/uploads/default.png",
            Locale = "en-US",
            LdapImport = false,
            AutoassignLicenses = false

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
        Assert.AreEqual(expected.Avatar, actual.Avatar, $"{message}.Avatar");
        Assert.AreEqual(expected.FirstName, actual.FirstName, $"{message}.FirstName");
        Assert.AreEqual(expected.LastName, actual.LastName, $"{message}.LastName");
        Assert.AreEqual(expected.Username, actual.Username, $"{message}.Username");
        Assert.AreEqual(expected.Remote, actual.Remote, $"{message}.Remote");
        Assert.AreEqual(expected.Locale, actual.Locale, $"{message}.Locale");
        Assert.AreEqual(expected.EmployeeNum, actual.EmployeeNum, $"{message}.EmployeeNum");
        Assert.AreEqual(expected.Manager, actual.Manager, $"{message}.Manager");
        Assert.AreEqual(expected.Jobtitle, actual.Jobtitle, $"{message}.Jobtitle");
        Assert.AreEqual(expected.Vip, actual.Vip, $"{message}.Vip");
        Assert.AreEqual(expected.Phone, actual.Phone, $"{message}.Phone");
        Assert.AreEqual(expected.Website, actual.Website, $"{message}.Website");
        Assert.AreEqual(expected.Address, actual.Address, $"{message}.Address");
        Assert.AreEqual(expected.City, actual.City, $"{message}.City");
        Assert.AreEqual(expected.State, actual.State, $"{message}.State");
        Assert.AreEqual(expected.Country, actual.Country, $"{message}.Country");
        Assert.AreEqual(expected.Zip, actual.Zip, $"{message}.Zip");
        Assert.AreEqual(expected.Email, actual.Email, $"{message}.Email");
        Assert.AreEqual(expected.Department, actual.Department, $"{message}.Department");
        Assert.AreEqual(expected.Location, actual.Location, $"{message}.Location");
        Assert.AreEqual(expected.Permissions, actual.Permissions, $"{message}.Permissions");
        Assert.AreEqual(expected.Activated, actual.Activated, $"{message}.Activated");
        Assert.AreEqual(expected.AutoassignLicenses, actual.AutoassignLicenses, $"{message}.AutoassignLicenses");
        Assert.AreEqual(expected.LdapImport, actual.LdapImport, $"{message}.LdapImport");
        Assert.AreEqual(expected.TwoFactorEnrolled, actual.TwoFactorEnrolled, $"{message}.TwoFactorEnrolled");
        Assert.AreEqual(expected.TwoFactorOptin, actual.TwoFactorOptin, $"{message}.TwoFactorOptin");
        Assert.AreEqual(expected.AssetsCount, actual.AssetsCount, $"{message}.AssetsCount");
        Assert.AreEqual(expected.LicensesCount, actual.LicensesCount, $"{message}.LicensesCount");
        Assert.AreEqual(expected.AccessoriesCount, actual.AccessoriesCount, $"{message}.AccessoriesCount");
        Assert.AreEqual(expected.ConsumablesCount, actual.ConsumablesCount, $"{message}.ConsumablesCount");
        Assert.AreEqual(expected.ManagesUsersCount, actual.ManagesUsersCount, $"{message}.ManagesUsersCount");
        Assert.AreEqual(expected.ManagesLocationsCount, actual.ManagesLocationsCount, $"{message}.ManagesLocationsCount");
        Assert.AreEqual(expected.Company, actual.Company, $"{message}.Company");
        DateAssert.AreEqual(expected.StartDate, actual.StartDate, $"{message}.StartDate");
        DateAssert.AreEqual(expected.EndDate, actual.EndDate, $"{message}.EndDate");
        DateAssert.AreEqual(expected.LastLogin, actual.LastLogin, $"{message}.LastLogin");
        CollectionAssert.AreEqual(expected.Groups, actual.Groups, $"{message}.Groups");
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
