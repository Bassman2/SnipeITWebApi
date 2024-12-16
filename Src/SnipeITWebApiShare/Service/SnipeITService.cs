namespace SnipeITWebApi.Service;

internal class SnipeITService(Uri host, string apikey) : JsonService(host, SourceGenerationContext.Default, new BearerAuthenticator(apikey))
{
    private const int limit = 1000;

    protected override string? AuthenticationTestUrl => "api/v1/hardware?limit=1&offset=0";

    public IAsyncEnumerable<HardwareModel> GetHardwareListAsync(CancellationToken cancellationToken)
    {
        var res = GetListAsync<HardwareModel>("api/v1/hardware?", cancellationToken);
        return res;
    }

    public IAsyncEnumerable<HardwareModel> GetHardwareListByCategoryAsync(int category, CancellationToken cancellationToken)
    {
        var res = GetListAsync<HardwareModel>($"api/v1/hardware?category_id={category}&", cancellationToken);
        return res;
    }

    #region Private

    private async IAsyncEnumerable<T> GetListAsync<T>(string? requestUri, [EnumeratorCancellation] CancellationToken cancellationToken, [CallerMemberName] string memberName = "") //where T : class
    {
        ArgumentRequestUriException.ThrowIfNullOrWhiteSpace(requestUri, nameof(requestUri));
        WebServiceException.ThrowIfNullOrNotConnected(this);

        int count = 1;
        int offset = 0;
        while (count > offset)
        {
            var res = await GetFromJsonAsync<ListModel<T>>($"{requestUri}limit={limit}&offset={offset}", cancellationToken);
            if (res != null && res.Rows != null)
            {
                foreach (var item in res.Rows)
                {
                    yield return item;
                }
            }
            count = res?.Total ?? 0;
            offset += limit;
        }
    }

    #endregion
}
