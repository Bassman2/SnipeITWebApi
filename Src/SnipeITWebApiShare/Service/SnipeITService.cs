namespace SnipeITWebApi.Service;

internal class SnipeITService(Uri host, string apikey) : JsonService(host, SourceGenerationContext.Default, new BearerAuthenticator(apikey))
{
    private const int limit = 100;

    protected override void TestAutentication()
    {
        try
        {
            var _ = GetStringAsync("/rest/api/2/serverInfo", default).Result;
        }
        catch (Exception ex)
        {
            throw new AuthenticationException(ex.Message, ex);
        }
    }

    public async IAsyncEnumerable<HardwareModel> GetHardwareListAsync([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        int count = 1;
        int offset = 0;
        while (count > offset)
        {
            var res = await GetFromJsonAsync<HardwareListModel>($"api/v1/hardware?limit={limit}&offset={offset}", cancellationToken);
            if (res != null && res.Hardwares != null)
            {
                foreach (var item in res.Hardwares)
                {
                    yield return item;
                }
            }
            count = res?.Total ?? 0;
            offset += limit;
        }
    }

    public async IAsyncEnumerable<HardwareModel> GetHardwareListByCategoryAsync(int category, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        int count = 1;
        int offset = 0;
        while (count > offset)
        {
            var res = await GetFromJsonAsync<HardwareListModel>($"api/v1/hardware?category_id={category}&limit={limit}&offset={offset}", cancellationToken);
            if (res != null && res.Hardwares != null)
            {
                foreach (var item in res.Hardwares)
                {
                    yield return item;
                }
            }
            count = res?.Total ?? 0;
            offset += limit;
        }
    }
}
