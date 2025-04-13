namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITCategoriesUnitTest : SnipeITBaseUnitTest<Category>
{

    [TestMethod]
    public async Task TestMethodGetCategoriesAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetCategoriesAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(i => i.Id == categoryId);
        Assert.IsNotNull(item);
        Assert.AreEqual(categoryId, item.Id, "item.Id");
        Assert.AreEqual(categoryName, item.Name, "item.Name");


    }

    [TestMethod]
    public async Task TestMethodGetCategoryAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetCategoryAsync(categoryId);

        Assert.IsNotNull(item);
        Assert.AreEqual(categoryId, item.Id, "item.Id");
        Assert.AreEqual(categoryName, item.Name, "item.Name");
    }

    //[TestMethod]
    //public async Task TestMethodCreateCategoryAsync()
    //{
    //    using var snipeIT = new SnipeIT(developStoreKey, appName);

    //    string createName = Guid.NewGuid().ToString();
    //    string updateName = Guid.NewGuid().ToString();
    //    string patchName = Guid.NewGuid().ToString();

    //    var create = await snipeIT.CreateCategoryAsync(new()
    //    {
    //        Name = createName,
    //        CategoryType = CategoryType.Asset,
    //        //Image = imageCreate,    
    //        Notes = notesCreate,
    //    });
    //    Assert.IsNotNull(create);
    //    Assert.IsTrue(create.Id > 0, "create.Id");
    //    int id = create.Id;

    //    var update = await snipeIT.UpdateCategoryAsync(id, new()
    //    {
    //        Name = updateName,
    //        //Image = imageUpdate,
    //        Notes = notesUpdate,

    //    });
    //    Assert.IsNotNull(update);

    //    var patch = await snipeIT.PatchCategoryAsync(id, new()
    //    {
    //        Name = patchName,
    //        //Image = imagePatch,
    //        Notes = notesPatch,

    //    });
    //    Assert.IsNotNull(patch);

    //    var del = await snipeIT.DeleteCategoryAsync(id);

    //    await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetCategoryAsync(id));

    //    Assert.AreEqual(id, create.Id, "create.Id");
    //    Assert.AreEqual(createName, create.Name, "create.Name");
    //    Assert.AreEqual(CategoryType.Asset, create.CategoryType, "create.CategoryType");
    //    //Assert.AreEqual(imageCreate, create.Image, "create.Image");
    //    Assert.AreEqual(notesCreate, create.Notes, "create.Notes");

    //    Assert.AreEqual(id, update.Id, "update.Id");
    //    Assert.AreEqual(updateName, update.Name, "update.Name");
    //    //Assert.AreEqual(CategoryType.Accessory, update.CategoryType, "update.CategoryType");
    //    //Assert.AreEqual(imageUpdate, update.Image, "update.Image");
    //    Assert.AreEqual(notesUpdate, update.Notes, "update.Notes");

    //    Assert.AreEqual(id, patch.Id, "patch.Id");
    //    Assert.AreEqual(patchName, patch.Name, "patch.Name");
    //    //Assert.AreEqual(CategoryType.Component, patch.CategoryType, "patch.CategoryType");
    //    //Assert.AreEqual(imagePatch, patch.Image, "patch.Image");
    //    Assert.AreEqual(notesPatch, patch.Notes, "patch.Notes");
    //}

    [TestMethod]
    public async Task TestMethodCreateUpdateDeleteCategoryAsync()
    {
        var create = new Category()
        {
            Name = CreateName(),
            CategoryType = CategoryType.Asset,
            //Image = imageCreate,    
            Notes = notesCreate,
        };

        var update = new Category()
        {
            Name = CreateName(),
            //Image = imageUpdate,
            Notes = notesUpdate,

        };

        var patch = new Category()
        {
            Name = CreateName(),
            //Image = imageUpdate,
            Notes = notesUpdate,

        };

        await TestMethodAllAsync(create, update, patch);
    }

    [TestMethod]
    public async Task TestMethodCreateDuplicateCategoryAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.CreateCategoryAsync(new () { Name = categoryName, CategoryType = CategoryType.Asset }));
    }

    [TestMethod]
    public async Task TestMethodGetNotExistingCategoryAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetCategoryAsync(notExistingId));
    }

    [TestMethod]
    public async Task TestMethodDeleteNotExistingCompanyAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.DeleteCompanyAsync(notExistingId));
    }

    public override void AreEqual(int id, Category expected, Category? actual, string message)
    {
        Assert.IsNotNull(actual, $"{message}.actual");

        Assert.AreEqual(id, actual.Id, $"{message}.Id");
        Assert.AreEqual(expected.Name, actual.Name, $"{message}.Name");
        Assert.AreEqual(expected.Image, actual.Image, $"{message}.Image");
        //Assert.AreEqual(expected.Company, actual.Company, $"{message}.Company");
        //Assert.AreEqual(expected.Manufacturer, actual.Manufacturer, $"{message}.Manufacturer");
        //Assert.AreEqual(expected.Supplier, actual.Supplier, $"{message}.Supplier");
        //Assert.AreEqual(expected.ModelNumber, actual.ModelNumber, $"{message}.ModelNumber");
        //Assert.AreEqual(expected.Category, actual.Category, $"{message}.Category");
        //Assert.AreEqual(expected.Location, actual.Location, $"{message}.Location");
        //Assert.AreEqual(expected.Notes, actual.Notes, $"{message}.Notes");
        //Assert.AreEqual(expected.Qty, actual.Qty, $"{message}.Qty");
        //DateAssert.AreEqual(expected.PurchaseDate, actual.PurchaseDate, $"{message}.PurchaseDate");
        //Assert.AreEqual(expected.PurchaseCost, actual.PurchaseCost, $"{message}.PurchaseCost");
        //Assert.AreEqual(expected.OrderNumber, actual.OrderNumber, $"{message}.OrderNumber");
        //Assert.AreEqual(expected.MinQty, actual.MinQty, $"{message}.MinQty");
        //Assert.AreEqual(expected.MinAmt, actual.MinAmt, $"{message}.MinAmt");
        //Assert.AreEqual(expected.RemainingQty, actual.RemainingQty, $"{message}.RemainingQty");
        //Assert.AreEqual(expected.Remaining, actual.Remaining, $"{message}.Remaining");
        //RangeAssert.IsInRange(0, 9, actual.CheckoutsCount, $"{message}.CheckoutsCount");

        Assert.AreEqual(null, actual.CreatedBy, $"{message}.CreatedBy");
        DateAssert.AreEqual(today, actual.CreatedAt, $"{message}.CreatedAt");
        DateAssert.AreEqual(today, actual.UpdatedAt, $"{message}.UpdatedAt");

        Assert.IsNotNull(actual.AvailableActions, $"{message}.AvailableActions");
        Assert.IsFalse(actual.AvailableActions.Checkout, $"{message}.AvailableActions.Checkout");
        Assert.IsFalse(actual.AvailableActions.Checkin, $"{message}.AvailableActions.Checkin");
        Assert.IsTrue(actual.AvailableActions.Update, $"{message}.AvailableActions.Update");
        Assert.IsTrue(actual.AvailableActions.Delete, $"{message}.AvailableActions.Delete");
        Assert.IsFalse(actual.AvailableActions.Clone, $"{message}.AvailableActions.Clone");
    }

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
