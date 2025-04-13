namespace SnipeITWebApi.Service;

// https://snipe-it.readme.io/reference/api-overview

// Image: https://github.com/snipe/snipe-it/issues/12350

internal class SnipeITService(Uri host, IAuthenticator? authenticator, string appName) 
    : JsonService(host, authenticator, appName, SourceGenerationContext.Default)
{
    private const int limit = 500;

    protected override string? AuthenticationTestUrl => "api/v1/hardware?limit=1&offset=0";
       
    protected override async Task ErrorCheckAsync(HttpResponseMessage response, string memberName, CancellationToken cancellationToken)
    {
        await base.ErrorCheckAsync(response, memberName, cancellationToken);

        string str = await response.Content.ReadAsStringAsync(cancellationToken);
        if (str.StartsWith("{\"status\":\"error\""))
        {
            var res = await ReadFromJsonAsync<ResultModel>(response, cancellationToken);
            throw new WebServiceException(res!.Messages);
        }
    }

    #region Assets

    public async Task<int> GetNumberOfHardwaresAsync(CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        var res = await GetFromJsonAsync<ListModel<HardwareModel>>("api/v1/hardware?limit=1&offset=0", cancellationToken);
        if (res != null && res.Rows != null)
        {
            return res.Total;
        }
        return 0;
    }
    public IAsyncEnumerable<HardwareModel> GetHardwaresAsync(CancellationToken cancellationToken)
    {
        var res = GetListAsync<HardwareModel>("api/v1/hardware", cancellationToken);
        return res;
    }

    public IAsyncEnumerable<HardwareModel> GetHardwaresByCategoryAsync(int category, CancellationToken cancellationToken)
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

    public async Task<HardwareChangeModel?> CreateHardwareAsync(HardwareChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<HardwareChangeModel, ResultModel<HardwareChangeModel>>("api/v1/hardware", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<HardwareChangeModel?> UpdateHardwareAsync(int id, HardwareChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<HardwareChangeModel, ResultModel<HardwareChangeModel>>($"api/v1/hardware/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<HardwareChangeModel?> PatchHardwareAsync(int id, HardwareChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<HardwareChangeModel, ResultModel<HardwareChangeModel>>($"api/v1/hardware/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<HardwareChangeModel?> DeleteHardwareAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<HardwareChangeModel>>($"api/v1/hardware/{id}", cancellationToken);
        CheckResultForError(res);
        return res?.Payload;
    }

    public async Task<HardwareChangeModel?> CheckoutHardwareAsync(int id, HardwareChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PostAsJsonAsync<HardwareChangeModel, ResultModel<HardwareChangeModel>>($"api/v1/hardware/{id}/checkout", model, cancellationToken);
        CheckResultForError(res);
        return res?.Payload;
    }

    public async Task<HardwareChangeModel?> CheckinHardwareAsync(int id, HardwareChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PostAsJsonAsync<HardwareChangeModel, ResultModel<HardwareChangeModel>>($"api/v1/hardware/{id}/checkin", model, cancellationToken);
        CheckResultForError(res);
        return res?.Payload;
    }

    #endregion

    #region Accessories

    public IAsyncEnumerable<AccessoryModel> GetAccessoriesAsync(CancellationToken cancellationToken)
    {
        var res = GetListAsync<AccessoryModel>("api/v1/accessories", cancellationToken);
        return res;
    }

    public async Task<AccessoryModel?> GetAccessoryAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<AccessoryModel>($"api/v1/accessories/{id}", cancellationToken);
        return res;
    }

    public async Task<AccessoryChangeModel?> CreateAccessoryAsync(AccessoryChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<AccessoryChangeModel, ResultModel<AccessoryChangeModel>>("api/v1/accessories", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<AccessoryChangeModel?> UpdateAccessoryAsync(int id, AccessoryChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<AccessoryChangeModel, ResultModel<AccessoryChangeModel>>($"api/v1/accessories/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<AccessoryChangeModel?> PatchAccessoryAsync(int id, AccessoryChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<AccessoryChangeModel, ResultModel<AccessoryChangeModel>>($"api/v1/accessories/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<AccessoryChangeModel?> DeleteAccessoryAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<AccessoryChangeModel>>($"api/v1/accessories/{id}", cancellationToken);
        CheckResultForError(res);
        return res?.Payload;
    }

    #endregion
     
    #region Categories

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

    public async Task<CategoryChangeModel?> CreateCategoryAsync(CategoryChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<CategoryChangeModel, ResultModel<CategoryChangeModel>>("api/v1/categories", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<CategoryChangeModel?> UpdateCategoryAsync(int id, CategoryChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<CategoryChangeModel, ResultModel<CategoryChangeModel>>($"api/v1/categories/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<CategoryChangeModel?> PatchCategoryAsync(int id, CategoryChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<CategoryChangeModel, ResultModel<CategoryChangeModel>>($"api/v1/categories/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<CategoryChangeModel?> DeleteCategoryAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<CategoryChangeModel>>($"api/v1/categories/{id}", cancellationToken);
        CheckResultForError(res);
        return res?.Payload;
    }

    #endregion

    #region Companies

    public IAsyncEnumerable<CompanyModel> GetCompaniesAsync(CancellationToken cancellationToken)
    {
        var res = GetListAsync<CompanyModel>("api/v1/companies", cancellationToken);
        return res;
    }

    public async Task<CompanyModel?> GetCompanyAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<CompanyModel>($"api/v1/companies/{id}", cancellationToken);
        return res;
    }

    public async Task<CompanyChangeModel?> CreateCompanyAsync(CompanyChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<CompanyChangeModel, ResultModel<CompanyChangeModel>>("api/v1/companies", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<CompanyChangeModel?> UpdateCompanyAsync(int id, CompanyChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<CompanyChangeModel, ResultModel<CompanyChangeModel>>($"api/v1/companies/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<CompanyChangeModel?> PatchCompanyAsync(int id, CompanyChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<CompanyChangeModel, ResultModel<CompanyChangeModel>>($"api/v1/companies/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<CompanyChangeModel?> DeleteCompanyAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<CompanyChangeModel>>($"api/v1/companies/{id}", cancellationToken);
        CheckResultForError(res);
        return res?.Payload;
    }

    #endregion

    #region Components

    //public IAsyncEnumerable<ComponentModel> GetComponentsAsync(CancellationToken cancellationToken)
    //{
    //    var res = GetListAsync<ComponentModel>("api/v1/components", cancellationToken);
    //    return res;
    //}

    public IAsyncEnumerable<ComponentModel> GetComponentsAsync(string? name, string? search, string? orderNumber, CancellationToken cancellationToken)
    {
        string req = CombineUrl("api/v1/components", ("name", name), ("search", search), ("order_number", orderNumber));
        var res = GetListAsync<ComponentModel>(req, cancellationToken);
        return res;
    }

    public async Task<ComponentModel?> GetComponentAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<ComponentModel>($"api/v1/components/{id}", cancellationToken);
        return res;
    }

    public async Task<ComponentChangeModel?> CreateComponentAsync(ComponentChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<ComponentChangeModel, ResultModel<ComponentChangeModel>>("api/v1/components", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<ComponentChangeModel?> UpdateComponentAsync(int id, ComponentChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<ComponentChangeModel, ResultModel<ComponentChangeModel>>($"api/v1/components/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<ComponentChangeModel?> PatchComponentAsync(int id, ComponentChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<ComponentChangeModel, ResultModel<ComponentChangeModel>>($"api/v1/components/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<ComponentChangeModel?> DeleteComponentAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<ComponentChangeModel>>($"api/v1/components/{id}", cancellationToken);
        CheckResultForError(res);
        return res?.Payload;
    }

    #endregion

    #region Consumables

    public IAsyncEnumerable<ConsumableModel> GetConsumablesAsync(CancellationToken cancellationToken)
    {
        var res = GetListAsync<ConsumableModel>("api/v1/consumables", cancellationToken);
        return res;
    }

    public async Task<ConsumableModel?> GetConsumableAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<ConsumableModel>($"api/v1/consumables/{id}", cancellationToken);
        return res;
    }

    public async Task<ConsumableChangeModel?> CreateConsumableAsync(ConsumableChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<ConsumableChangeModel, ResultModel<ConsumableChangeModel>>("api/v1/consumables", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<ConsumableChangeModel?> UpdateConsumableAsync(int id, ConsumableChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<ConsumableChangeModel, ResultModel<ConsumableChangeModel>>($"api/v1/consumables/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<ConsumableChangeModel?> PatchConsumableAsync(int id, ConsumableChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<ConsumableChangeModel, ResultModel<ConsumableChangeModel>>($"api/v1/consumables/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<ConsumableChangeModel?> DeleteConsumableAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<ConsumableChangeModel>>($"api/v1/consumables/{id}", cancellationToken);
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

    public async Task<DepartmentChangeModel?> CreateDepartmentAsync(DepartmentChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<DepartmentChangeModel, ResultModel<DepartmentChangeModel>>("api/v1/departments", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<DepartmentChangeModel?> UpdateDepartmentAsync(int id, DepartmentChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<DepartmentChangeModel, ResultModel<DepartmentChangeModel>>($"api/v1/departments/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<DepartmentChangeModel?> PatchDepartmentAsync(int id, DepartmentChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<DepartmentChangeModel, ResultModel<DepartmentChangeModel>>($"api/v1/departments/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<DepartmentChangeModel?> DeleteDepartmentAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<DepartmentChangeModel>>($"api/v1/departments/{id}", cancellationToken);
        CheckResultForError(res);
        return res?.Payload;
    }

    #endregion

    #region Fieldsets

    public IAsyncEnumerable<FieldsetModel> GetFieldsetsAsync(CancellationToken cancellationToken)
    {
        var res = GetListAsync<FieldsetModel>("api/v1/fieldsets", cancellationToken);
        return res;
    }

    public async Task<FieldsetModel?> GetFieldsetAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<FieldsetModel>($"api/v1/fieldsets/{id}", cancellationToken);
        return res;
    }

    public async Task<FieldsetChangeModel?> CreateFieldsetAsync(FieldsetChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<FieldsetChangeModel, ResultModel<FieldsetChangeModel>>("api/v1/fieldsets", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<FieldsetChangeModel?> UpdateFieldsetAsync(int id, FieldsetChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<FieldsetChangeModel, ResultModel<FieldsetChangeModel>>($"api/v1/fieldsets/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<FieldsetChangeModel?> PatchFieldsetAsync(int id, FieldsetChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<FieldsetChangeModel, ResultModel<FieldsetChangeModel>>($"api/v1/fieldsets/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<FieldsetChangeModel?> DeleteFieldsetAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<FieldsetChangeModel>>($"api/v1/fieldsets/{id}", cancellationToken);
        CheckResultForError(res);
        return res?.Payload;
    }

    #endregion

    #region Fields

    public IAsyncEnumerable<FieldModel> GetFieldsAsync(CancellationToken cancellationToken)
    {
        var res = GetListAsync<FieldModel>("api/v1/fields", cancellationToken);
        return res;
    }

    public async Task<FieldModel?> GetFieldAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<FieldModel>($"api/v1/fields/{id}", cancellationToken);
        return res;
    }

    public async Task<FieldChangeModel?> CreateFieldAsync(FieldChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<FieldChangeModel, ResultModel<FieldChangeModel>>("api/v1/fields", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<FieldChangeModel?> UpdateFieldAsync(int id, FieldChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<FieldChangeModel, ResultModel<FieldChangeModel>>($"api/v1/fields/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<FieldChangeModel?> PatchFieldAsync(int id, FieldChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<FieldChangeModel, ResultModel<FieldChangeModel>>($"api/v1/fields/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<FieldChangeModel?> DeleteFieldAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<FieldChangeModel>>($"api/v1/fields/{id}", cancellationToken);
        CheckResultForError(res);
        return res?.Payload;
    }

    #endregion

    #region Groups

    public IAsyncEnumerable<GroupModel> GetGroupsAsync(CancellationToken cancellationToken)
    {
        var res = GetListAsync<GroupModel>("api/v1/groups", cancellationToken);
        return res;
    }

    public async Task<GroupModel?> GetGroupAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<GroupModel>($"api/v1/groups/{id}", cancellationToken);
        return res;
    }

    public async Task<GroupChangeModel?> CreateGroupAsync(GroupChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<GroupChangeModel, ResultModel<GroupChangeModel>>("api/v1/groups", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<GroupChangeModel?> UpdateGroupAsync(int id, GroupChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<GroupChangeModel, ResultModel<GroupChangeModel>>($"api/v1/groups/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<GroupChangeModel?> PatchGroupAsync(int id, GroupChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<GroupChangeModel, ResultModel<GroupChangeModel>>($"api/v1/groups/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<GroupChangeModel?> DeleteGroupAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<GroupChangeModel>>($"api/v1/groups/{id}", cancellationToken);
        CheckResultForError(res);
        return res?.Payload;
    }

    #endregion

    #region Licenses

    public IAsyncEnumerable<LicenseModel> GetLicensesAsync(CancellationToken cancellationToken)
    {
        var res = GetListAsync<LicenseModel>("api/v1/licenses", cancellationToken);
        return res;
    }

    public async Task<LicenseModel?> GetLicenseAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<LicenseModel>($"api/v1/licenses/{id}", cancellationToken);
        return res;
    }

    public async Task<LicenseChangeModel?> CreateLicenseAsync(LicenseChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<LicenseChangeModel, ResultModel<LicenseChangeModel>>("api/v1/licenses", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<LicenseChangeModel?> UpdateLicenseAsync(int id, LicenseChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<LicenseChangeModel, ResultModel<LicenseChangeModel>>($"api/v1/licenses/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<LicenseChangeModel?> PatchLicenseAsync(int id, LicenseChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<LicenseChangeModel, ResultModel<LicenseChangeModel>>($"api/v1/licenses/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<LicenseChangeModel?> DeleteLicenseAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<LicenseChangeModel>>($"api/v1/licenses/{id}", cancellationToken);
        CheckResultForError(res);
        return res?.Payload;
    }

    #endregion

    #region Locations

    public IAsyncEnumerable<LocationModel> GetLocationsAsync(CancellationToken cancellationToken)
    {
        var res = GetListAsync<LocationModel>("api/v1/locations", cancellationToken);
        return res;
    }

    public async Task<LocationModel?> GetLocationAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<LocationModel>($"api/v1/locations/{id}", cancellationToken);
        return res;
    }

    public async Task<LocationChangeModel?> CreateLocationAsync(LocationChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<LocationChangeModel, ResultModel<LocationChangeModel>>("api/v1/locations", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<LocationChangeModel?> UpdateLocationAsync(int id, LocationChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<LocationChangeModel, ResultModel<LocationChangeModel>>($"api/v1/locations/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<LocationChangeModel?> PatchLocationAsync(int id, LocationChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<LocationChangeModel, ResultModel<LocationChangeModel>>($"api/v1/locations/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<LocationChangeModel?> DeleteLocationAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<LocationChangeModel>>($"api/v1/locations/{id}", cancellationToken);
        CheckResultForError(res);
        return res?.Payload;
    }

    #endregion

    #region Maintenances

    public IAsyncEnumerable<MaintenanceModel> GetMaintenancesAsync(CancellationToken cancellationToken)
    {
        var res = GetListAsync<MaintenanceModel>("api/v1/maintenances", cancellationToken);
        return res;
    }

    public async Task<MaintenanceModel?> GetMaintenanceAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<MaintenanceModel>($"api/v1/maintenances/{id}", cancellationToken);
        return res;
    }

    public async Task<MaintenanceChangeModel?> CreateMaintenanceAsync(MaintenanceChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<MaintenanceChangeModel, ResultModel<MaintenanceChangeModel>>("api/v1/maintenances", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<MaintenanceChangeModel?> UpdateMaintenanceAsync(int id, MaintenanceChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<MaintenanceChangeModel, ResultModel<MaintenanceChangeModel>>($"api/v1/maintenances/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<MaintenanceChangeModel?> PatchMaintenanceAsync(int id, MaintenanceChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<MaintenanceChangeModel, ResultModel<MaintenanceChangeModel>>($"api/v1/maintenances/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<MaintenanceChangeModel?> DeleteMaintenanceAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<MaintenanceChangeModel>>($"api/v1/maintenances/{id}", cancellationToken);
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

    public async Task<ManufacturerChangeModel?> CreateManufacturerAsync(ManufacturerChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<ManufacturerChangeModel, ResultModel<ManufacturerChangeModel>>("api/v1/manufacturers", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<ManufacturerChangeModel?> UpdatManufacturerAsync(int id, ManufacturerChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<ManufacturerChangeModel, ResultModel<ManufacturerChangeModel>>($"api/v1/manufacturers/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<ManufacturerChangeModel?> PatchManufacturerAsync(int id, ManufacturerChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<ManufacturerChangeModel, ResultModel<ManufacturerChangeModel>>($"api/v1/manufacturers/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<ManufacturerChangeModel?> DeleteManufacturerAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<ManufacturerChangeModel>> ($"api/v1/manufacturers/{id}", cancellationToken);
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

    public async Task<ModelChangeModel?> CreateModelAsync(ModelChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<ModelChangeModel, ResultModel<ModelChangeModel>>("api/v1/models", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<ModelChangeModel?> UpdateModelAsync(int id, ModelChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<ModelChangeModel, ResultModel<ModelChangeModel>>($"api/v1/models/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<ModelChangeModel?> PatchModelAsync(int id, ModelChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<ModelChangeModel, ResultModel<ModelChangeModel>>($"api/v1/models/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<ModelChangeModel?> DeleteModelAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<ModelChangeModel>>($"api/v1/models/{id}", cancellationToken);
        CheckResultForError(res);
        return res?.Payload;
    }

    #endregion

    #region StatusLabels

    public IAsyncEnumerable<StatusLabelModel> GetStatusLabelsAsync(CancellationToken cancellationToken)
    {
        var res = GetListAsync<StatusLabelModel>("api/v1/statuslabels", cancellationToken);
        return res;
    }

    public async Task<StatusLabelModel?> GetStatusLabelAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<StatusLabelModel>($"api/v1/statuslabels/{id}", cancellationToken);
        return res;
    }

    public async Task<StatusLabelChangeModel?> CreateStatusLabelAsync(StatusLabelChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<StatusLabelChangeModel, ResultModel<StatusLabelChangeModel>>("api/v1/statuslabels", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<StatusLabelChangeModel?> UpdateStatusLabelAsync(int id, StatusLabelChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<StatusLabelChangeModel, ResultModel<StatusLabelChangeModel>>($"api/v1/statuslabels/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<StatusLabelChangeModel?> PatchStatusLabelAsync(int id, StatusLabelChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<StatusLabelChangeModel, ResultModel<StatusLabelChangeModel>>($"api/v1/statuslabels/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<StatusLabelChangeModel?> DeleteStatusLabelAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<StatusLabelChangeModel>>($"api/v1/statuslabels/{id}", cancellationToken);
        CheckResultForError(res);
        return res?.Payload;
    }

    #endregion

    #region Suppliers

    public IAsyncEnumerable<SupplierModel> GetSuppliersAsync(CancellationToken cancellationToken)
    {
        var res = GetListAsync<SupplierModel>("api/v1/suppliers", cancellationToken);
        return res;
    }

    public async Task<SupplierModel?> GetSupplierAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<SupplierModel>($"api/v1/suppliers/{id}", cancellationToken);
        return res;
    }

    public async Task<SupplierChangeModel?> CreateSupplierAsync(SupplierChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<SupplierChangeModel, ResultModel<SupplierChangeModel>>("api/v1/suppliers", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<SupplierChangeModel?> UpdateSupplierAsync(int id, SupplierChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<SupplierChangeModel, ResultModel<SupplierChangeModel>>($"api/v1/suppliers/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<SupplierChangeModel?> PatchSupplierAsync(int id, SupplierChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<SupplierChangeModel, ResultModel<SupplierChangeModel>>($"api/v1/suppliers/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<SupplierChangeModel?> DeleteSupplierAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<SupplierChangeModel>>($"api/v1/suppliers/{id}", cancellationToken);
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

    public async Task<UserChangeModel?> CreateUserAsync(UserChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<UserChangeModel, ResultModel<UserChangeModel>>("api/v1/users", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<UserChangeModel?> UpdateUserAsync(int id, UserChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<UserChangeModel, ResultModel<UserChangeModel>>($"api/v1/users/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<UserChangeModel?> PatchUserAsync(int id, UserChangeModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<UserChangeModel, ResultModel<UserChangeModel>>($"api/v1/users/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<UserChangeModel?> DeleteUserAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<UserChangeModel>>($"api/v1/users/{id}", cancellationToken);
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

        int total = 1;
        int offset = 0;
        while (offset < total)
        {
            
            var res = await GetFromJsonAsync<ListModel<T>>(CombineUrl(requestUri, ("limit", limit), ("offset", offset)), cancellationToken, memberName);
            if (res != null && res.Rows != null)
            {

                //Debug.WriteLine($"Offset {offset} Limit {limit} ListModel total {res.Total} rows {res.Rows.Count}");

                foreach (var item in res.Rows)
                {
                    yield return item;
                }

                total = res.Total;
                offset += res.Rows.Count;
            }
            else
            {
                //Debug.WriteLine("Else");
                break;
            }
        }

        //Debug.WriteLine("End");
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
