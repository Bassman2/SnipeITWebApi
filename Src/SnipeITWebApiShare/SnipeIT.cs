using System.Xml.Linq;

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

    public async Task<Category?> CreateCategoryAsync(Category create, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateCategoryAsync(create.ToCreate(), cancellationToken);
        return res.CastModel<Category>();
    }

    public async Task<Category?> UpdateCategoryAsync(Category create, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.UpdateCategoryAsync(create.ToUpdate(), cancellationToken);
        return res.CastModel<Category>();
    }

    public async Task<Category?> PatchCategoryAsync(Category patch, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.UpdateCategoryAsync(patch.ToPatch(), cancellationToken);
        return res.CastModel<Category>();
    }

    public async Task DeleteCategoryAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.DeleteCategoryAsync(id, cancellationToken);
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

    public async Task<Manufacturer?> CreateManufacturerAsync(Manufacturer create, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateManufacturerAsync(create.ToCreate(), cancellationToken);
        return res.CastModel<Manufacturer>(); 
    }

    public async Task<Manufacturer?> UpdateManufacturerAsync(Manufacturer create, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.UpdatManufacturerAsync(create.ToUpdate(), cancellationToken);
        return res.CastModel<Manufacturer>();
    }

    public async Task<Manufacturer?> PatchManufacturerAsync(Manufacturer patch, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.PatchManufacturerAsync(patch.ToPatch(), cancellationToken);
        return res.CastModel<Manufacturer>();
    }

    public async Task DeleteManufacturerAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.DeleteManufacturerAsync(id, cancellationToken);
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

        var res = await service.GetModelAsync(id, cancellationToken);
        return res.CastModel<Model>();
    }

    public async Task<Model?> CreateModelAsync(Model create, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateModelAsync(create.ToCreate(), cancellationToken);
        return res.CastModel<Model>();
    }

    public async Task<Model?> UpdateModelAsync(Model create, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.UpdateModelAsync(create.ToUpdate(), cancellationToken);
        return res.CastModel<Model>();
    }

    public async Task<Model?> PatchModelAsync(Model patch, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.PatchModelAsync(patch.ToPatch(), cancellationToken);
        return res.CastModel<Model>();
    }

    public async Task DeleteModelAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.DeleteModelAsync(id, cancellationToken);
    }

    #endregion

}
