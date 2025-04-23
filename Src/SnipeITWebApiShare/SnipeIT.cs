namespace SnipeITWebApi;

/// <summary>
/// Provides methods to interact with the Snipe-IT API for managing assets, accessories, categories, and more.
/// </summary>
/// <remarks>
/// The return JSON from create, update, patch, and delete operations is not identical to the JSON returned by get operations.
/// As a result, the return JSON is not used in these methods.
/// </remarks>
public class SnipeIT : IDisposable
{
    private SnipeITService? service;

    /// <summary>
    /// Initializes a new instance of the <see cref="SnipeIT"/> class using a store key and application name.
    /// </summary>
    /// <param name="storeKey">The key to retrieve the host and token from the key store.</param>
    /// <param name="appName">The name of the application using the API.</param>
    public SnipeIT(string storeKey, string appName)
    : this(new Uri(KeyStore.Key(storeKey)?.Host!), KeyStore.Key(storeKey)!.Token!, appName)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SnipeIT"/> class using a host URI, token, and application name.
    /// </summary>
    /// <param name="host">The base URI of the Snipe-IT API.</param>
    /// <param name="token">The authentication token for the API.</param>
    /// <param name="appName">The name of the application using the API.</param>
    public SnipeIT(Uri host, string token, string appName)
    {
        service = new(host, new BearerAuthenticator(token), appName);
    }

    /// <summary>
    /// Disposes the resources used by the <see cref="SnipeIT"/> instance.
    /// </summary>
    public void Dispose()
    {
        if (this.service != null)
        {
            this.service.Dispose();
            this.service = null;
        }
        GC.SuppressFinalize(this);
    }

    #region Assets

    /// <summary>
    /// Gets the total number of hardware assets.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The total number of hardware assets.</returns>
    public async Task<int> GetNumberOfHardwaresAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetNumberOfHardwaresAsync(cancellationToken);
        return res;
    }

    /// <summary>
    /// Retrieves all hardware assets asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An asynchronous stream of <see cref="Hardware"/> objects.</returns>
    public async IAsyncEnumerable<Hardware> GetHardwaresAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetHardwaresAsync(cancellationToken);
        int i = 0;
        await foreach (var item in res)
        {
            i++;
            yield return item.CastModel<Hardware>()!;
        }
        //Debug.WriteLine($"GetHardwaresAsync: {i}");
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(category, 0, nameof(category));

        var res = service.GetHardwaresByCategoryAsync(category, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.GetHardwareAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateHardwareAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing hardware asset.
    /// </summary>
    /// <param name="id">The ID of the hardware asset to update.</param>
    /// <param name="item">The updated hardware asset.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateHardwareAsync(int id, Hardware item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateHardwareAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Hardware>();
    }

    /// <summary>
    /// Patches an existing hardware asset.
    /// </summary>
    /// <param name="id">The ID of the hardware asset to patch.</param>
    /// <param name="item">The patched hardware asset.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchHardwareAsync(int id, Hardware item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchHardwareAsync(id, item.ToUpdate(), cancellationToken);
    }

    /// <summary>
    /// Deletes a hardware asset.
    /// </summary>
    /// <param name="id">The ID of the hardware asset to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteHardwareAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteHardwareAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.CheckoutHardwareAsync(id, item.ToUpdate(), cancellationToken);
        return res.CastModel<Hardware>();
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.CheckinHardwareAsync(id, item.ToUpdate(), cancellationToken);
        return res.CastModel<Hardware>();
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetAccessoriesAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetAccessoryAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateAccessoryAsync(item.ToChange(), cancellationToken);
        return res?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing accessory.
    /// </summary>
    /// <param name="id">The ID of the accessory to update.</param>
    /// <param name="item">The updated accessory.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateAccessoryAsync(int id, Accessory item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateAccessoryAsync(id, item.ToChange(), cancellationToken);
        //return res.CastModel<Accessory>();
    }

    /// <summary>
    /// Patches an existing accessory.
    /// </summary>
    /// <param name="id">The ID of the accessory to patch.</param>
    /// <param name="item">The patched accessory.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchAccessoryAsync(int id, Accessory item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchAccessoryAsync(id, item.ToChange(), cancellationToken);
        //return res.CastModel<Accessory>();
    }

    /// <summary>
    /// Deletes an accessory.
    /// </summary>
    /// <param name="id">The ID of the accessory to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteAccessoryAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteAccessoryAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetCategoriesAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetCategoryAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateCategoryAsync(item.ToCreate(), cancellationToken);
        return res?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing category.
    /// </summary>
    /// <param name="id">The ID of the category to update.</param>
    /// <param name="item">The updated category.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateCategoryAsync(int id, Category item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateCategoryAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Category>();
    }

    /// <summary>
    /// Patches an existing category.
    /// </summary>
    /// <param name="id">The ID of the category to patch.</param>
    /// <param name="item">The patched category.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchCategoryAsync(int id, Category item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchCategoryAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Category>();
    }

    /// <summary>
    /// Deletes a category.
    /// </summary>
    /// <param name="id">The ID of the category to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteCategoryAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteCategoryAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetCompaniesAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetCompanyAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateCompanyAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing company.
    /// </summary>
    /// <param name="id">The ID of the company to update.</param>
    /// <param name="item">The updated company.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateCompanyAsync(int id, Company item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateCompanyAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Company>();
    }

    /// <summary>
    /// Patches an existing company.
    /// </summary>
    /// <param name="id">The ID of the company to patch.</param>
    /// <param name="item">The patched company.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchCompanyAsync(int id, Company item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchCompanyAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Company>();
    }

    /// <summary>
    /// Deletes a company.
    /// </summary>
    /// <param name="id">The ID of the company to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteCompanyAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteCompanyAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetComponentsAsync(null, null, null, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetComponentsAsync(name, search, orderNumber, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetComponentAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateComponentAsync(item.ToCreate(), cancellationToken);
        return res?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing component.
    /// </summary>
    /// <param name="id">The ID of the component to update.</param>
    /// <param name="item">The updated component.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateComponentAsync(int id, Component item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateComponentAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Component>();
    }

    /// <summary>
    /// Patches an existing component.
    /// </summary>
    /// <param name="id">The ID of the component to patch.</param>
    /// <param name="item">The patched component.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchComponentAsync(int id, Component item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchComponentAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Component>();
    }

    /// <summary>
    /// Deletes a component.
    /// </summary>
    /// <param name="id">The ID of the component to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteComponentAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteComponentAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetConsumablesAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetConsumableAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateConsumableAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing consumable.
    /// </summary>
    /// <param name="id">The ID of the consumable to update.</param>
    /// <param name="item">The updated consumable.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateConsumableAsync(int id, Consumable item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateConsumableAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Consumable>();
    }

    /// <summary>
    /// Patches an existing consumable.
    /// </summary>
    /// <param name="id">The ID of the consumable to patch.</param>
    /// <param name="item">The patched consumable.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchConsumableAsync(int id, Consumable item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchConsumableAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Consumable>();
    }

    /// <summary>
    /// Deletes a consumable.
    /// </summary>
    /// <param name="id">The ID of the consumable to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteConsumableAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteConsumableAsync(id, cancellationToken);
    }

    #endregion

    #region Departments

    public async IAsyncEnumerable<Department> GetDepartmentsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetDepartmentsAsync(cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Department>()!;
        }
    }

    public async Task<Department?> GetDepartmentAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetDepartmentAsync(id, cancellationToken);
        return res.CastModel<Department>();
    }

    public async Task<int> CreateDepartmentAsync(Department item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateDepartmentAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    public async Task UpdateDepartmentAsync(int id, Department item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateDepartmentAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Department>();
    }

    public async Task PatchDepartmentAsync(int id, Department item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchDepartmentAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Department>();
    }

    public async Task DeleteDepartmentAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteDepartmentAsync(id, cancellationToken);
    }

    #endregion

    #region Fieldsets

    public async IAsyncEnumerable<Fieldset> GetFieldsetsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetFieldsetsAsync(cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Fieldset>()!;
        }
    }

    public async Task<Fieldset?> GetFieldsetAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetFieldsetAsync(id, cancellationToken);
        return res.CastModel<Fieldset>();
    }

    public async Task<int> CreateFieldsetAsync(Fieldset item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateFieldsetAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    public async Task UpdateFieldsetAsync(int id, Fieldset item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateFieldsetAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Fieldset>();
    }

    public async Task PatchFieldsetAsync(int id, Fieldset item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchFieldsetAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Fieldset>();
    }

    public async Task DeleteFieldsetAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteFieldsetAsync(id, cancellationToken);
    }

    #endregion

    #region Fields

    public async IAsyncEnumerable<Field> GetFieldsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetFieldsAsync(cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Field>()!;
        }
    }

    public async Task<Field?> GetFieldAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetFieldAsync(id, cancellationToken);
        return res.CastModel<Field>();
    }

    public async Task<int> CreateFieldAsync(Field item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateFieldAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    public async Task UpdateFieldAsync(int id, Field item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateFieldAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Field>();
    }

    public async Task PatchFieldAsync(int id, Field item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchFieldAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Field>();
    }

    public async Task DeleteFieldAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteFieldAsync(id, cancellationToken);
    }

    #endregion

    #region Groups

    public async IAsyncEnumerable<Group> GetGroupsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetGroupsAsync(cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Group>()!;
        }
    }

    public async Task<Group?> GetGroupAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetGroupAsync(id, cancellationToken);
        return res.CastModel<Group>();
    }

    public async Task<int> CreateGroupAsync(Group item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateGroupAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    public async Task UpdateGroupAsync(int id, Group item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateGroupAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Group>();
    }

    public async Task PatchGroupAsync(int id, Group item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchGroupAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Group>();
    }

    public async Task DeleteGroupAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteGroupAsync(id, cancellationToken);
    }

    #endregion

    #region Licenses

    public async IAsyncEnumerable<License> GetLicensesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetLicensesAsync(cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<License>()!;
        }
    }

    public async Task<License?> GetLicenseAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetLicenseAsync(id, cancellationToken);
        return res.CastModel<License>();
    }

    public async Task<int> CreateLicenseAsync(License item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateLicenseAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    public async Task UpdateLicenseAsync(int id, License item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateLicenseAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<License>();
    }

    public async Task PatchLicenseAsync(int id, License item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchLicenseAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<License>();
    }

    public async Task DeleteLicenseAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteLicenseAsync(id, cancellationToken);
    }

    #endregion

    #region Locations

    public async IAsyncEnumerable<Location> GetLocationsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetLocationsAsync(cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Location>()!;
        }
    }

    public async Task<Location?> GetLocationAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetLocationAsync(id, cancellationToken);
        return res.CastModel<Location>();
    }

    public async Task<int> CreateLocationAsync(Location item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateLocationAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    public async Task UpdateLocationAsync(int id, Location item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateLocationAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Location>();
    }

    public async Task PatchLocationAsync(int id, Location item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchLocationAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Location>();
    }

    public async Task DeleteLocationAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteLocationAsync(id, cancellationToken);
    }

    #endregion

    #region Maintenances

    public async IAsyncEnumerable<Maintenance> GetMaintenancesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetMaintenancesAsync(cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Maintenance>()!;
        }
    }

    public async Task<Maintenance?> GetMaintenanceAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetMaintenanceAsync(id, cancellationToken);
        return res.CastModel<Maintenance>();
    }

    public async Task<int> CreateMaintenanceAsync(Maintenance item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateMaintenanceAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    public async Task UpdateMaintenanceAsync(int id, Maintenance item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateMaintenanceAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Maintenance>();
    }

    public async Task PatchMaintenanceAsync(int id, Maintenance item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchMaintenanceAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Maintenance>();
    }

    public async Task DeleteMaintenanceAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteMaintenanceAsync(id, cancellationToken);
    }

    #endregion

    #region Manufacturers

    public async IAsyncEnumerable<Manufacturer> GetManufacturersAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetManufacturersAsync(cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Manufacturer>()!;
        }
    }

    public async Task<Manufacturer?> GetManufacturerAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetManufacturerAsync(id, cancellationToken);
        return res.CastModel<Manufacturer>();
    }

    public async Task<int> CreateManufacturerAsync(Manufacturer item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateManufacturerAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    public async Task UpdateManufacturerAsync(int id, Manufacturer item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdatManufacturerAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Manufacturer>();
    }

    public async Task PatchManufacturerAsync(int id, Manufacturer item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchManufacturerAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Manufacturer>();
    }

    public async Task DeleteManufacturerAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteManufacturerAsync(id, cancellationToken);
    }

    #endregion

    #region Models

    public async IAsyncEnumerable<Model> GetModelsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetModelsAsync(cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Model>()!;
        }
    }

    public async Task<Model?> GetModelAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.GetModelAsync(id, cancellationToken);
        return res.CastModel<Model>();
    }

    public async Task<int> CreateModelAsync(Model item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateModelAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    public async Task UpdateModelAsync(int id, Model item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateModelAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Model>();
    }

    public async Task PatchModelAsync(int id, Model item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchModelAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Model>();
    }

    public async Task DeleteModelAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteModelAsync(id, cancellationToken);
    }

    #endregion

    #region StatusLabels

    public async IAsyncEnumerable<StatusLabel> GetStatusLabelsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetStatusLabelsAsync(cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<StatusLabel>()!;
        }
    }

    public async Task<StatusLabel?> GetStatusLabelAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetStatusLabelAsync(id, cancellationToken);
        return res.CastModel<StatusLabel>();
    }

    public async Task<int> CreateStatusLabelAsync(StatusLabel item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateStatusLabelAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    public async Task UpdateStatusLabelAsync(int id, StatusLabel item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateStatusLabelAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<StatusLabel>();
    }

    public async Task PatchStatusLabelAsync(int id, StatusLabel item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchStatusLabelAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<StatusLabel>();
    }

    public async Task DeleteStatusLabelAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteStatusLabelAsync(id, cancellationToken);
    }

    #endregion

    #region Suppliers

    public async IAsyncEnumerable<Supplier> GetSuppliersAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetSuppliersAsync(cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Supplier>()!;
        }
    }

    public async Task<Supplier?> GetSupplierAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetSupplierAsync(id, cancellationToken);
        return res.CastModel<Supplier>();
    }

    public async Task<int> CreateSupplierAsync(Supplier item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateSupplierAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    public async Task UpdateSupplierAsync(int id, Supplier item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateSupplierAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Supplier>();
    }

    public async Task PatchSupplierAsync(int id, Supplier item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchSupplierAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<Supplier>();
    }

    public async Task DeleteSupplierAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteSupplierAsync(id, cancellationToken);
    }

    #endregion

    #region Users

    public async IAsyncEnumerable<User> GetUsersAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetUsersAsync(cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<User>()!;
        }
    }

    public async Task<User?> GetUserAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.GetUserAsync(id, cancellationToken);
        return res.CastModel<User>();
    }

    public async Task<int> CreateUserAsync(User item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateUserAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    public async Task UpdateUserAsync(int id, User item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateUserAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<User>();
    }

    public async Task PatchUserAsync(int id, User item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchUserAsync(id, item.ToUpdate(), cancellationToken);
        //return res.CastModel<User>();
    }

    public async Task DeleteUserAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteUserAsync(id, cancellationToken);
    }

    public async Task<User?> GetUserMeAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetUserMeAsync(cancellationToken);
        return res.CastModel<User>();
    }

    #endregion
}
