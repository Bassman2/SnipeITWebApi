namespace SnipeITWebApi;

public class Permissions
{
    internal Permissions(PermissionsModel mode)
    {
        Superuser = mode.Superuser;
        Admin = mode.Admin;
        Import = mode.Import;
        ReportsView = mode.ReportsView;
        AssetsView = mode.AssetsView;
        AssetsCreate = mode.AssetsCreate;
        AssetsEdit = mode.AssetsEdit;
        AssetsDelete = mode.AssetsDelete;
        AssetsCheckin = mode.AssetsCheckin;
        AssetsCheckout = mode.AssetsCheckout;
        AssetsAudit = mode.AssetsAudit;
        AssetsViewRequestable = mode.AssetsViewRequestable;
        AssetsViewEncryptedCustomFields = mode.AssetsViewEncryptedCustomFields;
        AccessoriesView = mode.AccessoriesView;
        AccessoriesCreate = mode.AccessoriesCreate;
        AccessoriesEdit = mode.AccessoriesEdit;
        AccessoriesDelete = mode.AccessoriesDelete;
        AccessoriesCheckout = mode.AccessoriesCheckout;
        AccessoriesCheckin = mode.AccessoriesCheckin;
        AccessoriesFiles = mode.AccessoriesFiles;
        ConsumablesView = mode.ConsumablesView;
        ConsumablesCreate = mode.ConsumablesCreate;
        ConsumablesEdit = mode.ConsumablesEdit;
        ConsumablesDelete = mode.ConsumablesDelete;
        ConsumablesCheckout = mode.ConsumablesCheckout;
        ConsumablesFiles = mode.ConsumablesFiles;
        LicensesView = mode.LicensesView;
        LicensesCreate = mode.LicensesCreate;
        LicensesEdit = mode.LicensesEdit;
        LicensesDelete = mode.LicensesDelete;
        LicensesCheckout = mode.LicensesCheckout;
        LicensesKeys = mode.LicensesKeys;
        LicensesFiles = mode.LicensesFiles;
        ComponentsView = mode.ComponentsView;
        ComponentsCreate = mode.ComponentsCreate;
        ComponentsEdit = mode.ComponentsEdit;
        ComponentsDelete = mode.ComponentsDelete;
        ComponentsCheckout = mode.ComponentsCheckout;
        ComponentsCheckin = mode.ComponentsCheckin;
        ComponentsFiles = mode.ComponentsFiles;
        KitsView = mode.KitsView;
        KitsCreate = mode.KitsCreate;
        KitsEdit = mode.KitsEdit;
        KitsDelete = mode.KitsDelete;
        UsersView = mode.UsersView;
        UsersCreate = mode.UsersCreate;
        UsersEdit = mode.UsersEdit;
        UsersDelete = mode.UsersDelete;
        ModelsView = mode.ModelsView;
        ModelsCreate = mode.ModelsCreate;
        ModelsEdit = mode.ModelsEdit;
        ModelsDelete = mode.ModelsDelete;
        CategoriesView = mode.CategoriesView;
        CategoriesCreate = mode.CategoriesCreate;
        CategoriesEdit = mode.CategoriesEdit;
        CategoriesDelete = mode.CategoriesDelete;
        DepartmentsView = mode.DepartmentsView;
        DepartmentsCreate = mode.DepartmentsCreate;
        DepartmentsEdit = mode.DepartmentsEdit;
        DepartmentsDelete = mode.DepartmentsDelete;
        StatusLabelsView = mode.StatusLabelsView;
        StatusLabelsCreate = mode.StatusLabelsCreate;
        StatusLabelsEdit = mode.StatusLabelsEdit;
        StatusLabelsDelete = mode.StatusLabelsDelete;
        CustomFieldsView = mode.CustomFieldsView;
        CustomFieldsCreate = mode.CustomFieldsCreate;
        CustomFieldsEdit = mode.CustomFieldsEdit;
        CustomFieldsDelete = mode.CustomFieldsDelete;
        SuppliersView = mode.SuppliersView;
        SuppliersCreate = mode.SuppliersCreate;
        SuppliersEdit = mode.SuppliersEdit;
        SuppliersDelete = mode.SuppliersDelete;
        ManufacturersView = mode.ManufacturersView;
        ManufacturersCreate = mode.ManufacturersCreate;
        ManufacturersEdit = mode.ManufacturersEdit;
        ManufacturersDelete = mode.ManufacturersDelete;
        DepreciationsView = mode.DepreciationsView;
        DepreciationsCreate = mode.DepreciationsCreate;
        DepreciationsEdit = mode.DepreciationsEdit;
        DepreciationsDelete = mode.DepreciationsDelete;
        LocationsView = mode.LocationsView;
        LocationsCreate = mode.LocationsCreate;
        LocationsEdit = mode.LocationsEdit;
        LocationsDelete = mode.LocationsDelete;
        CompaniesView = mode.CompaniesView;
        CompaniesCreate = mode.CompaniesCreate;
        CompaniesEdit = mode.CompaniesEdit;
        CompaniesDelete = mode.CompaniesDelete;
        SelfTwoFactor = mode.SelfTwoFactor;
        SelfApi = mode.SelfApi;
        SelfEditLocation = mode.SelfEditLocation;
        SelfCheckoutAssets = mode.SelfCheckoutAssets;
        SelfViewPurchaseCost = mode.SelfViewPurchaseCost;
    }

    public string? Superuser { get; set; }
    public string? Admin { get; set; }
    public string? Import { get; set; }
    public string? ReportsView { get; set; }
    public string? AssetsView { get; set; }
    public string? AssetsCreate { get; set; }
    public string? AssetsEdit { get; set; }
    public string? AssetsDelete { get; set; }
    public string? AssetsCheckin { get; set; }
    public string? AssetsCheckout { get; set; }
    public string? AssetsAudit { get; set; }
    public string? AssetsViewRequestable { get; set; }
    public string? AssetsViewEncryptedCustomFields { get; set; }
    public string? AccessoriesView { get; set; }
    public string? AccessoriesCreate { get; set; }
    public string? AccessoriesEdit { get; set; }
    public string? AccessoriesDelete { get; set; }
    public string? AccessoriesCheckout { get; set; }
    public string? AccessoriesCheckin { get; set; }
    public string? AccessoriesFiles { get; set; }
    public string? ConsumablesView { get; set; }
    public string? ConsumablesCreate { get; set; }
    public string? ConsumablesEdit { get; set; }
    public string? ConsumablesDelete { get; set; }
    public string? ConsumablesCheckout { get; set; }
    public string? ConsumablesFiles { get; set; }
    public string? LicensesView { get; set; }
    public string? LicensesCreate { get; set; }
    public string? LicensesEdit { get; set; }
    public string? LicensesDelete { get; set; }
    public string? LicensesCheckout { get; set; }
    public string? LicensesKeys { get; set; }
    public string? LicensesFiles { get; set; }
    public string? ComponentsView { get; set; }
    public string? ComponentsCreate { get; set; }
    public string? ComponentsEdit { get; set; }
    public string? ComponentsDelete { get; set; }
    public string? ComponentsCheckout { get; set; }
    public string? ComponentsCheckin { get; set; }
    public string? ComponentsFiles { get; set; }
    public string? KitsView { get; set; }
    public string? KitsCreate { get; set; }
    public string? KitsEdit { get; set; }
    public string? KitsDelete { get; set; }
    public string? UsersView { get; set; }
    public string? UsersCreate { get; set; }
    public string? UsersEdit { get; set; }
    public string? UsersDelete { get; set; }
    public string? ModelsView { get; set; }
    public string? ModelsCreate { get; set; }
    public string? ModelsEdit { get; set; }
    public string? ModelsDelete { get; set; }
    public string? CategoriesView { get; set; }
    public string? CategoriesCreate { get; set; }
    public string? CategoriesEdit { get; set; }
    public string? CategoriesDelete { get; set; }
    public string? DepartmentsView { get; set; }
    public string? DepartmentsCreate { get; set; }
    public string? DepartmentsEdit { get; set; }
    public string? DepartmentsDelete { get; set; }
    public string? StatusLabelsView { get; set; }
    public string? StatusLabelsCreate { get; set; }
    public string? StatusLabelsEdit { get; set; }
    public string? StatusLabelsDelete { get; set; }
    public string? CustomFieldsView { get; set; }
    public string? CustomFieldsCreate { get; set; }
    public string? CustomFieldsEdit { get; set; }
    public string? CustomFieldsDelete { get; set; }
    public string? SuppliersView { get; set; }
    public string? SuppliersCreate { get; set; }
    public string? SuppliersEdit { get; set; }
    public string? SuppliersDelete { get; set; }
    public string? ManufacturersView { get; set; }
    public string? ManufacturersCreate { get; set; }
    public string? ManufacturersEdit { get; set; }
    public string? ManufacturersDelete { get; set; }
    public string? DepreciationsView { get; set; }
    public string? DepreciationsCreate { get; set; }
    public string? DepreciationsEdit { get; set; }
    public string? DepreciationsDelete { get; set; }
    public string? LocationsView { get; set; }
    public string? LocationsCreate { get; set; }
    public string? LocationsEdit { get; set; }
    public string? LocationsDelete { get; set; }
    public string? CompaniesView { get; set; }
    public string? CompaniesCreate { get; set; }
    public string? CompaniesEdit { get; set; }
    public string? CompaniesDelete { get; set; }
    public string? SelfTwoFactor { get; set; }
    public string? SelfApi { get; set; }
    public string? SelfEditLocation { get; set; }
    public string? SelfCheckoutAssets { get; set; }
    public string? SelfViewPurchaseCost { get; set; }
}
