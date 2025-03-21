namespace SnipeITWebApi;

public class SnipeIT : IDisposable
{
    private SnipeITService? service;

    public SnipeIT(string storeKey, string appName)
    : this(new Uri(KeyStore.Key(storeKey)?.Host!), KeyStore.Key(storeKey)!.Token!, appName)
    { }

    public SnipeIT(Uri host, string token, string appName)
    {
        service = new(host, new BearerAuthenticator(token), appName);
    }

    public void Dispose()
    {
        if (this.service != null)
        {
            this.service.Dispose();
            this.service = null;
        }
        GC.SuppressFinalize(this);
    }

    #region Assets

    public async IAsyncEnumerable<Hardware> GetHardwareListAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetHardwareListAsync(cancellationToken);

        await foreach (var item in res)
        {
            yield return item.CastModel<Hardware>()!;
        }

    }

    public async IAsyncEnumerable<Hardware> GetHardwareListByCategoryAsync(int category, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetHardwareListByCategoryAsync(category, cancellationToken);

        await foreach (var item in res)
        {
            yield return item.CastModel<Hardware>()!;
        }
        

    }

    public async Task<Hardware?> GetHardwareAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.GetHardwareAsync(id, cancellationToken);
        return res.CastModel<Hardware>();
    }

    public async Task<Hardware?> CreateCategoryAsync(Hardware item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateHardwareAsync(item.ToCreate(), cancellationToken);
        return res.CastModel<Hardware>();
    }

    public async Task<Hardware?> UpdateHardwareAsync(int id, Hardware item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateHardwareAsync(id, item.ToUpdate(), cancellationToken);
        return res.CastModel<Hardware>();
    }

    public async Task<Hardware?> PatchHardwareAsync(int id, Hardware item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchHardwareAsync(id, item.ToPatch(), cancellationToken);
        return res.CastModel<Hardware>();
    }

    public async Task<Hardware?> DeleteHardwareAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteCategoryAsync(id, cancellationToken);
        return res.CastModel<Hardware>();
    }

    public async Task<Hardware?> CheckoutHardwareAsync(int id, Hardware item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.CheckoutHardwareAsync(id, item.ToCheckout(), cancellationToken);
        return res.CastModel<Hardware>();
    }

    public async Task<Hardware?> CheckinHardwareAsync(int id, Hardware item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.CheckinHardwareAsync(id, item.ToCheckin(), cancellationToken);
        return res.CastModel<Hardware>();
    }

    #endregion

    #region Categories

    public async IAsyncEnumerable<Category> GetCategoriesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetCategoriesAsync(cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Category>()!;
        }
    }

    public async Task<Category?> GetCategoryAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetCategoryAsync(id, cancellationToken);
        return res.CastModel<Category>();
    }

    public async Task<Category?> CreateCategoryAsync(Category item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateCategoryAsync(item.ToCreate(), cancellationToken);
        return res.CastModel<Category>();
    }

    public async Task<Category?> UpdateCategoryAsync(int id, Category item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateCategoryAsync(id, item.ToUpdate(), cancellationToken);
        return res.CastModel<Category>();
    }

    public async Task<Category?> PatchCategoryAsync(int id, Category item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchCategoryAsync(id, item.ToPatch(), cancellationToken);
        return res.CastModel<Category>();
    }

    public async Task<Category?> DeleteCategoryAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteCategoryAsync(id, cancellationToken);
        return res.CastModel<Category>();
    }

    #endregion

    #region Departments

    public async IAsyncEnumerable<Department> GetDepartmentsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetDepartmentsAsync(cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Department>()!;
        }
    }

    public async Task<Department?> GetDepartmentAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetDepartmentAsync(id, cancellationToken);
        return res.CastModel<Department>();
    }

    public async Task<Department?> CreateDepartmentAsync(Department item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateDepartmentAsync(item.ToCreate(), cancellationToken);
        return res.CastModel<Department>();
    }

    public async Task<Department?> UpdateDepartmentAsync(int id, Department item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateDepartmentAsync(id, item.ToUpdate(), cancellationToken);
        return res.CastModel<Department>();
    }

    public async Task<Department?> PatchDepartmentAsync(int id, Department item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchDepartmentAsync(id, item.ToPatch(), cancellationToken);
        return res.CastModel<Department>();
    }

    public async Task<Department?> DeleteDepartmentAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteDepartmentAsync(id, cancellationToken);
        return res.CastModel<Department>();
    }

    #endregion

    #region Manufacturers

    public async IAsyncEnumerable<Manufacturer> GetManufacturersAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetManufacturersAsync(cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Manufacturer>()!;
        }
    }

    public async Task<Manufacturer?> GetManufacturerAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetManufacturerAsync(id, cancellationToken);
        return res.CastModel<Manufacturer>();
    }

    public async Task<Manufacturer?> CreateManufacturerAsync(Manufacturer item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateManufacturerAsync(item.ToCreate(), cancellationToken);
        return res.CastModel<Manufacturer>(); 
    }

    public async Task<Manufacturer?> UpdateManufacturerAsync(int id, Manufacturer item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdatManufacturerAsync(id, item.ToUpdate(), cancellationToken);
        return res.CastModel<Manufacturer>();
    }

    public async Task<Manufacturer?> PatchManufacturerAsync(int id, Manufacturer item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchManufacturerAsync(id, item.ToPatch(), cancellationToken);
        return res.CastModel<Manufacturer>();
    }

    public async Task<Manufacturer?> DeleteManufacturerAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteManufacturerAsync(id, cancellationToken);
        return res.CastModel<Manufacturer>();
    }

    #endregion

    #region Models

    public async IAsyncEnumerable<Model> GetModelsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetModelsAsync(cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Model>()!;
        }
    }

    public async Task<Model?> GetModelAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.GetModelAsync(id, cancellationToken);
        return res.CastModel<Model>();
    }

    public async Task<Model?> CreateModelAsync(Model item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateModelAsync(item.ToCreate(), cancellationToken);
        return res.CastModel<Model>();
    }

    public async Task<Model?> UpdateModelAsync(int id, Model item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateModelAsync(id, item.ToUpdate(), cancellationToken);
        return res.CastModel<Model>();
    }

    public async Task<Model?> PatchModelAsync(int id, Model item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchModelAsync(id, item.ToPatch(), cancellationToken);
        return res.CastModel<Model>();
    }

    public async Task<Model?> DeleteModelAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteModelAsync(id, cancellationToken);
        return res.CastModel<Model>();
    }

    #endregion
}
