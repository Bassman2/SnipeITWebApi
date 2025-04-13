namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITSuppliersUnitTest : SnipeITBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetSuppliersAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetSuppliersAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == supplierId);
        Assert.IsNotNull(item);
        Assert.AreEqual(supplierId, item.Id, "item.Id");
        Assert.AreEqual(supplierName, item.Name, "item.Name");
    }

    [TestMethod]
    public async Task TestMethodGetSupplierAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetSupplierAsync(supplierId);

        Assert.IsNotNull(item);
        Assert.AreEqual(supplierId, item.Id, "item.Id");
        Assert.AreEqual(supplierName, item.Name, "item.Name");
    }

    //[TestMethod]
    //public async Task TestMethodCreateSupplierAsync()
    //{
    //    using var snipeIT = new SnipeIT(developStoreKey, appName);

    //    string createName = Guid.NewGuid().ToString();
    //    string updateName = Guid.NewGuid().ToString();
    //    string patchName = Guid.NewGuid().ToString();

    //    var create = await snipeIT.CreateSupplierAsync(new()
    //    {
    //        Name = createName,
    //        Phone = phoneCreate,
    //        Fax = faxCreate,
    //        Email = emailCreate,
    //        //Image = imageCreate,    
    //        Notes = notesCreate,
    //    });
    //    Assert.IsNotNull(create);
    //    Assert.IsTrue(create.Id > 0, "create.Id");
    //    int id = create.Id;

    //    var update = await snipeIT.UpdateSupplierAsync(id, new()
    //    {
    //        Name = updateName,
    //        Phone = phoneUpdate,
    //        Fax = faxUpdate,
    //        Email = emailUpdate,
    //        //Image = imageUpdate,
    //        Notes = notesUpdate,

    //    });
    //    Assert.IsNotNull(update);

    //    var patch = await snipeIT.PatchSupplierAsync(id, new()
    //    {
    //        Name = patchName,
    //        Phone = phonePatch,
    //        Fax = faxPatch,
    //        Email = emailPatch,
    //        //Image = imagePatch,
    //        Notes = notesPatch,

    //    });
    //    Assert.IsNotNull(patch);

    //    var del = await snipeIT.DeleteSupplierAsync(id);

    //    await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetSupplierAsync(id));

    //    Assert.AreEqual(id, create.Id, "create.Id");
    //    Assert.AreEqual(createName, create.Name, "create.Name");
    //    Assert.AreEqual(phoneCreate, create.Phone, "create.Phone");
    //    Assert.AreEqual(faxCreate, create.Fax, "create.Fax");
    //    Assert.AreEqual(emailCreate, create.Email, "create.Email");
    //    //Assert.AreEqual(imageCreate, create.Image, "create.Image");
    //    Assert.AreEqual(notesCreate, create.Notes, "create.Notes");

    //    Assert.AreEqual(id, update.Id, "update.Id");
    //    Assert.AreEqual(updateName, update.Name, "update.Name");
    //    Assert.AreEqual(phoneUpdate, update.Phone, "update.Phone");
    //    Assert.AreEqual(faxUpdate, update.Fax, "update.Fax");
    //    Assert.AreEqual(emailUpdate, update.Email, "update.Email");
    //    //Assert.AreEqual(imageUpdate, update.Image, "update.Image");
    //    Assert.AreEqual(notesUpdate, update.Notes, "update.Notes");

    //    Assert.AreEqual(id, patch.Id, "patch.Id");
    //    Assert.AreEqual(patchName, patch.Name, "patch.Name");
    //    Assert.AreEqual(phonePatch, patch.Phone, "patch.Phone");
    //    Assert.AreEqual(faxPatch, patch.Fax, "patch.Fax");
    //    Assert.AreEqual(emailPatch, patch.Email, "patch.Email");
    //    //Assert.AreEqual(imagePatch, patch.Image, "patch.Image");
    //    Assert.AreEqual(notesPatch, patch.Notes, "patch.Notes");
    //}

    [TestMethod]
    public async Task TestMethodCreateDuplicateSupplierAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.CreateSupplierAsync(new() { Name = supplierName }));
    }

    [TestMethod]
    public async Task TestMethodGetNotExistingSupplierAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetSupplierAsync(notExistingId));
    }

    [TestMethod]
    public async Task TestMethodDeleteNotExistingSupplierAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.DeleteSupplierAsync(notExistingId));
    }
}
