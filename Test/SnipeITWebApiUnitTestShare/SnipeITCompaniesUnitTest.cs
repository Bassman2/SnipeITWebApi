namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITCompaniesUnitTest : SnipeITBaseUnitTest<Company>
{
    [TestMethod]
    public async Task TestMethodCreateUpdateDeleteCompanyAsync()
    {
        var create = new Company()
        {
            Name = CreateName(),
            Phone = phoneCreate,
            Fax = faxCreate,
            Email = emailCreate,
            //Image = imageCreate,    
            Notes = notesCreate,
        };

        var update = new Company()
        {
            Name = CreateName(),
            Phone = phoneUpdate,
            Fax = faxUpdate,
            Email = emailUpdate,
            //Image = imageUpdate,
            Notes = notesUpdate,

        };

        var patch = new Company()
        {
            Name = CreateName(),
            Phone = phonePatch,
            Fax = faxPatch,
            Email = emailPatch,
            //Image = imagePatch,
            Notes = notesPatch,
        };

        await TestMethodAllAsync(create, update, patch);
    }

    [TestMethod]
    public async Task TestMethodCreateDuplicateCompanyAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.CreateCompanyAsync(new () { Name = companyName }));
    }

    [TestMethod]
    public async Task TestMethodGetNotExistingCompanyAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.GetCompanyAsync(notExistingId));
    }

    [TestMethod]
    public async Task TestMethodDeleteNotExistingCompanyAsync()
    {
        using var snipeIT = new SnipeIT(developStoreKey, appName);

        await Assert.ThrowsExactlyAsync<WebServiceException>(async () => await snipeIT.DeleteCompanyAsync(notExistingId));
    }

    public override void AreEqual(int id, Company expected, Company? actual, string message)
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

    public override IAsyncEnumerable<Company> GetAsync(SnipeIT snipeIT)
        => snipeIT.GetCompaniesAsync();

    public override async Task<Company?> GetAsync(SnipeIT snipeIT, int id)
        => await snipeIT.GetCompanyAsync(id);

    public override async Task<int> CreateAsync(SnipeIT snipeIT, Company value)
        => await snipeIT.CreateCompanyAsync(value);

    public override async Task UpdateAsync(SnipeIT snipeIT, int id, Company value)
        => await snipeIT.UpdateCompanyAsync(id, value);

    public override async Task PatchAsync(SnipeIT snipeIT, int id, Company value)
        => await snipeIT.PatchCompanyAsync(id, value);

    public override async Task DeleteAsync(SnipeIT snipeIT, int id)
        => await snipeIT.DeleteCompanyAsync(id);
}
