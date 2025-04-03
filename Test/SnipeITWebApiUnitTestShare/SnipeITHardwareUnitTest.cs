namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITHardwareUnitTest : SnipeITBaseUnitTest
{

    [TestMethod]
    public async Task TestMethodGetHardwaresAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetHardwaresAsync();

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

        var item = list.FirstOrDefault(d => d.Id == hardwareId);
        Assert.IsNotNull(item);
        Assert.AreEqual(departmentId, item.Id, "item.Id");
        Assert.AreEqual(departmentName, item.Name, "item.Name");
        //Assert.IsNull(item.Phone, "item.Phone");
        //Assert.IsNull(item.Fax, "item.Fax");
        //Assert.IsNull(item.Image, "item.Image");
        //Assert.IsNull(item.Company, "item.Company");
        //Assert.IsNull(item.Manager, "item.Manager");
        //Assert.IsNull(item.Location, "item.Location");
        //Assert.IsTrue(item.UsersCount > 10, "item.UsersCount");
        //Assert.AreEqual("Created by DB seeder", item.Notes, "item.Notes");
        //DateTimeAssert.AreEqual("2025-02-20", item.CreatedAt, "item.CreatedAt");
        //DateTimeAssert.AreEqual("2025-02-20", item.UpdatedAt, "item.UpdatedAt");
        //Assert.IsNotNull(item.AvailableActions, "item.AvailableActions");
        //Assert.IsTrue(item.AvailableActions.Update, "item.AvailableActions.Update");
        //Assert.IsFalse(item.AvailableActions.Delete, "item.AvailableActions.Delete");
 
    }

    [TestMethod]
    public async Task TestMethodGetHardwaresByCategoryAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var asyncList = snipeIT.GetHardwaresByCategoryAsync(2);

        var list = await asyncList.ToListAsync();

        Assert.IsNotNull(list);
        Assert.IsNotEmpty(list);

    }

    [TestMethod]
    public async Task TestMethodGetHardwareAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        var item = await snipeIT.GetHardwareAsync(hardwareId);
                
        Assert.IsNotNull(item);
        Assert.AreEqual(hardwareId, item.Id, "item.Id");
        Assert.AreEqual(hardwareName, item.Name, "item.Name");
        Assert.AreEqual("283896877", item.AssetTag, "item.AssetTag");
        Assert.AreEqual("632aeacb-a1ff-30f6-838f-9f639e036dda", item.Serial, "item.Serial");
        Assert.AreEqual(new NamedItem(1, "Macbook Pro 13&quot;"), item.Model, "item.Model"); 
        Assert.AreEqual(false, item.Byod, "item.Byod");
        Assert.AreEqual(false, item.Requestable, "item.Requestable");
        Assert.AreEqual("4532230160393106", item.ModelNumber, "item.ModelNumber");
        Assert.AreEqual("36 months", item.Eol, "item.Eol");
        DateTimeAssert.AreEqual(null, item.AssetEolDate, "item.AssetEolDate");
        Assert.AreEqual(new NamedItem(2, "Pending"), item.StatusLabel, "item.StatusLabel");
        Assert.AreEqual(new NamedItem(1, "Laptops"), item.Category, "item.Category");
        Assert.AreEqual(null, item.Manufacturer, "item.Manufacturer");
        Assert.AreEqual(new NamedItem(3, "Jast PLC"), item.Supplier, "item.Supplier");
        Assert.AreEqual("Created by DB seeder", item.Notes, "item.Notes");
        Assert.AreEqual("28492477", item.OrderNumber, "item.OrderNumber");
        Assert.AreEqual(null, item.Company, "item.Company");
        Assert.AreEqual(new NamedItem(2, "Port Camrynland"), item.Location, "item.Location");
        Assert.AreEqual(null, item.RtdLocation, "item.RtdLocation");
        Assert.AreEqual("https://develop.snipeitapp.com/uploads/models/mbp.jpg", item.Image, "item.Image");
        Assert.AreEqual(null, item.Qr, "item.Qr");
        Assert.AreEqual(null, item.AltBarcode, "item.AltBarcode");
        Assert.AreEqual(null, item.AssignedTo, "item.AssignedTo");
        Assert.AreEqual(null, item.WarrantyMonths, "item.WarrantyMonths");
        DateTimeAssert.AreEqual(null, item.WarrantyExpires, "item.WarrantyExpires");
        Assert.AreEqual(new NamedItem(1, "Admin User"), item.CreatedBy, "item.CreatedBy");
        DateTimeAssert.AreEqual(lastUpdate, item.CreatedAt, "item.CreatedAt");
        DateTimeAssert.AreEqual(lastUpdate, item.UpdatedAt, "item.UpdatedAt");
        DateTimeAssert.AreEqual(null, item.LastAuditDate, "item.LastAuditDate");
        DateTimeAssert.AreEqual(null, item.NextAuditDate, "item.NextAuditDate");
        DateTimeAssert.AreEqual(null, item.DeletedAt, "item.DeletedAt");
        DateTimeAssert.AreEqual(null, item.PurchaseDate, "item.PurchaseDate");
        Assert.AreEqual("9 months ago", item.Age, "item.Age");
        DateTimeAssert.AreEqual(null, item.LastCheckout, "item.LastCheckout");
        DateTimeAssert.AreEqual(null, item.LastCheckin, "item.LastCheckin");
        DateTimeAssert.AreEqual(null, item.ExpectedCheckin, "item.ExpectedCheckin");
        Assert.AreEqual(null, item.PurchaseCost, "item.PurchaseCost");
        Assert.AreEqual(0, item.CheckinCounter, "item.CheckinCounter");
        Assert.AreEqual(0, item.CheckoutCounter, "item.CheckoutCounter");
        Assert.AreEqual(0, item.RequestsCounter, "item.RequestsCounter");
        Assert.AreEqual(false, item.UserCanCheckout, "item.UserCanCheckout");
        Assert.AreEqual("0,00", item.BookValue, "item.BookValue");

        Assert.IsNotNull(item.CustomFields, "item.CustomFields");
        Assert.IsTrue(item.CustomFields.Count > 0, "item.CustomFields");

        var customFiledMACAddress = item.CustomFields["MAC Address"];
        Assert.IsNotNull(customFiledMACAddress, "customFiledMACAddress");
        Assert.AreEqual("_snipeit_mac_address_5", customFiledMACAddress.Field, "customFiledMACAddress.Field");
        Assert.AreEqual("", customFiledMACAddress.Value, "customFiledMACAddress.Value");
        Assert.AreEqual("regex:/^([0-9a-fA-F]{2}[:-]){5}[0-9a-fA-F]{2}$/", customFiledMACAddress.FieldFormat, "customFiledMACAddress.FieldFormat");
        Assert.AreEqual("text", customFiledMACAddress.Element, "customFiledMACAddress.Element");

        Assert.IsNotNull(item.AvailableActions, "item.AvailableActions");
        Assert.IsTrue(item.AvailableActions.Checkout, "item.AvailableActions.Checkout");
        Assert.IsTrue(item.AvailableActions.Checkin, "item.AvailableActions.Checkin");
        Assert.IsTrue(item.AvailableActions.Update, "item.AvailableActions.Update");
        Assert.IsFalse(item.AvailableActions.Restore, "item.AvailableActions.Restore");
        Assert.IsTrue(item.AvailableActions.Delete, "item.AvailableActions.Delete");
        Assert.IsTrue(item.AvailableActions.Clone, "item.AvailableActions.Clone");


    }

}
