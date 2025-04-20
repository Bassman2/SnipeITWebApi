namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITFieldsUnitTest : SnipeITBaseUnitTest<Field>
{
    public SnipeITFieldsUnitTest()
    {
        handleNotes = false;
        userCanCheckout = null;
        availableActions = null; // Actions.Update | Actions.Delete | Actions.Checkout | Actions.Checkin;

        TestCreate = new()
        {
            Element = Elements.text,

            // test
            Type = "text",
            Required = false,
            //Phone = createPhone,
            //Fax = createFax,
            //Email = emailCreate,
            ////Image = imageCreate,    
            //Notes = createNotes,
        };

        TestUpdate = new()
        {
            // test
            Type = "text",
            Required = false,
            //Phone = updatePhone,
            //Fax = updateFax,
            //Email = emailUpdate,
            ////Image = imageUpdate,
            //Notes = updateNotes,
        };

        TestPatch = new()
        {
            // test
            Type = "text",
            Required = false,
            //Phone = patchPhone,
            //Fax = patchFax,
            //Email = emailPatch,
            ////Image = imagePatch,
            //Notes = patchNotes,
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
