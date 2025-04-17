namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITModelsUnitTest : SnipeITBaseUnitTest<Model>
{
    public SnipeITModelsUnitTest()
    {
        userCanCheckout = true;
        availableActions = Actions.Delete | Actions.Update | Actions.Clone;


        create = new()
        {
            Category = (categoryId, categoryName),
            //Url = "https://test.com",
            //SupportUrl = "https://support.test.com",
            //WarrantyLookupUrl = "https://checkcoverage.test.com",
            //SupportPhone = "+12725858512",
            //SupportEmail = "unknown@microsoft.com",
        };

        update = new()
        {
            Category = (categoryId, categoryName),
            //Phone = updatePhone,
            //Fax = updateFax,
            //Email = emailUpdate,
        };

        patch = new()
        {
            Category = (categoryId, categoryName),
            //Phone = patchPhone,
            //Fax = patchFax,
            //Email = emailPatch,
        };
    }

    public override void AreEqual(Model expected, Model actual, string message)
    {
        Assert.AreEqual(expected.Manufacturer, actual.Manufacturer, $"{message}.Manufacturer");
        Assert.AreEqual(expected.MinAmt, actual.MinAmt, $"{message}.MinAmt");
        //Assert.AreEqual(expected.Remaining, actual.Remaining, $"{message}.Remaining");
        Assert.AreEqual(expected.Depreciation, actual.Depreciation, $"{message}.Depreciation");
        //Assert.AreEqual(expected.AssetsCount, actual.AssetsCount, $"{message}.AssetsCount");
        Assert.AreEqual(expected.Category, actual.Category, $"{message}.Category");
        Assert.AreEqual(expected.Fieldset, actual.Fieldset, $"{message}.Fieldset");
        //Assert.AreEqual(expected.Eol, actual.Eol, $"{message}.Eol");
        Assert.AreEqual(expected.Requestable ?? false, actual.Requestable ?? false, $"{message}.Requestable");

        //Assert.AreEqual(new NamedItem(2, "Microsoft"), item.Manufacturer, "item.Manufacturer");
        //Assert.AreEqual("https://develop.snipeitapp.com/uploads/models/surface.jpg", item.Image, "item.Image");
        //Assert.AreEqual(null, item.MinAmt, "item.MinAmt");
        //Assert.IsTrue(item.Remaining >= 50, "item.Remaining");
        //Assert.AreEqual(new NamedItem(1, "Computer Depreciation"), item.Depreciation, "item.Depreciation");
        //Assert.IsTrue(item.AssetsCount >= 50, "item.AssetsCount");
        //Assert.AreEqual(new NamedItem(1, "Laptops"), item.Category, "item.Category");
        //Assert.AreEqual(new NamedItem(2, "Laptops and Desktops"), item.Fieldset, "item.Fieldset");
        //Assert.AreEqual("36 months", item.Eol, "item.Eol");
        //Assert.AreEqual(false, item.Requestable, "item.Requestable");
        //Assert.AreEqual("Created by demo seeder", item.Notes, "item.Notes");
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
