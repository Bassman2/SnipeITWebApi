namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITFieldsUnitTest : SnipeITBaseUnitTest<Field>
{
    public SnipeITFieldsUnitTest()
    {
        create = new()
        {
            Name = CreateName(),
            //Phone = phoneCreate,
            //Fax = faxCreate,
            //Email = emailCreate,
            ////Image = imageCreate,    
            //Notes = notesCreate,
        };

        update = new()
        {
            Name = CreateName(),
            //Phone = phoneUpdate,
            //Fax = faxUpdate,
            //Email = emailUpdate,
            ////Image = imageUpdate,
            //Notes = notesUpdate,
        };

        patch = new()
        {
            Name = CreateName(),
            //Phone = phonePatch,
            //Fax = faxPatch,
            //Email = emailPatch,
            ////Image = imagePatch,
            //Notes = notesPatch,
        };
    }

    public override void AreEqual(Field expected, Field actual, string message)
    {
        Assert.AreEqual(expected.Type, actual.Type, $"{message}.Type");
        Assert.AreEqual(expected.Required, actual.Required, $"{message}.Required");
        //Assert.AreEqual(expected.DefaultValue, actual.DefaultValue, $"{message}.DefaultValue");
    }

    public override IAsyncEnumerable<Field> GetAsync(SnipeIT snipeIT)
        => snipeIT.GetFieldsAsync();

    public override async Task<Field?> GetAsync(SnipeIT snipeIT, int id)
        => await snipeIT.GetFieldAsync(id);

    public override async Task<int> CreateAsync(SnipeIT snipeIT, Field value)
        => await snipeIT.CreateFieldAsync(value);

    public override async Task UpdateAsync(SnipeIT snipeIT, int id, Field value)
        => await snipeIT.UpdateFieldAsync(id, value);

    public override async Task PatchAsync(SnipeIT snipeIT, int id, Field value)
        => await snipeIT.PatchFieldAsync(id, value);

    public override async Task DeleteAsync(SnipeIT snipeIT, int id)
        => await snipeIT.DeleteFieldAsync(id);
}
