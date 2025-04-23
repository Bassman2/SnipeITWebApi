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

        await service.UpdateHardwareAsync(id, item.ToUpdate(), cancellationToken);
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

        await service.PatchHardwareAsync(id, item.ToUpdate(), cancellationToken);
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

        await service.DeleteHardwareAsync(id, cancellationToken);
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

        await service.UpdateAccessoryAsync(id, item.ToChange(), cancellationToken);
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

        await service.PatchAccessoryAsync(id, item.ToChange(), cancellationToken);
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

        await service.DeleteAccessoryAsync(id, cancellationToken);
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

        await service.UpdateCategoryAsync(id, item.ToUpdate(), cancellationToken);
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

        await service.PatchCategoryAsync(id, item.ToUpdate(), cancellationToken);
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

        await service.DeleteCategoryAsync(id, cancellationToken);
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

        await service.UpdateCompanyAsync(id, item.ToUpdate(), cancellationToken);
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

        await service.PatchCompanyAsync(id, item.ToUpdate(), cancellationToken);
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

        await service.DeleteCompanyAsync(id, cancellationToken);
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

        await service.UpdateComponentAsync(id, item.ToUpdate(), cancellationToken);
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

        await service.PatchComponentAsync(id, item.ToUpdate(), cancellationToken);
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

        await service.DeleteComponentAsync(id, cancellationToken);
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

        await service.UpdateConsumableAsync(id, item.ToUpdate(), cancellationToken);
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

        await service.PatchConsumableAsync(id, item.ToUpdate(), cancellationToken);
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

        await service.DeleteConsumableAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetDepartmentsAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetDepartmentAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateDepartmentAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing department.
    /// </summary>
    /// <param name="id">The ID of the department to update.</param>
    /// <param name="item">The updated department.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateDepartmentAsync(int id, Department item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.UpdateDepartmentAsync(id, item.ToUpdate(), cancellationToken);
    }

    /// <summary>
    /// Patches an existing department.
    /// </summary>
    /// <param name="id">The ID of the department to patch.</param>
    /// <param name="item">The patched department.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchDepartmentAsync(int id, Department item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.PatchDepartmentAsync(id, item.ToUpdate(), cancellationToken);
    }

    /// <summary>
    /// Deletes a department.
    /// </summary>
    /// <param name="id">The ID of the department to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteDepartmentAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.DeleteDepartmentAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetFieldsetsAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetFieldsetAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateFieldsetAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing fieldset.
    /// </summary>
    /// <param name="id">The ID of the fieldset to update.</param>
    /// <param name="item">The updated fieldset.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateFieldsetAsync(int id, Fieldset item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.UpdateFieldsetAsync(id, item.ToUpdate(), cancellationToken);
    }

    /// <summary>
    /// Patches an existing fieldset.
    /// </summary>
    /// <param name="id">The ID of the fieldset to patch.</param>
    /// <param name="item">The patched fieldset.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchFieldsetAsync(int id, Fieldset item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.PatchFieldsetAsync(id, item.ToUpdate(), cancellationToken);
    }

    /// <summary>
    /// Deletes a fieldset.
    /// </summary>
    /// <param name="id">The ID of the fieldset to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteFieldsetAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.DeleteFieldsetAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetFieldsAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetFieldAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateFieldAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing field.
    /// </summary>
    /// <param name="id">The ID of the field to update.</param>
    /// <param name="item">The updated field.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateFieldAsync(int id, Field item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.UpdateFieldAsync(id, item.ToUpdate(), cancellationToken);
    }

    /// <summary>
    /// Patches an existing field.
    /// </summary>
    /// <param name="id">The ID of the field to patch.</param>
    /// <param name="item">The patched field.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchFieldAsync(int id, Field item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.PatchFieldAsync(id, item.ToUpdate(), cancellationToken);
    }

    /// <summary>
    /// Deletes a field.
    /// </summary>
    /// <param name="id">The ID of the field to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteFieldAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.DeleteFieldAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetGroupsAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetGroupAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateGroupAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing group.
    /// </summary>
    /// <param name="id">The ID of the group to update.</param>
    /// <param name="item">The updated group.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateGroupAsync(int id, Group item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.UpdateGroupAsync(id, item.ToUpdate(), cancellationToken);
    }

    /// <summary>
    /// Patches an existing group.
    /// </summary>
    /// <param name="id">The ID of the group to patch.</param>
    /// <param name="item">The patched group.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchGroupAsync(int id, Group item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.PatchGroupAsync(id, item.ToUpdate(), cancellationToken);
    }

    /// <summary>
    /// Deletes a group.
    /// </summary>
    /// <param name="id">The ID of the group to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteGroupAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.DeleteGroupAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetLicensesAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetLicenseAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateLicenseAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing license.
    /// </summary>
    /// <param name="id">The ID of the license to update.</param>
    /// <param name="item">The updated license.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateLicenseAsync(int id, License item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.UpdateLicenseAsync(id, item.ToUpdate(), cancellationToken);
    }

    /// <summary>
    /// Patches an existing license.
    /// </summary>
    /// <param name="id">The ID of the license to patch.</param>
    /// <param name="item">The patched license.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchLicenseAsync(int id, License item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.PatchLicenseAsync(id, item.ToUpdate(), cancellationToken);
    }

    /// <summary>
    /// Deletes a license.
    /// </summary>
    /// <param name="id">The ID of the license to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteLicenseAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.DeleteLicenseAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetLocationsAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetLocationAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateLocationAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing location.
    /// </summary>
    /// <param name="id">The ID of the location to update.</param>
    /// <param name="item">The updated location.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateLocationAsync(int id, Location item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.UpdateLocationAsync(id, item.ToUpdate(), cancellationToken);
    }

    /// <summary>
    /// Patches an existing location.
    /// </summary>
    /// <param name="id">The ID of the location to patch.</param>
    /// <param name="item">The patched location.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchLocationAsync(int id, Location item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.PatchLocationAsync(id, item.ToUpdate(), cancellationToken);
    }

    /// <summary>
    /// Deletes a location.
    /// </summary>
    /// <param name="id">The ID of the location to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteLocationAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.DeleteLocationAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetMaintenancesAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetMaintenanceAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateMaintenanceAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing maintenance record.
    /// </summary>
    /// <param name="id">The ID of the maintenance record to update.</param>
    /// <param name="item">The updated maintenance record.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateMaintenanceAsync(int id, Maintenance item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.UpdateMaintenanceAsync(id, item.ToUpdate(), cancellationToken);
    }

    /// <summary>
    /// Patches an existing maintenance record.
    /// </summary>
    /// <param name="id">The ID of the maintenance record to patch.</param>
    /// <param name="item">The patched maintenance record.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchMaintenanceAsync(int id, Maintenance item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.PatchMaintenanceAsync(id, item.ToUpdate(), cancellationToken);
    }

    /// <summary>
    /// Deletes a maintenance record.
    /// </summary>
    /// <param name="id">The ID of the maintenance record to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteMaintenanceAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.DeleteMaintenanceAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetManufacturersAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetManufacturerAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateManufacturerAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing manufacturer.
    /// </summary>
    /// <param name="id">The ID of the manufacturer to update.</param>
    /// <param name="item">The updated manufacturer.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateManufacturerAsync(int id, Manufacturer item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.UpdatManufacturerAsync(id, item.ToUpdate(), cancellationToken);
    }

    /// <summary>
    /// Patches an existing manufacturer.
    /// </summary>
    /// <param name="id">The ID of the manufacturer to patch.</param>
    /// <param name="item">The patched manufacturer.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchManufacturerAsync(int id, Manufacturer item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.PatchManufacturerAsync(id, item.ToUpdate(), cancellationToken);
    }

    /// <summary>
    /// Deletes a manufacturer.
    /// </summary>
    /// <param name="id">The ID of the manufacturer to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteManufacturerAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.DeleteManufacturerAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetModelsAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.GetModelAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateModelAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing model.
    /// </summary>
    /// <param name="id">The ID of the model to update.</param>
    /// <param name="item">The updated model.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateModelAsync(int id, Model item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.UpdateModelAsync(id, item.ToUpdate(), cancellationToken);
    }

    /// <summary>
    /// Patches an existing model.
    /// </summary>
    /// <param name="id">The ID of the model to patch.</param>
    /// <param name="item">The patched model.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchModelAsync(int id, Model item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.PatchModelAsync(id, item.ToUpdate(), cancellationToken);
    }

    /// <summary>
    /// Deletes a model.
    /// </summary>
    /// <param name="id">The ID of the model to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteModelAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.DeleteModelAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetStatusLabelsAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetStatusLabelAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateStatusLabelAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing status label.
    /// </summary>
    /// <param name="id">The ID of the status label to update.</param>
    /// <param name="item">The updated status label.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateStatusLabelAsync(int id, StatusLabel item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.UpdateStatusLabelAsync(id, item.ToUpdate(), cancellationToken);
    }

    /// <summary>
    /// Patches an existing status label.
    /// </summary>
    /// <param name="id">The ID of the status label to patch.</param>
    /// <param name="item">The patched status label.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchStatusLabelAsync(int id, StatusLabel item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.PatchStatusLabelAsync(id, item.ToUpdate(), cancellationToken);
    }

    /// <summary>
    /// Deletes a status label.
    /// </summary>
    /// <param name="id">The ID of the status label to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteStatusLabelAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.DeleteStatusLabelAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetSuppliersAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetSupplierAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateSupplierAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing supplier.
    /// </summary>
    /// <param name="id">The ID of the supplier to update.</param>
    /// <param name="item">The updated supplier.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateSupplierAsync(int id, Supplier item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.UpdateSupplierAsync(id, item.ToUpdate(), cancellationToken);
    }

    /// <summary>
    /// Patches an existing supplier.
    /// </summary>
    /// <param name="id">The ID of the supplier to patch.</param>
    /// <param name="item">The patched supplier.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchSupplierAsync(int id, Supplier item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.PatchSupplierAsync(id, item.ToUpdate(), cancellationToken);
    }

    /// <summary>
    /// Deletes a supplier.
    /// </summary>
    /// <param name="id">The ID of the supplier to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteSupplierAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.DeleteSupplierAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetUsersAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.GetUserAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateUserAsync(item.ToUpdate(), cancellationToken);
        return res?.Id ?? 0;
    }

    /// <summary>
    /// Updates an existing user.
    /// </summary>
    /// <param name="id">The ID of the user to update.</param>
    /// <param name="item">The updated user details.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task UpdateUserAsync(int id, User item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.UpdateUserAsync(id, item.ToUpdate(), cancellationToken);
    }

    /// <summary>
    /// Patches an existing user.
    /// </summary>
    /// <param name="id">The ID of the user to patch.</param>
    /// <param name="item">The patched user details.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task PatchUserAsync(int id, User item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.PatchUserAsync(id, item.ToUpdate(), cancellationToken);
    }

    /// <summary>
    /// Deletes a user.
    /// </summary>
    /// <param name="id">The ID of the user to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the ID is less than or equal to zero.</exception>
    public async Task DeleteUserAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        await service.DeleteUserAsync(id, cancellationToken);
    }

    /// <summary>
    /// Retrieves the currently authenticated user.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The <see cref="User"/> object representing the authenticated user.</returns>
    public async Task<User?> GetUserMeAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetUserMeAsync(cancellationToken);
        return res.CastModel<User>();
    }

    #endregion
}
