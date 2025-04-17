namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITCompaniesUnitTest : SnipeITBaseUnitTest<Company>
{
    public SnipeITCompaniesUnitTest()
    {
        create = new Company()
        {
            // required
            Name = CreateName(),

            // optional

            // optional not documented
            Phone = phoneCreate,
            Fax = faxCreate,
            Email = emailCreate,

            // default
            Notes = createNotes,
            Image = createImage,

            // test
            AvailableActions = Actions.Update | Actions.Delete
        };

        update = new Company()
        {
            // required
            Name = CreateName(),

            // optional

            // optional not documented
            Phone = phoneUpdate,
            Fax = faxUpdate,
            Email = emailUpdate,

            // default
            Notes = updateNotes,
            Image = updateImage,

            // test
            AvailableActions = Actions.Update | Actions.Delete
        };

        patch = new Company()
        {
            // required
            Name = CreateName(),

            // optional

            // optional not documented
            Phone = phonePatch,
            Fax = faxPatch,
            Email = emailPatch,

            // default
            Notes = patchNotes,
            Image = patchImage,

            // test
            AvailableActions = Actions.Update | Actions.Delete
        };
    }

    public override void AreEqual(Company expected, Company actual, string message)
    {
        Assert.AreEqual(expected.Phone, actual.Phone, $"{message}.Phone");
        Assert.AreEqual(expected.Fax, actual.Fax, $"{message}.Fax");
        Assert.AreEqual(expected.Email, actual.Email, $"{message}.Email");
        Assert.AreEqual(expected.AssetsCount, actual.AssetsCount, $"{message}.AssetsCount");
        Assert.AreEqual(expected.LicenseCount, actual.LicenseCount, $"{message}.LicenseCount");
        Assert.AreEqual(expected.AccessoriesCount, actual.AccessoriesCount, $"{message}.AccessoriesCount");
        Assert.AreEqual(expected.ConsumablesCount, actual.ConsumablesCount, $"{message}.ConsumablesCount");
        Assert.AreEqual(expected.ComponentsCount, actual.ComponentsCount, $"{message}.ComponentsCount");
        Assert.AreEqual(expected.UsersCount, actual.UsersCount, $"{message}.UsersCount");
    }

    public override IAsyncEnumerable<Company> GetAsync(SnipeIT snipeIT)
        => snipeIT.GetCompaniesAsync();

    public override async Task<Company?> GetAsync(SnipeIT snipeIT, int id)
        => await snipeIT.GetCompanyAsync(id);

    public override async Task<int> CreateAsync(SnipeIT snipeIT, Company value)
        => await snipeIT.CreateCompanyAsync(value);

    public override async Task UpdateAsync(SnipeIT snipeIT, int id, Company value)
        => await snipeIT.UpdateCompanyAsync(id, value);

    public override async Task PatchAsync(SnipeIT snipeIT, int id, Company value)
        => await snipeIT.PatchCompanyAsync(id, value);

    public override async Task DeleteAsync(SnipeIT snipeIT, int id)
        => await snipeIT.DeleteCompanyAsync(id);
}
