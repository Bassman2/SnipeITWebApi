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


    protected const string phoneCreate = "+11114711";
    protected const string phoneUpdate = "+11114712";
    protected const string phonePatch = "+11114713";

    protected const string faxCreate = "+11114811";
    protected const string faxUpdate = "+11114812";
    protected const string faxPatch = "+11114813";

    protected const string notesCreate = "Note Create";
    protected const string notesUpdate = "Note Update";
    protected const string notesPatch = "Note Patch";
}
