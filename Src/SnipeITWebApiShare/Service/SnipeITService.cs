namespace SnipeITWebApi.Service;

// https://snipe-it.readme.io/reference/api-overview

internal class SnipeITService(Uri host, IAuthenticator? authenticator, string appName) 
    : JsonService(host, authenticator, appName, SourceGenerationContext.Default)
{
    private const int limit = 1000;

    protected override string? AuthenticationTestUrl => "api/v1/hardware?limit=1&offset=0";

    protected override async Task ErrorHandlingAsync(HttpResponseMessage response, string memberName, CancellationToken cancellationToken)
    {
        var errorMessage = await ReadFromJsonAsync<ErrorMessageModel>(response, cancellationToken);
        throw new WebServiceException(errorMessage?.Message, response.RequestMessage?.RequestUri, response.StatusCode, response.ReasonPhrase, memberName);
    }

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

    public IAsyncEnumerable<CategoryModel> GetCategoriesAsync(CancellationToken cancellationToken)
    {
        var res = GetListAsync<CategoryModel>($"api/v1/categories?", cancellationToken);
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
