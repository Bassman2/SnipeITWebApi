namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITLicensesUnitTest : SnipeITBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetLicensesAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetLicensesAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == licenseId);
        Assert.IsNotNull(item);
        Assert.AreEqual(licenseId, item.Id, "item.Id");
        Assert.AreEqual(licenseName, item.Name, "item.Name");
        Assert.AreEqual(null, item.Company, "item.Company");
        Assert.AreEqual(new NamedItem(9, "Adobe"), item.Manufacturer, "item.Manufacturer");
        Assert.AreEqual("f267bf5d-f8dd-35fd-a43a-a657b20be330", item.ProductKey, "item.ProductKey");
        Assert.AreEqual("11504574", item.OrderNumber, "item.OrderNumber");
        Assert.AreEqual("13503Q", item.PurchaseOrder, "item.PurchaseOrder");
        DateAssert.IsNull(item.PurchaseDate, "item.PurchaseDate");
        DateAssert.IsNull(item.TerminationDate, "item.TerminationDate");
        Assert.AreEqual(null, item.Depreciation, "item.Depreciation");
        Assert.AreEqual("29.999,00", item.PurchaseCost, "item.PurchaseCost");
        Assert.AreEqual("29999.00", item.PurchaseCostNumeric, "item.PurchaseCostNumeric");
        Assert.AreEqual(notes, item.Notes, "item.Notes");
        DateAssert.IsNull(item.ExpirationDate, "item.ExpirationDate");
        Assert.AreEqual(10, item.Seats, "item.Seats");
        RangeAssert.IsInRange(4, 6, item.FreeSeatsCount, "item.FreeSeatsCount");
        RangeAssert.IsInRange(4, 6, item.Remaining, "item.Remaining");
        Assert.AreEqual(null, item.MinAmt, "item.MinAmt");
        Assert.AreEqual(null, item.LicenseName, "item.LicenseName");
        Assert.AreEqual("zbatz@example.net", item.LicenseEmail, "item.LicenseEmail");
        Assert.AreEqual(true, item.Reassignable, "item.Reassignable");
        Assert.AreEqual(true, item.Maintained, "item.Maintained");
        Assert.AreEqual(new NamedItem(2, "Collier, Dibbert and Cronin"), item.Supplier, "item.Supplier");
        Assert.AreEqual(new NamedItem(14, "Graphics Software"), item.Category, "item.Category");
        Assert.AreEqual(adminUser, item.CreatedBy, "item.CreatedBy");
        DateAssert.AreEqual(lastUpdate, item.CreatedAt, "item.CreatedAt");
        DateAssert.AreEqual(lastUpdate, item.UpdatedAt, "item.UpdatedAt");
        DateAssert.IsNull(item.DeletedAt, "item.DeletedAt");
        Assert.AreEqual(true, item.UserCanCheckout, "item.UserCanCheckout");
        Assert.IsNotNull(item.AvailableActions, "item.AvailableActions");
        Assert.IsTrue(item.AvailableActions.Checkin, "item.AvailableActions.Checkin");
        Assert.IsTrue(item.AvailableActions.Checkout, "item.AvailableActions.Checkout");
        Assert.IsTrue(item.AvailableActions.Clone, "item.AvailableActions.Clone");
        Assert.IsTrue(item.AvailableActions.Update, "item.AvailableActions.Update");
        Assert.IsTrue(item.AvailableActions.Delete, "item.AvailableActions.Delete");
    }

    [TestMethod]
    public async Task TestMethodGetLicenseAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetLicenseAsync(licenseId);

        Assert.IsNotNull(item);
        Assert.AreEqual(licenseId, item.Id, "item.Id");
        Assert.AreEqual(licenseName, item.Name, "item.Name");
        Assert.AreEqual(null, item.Company, "item.Company");
        Assert.AreEqual(new NamedItem(9, "Adobe"), item.Manufacturer, "item.Manufacturer");
        Assert.AreEqual("f267bf5d-f8dd-35fd-a43a-a657b20be330", item.ProductKey, "item.ProductKey");
        Assert.AreEqual("11504574", item.OrderNumber, "item.OrderNumber");
        Assert.AreEqual("13503Q", item.PurchaseOrder, "item.PurchaseOrder");
        DateAssert.IsNull(item.PurchaseDate, "item.PurchaseDate");
        DateAssert.IsNull(item.TerminationDate, "item.TerminationDate");
        Assert.AreEqual(null, item.Depreciation, "item.Depreciation");
        Assert.AreEqual("29.999,00", item.PurchaseCost, "item.PurchaseCost");
        Assert.AreEqual("29999.00", item.PurchaseCostNumeric, "item.PurchaseCostNumeric");
        Assert.AreEqual(notes, item.Notes, "item.Notes");
        DateAssert.IsNull(item.ExpirationDate, "item.ExpirationDate");
        Assert.AreEqual(10, item.Seats, "item.Seats");
        RangeAssert.IsInRange(4, 6, item.FreeSeatsCount, "item.FreeSeatsCount");
        RangeAssert.IsInRange(4, 6, item.Remaining, "item.Remaining");
        Assert.AreEqual(null, item.MinAmt, "item.MinAmt");
        Assert.AreEqual(null, item.LicenseName, "item.LicenseName");
        Assert.AreEqual("zbatz@example.net", item.LicenseEmail, "item.LicenseEmail");
        Assert.AreEqual(true, item.Reassignable, "item.Reassignable");
        Assert.AreEqual(true, item.Maintained, "item.Maintained");
        Assert.AreEqual(new NamedItem(2, "Collier, Dibbert and Cronin"), item.Supplier, "item.Supplier");
        Assert.AreEqual(new NamedItem(14, "Graphics Software"), item.Category, "item.Category");
        Assert.AreEqual(adminUser, item.CreatedBy, "item.CreatedBy");
        DateAssert.AreEqual(lastUpdate, item.CreatedAt, "item.CreatedAt");
        DateAssert.AreEqual(lastUpdate, item.UpdatedAt, "item.UpdatedAt");
        DateAssert.IsNull(item.DeletedAt, "item.DeletedAt");
        Assert.AreEqual(true, item.UserCanCheckout, "item.UserCanCheckout");
        Assert.IsNotNull(item.AvailableActions, "item.AvailableActions");
        Assert.IsTrue(item.AvailableActions.Checkin, "item.AvailableActions.Checkin");
        Assert.IsTrue(item.AvailableActions.Checkout, "item.AvailableActions.Checkout");
        Assert.IsTrue(item.AvailableActions.Clone, "item.AvailableActions.Clone");
        Assert.IsTrue(item.AvailableActions.Update, "item.AvailableActions.Update");
        Assert.IsTrue(item.AvailableActions.Delete, "item.AvailableActions.Delete");
    }

    [TestMethod]
    public async Task TestMethodCreateLicenseAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        string createName = Guid.NewGuid().ToString();
        string updateName = Guid.NewGuid().ToString();
        string patchName = Guid.NewGuid().ToString();

        var create = await snipeIT.CreateLicenseAsync(new()
        {
            // required
            Name = createName,
            Seats = 10,
            Category = new NamedItem(categoryId, categoryName),

            // optional 
            Notes = notesCreate,

            // Image = imageCreate,    
        });
        Assert.IsNotNull(create);
        Assert.IsTrue(create.Id > 0, "create.Id");
        int id = create.Id;

        var update = await snipeIT.UpdateLicenseAsync(id, new()
        {
            // optional
            Name = updateName,
            Notes = notesUpdate,

            // Image = imageUpdate,
        });
        Assert.IsNotNull(update);

        var patch = await snipeIT.PatchLicenseAsync(id, new()
        {
            // optional 
            Name = patchName,
            Notes = notesPatch,

            // Image = imagePatch,
        });
        Assert.IsNotNull(patch);

        var del =  await snipeIT.DeleteLicenseAsync(id);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetLicenseAsync(id));

        Assert.AreEqual(id, create.Id, "create.Id");
        Assert.AreEqual(createName, create.Name, "create.Name");
        //Assert.AreEqual(imageCreate, create.Image, "create.Image");
        Assert.AreEqual(notesCreate, create.Notes, "create.Notes");

        Assert.AreEqual(id, update.Id, "update.Id");
        Assert.AreEqual(updateName, update.Name, "update.Name");
        //Assert.AreEqual(imageUpdate, update.Image, "update.Image");
        Assert.AreEqual(notesUpdate, update.Notes, "update.Notes");

        Assert.AreEqual(id, patch.Id, "patch.Id");
        Assert.AreEqual(patchName, patch.Name, "patch.Name");
        //Assert.AreEqual(imagePatch, patch.Image, "patch.Image");
        Assert.AreEqual(notesPatch, patch.Notes, "patch.Notes");
    }

    // no bug for duplicated license name

    //[TestMethod]
    //public async Task TestMethodCreateDuplicateLicenseAsync()
    //{
    //    using var snipeIT = new SnipeIT(developStoreKey, appName);

    //    await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.CreateLicenseAsync(new() { Name = licenseName, Seats = 10, Category = new NamedItem(categoryId, categoryName) }));
    //}

    [TestMethod]
    public async Task TestMethodGetNotExistingLicenseAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetLicenseAsync(notExistingId));
    }

    [TestMethod]
    public async Task TestMethodDeleteNotExistingLicenseAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.DeleteLicenseAsync(notExistingId));
    }
}
