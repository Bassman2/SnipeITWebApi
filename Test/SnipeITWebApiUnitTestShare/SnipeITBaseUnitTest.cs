namespace SnipeITWebApiUnitTest;

public abstract class SnipeITBaseUnitTest
{
    protected const string internalStoreKey = "snipeit";
    protected const string developStoreKey = "develop-snipeit";

    protected const string appName = "UnitTest";

    protected const string lastUpdate = "2025-04-19";


    // server: "2025-04-15 23:54:50"
    // local:  "2025-04-16 08:54:50"
    protected readonly DateTime todayDate = DateTime.Now.AddHours(-9);
    protected readonly string today = DateTime.Now.AddHours(-9).ToString("yyyy-MM-dd");


    protected const int notExistingId = 65000;


    protected const int accessoryId = 1;
    protected const string accessoryName = "USB Keyboard";

    protected const int categoryId = 1;
    protected const string categoryName = "Laptops";

    protected const int companyId = 1;
    protected const string companyName = "Quigley-Luettgen";

    protected const int componentId = 1;
    protected const string componentName = "Crucial 4GB DDR3L-1600 SODIMM";

    protected const int consumableId = 1;
    protected const string consumableName = "Cardstock (White)";

    protected const int departmentId = 1;
    protected const string departmentName = "Human Resources";

    protected const int fieldsetId = 1;
    protected const string fieldsetName = "Mobile Devices";

    protected const int fieldId = 1;
    protected const string fieldName = "IMEI";

    protected const int groupId = 1;
    protected const string groupName = "hoge";

    protected const int hardwareId = 1;
    protected const string hardwareName = "";

    protected const int licenseId = 1;
    protected const string licenseName = "Photoshop";

    protected const int locationId = 1;
    protected const string locationName = "East Alex";

    protected const int maintenanceId = 1;
    protected const string? maintenanceName = null;

    protected const int manufacturerId = 1;
    protected const string manufacturerName = "Apple";

    protected const int modelId = 3;
    protected const string modelName = "Surface";
    protected const string modelNumber = "5268087447872907";

    protected const int statusLabelId = 1;
    protected const string statusLabelName = "Ready to Deploy";

    protected const int supplierId = 1;
    protected const string supplierName = "Bernhard PLC";

    protected const int userId = 1;
    protected const string userName = "User Admin";


    protected const string createPhone = "11114711";
    protected const string updatePhone = "11114712";
    protected const string patchPhone = "11114713";

    protected const string createFax = "+11114811";
    protected const string updateFax = "+11114812";
    protected const string patchFax = "+11114813";

    protected const string emailCreate = "Peter.A@unknown.com";
    protected const string emailUpdate = "Peter.B@unknown.com";
    protected const string emailPatch = "Peter.C@unknown.com";

    protected const string imageCreate = @"D:\_Data\SnipeIT\Test\ImageA.png";
    protected const string imageUpdate = @"D:\_Data\SnipeIT\Test\ImageB.png";
    protected const string imagePatch = @"D:\_Data\SnipeIT\Test\ImageC.png";

    protected const string firstNameCreate = "Peter";
    protected const string firstNameUpdate = "Paul";
    protected const string firstNamePatch = "Mary";

    protected const string lastNameCreate = "Miller";
    protected const string lastNameUpdate = "Butcher";
    protected const string lastNamePatch = "Dougle";

    protected const string usernameCreate = "un0001";
    protected const string usernameUpdate = "un0002";
    protected const string usernamePatch = "un0003";

    protected const string createAddress = "First Street 1";
    protected const string updateAddress = "Second Street 2";
    protected const string patchAddress = "Third Street 3";


    protected const string passwordCreate = "|Mnx7=4-@vd:";
    protected const string passwordUpdate = "5~g=?=m7JPDg";
    protected const string passwordPatch = "py4Nx/r$!,zQ";

    protected const string createAddress2 = "Entrance A";
    protected const string updateAddress2 = "Entrance B";
    protected const string patchAddress2 = "Entrance C";

    protected const string createCity = "New York";
    protected const string updateCity = "Boston";
    protected const string patchCity = "Washington";

    protected const string createState = "NY";
    protected const string updateState = "TE";
    protected const string patchState = "HW";

    protected const string createCountry = "Orange Country";
    protected const string updateCountry = "Green Country";
    protected const string patchCountry = "Blue Country";

    protected const string createZip = "10000";
    protected const string updateZip = "20000";
    protected const string patchZip = "30000";

    protected const int modelCreateId = 1;
    protected const string modelCreateName = "Macbook Pro 13&quot;";
    protected const string modelCreateNumber = "4532230160393106";
    protected const int modelCreateCategoryId = 1;
    protected const string modelCreateCategoryName = "Laptops";
    protected readonly NamedItem? modelCreateManufacturer = null;

    protected const int modelUpdateId = 2;
    protected const string modelUpdateName = "Macbook Air";
    protected const string modelUpdateNumber = "3528835919718805";
    protected const int modelUpdateCategoryId = 1;
    protected const string modelUpdateCategoryName = "Laptops";
    protected readonly NamedItem? modelUpdateManufacturer = (1, "example");

    protected const int modelPatchId = 4;
    protected const string modelPatchName = "XPS 13";
    protected const string modelPatchNumber = "4164654283655320";
    protected const int modelPatchCategoryId = 1;
    protected const string modelPatchCategoryName = "Laptops";
    protected readonly NamedItem? modelPatchManufacturer = (3, "Dell");

    protected const string notes = "Created by DB seeder";

    protected static readonly NamedItem adminUser = (1, "Admin User");

    protected const string adminAvatar = "https://develop.snipeitapp.com/uploads/avatars/1.jpg";
    protected const string adminAddress = "87374 Cummings Centers\nNorth Camron, AZ 89719-4068";
    protected const string adminCity = "East Hectorfurt";
    protected const string adminState = "MN";
    protected const string adminCountry = "Saint Pierre and Miquelon";
    protected const string adminZip = "04529-0110";
    protected const string adminEmail = "herzog.earl@example.org";


    protected const string createNotes = "Note Create";
    protected const string updateNotes = "Note Update";
    protected const string patchNotes = "Note Patch";

    protected const string createImage = null;
    protected const string updateImage = null;
    protected const string patchImage = null;

    protected const string createModelNumber = "100011";
    protected const string updateModelNumber = "200022";
    protected const string patchModelNumber = "300033";

    protected static readonly NamedItem createAccessoryCategory = (8, "Keyboards");
    protected static readonly NamedItem updateAccessoryCategory = (9, "Mouse");
    protected static readonly NamedItem patchAccessoryCategory = (8, "Keyboards");

    protected static readonly NamedItem createComponentCategory = (8, "Keyboards");
    protected static readonly NamedItem updateComponentCategory = (9, "Mouse");
    protected static readonly NamedItem patchComponentCategory = (8, "Keyboards");

    protected static readonly NamedItem createAssetCategory = (1, "Laptops");
    protected static readonly NamedItem updateAssetCategory = (2, "Desktops");
    protected static readonly NamedItem patchAssetCategory = (3, "Tablets");

    protected static readonly NamedItem createCompany = (1, "Paucek, Krajcik and Rogahn");
    protected static readonly NamedItem updateCompany = (2, "Feest Group");
    protected static readonly NamedItem patchCompany = (3, "Rice LLC");

    protected static readonly NamedItem createLocation = (1, "East Jeanette");
    protected static readonly NamedItem updateLocation = (2, "Samanthaside");
    protected static readonly NamedItem patchLocation = (3, "New Steve");

    protected static readonly NamedItem createManufacturer = (2, "Microsoft");
    protected static readonly NamedItem updateManufacturer = (3, "Dell");
    protected static readonly NamedItem patchManufacturer = (4, "Asus");

    protected static readonly NamedItem createSupplier = (1, "Cartwright, Denesik and Denesik");
    protected static readonly NamedItem updateSupplier = (2, "Kling and Sons");
    protected static readonly NamedItem patchSupplier = (3, "Schaden-Mertz");

    protected static readonly NamedItem createUser = (2, "Head Snipe E.");
    protected static readonly NamedItem updateUser = (3, "Gianotto Alison");
    protected static readonly NamedItem patchUser = (4, "Kessler Jessica");

    protected static readonly NamedItem createUserSwitched = (2, "Snipe E. Head");
    protected static readonly NamedItem updateUserSwitched = (3, "Alison Gianotto");
    protected static readonly NamedItem patchUserSwitched = (4, "Jessica Kessler");

    protected static readonly NamedItem createDepartment = (1, "Human Resources");
    protected static readonly NamedItem updateDepartment = (2, "Engineering");
    protected static readonly NamedItem patchDepartment = (3, "Marketing");

    protected static readonly NamedItem createGroup = (1, "admin");
    protected static readonly NamedItem updateGroup = (1, "admin");
    protected static readonly NamedItem patchGroup = (1, "admin");


    protected static readonly NamedItem createFieldset = (1, "Mobile Devices");
    protected static readonly NamedItem updateFieldset = (2, "Laptops and Desktops");
    protected static readonly NamedItem patchFieldset = (1, "Mobile Devices");

    protected static readonly Hardware createHardware = (1, "", "1632299708");
    protected static readonly Hardware updateHardware = (2, "", "440728759");
    protected static readonly Hardware patchHardware = (3, "", "587501817");

    protected static readonly NamedItem createHardwareLocation = (5, "Celestineberg");  // Hardware 1
    protected static readonly NamedItem updateHardwareLocation = (10, "Boehmside");   // Hardware 2
    protected static readonly NamedItem patchHardwareLocation = (4, "Mylenefurt");    // Hardware 3

    protected static readonly DateTime createDate = DateTime.Now.AddYears(5);
    protected static readonly DateTime updateDate = DateTime.Now.AddYears(6);
    protected static readonly DateTime patchDate = DateTime.Now.AddYears(7);

    protected static readonly float createCost = 11000.11f;
    protected static readonly float updateCost = 22000.22f;
    protected static readonly float patchCost = 33000.33f;

    protected const string defaultEula = "<h1>COMPANY-OWNED EQUIPMENT AGREEMENT</h1>\n<p>Use of all equipment, software, and data owned by The Company is limited to authorized persons for business purposes only.\nThe term equipment refers to all laptop computers, desktop computers, tablets, software, printers, blackberries, key fobs, cell phones and other tangible items provided by The Company.</p>\n<ul>\n<li>All equipment provided to employees in the offices of The Company is considered the property of The Company.</li>\n<li>All equipment purchased by The Company for an employee is considered the property of The Company.</li>\n<li>Any equipment purchased by an employee and then reimbursed through the expense procedure is considered the property of The Company.</li>\n<li>Software purchased by the employee for personal use and stored on equipment owned by The Company is considered the property of The Company. </li>\n<li>If upgrades are made to the equipment (e.g. cell phones, tablets, software, etc.), whether paid for by the employee or by The Company, the equipment remains the property of The Company.</li>\n<li>If upgrading to a newer device (e.g. cell phone), the old device is to be returned to The Company.</li>\n<li>All computer, electronic, and telephonic documents and communications transmitted by, received from, or stored in the employer's equipment are the property of the employer. Employees are not to transmit or store material on the employer’s equipment in violation of any state or federal law or government regulation.</li>\n<li>Employees who are provided with equipment owned by The Company have a responsibility to protect the equipment from being lost, damaged, or stolen. If the equipment is lost, damaged, or stolen because of the employee’s negligence or willful disregard, the employee will pay the employer the amount equal to the replacement value or repair cost of the equipment.</li>\n</ul>\n<p>Upon termination, it is the employee’s responsibility to return all equipment owned by The Company to The Company on or before the last day of employment.</p>";

}

public abstract class SnipeITBaseUnitTest<T> : SnipeITBaseUnitTest where T : BaseItem
{
    public required T create;
    public required T update;
    public required T patch;
    public bool checkDeleted = true;

    protected bool handleName = true;
    protected bool handleNotes = true;
    protected bool? userCanCheckout = null;
    protected AvailableActions? availableActions = null;

    [TestMethod]
    public async Task TestMethodWorkAsync()
    { 
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        int id = await CreateAsync(snipeIT, create);
        Trace.WriteLine($"Created {typeof(T).Name}: {id}");
        T? created = await GetAsync(snipeIT, id);

        //var list = await GetAsync(snipeIT).ToListAsync();
        //Assert.IsNotNull(list, "list");
        //var listItem = list.FirstOrDefault(d => d.Id == id);
        //Assert.IsNotNull(listItem, "listItem");

        await UpdateAsync(snipeIT, id, update);
        T? updated = await GetAsync(snipeIT, id);

        await PatchAsync(snipeIT, id, patch);
        T? patched = await GetAsync(snipeIT, id);

       // await DeleteAsync(snipeIT, id);

        //if (checkDeleted)
        //{
        //    await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await GetAsync(snipeIT, id));
        //}

        Assert.IsNotNull(created, "created");

        AreEqualIternal(id, create, created, "created");
        AreEqualIternal(id, update, updated, "updated");
        AreEqualIternal(id, patch, patched, "patched");
    }

    //[TestMethod]
    //public async Task TestMethodCreateDuplicateAsync()
    //{
    //    using var snipeIT = new SnipeIT(developStoreKey, appName);

    //    await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await CreateAsync(snipeIT, default));
    //}

    //[TestMethod]
    //public async Task TestMethodGetNotExistingAsync()
    //{
    //    using var snipeIT = new SnipeIT(developStoreKey, appName);

    //    await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await GetAsync(snipeIT, notExistingId));
    //}

    //[TestMethod]
    //public async Task TestMethodDeleteNotExistingasync()
    //{
    //    using var snipeIT = new SnipeIT(developStoreKey, appName);

    //    await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await DeleteAsync(snipeIT, notExistingId));
    //}

    public abstract IAsyncEnumerable<T> GetAsync(SnipeIT snipeIT);

    public abstract Task<T?> GetAsync(SnipeIT snipeIT, int id);

    public abstract Task<int> CreateAsync(SnipeIT snipeIT, T value);

    public abstract Task UpdateAsync(SnipeIT snipeIT, int id, T value);

    public abstract Task PatchAsync(SnipeIT snipeIT, int id, T value);

    public abstract Task DeleteAsync(SnipeIT snipeIT, int id);

    public abstract void AreEqual(T expected, T actual, string message);

    

    public void AreEqualIternal(int id, T expected, T? actual, string message)
    {
        Assert.IsNotNull(actual, $"{message}.actual");

        Assert.AreEqual(id, actual.Id, $"{message}.Id");
        Assert.AreEqual(handleName ? expected.Name : null, actual.Name, $"{message}.Name");
        //Assert.AreEqual(expected.Image, actual.Image, $"{message}.Image");
        Assert.AreEqual(handleNotes ? expected.Notes : null, actual.Notes, $"{message}.Notes");

        AreEqual(expected, actual, message);

        if (actual.CreatedBy != null)
        {
            Assert.AreEqual(adminUser, actual.CreatedBy, $"{message}.CreatedBy");
        }
        
        DateAssert.AreEqual(today, actual.CreatedAt, $"{message}.CreatedAt");
        DateAssert.AreEqual(today, actual.UpdatedAt, $"{message}.UpdatedAt");
        //DateAssert.AreEqual(null, actual.DeletedAt, $"{message}.DeletedAt");

        Assert.AreEqual(userCanCheckout, actual.UserCanCheckout, $"{message}.UserCanCheckout");

        if (availableActions != null || actual.AvailableActions != null)
        {
            Assert.IsNotNull(actual.AvailableActions, $"{message}.actual.AvailableActions");
            Assert.IsNotNull(availableActions, $"{message}.expected.AvailableActions");
            Assert.AreEqual(availableActions.Checkout, actual.AvailableActions.Checkout, $"{message}.AvailableActions.Checkout");
            Assert.AreEqual(availableActions.Checkin, actual.AvailableActions.Checkin, $"{message}.AvailableActions.Checkin");
            Assert.AreEqual(availableActions.Update, actual.AvailableActions.Update, $"{message}.AvailableActions.Update");
            Assert.AreEqual(availableActions.Restore, actual.AvailableActions.Restore, $"{message}.AvailableActions.Restore");
            Assert.AreEqual(availableActions.Delete, actual.AvailableActions.Delete, $"{message}.AvailableActions.Delete");
            Assert.AreEqual(availableActions.Clone, actual.AvailableActions.Clone, $"{message}.AvailableActions.Clone");
        }
    }

    protected T TestCreate
    {
        set
        {
            value.Name = value.Name ?? CreateName();
            value.Notes = value.Notes ?? createNotes;
            value.Image = createImage;
            create = value;
        }
    }

    protected T TestUpdate
    {
        set
        {
            value.Name = value.Name ?? CreateName();
            value.Notes = value.Notes ?? updateNotes;
            value.Image = updateImage;
            update = value;
        }
    }

    protected T TestPatch
    {
        set
        {
            value.Name = value.Name ?? CreateName();
            value.Notes = value.Notes ?? patchNotes;
            value.Image = patchImage;
            patch = value;
        }
    }

    public string CreateName() => Guid.NewGuid().ToString();
}
