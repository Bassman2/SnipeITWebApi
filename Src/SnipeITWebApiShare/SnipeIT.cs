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

    public async IAsyncEnumerable<Category> GetCategoriesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetCategoriesAsync(cancellationToken);

        //return res!.CastModelAsync<Category, CategoryModel>();
        await foreach (var item in res)
        {
            yield return item.CastModel<Category>()!;
        }
    }

    public async IAsyncEnumerable<Manufacturer> GetManufacturersAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetManufacturersAsync(cancellationToken);

        //return res!.CastModelAsync<Category, CategoryModel>();
        await foreach (var item in res)
        {
            yield return item.CastModel<Manufacturer>()!;
        }

    }
}
