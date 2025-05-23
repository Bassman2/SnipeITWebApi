﻿namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITFieldsetsUnitTest : SnipeITBaseUnitTest<Fieldset>
{
    public SnipeITFieldsetsUnitTest()
    {
        handleNotes = false;
        userCanCheckout = null;
        availableActions = null;

        TestCreate = new()
        {
            // test
        };

        TestUpdate = new()
        {
            // test
        };


        TestPatch = new()
        {
            // test
        };
    }


    public override void AreEqual(Fieldset expected, Fieldset actual, string message)
    {
        //Assert.AreEqual(expected.FieldsCount, actual.FieldsCount, $"{message}.FieldsCount");
        //Assert.AreEqual(expected.FieldsetItemsCount, actual.FieldsetItemsCount, $"{message}.FieldsetItemsCount");
        //Assert.AreEqual(expected.AssetFieldsetItemsCount, actual.AssetFieldsetItemsCount, $"{message}.AssetFieldsetItemsCount");
    }

    public override IAsyncEnumerable<Fieldset> GetAsync(SnipeIT snipeIT)
        => snipeIT.GetFieldsetsAsync();

    public override async Task<Fieldset?> GetAsync(SnipeIT snipeIT, int id)
        => await snipeIT.GetFieldsetAsync(id);

    public override async Task<int> CreateAsync(SnipeIT snipeIT, Fieldset value)
        => await snipeIT.CreateFieldsetAsync(value);

    public override async Task UpdateAsync(SnipeIT snipeIT, int id, Fieldset value)
        => await snipeIT.UpdateFieldsetAsync(id, value);

    public override async Task PatchAsync(SnipeIT snipeIT, int id, Fieldset value)
        => await snipeIT.PatchFieldsetAsync(id, value);

    public override async Task DeleteAsync(SnipeIT snipeIT, int id)
        => await snipeIT.DeleteFieldsetAsync(id);
}
