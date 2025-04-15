using System.Diagnostics;

namespace SnipeITWebApiUnitTest;

public abstract class SnipeITBaseUnitTest
{
    protected const string internalStoreKey = "snipeit";
    protected const string developStoreKey = "develop-snipeit";

    protected const string appName = "UnitTest";

    protected const string lastUpdate = "2025-04-03";
    protected readonly string today = DateTime.Now.ToString("yyyy-MM-dd");


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


    protected const string phoneCreate = "+11114711";
    protected const string phoneUpdate = "+11114712";
    protected const string phonePatch = "+11114713";

    protected const string faxCreate = "+11114811";
    protected const string faxUpdate = "+11114812";
    protected const string faxPatch = "+11114813";

    protected const string emailCreate = "Peter.A@unknown.com";
    protected const string emailUpdate = "Peter.B@unknown.com";
    protected const string emailPatch = "Peter.C@unknown.com";

    protected const string imageCreate = @"D:\_Data\SnipeIT\Test\ImageA.png";
    protected const string imageUpdate = @"D:\_Data\SnipeIT\Test\ImageB.png";
    protected const string imagePatch =  @"D:\_Data\SnipeIT\Test\ImageC.png";

    protected const string notesCreate = "Note Create";
    protected const string notesUpdate = "Note Update";
    protected const string notesPatch = "Note Patch";

    protected const string firstNameCreate = "Peter";
    protected const string firstNameUpdate = "Paul";
    protected const string firstNamePatch = "Mary";

    protected const string lastNameCreate = "Miller";
    protected const string lastNameUpdate = "Butcher";
    protected const string lastNamePatch = "Dougle";

    protected const string usernameCreate = "un0001";
    protected const string usernameUpdate = "un0002";
    protected const string usernamePatch = "un0003";

    protected const string passwordCreate = "|Mnx7=4-@vd:";
    protected const string passwordUpdate = "5~g=?=m7JPDg";
    protected const string passwordPatch = "py4Nx/r$!,zQ";

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

    protected static readonly NamedItem createAccessoryCategory = (8, "Keyboards");
    protected static readonly NamedItem updateAccessoryCategory = (9, "Mouse");
    protected static readonly NamedItem patchAccessoryCategory = (8, "Keyboards");
}

public abstract class SnipeITBaseUnitTest<T> : SnipeITBaseUnitTest where T : class
{
    public abstract IAsyncEnumerable<T> GetAsync(SnipeIT snipeIT);

    public abstract Task<T?> GetAsync(SnipeIT snipeIT, int id);

    public abstract Task<int> CreateAsync(SnipeIT snipeIT, T value);

    public abstract Task UpdateAsync(SnipeIT snipeIT, int id, T value);

    public abstract Task PatchAsync(SnipeIT snipeIT, int id, T value);

    public abstract Task DeleteAsync(SnipeIT snipeIT, int id);

    public abstract void AreEqual(int id, T expected, T? actual, string message);

    public async Task TestMethodAllAsync(T create, T update, T patch, bool checkDeleted = true)
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        int id = await CreateAsync(snipeIT, create);
        Trace.WriteLine($"Created {typeof(T).Name}: {id}");
        T? created = await GetAsync(snipeIT, id);

        var asyncList = await snipeIT.GetAccessoriesAsync().ToListAsync();
        Assert.IsNotNull(asyncList, "asyncList");
        var asyncListItem = asyncList.FirstOrDefault(d => d.Id == id);
        Assert.IsNotNull(asyncListItem, "asyncListItem");

        await UpdateAsync(snipeIT, id, update);
        T? updated = await GetAsync(snipeIT, id);

        await PatchAsync(snipeIT, id, patch);
        T? patched = await GetAsync(snipeIT, id);

        await DeleteAsync(snipeIT, id);

        if (checkDeleted)
        {
            await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await GetAsync(snipeIT, id));
        }

        Assert.IsNotNull(created, "created");

        AreEqual(id, create, created, "created");
        AreEqual(id, update, updated, "updated");
        AreEqual(id, patch, patched, "patched");
    }

    public string CreateName() => Guid.NewGuid().ToString();
}
