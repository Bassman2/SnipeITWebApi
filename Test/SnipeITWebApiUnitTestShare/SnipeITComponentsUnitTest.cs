using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data.Common;
using System;

namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITComponentsUnitTest : SnipeITBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetComponentsAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetComponentsAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == componentId);
        Assert.IsNotNull(item);
        Assert.AreEqual(componentId, item.Id, "item.Id");
        Assert.AreEqual(componentName, item.Name, "item.Name");
        Assert.AreEqual(null, item.Image, "item.Image");
        Assert.AreEqual("9a659795-2c29-31a8-a066-60da4cf28b53", item.Serial, "item.Serial");
        Assert.AreEqual(new NamedItem(3, "Jarrellport"), item.Location, "item.Location");
        Assert.AreEqual(10, item.Qty, "item.Qty");
        Assert.AreEqual(2, item.MinAmt, "item.MinAmt");
        Assert.AreEqual(new NamedItem(13, "RAM"), item.Category, "item.Category");
        Assert.AreEqual(new NamedItem(6, "Schulist-Daugherty"), item.Supplier, "item.Supplier");
        Assert.AreEqual(new NamedItem(11, "Crucial"), item.Manufacturer, "item.Manufacturer");
        Assert.AreEqual("11525744", item.ModelNumber, "item.ModelNumber");
        Assert.AreEqual("49148111", item.OrderNumber, "item.OrderNumber");
        DateTimeAssert.AreEqual(null, item.PurchaseDate, "item.PurchaseDate");
        Assert.AreEqual("2,40", item.PurchaseCost, "item.PurchaseCost");
        Assert.AreEqual(9, item.Remaining, "item.Remaining");
        Assert.AreEqual(new NamedItem(1, "Quigley-Luettgen"), item.Company, "item.Company");
        Assert.AreEqual(null, item.Notes, "item.Notes");
        Assert.AreEqual(null, item.CreatedBy, "item.CreatedBy");
        DateTimeAssert.AreEqual(lastUpdate, item.CreatedAt, "item.CreatedAt");
        DateTimeAssert.AreEqual(lastUpdate, item.UpdatedAt, "item.UpdatedAt");
        Assert.AreEqual(1, item.UserCanCheckout, "item.UserCanCheckout");
        Assert.IsNotNull(item.AvailableActions, "item.AvailableActions");
        Assert.IsTrue(item.AvailableActions.Checkout, "item.AvailableActions.Checkout");
        Assert.IsTrue(item.AvailableActions.Checkin, "item.AvailableActions.Checkin");
        Assert.IsTrue(item.AvailableActions.Update, "item.AvailableActions.Update");
        Assert.IsFalse(item.AvailableActions.Delete, "item.AvailableActions.Delete");
    }

    [TestMethod]
    public async Task TestMethodGetComponentsQueryAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        int numAll = await snipeIT.GetComponentsAsync(CancellationToken.None).CountAsync();

        int numName = await snipeIT.GetComponentsAsync(name: "Crucial 4GB DDR3L-1600 SODIMM").CountAsync();

        int numSearch = await snipeIT.GetComponentsAsync(search: "Laptops").CountAsync();

        int numOrderNumber = await snipeIT.GetComponentsAsync(orderNumber: "30959123").CountAsync();
        
        RangeAssert.IsInRange(1, 9, numAll, "numAll");
        RangeAssert.IsInRange(1, 9, numName, "numName");
        RangeAssert.IsInRange(0, 9, numSearch, "numSearch");
        RangeAssert.IsInRange(1, 9, numOrderNumber, "numOrderNumber");
    }

    [TestMethod]
    public async Task TestMethodGetComponentAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetComponentAsync(componentId);
        
        Assert.IsNotNull(item);
        Assert.AreEqual(componentId, item.Id, "item.Id");
        Assert.AreEqual(componentName, item.Name, "item.Name");
        Assert.AreEqual(null, item.Image, "item.Image");
        Assert.AreEqual("9a659795-2c29-31a8-a066-60da4cf28b53", item.Serial, "item.Serial");
        Assert.AreEqual(new NamedItem(3, "Jarrellport"), item.Location, "item.Location");
        Assert.AreEqual(10, item.Qty, "item.Qty");
        Assert.AreEqual(2, item.MinAmt, "item.MinAmt");
        Assert.AreEqual(new NamedItem(13, "RAM"), item.Category, "item.Category");
        Assert.AreEqual(new NamedItem(6, "Schulist-Daugherty"), item.Supplier, "item.Supplier");
        Assert.AreEqual(new NamedItem(11, "Crucial"), item.Manufacturer, "item.Manufacturer");
        Assert.AreEqual("11525744", item.ModelNumber, "item.ModelNumber");
        Assert.AreEqual("49148111", item.OrderNumber, "item.OrderNumber");
        DateTimeAssert.AreEqual(null, item.PurchaseDate, "item.PurchaseDate");
        Assert.AreEqual("2,40", item.PurchaseCost, "item.PurchaseCost");
        Assert.AreEqual(9, item.Remaining, "item.Remaining");
        Assert.AreEqual(new NamedItem(1, "Quigley-Luettgen"), item.Company, "item.Company");
        Assert.AreEqual(null, item.Notes, "item.Notes");
        Assert.AreEqual(null, item.CreatedBy, "item.CreatedBy");
        DateTimeAssert.AreEqual(lastUpdate, item.CreatedAt, "item.CreatedAt");
        DateTimeAssert.AreEqual(lastUpdate, item.UpdatedAt, "item.UpdatedAt");
        Assert.AreEqual(1, item.UserCanCheckout, "item.UserCanCheckout");
        Assert.IsNotNull(item.AvailableActions, "item.AvailableActions");
        Assert.IsTrue(item.AvailableActions.Checkout, "item.AvailableActions.Checkout");
        Assert.IsTrue(item.AvailableActions.Checkin, "item.AvailableActions.Checkin");
        Assert.IsTrue(item.AvailableActions.Update, "item.AvailableActions.Update");
        Assert.IsFalse(item.AvailableActions.Delete, "item.AvailableActions.Delete");
    }

    [TestMethod]
    public async Task TestMethodCreateComponentAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        string createName = Guid.NewGuid().ToString();
        string updateName = Guid.NewGuid().ToString();
        string patchName = Guid.NewGuid().ToString();

        var create = await snipeIT.CreateComponentAsync(new()
        {
            Name = createName,
            Qty = 5,
            Category = categoryId,
            
            //Notes = notesCreate,
        });
        Assert.IsNotNull(create);
        Assert.IsTrue(create.Id > 0, "create.Id");
        int id = create.Id;

        var update = await snipeIT.UpdateComponentAsync(id, new()
        {
            Name = updateName,
            //Image = imageUpdate,
            //Notes = notesUpdate,

        });
        Assert.IsNotNull(update);

        var patch = await snipeIT.PatchComponentAsync(id, new()
        {
            Name = patchName,
            //Image = imagePatch,
            //Notes = notesPatch,

        });
        Assert.IsNotNull(patch);

        var del = await snipeIT.DeleteComponentAsync(id);

        Assert.AreEqual(id, create.Id, "create.Id");
        Assert.AreEqual(createName, create.Name, "create.Name");
        //Assert.AreEqual(imageCreate, create.Image, "create.Image");
        //Assert.AreEqual(notesCreate, create.Notes, "create.Notes");

        Assert.AreEqual(id, update.Id, "update.Id");
        Assert.AreEqual(updateName, update.Name, "update.Name");
        //Assert.AreEqual(imageUpdate, update.Image, "update.Image");
        //Assert.AreEqual(notesUpdate, update.Notes, "update.Notes");

        Assert.AreEqual(id, patch.Id, "patch.Id");
        Assert.AreEqual(patchName, patch.Name, "patch.Name");
        //Assert.AreEqual(imagePatch, patch.Image, "patch.Image");
        //Assert.AreEqual(notesPatch, patch.Notes, "patch.Notes");
    }

    // Duplicate component name allowed

    //[TestMethod]
    //public async Task TestMethodCreateDuplicateComponentAsync()
    //{
    //    using var snipeIT = new SnipeIT(developStoreKey, appName);

    //    await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.CreateComponentAsync(new() { Name = componentName, Qty = 5, Category = categoryId }));
    //}

    [TestMethod]
    public async Task TestMethodGetNotExistingComponentAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetComponentAsync(notExistingId));
    }

    [TestMethod]
    public async Task TestMethodDeleteNotExistingComponentAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.DeleteComponentAsync(notExistingId));
    }
}
