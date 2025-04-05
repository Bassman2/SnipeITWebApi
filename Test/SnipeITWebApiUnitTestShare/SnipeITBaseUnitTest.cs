namespace SnipeITWebApiUnitTest;

public abstract class SnipeITBaseUnitTest
{
    protected const string internalStoreKey = "snipeit";
    protected const string developStoreKey = "develop-snipeit";

    protected const string appName = "UnitTest";

    protected const string lastUpdate = "2025-04-03";


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

    protected const string notes = "Created by DB seeder";
    protected static readonly NamedItem adminUser = new(1, "Admin User");

    protected const string adminAvatar = "https://develop.snipeitapp.com/uploads/avatars/1.jpg";
    protected const string adminAddress = "87374 Cummings Centers\nNorth Camron, AZ 89719-4068";
    protected const string adminCity = "East Hectorfurt";
    protected const string adminState = "MN";
    protected const string adminCountry = "Saint Pierre and Miquelon";
    protected const string adminZip = "04529-0110";
    protected const string adminEmail = "herzog.earl@example.org";
}
