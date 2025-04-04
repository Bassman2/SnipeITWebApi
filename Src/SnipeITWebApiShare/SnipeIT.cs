﻿using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace SnipeITWebApi;

public class SnipeIT : IDisposable
{
    private SnipeITService? service;

    public SnipeIT(string storeKey, string appName)
    : this(new Uri(KeyStore.Key(storeKey)?.Host!), KeyStore.Key(storeKey)!.Token!, appName)
    { }

    public SnipeIT(Uri host, string token, string appName)
    {
        service = new(host, new BearerAuthenticator(token), appName);
    }

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

    public async Task<int> GetNumberOfHardwaresAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetNumberOfHardwaresAsync(cancellationToken);
        return res;
    }

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

    public async Task<Hardware?> GetHardwareAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.GetHardwareAsync(id, cancellationToken);
        return res.CastModel<Hardware>();
    }

    public async Task<Hardware?> CreateHardwareAsync(Hardware item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateHardwareAsync(item.ToCreate(), cancellationToken);
        return res.CastModel<Hardware>();
    }

    public async Task<Hardware?> UpdateHardwareAsync(int id, Hardware item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateHardwareAsync(id, item.ToUpdate(), cancellationToken);
        return res.CastModel<Hardware>();
    }

    public async Task<Hardware?> PatchHardwareAsync(int id, Hardware item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchHardwareAsync(id, item.ToPatch(), cancellationToken);
        return res.CastModel<Hardware>();
    }

    public async Task<Hardware?> DeleteHardwareAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteHardwareAsync(id, cancellationToken);
        return res.CastModel<Hardware>();
    }

    public async Task<Hardware?> CheckoutHardwareAsync(int id, Hardware item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.CheckoutHardwareAsync(id, item.ToCheckout(), cancellationToken);
        return res.CastModel<Hardware>();
    }

    public async Task<Hardware?> CheckinHardwareAsync(int id, Hardware item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.CheckinHardwareAsync(id, item.ToCheckin(), cancellationToken);
        return res.CastModel<Hardware>();
    }

    #endregion

    #region Accessories

    public async IAsyncEnumerable<Accessory> GetAccessoriesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetAccessoriesAsync(cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Accessory>()!;
        }
    }

    public async Task<Accessory?> GetAccessoryAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetAccessoryAsync(id, cancellationToken);
        return res.CastModel<Accessory>();
    }

    public async Task<Accessory?> CreateAccessoryAsync(Accessory item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateAccessoryAsync(item.ToCreate(), cancellationToken);
        return res.CastModel<Accessory>();
    }

    public async Task<Accessory?> UpdateAccessoryAsync(int id, Accessory item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateAccessoryAsync(id, item.ToUpdate(), cancellationToken);
        return res.CastModel<Accessory>();
    }

    public async Task<Accessory?> PatchAccessoryAsync(int id, Accessory item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchAccessoryAsync(id, item.ToPatch(), cancellationToken);
        return res.CastModel<Accessory>();
    }

    public async Task<Accessory?> DeleteAccessoryAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteAccessoryAsync(id, cancellationToken);
        return res.CastModel<Accessory>();
    }

    #endregion

    #region Categories

    public async IAsyncEnumerable<Category> GetCategoriesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetCategoriesAsync(cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Category>()!;
        }
    }

    public async Task<Category?> GetCategoryAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetCategoryAsync(id, cancellationToken);
        return res.CastModel<Category>();
    }

    public async Task<Category?> CreateCategoryAsync(Category item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateCategoryAsync(item.ToCreate(), cancellationToken);
        return res.CastModel<Category>();
    }

    public async Task<Category?> UpdateCategoryAsync(int id, Category item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateCategoryAsync(id, item.ToUpdate(), cancellationToken);
        return res.CastModel<Category>();
    }

    public async Task<Category?> PatchCategoryAsync(int id, Category item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchCategoryAsync(id, item.ToPatch(), cancellationToken);
        return res.CastModel<Category>();
    }

    public async Task<Category?> DeleteCategoryAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteCategoryAsync(id, cancellationToken);
        return res.CastModel<Category>();
    }

    #endregion

    #region Companies

    public async IAsyncEnumerable<Company> GetCompaniesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetCompaniesAsync(cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Company>()!;
        }
    }

    public async Task<Company?> GetCompanyAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetCompanyAsync(id, cancellationToken);
        return res.CastModel<Company>();
    }

    public async Task<Company?> CreateCompanyAsync(Company item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateCompanyAsync(item.ToCreate(), cancellationToken);
        return res.CastModel<Company>();
    }

    public async Task<Company?> UpdateCompanyAsync(int id, Company item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateCompanyAsync(id, item.ToUpdate(), cancellationToken);
        return res.CastModel<Company>();
    }

    public async Task<Company?> PatchCompanyAsync(int id, Company item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchCompanyAsync(id, item.ToPatch(), cancellationToken);
        return res.CastModel<Company>();
    }

    public async Task<Company?> DeleteCompanyAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteCompanyAsync(id, cancellationToken);
        return res.CastModel<Company>();
    }

    #endregion

    #region Components

    public async IAsyncEnumerable<Component> GetComponentsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetComponentsAsync(cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Component>()!;
        }
    }

    public async Task<Component?> GetComponentAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetComponentAsync(id, cancellationToken);
        return res.CastModel<Component>();
    }

    public async Task<Component?> CreateComponentAsync(Component item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateComponentAsync(item.ToCreate(), cancellationToken);
        return res.CastModel<Component>();
    }

    public async Task<Component?> UpdateComponentAsync(int id, Component item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateComponentAsync(id, item.ToUpdate(), cancellationToken);
        return res.CastModel<Component>();
    }

    public async Task<Component?> PatchComponentAsync(int id, Component item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchComponentAsync(id, item.ToPatch(), cancellationToken);
        return res.CastModel<Component>();
    }

    public async Task<Component?> DeleteComponentAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteComponentAsync(id, cancellationToken);
        return res.CastModel<Component>();
    }

    #endregion

    #region Consumables

    public async IAsyncEnumerable<Consumable> GetConsumablesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = service.GetConsumablesAsync(cancellationToken);
        await foreach (var item in res)
        {
            yield return item.CastModel<Consumable>()!;
        }
    }

    public async Task<Consumable?> GetConsumableAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetConsumableAsync(id, cancellationToken);
        return res.CastModel<Consumable>();
    }

    public async Task<Consumable?> CreateConsumableAsync(Consumable item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateConsumableAsync(item.ToCreate(), cancellationToken);
        return res.CastModel<Consumable>();
    }

    public async Task<Consumable?> UpdateConsumableAsync(int id, Consumable item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateConsumableAsync(id, item.ToUpdate(), cancellationToken);
        return res.CastModel<Consumable>();
    }

    public async Task<Consumable?> PatchConsumableAsync(int id, Consumable item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchConsumableAsync(id, item.ToPatch(), cancellationToken);
        return res.CastModel<Consumable>();
    }

    public async Task<Consumable?> DeleteConsumableAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteConsumableAsync(id, cancellationToken);
        return res.CastModel<Consumable>();
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

    public async Task<Department?> CreateDepartmentAsync(Department item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateDepartmentAsync(item.ToCreate(), cancellationToken);
        return res.CastModel<Department>();
    }

    public async Task<Department?> UpdateDepartmentAsync(int id, Department item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateDepartmentAsync(id, item.ToUpdate(), cancellationToken);
        return res.CastModel<Department>();
    }

    public async Task<Department?> PatchDepartmentAsync(int id, Department item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchDepartmentAsync(id, item.ToPatch(), cancellationToken);
        return res.CastModel<Department>();
    }

    public async Task<Department?> DeleteDepartmentAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteDepartmentAsync(id, cancellationToken);
        return res.CastModel<Department>();
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

    public async Task<Fieldset?> CreateFieldsetAsync(Fieldset item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateFieldsetAsync(item.ToCreate(), cancellationToken);
        return res.CastModel<Fieldset>();
    }

    public async Task<Fieldset?> UpdateFieldsetAsync(int id, Fieldset item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateFieldsetAsync(id, item.ToUpdate(), cancellationToken);
        return res.CastModel<Fieldset>();
    }

    public async Task<Fieldset?> PatchFieldsetAsync(int id, Fieldset item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchFieldsetAsync(id, item.ToPatch(), cancellationToken);
        return res.CastModel<Fieldset>();
    }

    public async Task<Fieldset?> DeleteFieldsetAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteFieldsetAsync(id, cancellationToken);
        return res.CastModel<Fieldset>();
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

    public async Task<Field?> CreateFieldAsync(Field item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateFieldAsync(item.ToCreate(), cancellationToken);
        return res.CastModel<Field>();
    }

    public async Task<Field?> UpdateFieldAsync(int id, Field item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateFieldAsync(id, item.ToUpdate(), cancellationToken);
        return res.CastModel<Field>();
    }

    public async Task<Field?> PatchFieldAsync(int id, Field item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchFieldAsync(id, item.ToPatch(), cancellationToken);
        return res.CastModel<Field>();
    }

    public async Task<Field?> DeleteFieldAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteFieldAsync(id, cancellationToken);
        return res.CastModel<Field>();
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

    public async Task<Group?> CreateGroupAsync(Group item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateGroupAsync(item.ToCreate(), cancellationToken);
        return res.CastModel<Group>();
    }

    public async Task<Group?> UpdateGroupAsync(int id, Group item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateGroupAsync(id, item.ToUpdate(), cancellationToken);
        return res.CastModel<Group>();
    }

    public async Task<Group?> PatchGroupAsync(int id, Group item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchGroupAsync(id, item.ToPatch(), cancellationToken);
        return res.CastModel<Group>();
    }

    public async Task<Group?> DeleteGroupAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteGroupAsync(id, cancellationToken);
        return res.CastModel<Group>();
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

    public async Task<License?> CreateLicenseAsync(License item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateLicenseAsync(item.ToCreate(), cancellationToken);
        return res.CastModel<License>();
    }

    public async Task<License?> UpdateLicenseAsync(int id, License item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateLicenseAsync(id, item.ToUpdate(), cancellationToken);
        return res.CastModel<License>();
    }

    public async Task<License?> PatchLicenseAsync(int id, License item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchLicenseAsync(id, item.ToPatch(), cancellationToken);
        return res.CastModel<License>();
    }

    public async Task<License?> DeleteLicenseAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteLicenseAsync(id, cancellationToken);
        return res.CastModel<License>();
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

    public async Task<Location?> CreateLocationAsync(Location item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateLocationAsync(item.ToCreate(), cancellationToken);
        return res.CastModel<Location>();
    }

    public async Task<Location?> UpdateLocationAsync(int id, Location item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateLocationAsync(id, item.ToUpdate(), cancellationToken);
        return res.CastModel<Location>();
    }

    public async Task<Location?> PatchLocationAsync(int id, Location item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchLocationAsync(id, item.ToPatch(), cancellationToken);
        return res.CastModel<Location>();
    }

    public async Task<Location?> DeleteLocationAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteLocationAsync(id, cancellationToken);
        return res.CastModel<Location>();
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

    public async Task<Maintenance?> CreateMaintenanceAsync(Maintenance item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateMaintenanceAsync(item.ToCreate(), cancellationToken);
        return res.CastModel<Maintenance>();
    }

    public async Task<Maintenance?> UpdateMaintenanceAsync(int id, Maintenance item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateMaintenanceAsync(id, item.ToUpdate(), cancellationToken);
        return res.CastModel<Maintenance>();
    }

    public async Task<Maintenance?> PatchMaintenanceAsync(int id, Maintenance item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchMaintenanceAsync(id, item.ToPatch(), cancellationToken);
        return res.CastModel<Maintenance>();
    }

    public async Task<Maintenance?> DeleteMaintenanceAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteMaintenanceAsync(id, cancellationToken);
        return res.CastModel<Maintenance>();
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

    public async Task<Manufacturer?> CreateManufacturerAsync(Manufacturer item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateManufacturerAsync(item.ToCreate(), cancellationToken);
        return res.CastModel<Manufacturer>(); 
    }

    public async Task<Manufacturer?> UpdateManufacturerAsync(int id, Manufacturer item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdatManufacturerAsync(id, item.ToUpdate(), cancellationToken);
        return res.CastModel<Manufacturer>();
    }

    public async Task<Manufacturer?> PatchManufacturerAsync(int id, Manufacturer item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchManufacturerAsync(id, item.ToPatch(), cancellationToken);
        return res.CastModel<Manufacturer>();
    }

    public async Task<Manufacturer?> DeleteManufacturerAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteManufacturerAsync(id, cancellationToken);
        return res.CastModel<Manufacturer>();
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

    public async Task<Model?> CreateModelAsync(Model item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateModelAsync(item.ToCreate(), cancellationToken);
        return res.CastModel<Model>();
    }

    public async Task<Model?> UpdateModelAsync(int id, Model item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateModelAsync(id, item.ToUpdate(), cancellationToken);
        return res.CastModel<Model>();
    }

    public async Task<Model?> PatchModelAsync(int id, Model item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchModelAsync(id, item.ToPatch(), cancellationToken);
        return res.CastModel<Model>();
    }

    public async Task<Model?> DeleteModelAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteModelAsync(id, cancellationToken);
        return res.CastModel<Model>();
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

    public async Task<StatusLabel?> CreateStatusLabelAsync(StatusLabel item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateStatusLabelAsync(item.ToCreate(), cancellationToken);
        return res.CastModel<StatusLabel>();
    }

    public async Task<StatusLabel?> UpdateStatusLabelAsync(int id, StatusLabel item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateStatusLabelAsync(id, item.ToUpdate(), cancellationToken);
        return res.CastModel<StatusLabel>();
    }

    public async Task<StatusLabel?> PatchStatusLabelAsync(int id, StatusLabel item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchStatusLabelAsync(id, item.ToPatch(), cancellationToken);
        return res.CastModel<StatusLabel>();
    }

    public async Task<StatusLabel?> DeleteStatusLabelAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteStatusLabelAsync(id, cancellationToken);
        return res.CastModel<StatusLabel>();
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

    public async Task<Supplier?> CreateSupplierAsync(Supplier item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateSupplierAsync(item.ToCreate(), cancellationToken);
        return res.CastModel<Supplier>();
    }

    public async Task<Supplier?> UpdateSupplierAsync(int id, Supplier item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateSupplierAsync(id, item.ToUpdate(), cancellationToken);
        return res.CastModel<Supplier>();
    }

    public async Task<Supplier?> PatchSupplierAsync(int id, Supplier item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchSupplierAsync(id, item.ToPatch(), cancellationToken);
        return res.CastModel<Supplier>();
    }

    public async Task<Supplier?> DeleteSupplierAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteSupplierAsync(id, cancellationToken);
        return res.CastModel<Supplier>();
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

    public async Task<User?> CreateUserAsync(User item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.CreateUserAsync(item.ToCreate(), cancellationToken);
        return res.CastModel<User>();
    }

    public async Task<User?> UpdateUserAsync(int id, User item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.UpdateUserAsync(id, item.ToUpdate(), cancellationToken);
        return res.CastModel<User>();
    }

    public async Task<User?> PatchUserAsync(int id, User item, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.PatchUserAsync(id, item.ToPatch(), cancellationToken);
        return res.CastModel<User>();
    }

    public async Task<User?> DeleteUserAsync(int id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0, nameof(id));

        var res = await service.DeleteUserAsync(id, cancellationToken);
        return res.CastModel<User>();
    }

    public async Task<User?> GetUserMeAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service.GetUserMeAsync(cancellationToken);
        return res.CastModel<User>();
    }

    #endregion
}
