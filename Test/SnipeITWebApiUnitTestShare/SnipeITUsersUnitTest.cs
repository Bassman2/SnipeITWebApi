namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITUsersUnitTest : SnipeITBaseUnitTest
{

    [TestMethod]
    public async Task TestMethodGetUsersAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetUsersAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(i => i.Id == userId);
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

    [TestMethod]
    public async Task TestMethodGetUserAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetUserAsync(userId);

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

    [TestMethod]
    public async Task TestMethodCreateUserAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        //string createName = Guid.NewGuid().ToString();
        //string updateName = Guid.NewGuid().ToString();
        //string patchName = Guid.NewGuid().ToString();

        //await snipeIT.DeleteUserAsync(138);

        var create = await snipeIT.CreateUserAsync(new()
        {
            //Name = createName,
            FirstName = firstNameCreate,
            LastName = lastNameCreate,
            Username = usernameCreate,
            Password = passwordCreate,
            Phone = phoneCreate,
            Email = emailCreate,
            //Image = imageCreate,    
            Notes = notesCreate,
        });
        Assert.IsNotNull(create);
        Assert.IsTrue(create.Id > 0, "create.Id");
        int id = create.Id;

        var update = await snipeIT.UpdateUserAsync(id, new()
        {
            //Name = updateName,
            FirstName = firstNameUpdate,
            LastName = lastNameUpdate,
            Username = usernameUpdate,
            Password = passwordUpdate,
            Phone = phoneUpdate,
            Email = emailUpdate,
            //Image = imageUpdate,
            Notes = notesUpdate,

        });
        Assert.IsNotNull(update);

        var patch = await snipeIT.PatchUserAsync(id, new()
        {
            //Name = patchName,
            FirstName = firstNamePatch,
            LastName = lastNamePatch,
            Username = usernamePatch,
            Password = passwordPatch,
            Phone = phonePatch,
            Email = emailPatch,
            //Image = imagePatch,
            Notes = notesPatch,

        });
        Assert.IsNotNull(patch);

        await snipeIT.DeleteUserAsync(id);

        var del = await snipeIT.GetUserAsync(id);

        Assert.AreEqual(id, create.Id, "create.Id");
        Assert.AreEqual($"{lastNameCreate} {firstNameCreate}", create.Name, "create.Name");
        Assert.AreEqual(phoneCreate, create.Phone, "create.Phone");
        Assert.AreEqual(emailCreate, create.Email, "create.Email");
        //Assert.AreEqual(imageCreate, create.Image, "create.Image");
        Assert.AreEqual(notesCreate, create.Notes, "create.Notes");

        Assert.AreEqual(id, update.Id, "update.Id");
        Assert.AreEqual($"{lastNameUpdate} {firstNameUpdate}", update.Name, "update.Name");
        Assert.AreEqual(phoneUpdate, update.Phone, "update.Phone");
        Assert.AreEqual(emailUpdate, update.Email, "update.Email");
        //Assert.AreEqual(imageUpdate, update.Image, "update.Image");
        Assert.AreEqual(notesUpdate, update.Notes, "update.Notes");

        Assert.AreEqual(id, patch.Id, "patch.Id");
        Assert.AreEqual($"{lastNamePatch} {firstNamePatch}", patch.Name, "patch.Name");
        Assert.AreEqual(phonePatch, patch.Phone, "patch.Phone");
        Assert.AreEqual(emailPatch, patch.Email, "patch.Email");
        //Assert.AreEqual(imagePatch, patch.Image, "patch.Image");
        Assert.AreEqual(notesPatch, patch.Notes, "patch.Notes");
    }

    [TestMethod]
    public async Task TestMethodCreateDuplicateUserAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var create = new User() 
        {
            FirstName = "Demo",
            LastName = "Account",
            Username = "admin",
            Password = passwordCreate
        };

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.CreateUserAsync(create));
    }

    [TestMethod]
    public async Task TestMethodDeleteNotExistingUserAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.DeleteUserAsync(notExistingId));
    }
}
