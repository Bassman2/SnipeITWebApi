﻿namespace SnipeITWebApi.Service;

// https://snipe-it.readme.io/reference/api-overview

internal class SnipeITService(Uri host, IAuthenticator? authenticator, string appName) 
    : JsonService(host, authenticator, appName, SourceGenerationContext.Default)
{
    private const int limit = 1000;

    protected override string? AuthenticationTestUrl => "api/v1/hardware?limit=1&offset=0";

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

    public async Task<HardwareModel?> GetHardwareAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<HardwareModel>($"api/v1/hardware/{id}", cancellationToken);
        return res;
    }

    public async Task<HardwareModel?> CreateHardwareAsync(HardwareModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<HardwareModel, ResultModel<HardwareModel>>("api/v1/hardware", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<HardwareModel?> UpdateHardwareAsync(int id, HardwareModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<HardwareModel, ResultModel<HardwareModel>>($"api/v1/hardware/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<HardwareModel?> PatchHardwareAsync(int id, HardwareModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<HardwareModel, ResultModel<HardwareModel>>($"api/v1/hardware/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<HardwareModel?> DeleteHardwareAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<HardwareModel>>($"api/v1/hardware/{id}", cancellationToken);
        CheckResultForError(res);
        return res?.Payload;
    }

    public async Task<HardwareModel?> CheckoutHardwareAsync(int id, HardwareModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PostAsJsonAsync<HardwareModel, ResultModel<HardwareModel>>($"api/v1/hardware/{id}/checkout", model, cancellationToken);
        CheckResultForError(res);
        return res?.Payload;
    }

    public async Task<HardwareModel?> CheckinHardwareAsync(int id, HardwareModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PostAsJsonAsync<HardwareModel, ResultModel<HardwareModel>>($"api/v1/hardware/{id}/checkin", model, cancellationToken);
        CheckResultForError(res);
        return res?.Payload;
    }

    #endregion

    #region Category

    public IAsyncEnumerable<CategoryModel> GetCategoriesAsync(CancellationToken cancellationToken)
    {
        var res = GetListAsync<CategoryModel>("api/v1/categories", cancellationToken);
        return res;
    }

    public async Task<CategoryModel?> GetCategoryAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<CategoryModel>($"api/v1/categories/{id}", cancellationToken);
        return res;
    }

    public async Task<CategoryModel?> CreateCategoryAsync(CategoryModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<CategoryModel, ResultModel<CategoryModel>>("api/v1/categories", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<CategoryModel?> UpdateCategoryAsync(int id, CategoryModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<CategoryModel, ResultModel<CategoryModel>>($"api/v1/categories/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<CategoryModel?> PatchCategoryAsync(int id, CategoryModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<CategoryModel, ResultModel<CategoryModel>>($"api/v1/categories/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<CategoryModel?> DeleteCategoryAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<CategoryModel>>($"api/v1/categories/{id}", cancellationToken);
        CheckResultForError(res);
        return res?.Payload;
    }

    #endregion

    #region Departments

    public IAsyncEnumerable<DepartmentModel> GetDepartmentsAsync(CancellationToken cancellationToken)
    {
        var res = GetListAsync<DepartmentModel>("api/v1/departments", cancellationToken);
        return res;
    }

    public async Task<DepartmentModel?> GetDepartmentAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<DepartmentModel>($"api/v1/departments/{id}", cancellationToken);
        return res;
    }

    public async Task<DepartmentModel?> CreateDepartmentAsync(DepartmentModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<DepartmentModel, ResultModel<DepartmentModel>>("api/v1/departments", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<DepartmentModel?> UpdateDepartmentAsync(int id, DepartmentModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<DepartmentModel, ResultModel<DepartmentModel>>($"api/v1/departments/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<DepartmentModel?> PatchDepartmentAsync(int id, DepartmentModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<DepartmentModel, ResultModel<DepartmentModel>>($"api/v1/departments/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<DepartmentModel?> DeleteDepartmentAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<DepartmentModel>>($"api/v1/departments/{id}", cancellationToken);
        CheckResultForError(res);
        return res?.Payload;
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
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<ManufacturerModel>($"api/v1/manufacturers/{id}", cancellationToken);
        return res;
    }

    public async Task<ManufacturerModel?> CreateManufacturerAsync(ManufacturerModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<ManufacturerModel, ResultModel<ManufacturerModel>>("api/v1/manufacturers", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<ManufacturerModel?> UpdatManufacturerAsync(int id, ManufacturerModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<ManufacturerModel, ResultModel<ManufacturerModel>>($"api/v1/manufacturers/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<ManufacturerModel?> PatchManufacturerAsync(int id, ManufacturerModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<ManufacturerModel, ResultModel<ManufacturerModel>>($"api/v1/manufacturers/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<ManufacturerModel?> DeleteManufacturerAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<ManufacturerModel>> ($"api/v1/manufacturers/{id}", cancellationToken);
        CheckResultForError(res);
        return res?.Payload;
    }

    #endregion

    #region Models

    public IAsyncEnumerable<ModelModel> GetModelsAsync(CancellationToken cancellationToken)
    {
        var res = GetListAsync<ModelModel>("api/v1/models", cancellationToken);
        return res;
    }

    public async Task<ModelModel?> GetModelAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<ModelModel>($"api/v1/models/{id}", cancellationToken);
        return res;
    }

    public async Task<ModelModel?> CreateModelAsync(ModelModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<ModelModel, ResultModel<ModelModel>>("api/v1/models", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<ModelModel?> UpdateModelAsync(int id, ModelModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<ModelModel, ResultModel<ModelModel>>($"api/v1/models/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<ModelModel?> PatchModelAsync(int id, ModelModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<ModelModel, ResultModel<ModelModel>>($"api/v1/models/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<ModelModel?> DeleteModelAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<ModelModel>>($"api/v1/models/{id}", cancellationToken);
        CheckResultForError(res);
        return res?.Payload;
    }

    #endregion

    #region Users

    public IAsyncEnumerable<UserModel> GetUsersAsync(CancellationToken cancellationToken)
    {
        var res = GetListAsync<UserModel>("api/v1/users", cancellationToken);
        return res;
    }

    public async Task<UserModel?> GetUserAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<UserModel>($"api/v1/users/{id}", cancellationToken);
        return res;
    }

    public async Task<UserModel?> CreateUserAsync(UserModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<UserModel, ResultModel<UserModel>>("api/v1/users", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<UserModel?> UpdateUserAsync(int id, UserModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<UserModel, ResultModel<UserModel>>($"api/v1/users/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<UserModel?> PatchUserAsync(int id, UserModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<UserModel, ResultModel<UserModel>>($"api/v1/users/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<UserModel?> DeleteUserAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<UserModel>>($"api/v1/users/{id}", cancellationToken);
        CheckResultForError(res);
        return res?.Payload;
    }

    public async Task<UserModel?> GetUserMeAsync(CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await GetFromJsonAsync<UserModel>("api/v1/users/me", cancellationToken);
        return res;
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

    private static void CheckResultForError<T>(ResultModel<T>? result)
    {
        if (result != null && result.Status == Status.Error)
        {
            throw new WebServiceException(result.ToString());
        }
    }

    #endregion
}
