namespace SnipeITWebApi;

/// <summary>
/// Provides methods to interact with the Snipe-IT API for managing assets, accessories, categories, and more.
/// </summary>
/// <remarks>
/// The return JSON from create, update, patch, and delete operations is not identical to the JSON returned by get operations.
/// As a result, the return JSON is not used in these methods.
/// </remarks>
public class SnipeIT : JsonService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SnipeIT"/> class using a store key to retrieve the service host and authenticator.
    /// </summary>
    /// <param name="storeKey">The key used to retrieve the service host and authenticator from the key store.</param>
    /// <param name="appName">The name of the application using the service.</param>
    public SnipeIT(string storeKey, string appName) : base(storeKey, appName, SourceGenerationContext.Default)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SnipeIT"/> class with a specified service host and authenticator.
    /// </summary>
    /// <param name="host">The service host URI.</param>
    /// <param name="authenticator">The authenticator to use for the service, or null if not required.</param>
    /// <param name="appName">The name of the application using the service.</param>
    public SnipeIT(Uri host, IAuthenticator? authenticator, string appName) : base(host, authenticator, appName, SourceGenerationContext.Default)
    { }

    /// <summary>
    /// Configures the provided <see cref="HttpClient"/> instance with specific default headers required for API requests.
    /// This includes setting the User-Agent, Accept, and API version headers.
    /// </summary>
    /// <param name="client">The <see cref="HttpClient"/> to configure for GitHub API usage.</param>
    /// <param name="appName">The name of the application, used as the User-Agent header value.</param>
    protected override void InitializeClient(HttpClient client, string appName)
    {
        client.DefaultRequestHeaders.Add("User-Agent", appName);
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        //client.DefaultRequestHeaders.Add("Content-Type", "application/json");   // does not run with Content-Type
    }

    protected override string? AuthenticationTestUrl => "api/v1/hardware?limit=1&offset=0";

    protected override async Task ErrorCheckAsync(HttpResponseMessage response, string memberName, CancellationToken cancellationToken)
    {
        await base.ErrorCheckAsync(response, memberName, cancellationToken);

        string str = await response.Content.ReadAsStringAsync(cancellationToken);
        if (str.StartsWith("{\"status\":\"error\""))
        {
            //var res = await ReadFromJsonAsync<ResultModel>(response, cancellationToken);

            JsonTypeInfo<ResultModel> jsonTypeInfo = (JsonTypeInfo<ResultModel>)context.GetTypeInfo(typeof(ResultModel))!;
            var res = await response.Content.ReadFromJsonAsync<ResultModel>(jsonTypeInfo, cancellationToken);

            throw new WebServiceException(res!.Messages);
        }
    }

    #region Assets

    /// <summary>
    /// Gets the total number of hardware assets.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The total number of hardware assets.</returns>
    public async Task<int> GetNumberOfHardwaresAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await GetFromJsonAsync<ListModel<HardwareModel>>("api/v1/hardware?limit=1&offset=0", cancellationToken);
        if (res != null && res.Rows != null)
        {
            return res.Total;
        }
        return 0;
    }

    /// <summary>
    /// Retrieves all hardware assets asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An asynchronous stream of <see cref="Hardware"/> objects.</returns>
    public async IAsyncEnumerable<Hardware> GetHardwaresAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = GetListAsync<HardwareModel>("api/v1/hardware", cancellationToken);
        int i = 0;
        await foreach (var item in res)
        {
            i++;
            yield return item.CastModel<Hardware>()!;
        }
    }

    /// <summary>
    /// Retrieves hardware assets by category asynchronously.
    /// </summary>
    /// <param name="category">The ID of the category.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An asynchronous stream of <see cref="Hardware"/> objects.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the category ID is less than or equal to zero.</exception>
    public async IAsyncEnumerable<Hardware> GetHardwaresByCategoryAsync(int category, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(category, 0, nameof(category));

        var res = GetListAsync<HardwareModel>(CombineUrl("api/v1/hardware", ("category_id", category)), cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Hardware>()!;
        }
    }

    /// <summary>
    /// Retrieves a specific hardware asset by its ID.
    /// </summary>
    /// <param name="id">The ID of the hardware asset.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The <see cref="Hardware"/> object if found; otherwise, null.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task<Hardware?> GetHardwareAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<HardwareModel>($"api/v1/hardware/{id}", cancellationToken);
        return res.CastModel<Hardware>();
    }

    /// <summary>
    /// Creates a new hardware asset.
    /// </summary>
    /// <param name="item">The hardware asset to create.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The ID of the created hardware asset.</returns>
    public async Task<int> CreateHardwareAsync(Hardware item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<HardwareChangeModel, ResultModel<HardwareChangeModel>>("api/v1/hardware", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
        return res!.Payload?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing hardware asset.
    /// </summary>
    /// <param name="id">The ID of the hardware asset to update.</param>
    /// <param name="item">The updated hardware asset.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateHardwareAsync(int id, Hardware item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<HardwareChangeModel, ResultModel<HardwareChangeModel>>($"api/v1/hardware/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Patches an existing hardware asset.
    /// </summary>
    /// <param name="id">The ID of the hardware asset to patch.</param>
    /// <param name="item">The patched hardware asset.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchHardwareAsync(int id, Hardware item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<HardwareChangeModel, ResultModel<HardwareChangeModel>>($"api/v1/hardware/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Deletes a hardware asset.
    /// </summary>
    /// <param name="id">The ID of the hardware asset to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteHardwareAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<HardwareChangeModel>>($"api/v1/hardware/{id}", cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Checks out a hardware asset.
    /// </summary>
    /// <param name="id">The ID of the hardware asset to check out.</param>
    /// <param name="item">The hardware asset details for checkout.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The <see cref="Hardware"/> object after checkout.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task<Hardware?> CheckoutHardwareAsync(int id, Hardware item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PostAsJsonAsync<HardwareChangeModel, ResultModel<HardwareChangeModel>>($"api/v1/hardware/{id}/checkout", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
        return res?.Payload.CastModel<Hardware>();

    }

    /// <summary>
    /// Checks in a hardware asset.
    /// </summary>
    /// <param name="id">The ID of the hardware asset to check in.</param>
    /// <param name="item">The hardware asset details for check-in.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The <see cref="Hardware"/> object after check-in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task<Hardware?> CheckinHardwareAsync(int id, Hardware item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PostAsJsonAsync<HardwareChangeModel, ResultModel<HardwareChangeModel>>($"api/v1/hardware/{id}/checkin", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
        return res?.Payload.CastModel<Hardware>(); 
    }

    #endregion

    #region Accessories

    /// <summary>
    /// Retrieves all accessories asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An asynchronous stream of <see cref="Accessory"/> objects.</returns>
    public async IAsyncEnumerable<Accessory> GetAccessoriesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = GetListAsync<AccessoryModel>("api/v1/accessories", cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Accessory>()!;
        }
    }

    /// <summary>
    /// Retrieves a specific accessory by its ID.
    /// </summary>
    /// <param name="id">The ID of the accessory.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The <see cref="Accessory"/> object if found; otherwise, null.</returns>
    public async Task<Accessory?> GetAccessoryAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<AccessoryModel>($"api/v1/accessories/{id}", cancellationToken);
        return res.CastModel<Accessory>();
    }

    /// <summary>
    /// Creates a new accessory.
    /// </summary>
    /// <param name="item">The accessory to create.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The ID of the created accessory.</returns>
    public async Task<int> CreateAccessoryAsync(Accessory item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<AccessoryChangeModel, ResultModel<AccessoryChangeModel>>("api/v1/accessories", item.ToChange(), cancellationToken);
        CheckResultForError(res);
        return res!.Payload?.Id ?? 0; 
    }

    /// <summary>
    /// Updates an existing accessory.
    /// </summary>
    /// <param name="id">The ID of the accessory to update.</param>
    /// <param name="item">The updated accessory.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateAccessoryAsync(int id, Accessory item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<AccessoryChangeModel, ResultModel<AccessoryChangeModel>>($"api/v1/accessories/{id}", item.ToChange(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Patches an existing accessory.
    /// </summary>
    /// <param name="id">The ID of the accessory to patch.</param>
    /// <param name="item">The patched accessory.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchAccessoryAsync(int id, Accessory item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<AccessoryChangeModel, ResultModel<AccessoryChangeModel>>($"api/v1/accessories/{id}", item.ToChange(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Deletes an accessory.
    /// </summary>
    /// <param name="id">The ID of the accessory to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteAccessoryAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<AccessoryChangeModel>>($"api/v1/accessories/{id}", cancellationToken);
        CheckResultForError(res);
    }

    #endregion

    #region Categories

    /// <summary>
    /// Retrieves all categories asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An asynchronous stream of <see cref="Category"/> objects.</returns>
    public async IAsyncEnumerable<Category> GetCategoriesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = GetListAsync<CategoryModel>("api/v1/categories", cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Category>()!;
        }
    }

    /// <summary>
    /// Retrieves a specific category by its ID.
    /// </summary>
    /// <param name="id">The ID of the category.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The <see cref="Category"/> object if found; otherwise, null.</returns>
    public async Task<Category?> GetCategoryAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<CategoryModel>($"api/v1/categories/{id}", cancellationToken);
        return res.CastModel<Category>(); 
    }

    /// <summary>
    /// Creates a new category.
    /// </summary>
    /// <param name="item">The category to create.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The ID of the created category.</returns>
    public async Task<int> CreateCategoryAsync(Category item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<CategoryChangeModel, ResultModel<CategoryChangeModel>>("api/v1/categories", item.ToCreate(), cancellationToken);
        CheckResultForError(res);
        return res!.Payload?.Id ?? 0; 
    }

    /// <summary>
    /// Updates an existing category.
    /// </summary>
    /// <param name="id">The ID of the category to update.</param>
    /// <param name="item">The updated category.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateCategoryAsync(int id, Category item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<CategoryChangeModel, ResultModel<CategoryChangeModel>>($"api/v1/categories/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Patches an existing category.
    /// </summary>
    /// <param name="id">The ID of the category to patch.</param>
    /// <param name="item">The patched category.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchCategoryAsync(int id, Category item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<CategoryChangeModel, ResultModel<CategoryChangeModel>>($"api/v1/categories/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Deletes a category.
    /// </summary>
    /// <param name="id">The ID of the category to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteCategoryAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<CategoryChangeModel>>($"api/v1/categories/{id}", cancellationToken);
        CheckResultForError(res);
    }

    #endregion

    #region Companies

    /// <summary>
    /// Retrieves all companies asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An asynchronous stream of <see cref="Company"/> objects.</returns>
    public async IAsyncEnumerable<Company> GetCompaniesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = GetListAsync<CompanyModel>("api/v1/companies", cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Company>()!;
        }
    }

    /// <summary>
    /// Retrieves a specific company by its ID.
    /// </summary>
    /// <param name="id">The ID of the company.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The <see cref="Company"/> object if found; otherwise, null.</returns>
    public async Task<Company?> GetCompanyAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<CompanyModel>($"api/v1/companies/{id}", cancellationToken);
        return res.CastModel<Company>();
    }

    /// <summary>
    /// Creates a new company.
    /// </summary>
    /// <param name="item">The company to create.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The ID of the created company.</returns>
    public async Task<int> CreateCompanyAsync(Company item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<CompanyChangeModel, ResultModel<CompanyChangeModel>>("api/v1/companies", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
        return res!.Payload?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing company.
    /// </summary>
    /// <param name="id">The ID of the company to update.</param>
    /// <param name="item">The updated company.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateCompanyAsync(int id, Company item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<CompanyChangeModel, ResultModel<CompanyChangeModel>>($"api/v1/companies/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Patches an existing company.
    /// </summary>
    /// <param name="id">The ID of the company to patch.</param>
    /// <param name="item">The patched company.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchCompanyAsync(int id, Company item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<CompanyChangeModel, ResultModel<CompanyChangeModel>>($"api/v1/companies/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Deletes a company.
    /// </summary>
    /// <param name="id">The ID of the company to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteCompanyAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<CompanyChangeModel>>($"api/v1/companies/{id}", cancellationToken);
        CheckResultForError(res);
    }

    #endregion

    #region Components

    /// <summary>
    /// Retrieves all components asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An asynchronous stream of <see cref="Component"/> objects.</returns>
    public async IAsyncEnumerable<Component> GetComponentsAsync([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = GetListAsync<ComponentModel>("api/v1/components", cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Component>()!;
        }
    }

    /// <summary>
    /// Retrieves components asynchronously with optional filters.
    /// </summary>
    /// <param name="name">The name of the component to filter by.</param>
    /// <param name="search">A search term to filter components.</param>
    /// <param name="orderNumber">The order number to filter components.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An asynchronous stream of <see cref="Component"/> objects.</returns>
    public async IAsyncEnumerable<Component> GetComponentsAsync(
        string? name = null,
        string? search = null,
        string? orderNumber = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        string req = CombineUrl("api/v1/components", ("name", name), ("search", search), ("order_number", orderNumber));
        var res = GetListAsync<ComponentModel>(req, cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Component>()!;
        }
    }

    /// <summary>
    /// Retrieves a specific component by its ID.
    /// </summary>
    /// <param name="id">The ID of the component.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The <see cref="Component"/> object if found; otherwise, null.</returns>
    public async Task<Component?> GetComponentAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<ComponentModel>($"api/v1/components/{id}", cancellationToken);
        return res.CastModel<Component>();
    }

    /// <summary>
    /// Creates a new component.
    /// </summary>
    /// <param name="item">The component to create.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The ID of the created component.</returns>
    public async Task<int> CreateComponentAsync(Component item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<ComponentChangeModel, ResultModel<ComponentChangeModel>>("api/v1/components", item.ToCreate(), cancellationToken);
        CheckResultForError(res);
        return res!.Payload?.Id ?? 0; 
    }

    /// <summary>
    /// Updates an existing component.
    /// </summary>
    /// <param name="id">The ID of the component to update.</param>
    /// <param name="item">The updated component.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateComponentAsync(int id, Component item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<ComponentChangeModel, ResultModel<ComponentChangeModel>>($"api/v1/components/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Patches an existing component.
    /// </summary>
    /// <param name="id">The ID of the component to patch.</param>
    /// <param name="item">The patched component.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchComponentAsync(int id, Component item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<ComponentChangeModel, ResultModel<ComponentChangeModel>>($"api/v1/components/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Deletes a component.
    /// </summary>
    /// <param name="id">The ID of the component to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteComponentAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<ComponentChangeModel>>($"api/v1/components/{id}", cancellationToken);
        CheckResultForError(res);
    }

    #endregion

    #region Consumables

    /// <summary>
    /// Retrieves all consumables asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An asynchronous stream of <see cref="Consumable"/> objects.</returns>
    public async IAsyncEnumerable<Consumable> GetConsumablesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = GetListAsync<ConsumableModel>("api/v1/consumables", cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Consumable>()!;
        }
    }

    /// <summary>
    /// Retrieves a specific consumable by its ID.
    /// </summary>
    /// <param name="id">The ID of the consumable.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The <see cref="Consumable"/> object if found; otherwise, null.</returns>
    public async Task<Consumable?> GetConsumableAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<ConsumableModel>($"api/v1/consumables/{id}", cancellationToken);
        return res.CastModel<Consumable>();
    }

    /// <summary>
    /// Creates a new consumable.
    /// </summary>
    /// <param name="item">The consumable to create.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The ID of the created consumable.</returns>
    public async Task<int> CreateConsumableAsync(Consumable item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<ConsumableChangeModel, ResultModel<ConsumableChangeModel>>("api/v1/consumables", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
        return res!.Payload?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing consumable.
    /// </summary>
    /// <param name="id">The ID of the consumable to update.</param>
    /// <param name="item">The updated consumable.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateConsumableAsync(int id, Consumable item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<ConsumableChangeModel, ResultModel<ConsumableChangeModel>>($"api/v1/consumables/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Patches an existing consumable.
    /// </summary>
    /// <param name="id">The ID of the consumable to patch.</param>
    /// <param name="item">The patched consumable.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchConsumableAsync(int id, Consumable item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<ConsumableChangeModel, ResultModel<ConsumableChangeModel>>($"api/v1/consumables/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Deletes a consumable.
    /// </summary>
    /// <param name="id">The ID of the consumable to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteConsumableAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<ConsumableChangeModel>>($"api/v1/consumables/{id}", cancellationToken);
        CheckResultForError(res);
    }

    #endregion

    #region Departments

    /// <summary>
    /// Retrieves all departments asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An asynchronous stream of <see cref="Department"/> objects.</returns>
    public async IAsyncEnumerable<Department> GetDepartmentsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = GetListAsync<DepartmentModel>("api/v1/departments", cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Department>()!;
        }
    }

    /// <summary>
    /// Retrieves a specific department by its ID.
    /// </summary>
    /// <param name="id">The ID of the department.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The <see cref="Department"/> object if found; otherwise, null.</returns>
    public async Task<Department?> GetDepartmentAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<DepartmentModel>($"api/v1/departments/{id}", cancellationToken);

        return res.CastModel<Department>();
    }

    /// <summary>
    /// Creates a new department.
    /// </summary>
    /// <param name="item">The department to create.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The ID of the created department.</returns>
    public async Task<int> CreateDepartmentAsync(Department item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<DepartmentChangeModel, ResultModel<DepartmentChangeModel>>("api/v1/departments", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
        return res!.Payload?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing department.
    /// </summary>
    /// <param name="id">The ID of the department to update.</param>
    /// <param name="item">The updated department.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateDepartmentAsync(int id, Department item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<DepartmentChangeModel, ResultModel<DepartmentChangeModel>>($"api/v1/departments/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Patches an existing department.
    /// </summary>
    /// <param name="id">The ID of the department to patch.</param>
    /// <param name="item">The patched department.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchDepartmentAsync(int id, Department item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<DepartmentChangeModel, ResultModel<DepartmentChangeModel>>($"api/v1/departments/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Deletes a department.
    /// </summary>
    /// <param name="id">The ID of the department to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteDepartmentAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<DepartmentChangeModel>>($"api/v1/departments/{id}", cancellationToken);
        CheckResultForError(res);
    }

    #endregion

    #region Fieldsets

    /// <summary>
    /// Retrieves all fieldsets asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An asynchronous stream of <see cref="Fieldset"/> objects.</returns>
    public async IAsyncEnumerable<Fieldset> GetFieldsetsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = GetListAsync<FieldsetModel>("api/v1/fieldsets", cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Fieldset>()!;
        }
    }

    /// <summary>
    /// Retrieves a specific fieldset by its ID.
    /// </summary>
    /// <param name="id">The ID of the fieldset.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The <see cref="Fieldset"/> object if found; otherwise, null.</returns>
    public async Task<Fieldset?> GetFieldsetAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<FieldsetModel>($"api/v1/fieldsets/{id}", cancellationToken);
        return res.CastModel<Fieldset>();
    }

    /// <summary>
    /// Creates a new fieldset.
    /// </summary>
    /// <param name="item">The fieldset to create.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The ID of the created fieldset.</returns>
    public async Task<int> CreateFieldsetAsync(Fieldset item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<FieldsetChangeModel, ResultModel<FieldsetChangeModel>>("api/v1/fieldsets", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
        return res!.Payload?.Id ?? 0;        
    }

    /// <summary>
    /// Updates an existing fieldset.
    /// </summary>
    /// <param name="id">The ID of the fieldset to update.</param>
    /// <param name="item">The updated fieldset.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateFieldsetAsync(int id, Fieldset item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<FieldsetChangeModel, ResultModel<FieldsetChangeModel>>($"api/v1/fieldsets/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Patches an existing fieldset.
    /// </summary>
    /// <param name="id">The ID of the fieldset to patch.</param>
    /// <param name="item">The patched fieldset.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchFieldsetAsync(int id, Fieldset item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<FieldsetChangeModel, ResultModel<FieldsetChangeModel>>($"api/v1/fieldsets/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Deletes a fieldset.
    /// </summary>
    /// <param name="id">The ID of the fieldset to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteFieldsetAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<FieldsetChangeModel>>($"api/v1/fieldsets/{id}", cancellationToken);
        CheckResultForError(res);
    }

    #endregion

    #region Fields

    /// <summary>
    /// Retrieves all fields asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An asynchronous stream of <see cref="Field"/> objects.</returns>
    public async IAsyncEnumerable<Field> GetFieldsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = GetListAsync<FieldModel>("api/v1/fields", cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Field>()!;
        }
    }

    /// <summary>
    /// Retrieves a specific field by its ID.
    /// </summary>
    /// <param name="id">The ID of the field.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The <see cref="Field"/> object if found; otherwise, null.</returns>
    public async Task<Field?> GetFieldAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<FieldModel>($"api/v1/fields/{id}", cancellationToken);
        return res.CastModel<Field>();
    }

    /// <summary>
    /// Creates a new field.
    /// </summary>
    /// <param name="item">The field to create.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The ID of the created field.</returns>
    public async Task<int> CreateFieldAsync(Field item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<FieldChangeModel, ResultModel<FieldChangeModel>>("api/v1/fields", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
        return res!.Payload?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing field.
    /// </summary>
    /// <param name="id">The ID of the field to update.</param>
    /// <param name="item">The updated field.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateFieldAsync(int id, Field item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<FieldChangeModel, ResultModel<FieldChangeModel>>($"api/v1/fields/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Patches an existing field.
    /// </summary>
    /// <param name="id">The ID of the field to patch.</param>
    /// <param name="item">The patched field.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchFieldAsync(int id, Field item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<FieldChangeModel, ResultModel<FieldChangeModel>>($"api/v1/fields/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Deletes a field.
    /// </summary>
    /// <param name="id">The ID of the field to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteFieldAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<FieldChangeModel>>($"api/v1/fields/{id}", cancellationToken);
        CheckResultForError(res);
    }

    #endregion

    #region Groups

    /// <summary>
    /// Retrieves all groups asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An asynchronous stream of <see cref="Group"/> objects.</returns>
    public async IAsyncEnumerable<Group> GetGroupsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = GetListAsync<GroupModel>("api/v1/groups", cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Group>()!;
        }
    }

    /// <summary>
    /// Retrieves a specific group by its ID.
    /// </summary>
    /// <param name="id">The ID of the group.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The <see cref="Group"/> object if found; otherwise, null.</returns>
    public async Task<Group?> GetGroupAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<GroupModel>($"api/v1/groups/{id}", cancellationToken);
        return res.CastModel<Group>();
    }

    /// <summary>
    /// Creates a new group.
    /// </summary>
    /// <param name="item">The group to create.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The ID of the created group.</returns>
    public async Task<int> CreateGroupAsync(Group item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<GroupChangeModel, ResultModel<BaseChangeModel>>("api/v1/groups", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
        return res!.Payload?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing group.
    /// </summary>
    /// <param name="id">The ID of the group to update.</param>
    /// <param name="item">The updated group.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateGroupAsync(int id, Group item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<GroupChangeModel, ResultModel<GroupChangeModel>>($"api/v1/groups/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Patches an existing group.
    /// </summary>
    /// <param name="id">The ID of the group to patch.</param>
    /// <param name="item">The patched group.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchGroupAsync(int id, Group item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<GroupChangeModel, ResultModel<GroupChangeModel>>($"api/v1/groups/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Deletes a group.
    /// </summary>
    /// <param name="id">The ID of the group to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteGroupAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<GroupChangeModel>>($"api/v1/groups/{id}", cancellationToken);
        CheckResultForError(res);
    }

    #endregion

    #region Licenses

    /// <summary>
    /// Retrieves all licenses asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An asynchronous stream of <see cref="License"/> objects.</returns>
    public async IAsyncEnumerable<License> GetLicensesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = GetListAsync<LicenseModel>("api/v1/licenses", cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<License>()!;
        }
    }

    /// <summary>
    /// Retrieves a specific license by its ID.
    /// </summary>
    /// <param name="id">The ID of the license.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The <see cref="License"/> object if found; otherwise, null.</returns>
    public async Task<License?> GetLicenseAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<LicenseModel>($"api/v1/licenses/{id}", cancellationToken);
        return res.CastModel<License>();
    }

    /// <summary>
    /// Creates a new license.
    /// </summary>
    /// <param name="item">The license to create.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The ID of the created license.</returns>
    public async Task<int> CreateLicenseAsync(License item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<LicenseChangeModel, ResultModel<LicenseChangeModel>>("api/v1/licenses", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
        return res!.Payload?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing license.
    /// </summary>
    /// <param name="id">The ID of the license to update.</param>
    /// <param name="item">The updated license.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateLicenseAsync(int id, License item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<LicenseChangeModel, ResultModel<LicenseChangeModel>>($"api/v1/licenses/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Patches an existing license.
    /// </summary>
    /// <param name="id">The ID of the license to patch.</param>
    /// <param name="item">The patched license.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchLicenseAsync(int id, License item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<LicenseChangeModel, ResultModel<LicenseChangeModel>>($"api/v1/licenses/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
   }

    /// <summary>
    /// Deletes a license.
    /// </summary>
    /// <param name="id">The ID of the license to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteLicenseAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<LicenseChangeModel>>($"api/v1/licenses/{id}", cancellationToken);
        CheckResultForError(res);
    }

    #endregion

    #region Locations

    /// <summary>
    /// Retrieves all locations asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An asynchronous stream of <see cref="Location"/> objects.</returns>
    public async IAsyncEnumerable<Location> GetLocationsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = GetListAsync<LocationModel>("api/v1/locations", cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Location>()!;
        }
    }

    /// <summary>
    /// Retrieves a specific location by its ID.
    /// </summary>
    /// <param name="id">The ID of the location.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The <see cref="Location"/> object if found; otherwise, null.</returns>
    public async Task<Location?> GetLocationAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<LocationModel>($"api/v1/locations/{id}", cancellationToken);
        return res.CastModel<Location>();
    }

    /// <summary>
    /// Creates a new location.
    /// </summary>
    /// <param name="item">The location to create.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The ID of the created location.</returns>
    public async Task<int> CreateLocationAsync(Location item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<LocationChangeModel, ResultModel<LocationChangeModel>>("api/v1/locations", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
        return res!.Payload?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing location.
    /// </summary>
    /// <param name="id">The ID of the location to update.</param>
    /// <param name="item">The updated location.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateLocationAsync(int id, Location item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<LocationChangeModel, ResultModel<LocationChangeModel>>($"api/v1/locations/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Patches an existing location.
    /// </summary>
    /// <param name="id">The ID of the location to patch.</param>
    /// <param name="item">The patched location.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchLocationAsync(int id, Location item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<LocationChangeModel, ResultModel<LocationChangeModel>>($"api/v1/locations/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Deletes a location.
    /// </summary>
    /// <param name="id">The ID of the location to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteLocationAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<LocationChangeModel>>($"api/v1/locations/{id}", cancellationToken);
        CheckResultForError(res);
    }

    #endregion

    #region Maintenances

    /// <summary>
    /// Retrieves all maintenances asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An asynchronous stream of <see cref="Maintenance"/> objects.</returns>
    public async IAsyncEnumerable<Maintenance> GetMaintenancesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = GetListAsync<MaintenanceModel>("api/v1/maintenances", cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Maintenance>()!;
        }
    }

    /// <summary>
    /// Retrieves a specific maintenance by its ID.
    /// </summary>
    /// <param name="id">The ID of the maintenance.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The <see cref="Maintenance"/> object if found; otherwise, null.</returns>
    public async Task<Maintenance?> GetMaintenanceAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<MaintenanceModel>($"api/v1/maintenances/{id}", cancellationToken);
        return res.CastModel<Maintenance>();
    }

    /// <summary>
    /// Creates a new maintenance record.
    /// </summary>
    /// <param name="item">The maintenance record to create.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The ID of the created maintenance record.</returns>
    public async Task<int> CreateMaintenanceAsync(Maintenance item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<MaintenanceChangeModel, ResultModel<MaintenanceChangeModel>>("api/v1/maintenances", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
        return res!.Payload?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing maintenance record.
    /// </summary>
    /// <param name="id">The ID of the maintenance record to update.</param>
    /// <param name="item">The updated maintenance record.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateMaintenanceAsync(int id, Maintenance item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<MaintenanceChangeModel, ResultModel<MaintenanceChangeModel>>($"api/v1/maintenances/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Patches an existing maintenance record.
    /// </summary>
    /// <param name="id">The ID of the maintenance record to patch.</param>
    /// <param name="item">The patched maintenance record.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchMaintenanceAsync(int id, Maintenance item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<MaintenanceChangeModel, ResultModel<MaintenanceChangeModel>>($"api/v1/maintenances/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Deletes a maintenance record.
    /// </summary>
    /// <param name="id">The ID of the maintenance record to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteMaintenanceAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<MaintenanceChangeModel>>($"api/v1/maintenances/{id}", cancellationToken);
        CheckResultForError(res);
    }

    #region Manufacturers

    #endregion

    /// <summary>
    /// Retrieves all manufacturers asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An asynchronous stream of <see cref="Manufacturer"/> objects.</returns>
    public async IAsyncEnumerable<Manufacturer> GetManufacturersAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = GetListAsync<ManufacturerModel>("api/v1/manufacturers", cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Manufacturer>()!;
        }
    }

    /// <summary>
    /// Retrieves a specific manufacturer by its ID.
    /// </summary>
    /// <param name="id">The ID of the manufacturer.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The <see cref="Manufacturer"/> object if found; otherwise, null.</returns>
    public async Task<Manufacturer?> GetManufacturerAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<ManufacturerModel>($"api/v1/manufacturers/{id}", cancellationToken);
        return res.CastModel<Manufacturer>();
    }

    /// <summary>
    /// Creates a new manufacturer.
    /// </summary>
    /// <param name="item">The manufacturer to create.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The ID of the created manufacturer.</returns>
    public async Task<int> CreateManufacturerAsync(Manufacturer item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<ManufacturerChangeModel, ResultModel<ManufacturerChangeModel>>("api/v1/manufacturers", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
        return res!.Payload?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing manufacturer.
    /// </summary>
    /// <param name="id">The ID of the manufacturer to update.</param>
    /// <param name="item">The updated manufacturer.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateManufacturerAsync(int id, Manufacturer item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<ManufacturerChangeModel, ResultModel<ManufacturerChangeModel>>($"api/v1/manufacturers/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Patches an existing manufacturer.
    /// </summary>
    /// <param name="id">The ID of the manufacturer to patch.</param>
    /// <param name="item">The patched manufacturer.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchManufacturerAsync(int id, Manufacturer item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<ManufacturerChangeModel, ResultModel<ManufacturerChangeModel>>($"api/v1/manufacturers/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Deletes a manufacturer.
    /// </summary>
    /// <param name="id">The ID of the manufacturer to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteManufacturerAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<ManufacturerChangeModel>>($"api/v1/manufacturers/{id}", cancellationToken);
        CheckResultForError(res);
    }

    #endregion

    #region Models

    /// <summary>
    /// Retrieves all models asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An asynchronous stream of <see cref="Model"/> objects.</returns>
    public async IAsyncEnumerable<Model> GetModelsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = GetListAsync<ModelModel>("api/v1/models", cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Model>()!;
        }
    }

    /// <summary>
    /// Retrieves a specific model by its ID.
    /// </summary>
    /// <param name="id">The ID of the model.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The <see cref="Model"/> object if found; otherwise, null.</returns>
    public async Task<Model?> GetModelAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<ModelModel>($"api/v1/models/{id}", cancellationToken);
        return res.CastModel<Model>();
    }

    /// <summary>
    /// Creates a new model.
    /// </summary>
    /// <param name="item">The model to create.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The ID of the created model.</returns>
    public async Task<int> CreateModelAsync(Model item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<ModelChangeModel, ResultModel<ModelChangeModel>>("api/v1/models", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
        return res!.Payload?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing model.
    /// </summary>
    /// <param name="id">The ID of the model to update.</param>
    /// <param name="item">The updated model.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateModelAsync(int id, Model item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<ModelChangeModel, ResultModel<ModelChangeModel>>($"api/v1/models/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Patches an existing model.
    /// </summary>
    /// <param name="id">The ID of the model to patch.</param>
    /// <param name="item">The patched model.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchModelAsync(int id, Model item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<ModelChangeModel, ResultModel<ModelChangeModel>>($"api/v1/models/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Deletes a model.
    /// </summary>
    /// <param name="id">The ID of the model to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteModelAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<ModelChangeModel>>($"api/v1/models/{id}", cancellationToken);
        CheckResultForError(res);
    }

    #endregion

    #region StatusLabels

    /// <summary>
    /// Retrieves all status labels asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An asynchronous stream of <see cref="StatusLabel"/> objects.</returns>
    public async IAsyncEnumerable<StatusLabel> GetStatusLabelsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = GetListAsync<StatusLabelModel>("api/v1/statuslabels", cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<StatusLabel>()!;
        }
    }

    /// <summary>
    /// Retrieves a specific status label by its ID.
    /// </summary>
    /// <param name="id">The ID of the status label.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The <see cref="StatusLabel"/> object if found; otherwise, null.</returns>
    public async Task<StatusLabel?> GetStatusLabelAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<StatusLabelModel>($"api/v1/statuslabels/{id}", cancellationToken);
        return res.CastModel<StatusLabel>();
    }

    /// <summary>
    /// Creates a new status label.
    /// </summary>
    /// <param name="item">The status label to create.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The ID of the created status label.</returns>
    public async Task<int> CreateStatusLabelAsync(StatusLabel item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<StatusLabelChangeModel, ResultModel<StatusLabelChangeModel>>("api/v1/statuslabels", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
        return res!.Payload?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing status label.
    /// </summary>
    /// <param name="id">The ID of the status label to update.</param>
    /// <param name="item">The updated status label.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateStatusLabelAsync(int id, StatusLabel item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<StatusLabelChangeModel, ResultModel<StatusLabelChangeModel>>($"api/v1/statuslabels/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Patches an existing status label.
    /// </summary>
    /// <param name="id">The ID of the status label to patch.</param>
    /// <param name="item">The patched status label.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchStatusLabelAsync(int id, StatusLabel item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<StatusLabelChangeModel, ResultModel<StatusLabelChangeModel>>($"api/v1/statuslabels/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Deletes a status label.
    /// </summary>
    /// <param name="id">The ID of the status label to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteStatusLabelAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<StatusLabelChangeModel>>($"api/v1/statuslabels/{id}", cancellationToken);
        CheckResultForError(res);
    }

    #endregion

    #region Suppliers

    /// <summary>
    /// Retrieves all suppliers asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An asynchronous stream of <see cref="Supplier"/> objects.</returns>
    public async IAsyncEnumerable<Supplier> GetSuppliersAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = GetListAsync<SupplierModel>("api/v1/suppliers", cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Supplier>()!;
        }
    }

    /// <summary>
    /// Retrieves a specific supplier by its ID.
    /// </summary>
    /// <param name="id">The ID of the supplier.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The <see cref="Supplier"/> object if found; otherwise, null.</returns>
    public async Task<Supplier?> GetSupplierAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<SupplierModel>($"api/v1/suppliers/{id}", cancellationToken);
        return res.CastModel<Supplier>();
    }

    /// <summary>
    /// Creates a new supplier.
    /// </summary>
    /// <param name="item">The supplier to create.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The ID of the created supplier.</returns>
    public async Task<int> CreateSupplierAsync(Supplier item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<SupplierChangeModel, ResultModel<SupplierChangeModel>>("api/v1/suppliers", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
        return res!.Payload?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing supplier.
    /// </summary>
    /// <param name="id">The ID of the supplier to update.</param>
    /// <param name="item">The updated supplier.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateSupplierAsync(int id, Supplier item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<SupplierChangeModel, ResultModel<SupplierChangeModel>>($"api/v1/suppliers/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Patches an existing supplier.
    /// </summary>
    /// <param name="id">The ID of the supplier to patch.</param>
    /// <param name="item">The patched supplier.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchSupplierAsync(int id, Supplier item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<SupplierChangeModel, ResultModel<SupplierChangeModel>>($"api/v1/suppliers/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Deletes a supplier.
    /// </summary>
    /// <param name="id">The ID of the supplier to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteSupplierAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<SupplierChangeModel>>($"api/v1/suppliers/{id}", cancellationToken);
        CheckResultForError(res);
    }

    #endregion

    #region Users

    /// <summary>
    /// Retrieves all users asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An asynchronous stream of <see cref="User"/> objects.</returns>
    public async IAsyncEnumerable<User> GetUsersAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = GetListAsync<UserModel>("api/v1/users", cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<User>()!;
        }
    }

    /// <summary>
    /// Retrieves a specific user by their ID.
    /// </summary>
    /// <param name="id">The ID of the user.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The <see cref="User"/> object if found; otherwise, null.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task<User?> GetUserAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await GetFromJsonAsync<UserModel>($"api/v1/users/{id}", cancellationToken);
        return res.CastModel<User>();
    }

    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="item">The user to create.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The ID of the created user.</returns>
    public async Task<int> CreateUserAsync(User item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await PostAsJsonAsync<UserChangeModel, ResultModel<UserChangeModel>>("api/v1/users", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
        return res!.Payload?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing user.
    /// </summary>
    /// <param name="id">The ID of the user to update.</param>
    /// <param name="item">The updated user details.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateUserAsync(int id, User item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PutAsJsonAsync<UserChangeModel, ResultModel<UserChangeModel>>($"api/v1/users/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Patches an existing user.
    /// </summary>
    /// <param name="id">The ID of the user to patch.</param>
    /// <param name="item">The patched user details.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchUserAsync(int id, User item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await PatchAsJsonAsync<UserChangeModel, ResultModel<UserChangeModel>>($"api/v1/users/{id}", item.ToUpdate(), cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Deletes a user.
    /// </summary>
    /// <param name="id">The ID of the user to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteUserAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await DeleteAsJsonAsync<ResultModel<UserChangeModel>>($"api/v1/users/{id}", cancellationToken);
        CheckResultForError(res);
    }

    /// <summary>
    /// Retrieves the currently authenticated user.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The <see cref="User"/> object representing the authenticated user.</returns>
    public async Task<User?> GetUserMeAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await GetFromJsonAsync<UserModel>("api/v1/users/me", cancellationToken);
        return res.CastModel<User>();
    }

    #endregion

    #region private

    private async IAsyncEnumerable<T> GetListAsync<T>(string requestUri, [EnumeratorCancellation] CancellationToken cancellationToken, [CallerMemberName] string memberName = "") //where T : class
    {
        ArgumentRequestUriException.ThrowIfNullOrWhiteSpace(requestUri, nameof(requestUri));
        WebServiceException.ThrowIfNotConnected(client);

        const int limit = 500;
        int total = 1;
        int offset = 0;

        //const int limit = 100;  //500
        //int total = 2000;
        //int offset = 1520; // 0;
        while (offset < total)
        {

            var res = await GetFromJsonAsync<ListModel<T>>(CombineUrl(requestUri, ("limit", limit), ("offset", offset)), cancellationToken, memberName);
            if (res != null && res.Rows != null)
            {

                Debug.WriteLine($"Offset {offset} Limit {limit} ListModel total {res.Total} rows {res.Rows.Count}");

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
