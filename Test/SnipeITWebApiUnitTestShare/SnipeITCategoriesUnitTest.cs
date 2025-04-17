namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITCategoriesUnitTest : SnipeITBaseUnitTest<Category>
{
    public SnipeITCategoriesUnitTest()
    {
        create = new Category()
        {
            // required
            Name = CreateName(),
            CategoryType = CategoryType.Asset,

            // optional
            UseDefaultEula = true,
            RequireAcceptance = true,
            CheckinEmail = true,

            // default
            Notes = createNotes,
            Image = createImage,    

            // test
            HasEula = true,
            Eula = defaultEula,
            AvailableActions = Actions.Update | Actions.Delete,
        };

        update = new Category()
        {
            // required
            Name = CreateName(),
            //CategoryType = CategoryType.Asset,  // In contrast to the documentary not allowed

            // optional
            UseDefaultEula = false,
            RequireAcceptance = false,
            CheckinEmail = false,

            // default
            Notes = updateNotes,
            Image = updateImage,    

            // test
            CategoryType = CategoryType.Asset,
            HasEula = false,
            Eula = null,
            AvailableActions = Actions.Update | Actions.Delete,
        };

        patch = new Category()
        {
            // required
            Name = CreateName(),
            //CategoryType = CategoryType.Asset,   // In contrast to the documentary not allowed

            // optional
            UseDefaultEula = true,
            RequireAcceptance = true,
            CheckinEmail = true,

            // default
            Notes = patchNotes,
            Image = patchImage,  

            // test
            CategoryType = CategoryType.Asset,
            HasEula = true,
            Eula = defaultEula,
            AvailableActions = Actions.Update | Actions.Delete,
        };
    }

    public override void AreEqual(Category expected, Category actual, string message)
    {
        Assert.AreEqual(expected.CategoryType, actual.CategoryType, $"{message}.CategoryType");
        Assert.AreEqual(expected.HasEula, actual.HasEula, $"{message}.HasEula");
        Assert.AreEqual(expected.UseDefaultEula, actual.UseDefaultEula, $"{message}.UseDefaultEula");
        Assert.AreEqual(expected.Eula, actual.Eula, $"{message}.Eula");
        Assert.AreEqual(expected.CheckinEmail, actual.CheckinEmail, $"{message}.CheckinEmail");
        Assert.AreEqual(expected.RequireAcceptance, actual.RequireAcceptance, $"{message}.RequireAcceptance");
        Assert.AreEqual(expected.ItemCount, actual.ItemCount, $"{message}.ItemCount");
        Assert.AreEqual(expected.AssetsCount, actual.AssetsCount, $"{message}.AssetsCount");
        Assert.AreEqual(expected.AccessoriesCount, actual.AccessoriesCount, $"{message}.AccessoriesCount");
        Assert.AreEqual(expected.ConsumablesCount, actual.ConsumablesCount, $"{message}.ConsumablesCount");
        Assert.AreEqual(expected.LicensesCount, actual.LicensesCount, $"{message}.LicensesCount");
    }

    public override IAsyncEnumerable<Category> GetAsync(SnipeIT snipeIT)
            => snipeIT.GetCategoriesAsync();

    public override async Task<Category?> GetAsync(SnipeIT snipeIT, int id)
        => await snipeIT.GetCategoryAsync(id);

    public override async Task<int> CreateAsync(SnipeIT snipeIT, Category value)
        => await snipeIT.CreateCategoryAsync(value);

    public override async Task UpdateAsync(SnipeIT snipeIT, int id, Category value)
        => await snipeIT.UpdateCategoryAsync(id, value);

    public override async Task PatchAsync(SnipeIT snipeIT, int id, Category value)
        => await snipeIT.PatchCategoryAsync(id, value);

    public override async Task DeleteAsync(SnipeIT snipeIT, int id)
        => await snipeIT.DeleteCategoryAsync(id);
}
