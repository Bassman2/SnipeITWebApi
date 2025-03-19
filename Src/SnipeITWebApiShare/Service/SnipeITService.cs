using SnipeITWebApi.Service.Model;

namespace SnipeITWebApi.Service;

// https://snipe-it.readme.io/reference/api-overview

internal class SnipeITService(Uri host, IAuthenticator? authenticator, string appName) 
    : JsonService(host, authenticator, appName, SourceGenerationContext.Default)
{
    private const int limit = 1000;

    protected override string? AuthenticationTestUrl => "api/v1/hardware?limit=1&offset=0";

    //protected override async Task ErrorCheckAsync(HttpResponseMessage response, string memberName, CancellationToken cancellationToken)
    //{
    //    // SnipeIT errors can occure with a 200 status code

    //    // for not closing the stream use ReadAsStringAsync instead of ReadFromJsonAsync

    //    JsonTypeInfo<ErrorMessageModel> jsonTypeInfo = (JsonTypeInfo<ErrorMessageModel>)context.GetTypeInfo(typeof(ErrorMessageModel))!;

    //    string res = await response.Content.ReadAsStringAsync(cancellationToken);

    //    var errorMessageModel = JsonSerializer.Deserialize<ErrorMessageModel>(res, jsonTypeInfo);

        

    //    //r errorMessageModel = await ReadFromJsonAsync<ErrorMessageModel>(response, cancellationToken);




    //    if (!response.IsSuccessStatusCode)
    //    {
    //        await ErrorHandlingAsync(response, memberName, cancellationToken);
    //    }
    //}

    //protected override async Task ErrorHandlingAsync(HttpResponseMessage response, string memberName, CancellationToken cancellationToken)
    //{
    //    var errorMessage = await ReadFromJsonAsync<ErrorMessageModel>(response, cancellationToken);
    //    throw new WebServiceException(errorMessage?.Messages, response.RequestMessage?.RequestUri, response.StatusCode, response.ReasonPhrase, memberName);
    //}

    #region Assets

    public IAsyncEnumerable<HardwareModel> GetHardwareListAsync(CancellationToken cancellationToken)
    {
        var res = GetListAsync<HardwareModel>("api/v1/hardware", cancellationToken);
        return res;
    }

    public IAsyncEnumerable<HardwareModel> GetHardwareListByCategoryAsync(int category, CancellationToken cancellationToken)
    {
        var res = GetListAsync<HardwareModel>(CombineUrl("api/v1/hardware", ("category_id", category)), cancellationToken);
        return res;
    }

    #endregion



    #region Category

    public IAsyncEnumerable<CategoryModel> GetCategoriesAsync(CancellationToken cancellationToken)
    {
        var res = GetListAsync<CategoryModel>("api/v1/categories", cancellationToken);
        return res;
    }

    #endregion


    #region Manufacturers

    public IAsyncEnumerable<ManufacturerModel> GetManufacturersAsync(CancellationToken cancellationToken)
    {
        var res = GetListAsync<ManufacturerModel>("api/v1/manufacturers", cancellationToken);
        return res;
    }

    public async Task<ManufacturerModel?> GetManufacturerAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);


        var res = await GetFromJsonAsync<ManufacturerModel>($"api/v1/manufacturers/{id}", cancellationToken);
        return res;
    }

    public async Task<ManufacturerModel?> CreateManufacturerAsync(ManufacturerModel create, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<ManufacturerModel, ResultModel<ManufacturerModel>>("api/v1/manufacturers", create, cancellationToken);

        if (res != null && res.Status == Status.Error)
        {
            throw new WebServiceException(res.ToString());
        }
        return res!.Payload;
    }

    public async Task<ManufacturerModel?> DeleteManufacturerAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await DeleteAsJsonAsync<ResultModel<ManufacturerModel>> ($"api/v1/manufacturers/{id}", cancellationToken);

        if (res != null && res.Status == Status.Error)
        {
            throw new WebServiceException(res.ToString());
        }
        return res?.Payload;
    }

    #endregion



    #region Private

    private async IAsyncEnumerable<T> GetListAsync<T>(string requestUri, [EnumeratorCancellation] CancellationToken cancellationToken, [CallerMemberName] string memberName = "") //where T : class
    {
        ArgumentRequestUriException.ThrowIfNullOrWhiteSpace(requestUri, nameof(requestUri));
        WebServiceException.ThrowIfNotConnected(client);

        int count = 1;
        int offset = 0;
        while (count > offset)
        {
            
            //var res = await GetFromJsonAsync<ListModel<T>>($"{requestUri}limit={limit}&offset={offset}", cancellationToken);
            var res = await GetFromJsonAsync<ListModel<T>>(CombineUrl(requestUri, ("limit", limit), ("offset", offset)), cancellationToken, memberName);
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
