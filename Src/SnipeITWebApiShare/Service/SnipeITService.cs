using System.ComponentModel;

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

    public async Task<AccessoryModel?> CreateAccessoryAsync(AccessoryModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<AccessoryModel, ResultModel<AccessoryModel>>("api/v1/accessories", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<AccessoryModel?> UpdateAccessoryAsync(int id, AccessoryModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<AccessoryModel, ResultModel<AccessoryModel>>($"api/v1/accessories/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<AccessoryModel?> PatchAccessoryAsync(int id, AccessoryModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<AccessoryModel, ResultModel<AccessoryModel>>($"api/v1/accessories/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<AccessoryModel?> DeleteAccessoryAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<AccessoryModel>>($"api/v1/accessories/{id}", cancellationToken);
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

    public async Task<CompanyModel?> CreateCompanyAsync(CompanyModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<CompanyModel, ResultModel<CompanyModel>>("api/v1/companies", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<CompanyModel?> UpdateCompanyAsync(int id, CompanyModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<CompanyModel, ResultModel<CompanyModel>>($"api/v1/companies/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<CompanyModel?> PatchCompanyAsync(int id, CompanyModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<CompanyModel, ResultModel<CompanyModel>>($"api/v1/companies/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<CompanyModel?> DeleteCompanyAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<CompanyModel>>($"api/v1/companies/{id}", cancellationToken);
        CheckResultForError(res);
        return res?.Payload;
    }

    #endregion

    #region Components

    public IAsyncEnumerable<ComponentModel> GetComponentsAsync(CancellationToken cancellationToken)
    {
        var res = GetListAsync<ComponentModel>("api/v1/components", cancellationToken);
        return res;
    }

    public async Task<ComponentModel?> GetComponentAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<ComponentModel>($"api/v1/components/{id}", cancellationToken);
        return res;
    }

    public async Task<ComponentModel?> CreateComponentAsync(ComponentModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<ComponentModel, ResultModel<ComponentModel>>("api/v1/components", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<ComponentModel?> UpdateComponentAsync(int id, ComponentModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<ComponentModel, ResultModel<ComponentModel>>($"api/v1/components/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<ComponentModel?> PatchComponentAsync(int id, ComponentModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<ComponentModel, ResultModel<ComponentModel>>($"api/v1/components/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<ComponentModel?> DeleteComponentAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<ComponentModel>>($"api/v1/components/{id}", cancellationToken);
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

    public async Task<ConsumableModel?> CreateConsumableAsync(ConsumableModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<ConsumableModel, ResultModel<ConsumableModel>>("api/v1/consumables", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<ConsumableModel?> UpdateConsumableAsync(int id, ConsumableModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<ConsumableModel, ResultModel<ConsumableModel>>($"api/v1/consumables/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<ConsumableModel?> PatchConsumableAsync(int id, ConsumableModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<ConsumableModel, ResultModel<ConsumableModel>>($"api/v1/consumables/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<ConsumableModel?> DeleteConsumableAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<ConsumableModel>>($"api/v1/consumables/{id}", cancellationToken);
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

    public async Task<FieldsetModel?> CreateFieldsetAsync(FieldsetModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<FieldsetModel, ResultModel<FieldsetModel>>("api/v1/fieldsets", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<FieldsetModel?> UpdateFieldsetAsync(int id, FieldsetModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<FieldsetModel, ResultModel<FieldsetModel>>($"api/v1/fieldsets/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<FieldsetModel?> PatchFieldsetAsync(int id, FieldsetModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<FieldsetModel, ResultModel<FieldsetModel>>($"api/v1/fieldsets/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<FieldsetModel?> DeleteFieldsetAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<FieldsetModel>>($"api/v1/fieldsets/{id}", cancellationToken);
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

    public async Task<FieldModel?> CreateFieldAsync(FieldModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<FieldModel, ResultModel<FieldModel>>("api/v1/fields", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<FieldModel?> UpdateFieldAsync(int id, FieldModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<FieldModel, ResultModel<FieldModel>>($"api/v1/fields/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<FieldModel?> PatchFieldAsync(int id, FieldModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<FieldModel, ResultModel<FieldModel>>($"api/v1/fields/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<FieldModel?> DeleteFieldAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<FieldModel>>($"api/v1/fields/{id}", cancellationToken);
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

    public async Task<GroupModel?> CreateGroupAsync(GroupModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<GroupModel, ResultModel<GroupModel>>("api/v1/groups", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<GroupModel?> UpdateGroupAsync(int id, GroupModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<GroupModel, ResultModel<GroupModel>>($"api/v1/groups/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<GroupModel?> PatchGroupAsync(int id, GroupModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<GroupModel, ResultModel<GroupModel>>($"api/v1/groups/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<GroupModel?> DeleteGroupAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<GroupModel>>($"api/v1/groups/{id}", cancellationToken);
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

    public async Task<LicenseModel?> CreateLicenseAsync(LicenseModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<LicenseModel, ResultModel<LicenseModel>>("api/v1/licenses", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<LicenseModel?> UpdateLicenseAsync(int id, LicenseModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<LicenseModel, ResultModel<LicenseModel>>($"api/v1/licenses/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<LicenseModel?> PatchLicenseAsync(int id, LicenseModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<LicenseModel, ResultModel<LicenseModel>>($"api/v1/licenses/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<LicenseModel?> DeleteLicenseAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<LicenseModel>>($"api/v1/licenses/{id}", cancellationToken);
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

    public async Task<LocationModel?> CreateLocationAsync(LocationModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<LocationModel, ResultModel<LocationModel>>("api/v1/locations", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<LocationModel?> UpdateLocationAsync(int id, LocationModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<LocationModel, ResultModel<LocationModel>>($"api/v1/locations/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<LocationModel?> PatchLocationAsync(int id, LocationModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<LocationModel, ResultModel<LocationModel>>($"api/v1/locations/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<LocationModel?> DeleteLocationAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<LocationModel>>($"api/v1/locations/{id}", cancellationToken);
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

    public async Task<MaintenanceModel?> CreateMaintenanceAsync(MaintenanceModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<MaintenanceModel, ResultModel<MaintenanceModel>>("api/v1/maintenances", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<MaintenanceModel?> UpdateMaintenanceAsync(int id, MaintenanceModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<MaintenanceModel, ResultModel<MaintenanceModel>>($"api/v1/maintenances/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<MaintenanceModel?> PatchMaintenanceAsync(int id, MaintenanceModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<MaintenanceModel, ResultModel<MaintenanceModel>>($"api/v1/maintenances/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<MaintenanceModel?> DeleteMaintenanceAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<MaintenanceModel>>($"api/v1/maintenances/{id}", cancellationToken);
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

    public async Task<StatusLabelModel?> CreateStatusLabelAsync(StatusLabelModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<StatusLabelModel, ResultModel<StatusLabelModel>>("api/v1/statuslabels", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<StatusLabelModel?> UpdateStatusLabelAsync(int id, StatusLabelModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<StatusLabelModel, ResultModel<StatusLabelModel>>($"api/v1/statuslabels/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<StatusLabelModel?> PatchStatusLabelAsync(int id, StatusLabelModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<StatusLabelModel, ResultModel<StatusLabelModel>>($"api/v1/statuslabels/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<StatusLabelModel?> DeleteStatusLabelAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<StatusLabelModel>>($"api/v1/statuslabels/{id}", cancellationToken);
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

    public async Task<SupplierModel?> CreateSupplierAsync(SupplierModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<SupplierModel, ResultModel<SupplierModel>>("api/v1/suppliers", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<SupplierModel?> UpdateSupplierAsync(int id, SupplierModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<SupplierModel, ResultModel<SupplierModel>>($"api/v1/suppliers/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<SupplierModel?> PatchSupplierAsync(int id, SupplierModel model, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<SupplierModel, ResultModel<SupplierModel>>($"api/v1/suppliers/{id}", model, cancellationToken);
        CheckResultForError(res);
        return res!.Payload;
    }

    public async Task<SupplierModel?> DeleteSupplierAsync(int id, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<SupplierModel>>($"api/v1/suppliers/{id}", cancellationToken);
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
