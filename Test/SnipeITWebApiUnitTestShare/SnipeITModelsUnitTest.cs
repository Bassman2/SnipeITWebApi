using System.Xml.Linq;

namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITModelsUnitTest : SnipeITBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetModelsAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetModelsAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(i => i.Id == modelId);
        Assert.IsNotNull(item);
        Assert.AreEqual(modelId, item.Id, "item.Id");
        Assert.AreEqual(modelName, item.Name, "item.Name");
        Assert.AreEqual(new NamedItem(2, "Microsoft"), item.Manufacturer, "item.Manufacturer");
        Assert.AreEqual("https://develop.snipeitapp.com/uploads/models/surface.jpg", item.Image, "item.Image");
        Assert.AreEqual(null, item.MinAmt, "item.MinAmt");
        Assert.AreEqual(50, item.Remaining, "item.Remaining");
        Assert.AreEqual(new NamedItem(1, "Computer Depreciation"), item.Depreciation, "item.Depreciation");
        Assert.AreEqual(50, item.AssetsCount, "item.AssetsCount");
        Assert.AreEqual(new NamedItem(1, "Laptops"), item.Category, "item.Category");
        Assert.AreEqual(new NamedItem(2, "Laptops and Desktops"), item.Fieldset, "item.Fieldset");
        Assert.AreEqual("36 months", item.Eol, "item.Eol");
        Assert.AreEqual(false, item.Requestable, "item.Requestable");
        Assert.AreEqual("Created by demo seeder", item.Notes, "item.Notes");
        Assert.AreEqual(adminUser, item.CreatedBy, "item.CreatedBy");
        DateTimeAssert.AreEqual(lastUpdate, item.CreatedAt, "item.CreatedAt");
        DateTimeAssert.AreEqual(lastUpdate, item.UpdatedAt, "item.UpdatedAt");
        Assert.IsNotNull(item.AvailableActions, "item.AvailableActions");
        Assert.IsTrue(item.AvailableActions.Update, "item.AvailableActions.Update");
        Assert.IsFalse(item.AvailableActions.Delete, "item.AvailableActions.Delete");
    }

    [TestMethod]
    public async Task TestMethodGetModelAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetModelAsync(modelId);

        Assert.IsNotNull(item);
        Assert.AreEqual(modelId, item.Id, "item.Id");
        Assert.AreEqual(modelName, item.Name, "item.Name");
        Assert.AreEqual(new NamedItem(2, "Microsoft"), item.Manufacturer, "item.Manufacturer");
        Assert.AreEqual("https://develop.snipeitapp.com/uploads/models/surface.jpg", item.Image, "item.Image");
        Assert.AreEqual(null, item.MinAmt, "item.MinAmt");
        Assert.AreEqual(50, item.Remaining, "item.Remaining");
        Assert.AreEqual(new NamedItem(1, "Computer Depreciation"), item.Depreciation, "item.Depreciation");
        Assert.AreEqual(50, item.AssetsCount, "item.AssetsCount");
        Assert.AreEqual(new NamedItem(1, "Laptops"), item.Category, "item.Category");
        Assert.AreEqual(new NamedItem(2, "Laptops and Desktops"), item.Fieldset, "item.Fieldset");
        Assert.AreEqual("36 months", item.Eol, "item.Eol");
        Assert.AreEqual(false, item.Requestable, "item.Requestable");
        Assert.AreEqual("Created by demo seeder", item.Notes, "item.Notes");
        Assert.AreEqual(adminUser, item.CreatedBy, "item.CreatedBy");
        DateTimeAssert.AreEqual(lastUpdate, item.CreatedAt, "item.CreatedAt");
        DateTimeAssert.AreEqual(lastUpdate, item.UpdatedAt, "item.UpdatedAt");
        Assert.IsNotNull(item.AvailableActions, "item.AvailableActions");
        Assert.IsTrue(item.AvailableActions.Update, "item.AvailableActions.Update");
        Assert.IsFalse(item.AvailableActions.Delete, "item.AvailableActions.Delete");
    }

    [TestMethod]
    public async Task TestMethodCreateModelAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        string createName = Guid.NewGuid().ToString();
        string updateName = Guid.NewGuid().ToString();
        string patchName = Guid.NewGuid().ToString();

        var create = await snipeIT.CreateModelAsync(new Model()
        {
            Name = createName,
            Category = categoryId,
            //Url = "https://test.com",
            //Image = "https://develop.snipeitapp.com/uploads/manufacturers/apple.jpg",        // https://raw.githubusercontent.com/Bassman2/SnipeITWebApi/master/.github/images/donate.gif
            //SupportUrl = "https://support.test.com",
            //WarrantyLookupUrl = "https://checkcoverage.test.com",
            //SupportPhone = "+12725858512",
            //SupportEmail = "unknown@microsoft.com",
            //Notes = "Dummy Note"
        });
        Assert.IsNotNull(create);
        Assert.IsTrue(create.Id > 0, "create.Id");
        int id = create.Id;

        var update = await snipeIT.UpdateModelAsync(id, new()
        {
            Name = updateName,
            Category = categoryId,
            //Phone = phoneUpdate,
            //Fax = faxUpdate,
            //Email = emailUpdate,
            ////Image = imageUpdate,
            Notes = notesUpdate,

        });
        Assert.IsNotNull(update);

        var patch = await snipeIT.PatchModelAsync(id, new()
        {
            Name = patchName,
            Category = categoryId,
            //Phone = phonePatch,
            //Fax = faxPatch,
            //Email = emailPatch,
            //Image = imagePatch,
            Notes = notesPatch,

        });
        Assert.IsNotNull(patch);

        await snipeIT.DeleteModelAsync(id);

        var del = await snipeIT.GetModelAsync(id);
        
        Assert.AreEqual(id, create.Id, "create.id");
        Assert.AreEqual(createName, create.Name, "create.Name");
        //Assert.AreEqual(new NamedItem(2, ""), create.Manufacturer, "create.Manufacturer");
        Assert.AreEqual(null, create.Image, "create.Image");

        Assert.AreEqual(id, update.Id, "update.id");
        Assert.AreEqual(updateName, update.Name, "update.Name");
        //Assert.AreEqual(new NamedItem(2, ""), update.Manufacturer, "update.Manufacturer");
        Assert.AreEqual(null, update.Image, "update.Image");

        Assert.AreEqual(id, patch.Id, "patch.id");
        Assert.AreEqual(patchName, patch.Name, "patch.Name");
        //Assert.AreEqual(new NamedItem(2, ""), patch.Manufacturer, "patch.Manufacturer");
        Assert.AreEqual(null, patch.Image, "patch.Image");
    }

    [TestMethod]
    public async Task TestMethodCreateDuplicateModelAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.CreateModelAsync(new () { Name = modelName, Category = categoryId }));
    }

    [TestMethod]
    public async Task TestMethodGetNotExistingModelAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetModelAsync(notExistingId));
    }

    [TestMethod]
    public async Task TestMethodDeleteNotExistingModelAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.DeleteModelAsync(notExistingId));
    }
}
