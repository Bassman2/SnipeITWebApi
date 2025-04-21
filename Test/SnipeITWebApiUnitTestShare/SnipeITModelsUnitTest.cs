namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITModelsUnitTest : SnipeITBaseUnitTest<Model>
{
    public SnipeITModelsUnitTest()
    {
        userCanCheckout = null;
        availableActions = Actions.Delete | Actions.Update | Actions.Clone;

        TestCreate = new()
        {
            // required
            Category = createAssetCategory,

            // optional
            ModelNumber = createModelNumber,
            Manufacturer = createManufacturer,
            Eol = 9,
            Fieldset = createFieldset,

            // test
            Remaining = false,
            AssetsCount = 0,
            Requestable = false,
        };

        TestUpdate = new()
        {
            // required
            Category = updateAssetCategory,

            // optional
            ModelNumber = updateModelNumber,
            Manufacturer = updateManufacturer,
            Eol = 9,
            Fieldset = updateFieldset,
            Depreciation = null,

            // test
            Remaining = false,
            AssetsCount = 0,
            Requestable = false,
        };

        TestPatch = new()
        {
            // optional
            Category = patchAssetCategory,
            ModelNumber = patchModelNumber,
            Manufacturer = patchManufacturer,
            Eol = 9,
            Fieldset = patchFieldset,
            Depreciation = null,

            // test
            Remaining = false,
            AssetsCount = 0,
            Requestable = false,
        };
    }

    public override void AreEqual(Model expected, Model actual, string message)
    {
        Assert.AreEqual(expected.Manufacturer, actual.Manufacturer, $"{message}.Manufacturer");
        Assert.AreEqual(expected.ModelNumber, actual.ModelNumber, $"{message}.ModelNumber");
        Assert.AreEqual(expected.MinAmt, actual.MinAmt, $"{message}.MinAmt");
        Assert.AreEqual(expected.Remaining, actual.Remaining, $"{message}.Remaining");
        Assert.AreEqual(expected.Depreciation, actual.Depreciation, $"{message}.Depreciation");
        Assert.AreEqual(expected.AssetsCount, actual.AssetsCount, $"{message}.AssetsCount");
        Assert.AreEqual(expected.Category, actual.Category, $"{message}.Category");
        Assert.AreEqual(expected.Fieldset, actual.Fieldset, $"{message}.Fieldset");
        //Assert.AreEqual(expected.DefaultFieldsetValues, actual.DefaultFieldsetValues, $"{message}.DefaultFieldsetValues");
        Assert.AreEqual(expected.Eol, actual.Eol, $"{message}.Eol");
        Assert.AreEqual(expected.Requestable, actual.Requestable, $"{message}.Requestable");
    }

    public override IAsyncEnumerable<Model> GetAsync(SnipeIT snipeIT)
        => snipeIT.GetModelsAsync();

    public override async Task<Model?> GetAsync(SnipeIT snipeIT, int id)
        => await snipeIT.GetModelAsync(id);

    public override async Task<int> CreateAsync(SnipeIT snipeIT, Model value)
        => await snipeIT.CreateModelAsync(value);

    public override async Task UpdateAsync(SnipeIT snipeIT, int id, Model value)
        => await snipeIT.UpdateModelAsync(id, value);

    public override async Task PatchAsync(SnipeIT snipeIT, int id, Model value)
        => await snipeIT.PatchModelAsync(id, value);

    public override async Task DeleteAsync(SnipeIT snipeIT, int id)
        => await snipeIT.DeleteModelAsync(id);
}
