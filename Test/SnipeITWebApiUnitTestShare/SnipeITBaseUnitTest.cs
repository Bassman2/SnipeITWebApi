namespace SnipeITWebApiUnitTest;

public abstract class SnipeITBaseUnitTest
{
    protected const string internalStoreKey = "snipeit";
    protected const string developStoreKey = "develop-snipeit";

    protected const string appName = "UnitTest";

    protected const int notExistingId = 65000;

    protected const int companyId = 10;
    protected const string companyName = "Google, inc.";


    protected const int departmentId = 1;
    protected const string departmentName = "Human Resources";

    protected const int userId = 1;
    protected const string userName = "Account Demo";


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

}
