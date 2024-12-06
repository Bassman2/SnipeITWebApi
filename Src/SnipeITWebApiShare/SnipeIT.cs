namespace SnipeITWebApi;

public class SnipeIT : IDisposable
{
    private SnipeITService? service;

    public SnipeIT(Uri host, string apikey)
    {
        service = new SnipeITService(host, apikey);
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
        //if (res is not null)
        {
            await foreach (var item in res)
            {
                yield return item!;
            }
        }
    }

    // Servers = 155
    public async IAsyncEnumerable<Hardware> GetHardwareListByCategoryAsync(int category, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetHardwareListByCategoryAsync(category, cancellationToken);
        //if (res is not null)
        {
            await foreach (var item in res)
            {
                yield return item!;
            }
        }
    }

}
