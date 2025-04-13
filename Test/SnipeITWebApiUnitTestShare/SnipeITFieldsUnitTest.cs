namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITFieldsUnitTest : SnipeITBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetFieldsAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetFieldsAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == fieldId);
        Assert.IsNotNull(item);
        Assert.AreEqual(fieldId, item.Id, "item.Id");
        Assert.AreEqual(fieldName, item.Name, "item.Name");
    }

    [TestMethod]
    public async Task TestMethodGetFieldsAync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetFieldAsync(fieldId);
                
        Assert.IsNotNull(item);
        Assert.AreEqual(fieldId, item.Id, "item.Id");
        Assert.AreEqual(fieldName, item.Name, "item.Name");
    }

    //[TestMethod]
    //public async Task TestMethodCreateFieldAsync()
    //{
    //    using var snipeIT = new SnipeIT(developStoreKey, appName);

    //    string createName = Guid.NewGuid().ToString();
    //    string updateName = Guid.NewGuid().ToString();
    //    string patchName = Guid.NewGuid().ToString();

    //    var create = await snipeIT.CreateFieldAsync(new()
    //    {
    //        Name = createName,
    //        //Phone = phoneCreate,
    //        //Fax = faxCreate,
    //        //Email = emailCreate,
    //        ////Image = imageCreate,    
    //        //Notes = notesCreate,
    //    });
    //    Assert.IsNotNull(create);
    //    Assert.IsTrue(create.Id > 0, "create.Id");
    //    int id = create.Id;

    //    var update = await snipeIT.UpdateFieldAsync(id, new()
    //    {
    //        Name = updateName,
    //        //Phone = phoneUpdate,
    //        //Fax = faxUpdate,
    //        //Email = emailUpdate,
    //        ////Image = imageUpdate,
    //        //Notes = notesUpdate,

    //    });
    //    Assert.IsNotNull(update);

    //    var patch = await snipeIT.PatchFieldAsync(id, new()
    //    {
    //        Name = patchName,
    //        //Phone = phonePatch,
    //        //Fax = faxPatch,
    //        //Email = emailPatch,
    //        ////Image = imagePatch,
    //        //Notes = notesPatch,

    //    });
    //    Assert.IsNotNull(patch);

    //    var del = await snipeIT.DeleteFieldAsync(id);

    //    await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetFieldAsync(id));

    //    Assert.AreEqual(id, create.Id, "create.Id");
    //    Assert.AreEqual(createName, create.Name, "create.Name");
    //    //Assert.AreEqual(phoneCreate, create.Phone, "create.Phone");
    //    //Assert.AreEqual(faxCreate, create.Fax, "create.Fax");
    //    //Assert.AreEqual(emailCreate, create.Email, "create.Email");
    //    ////Assert.AreEqual(imageCreate, create.Image, "create.Image");
    //    //Assert.AreEqual(notesCreate, create.Notes, "create.Notes");

    //    Assert.AreEqual(id, update.Id, "update.Id");
    //    Assert.AreEqual(updateName, update.Name, "update.Name");
    //    //Assert.AreEqual(phoneUpdate, update.Phone, "update.Phone");
    //    //Assert.AreEqual(faxUpdate, update.Fax, "update.Fax");
    //    //Assert.AreEqual(emailUpdate, update.Email, "update.Email");
    //    ////Assert.AreEqual(imageUpdate, update.Image, "update.Image");
    //    //Assert.AreEqual(notesUpdate, update.Notes, "update.Notes");

    //    Assert.AreEqual(id, patch.Id, "patch.Id");
    //    Assert.AreEqual(patchName, patch.Name, "patch.Name");
    //    //Assert.AreEqual(phonePatch, patch.Phone, "patch.Phone");
    //    //Assert.AreEqual(faxPatch, patch.Fax, "patch.Fax");
    //    //Assert.AreEqual(emailPatch, patch.Email, "patch.Email");
    //    ////Assert.AreEqual(imagePatch, patch.Image, "patch.Image");
    //    //Assert.AreEqual(notesPatch, patch.Notes, "patch.Notes");
    //}

    [TestMethod]
    public async Task TestMethodCreateDuplicateFieldAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.CreateFieldAsync(new() { Name = fieldName }));
    }

    [TestMethod]
    public async Task TestMethodGetNotExistingFieldAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetFieldAsync(notExistingId));
    }

    [TestMethod]
    public async Task TestMethodDeleteNotExistingFieldAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.DeleteFieldAsync(notExistingId));
    }
}
