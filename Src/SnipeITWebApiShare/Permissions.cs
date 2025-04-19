namespace SnipeITWebApi;

public class Permissions
{
    public Permissions()
    { }

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

    internal PermissionsModel ToUpdate()
    {
        return new()
        {
            Superuser = Superuser,
            Admin = Admin,
            Import = Import,
            ReportsView = ReportsView,
            AssetsView = AssetsView,
            AssetsCreate = AssetsCreate,
            AssetsEdit = AssetsEdit,
            AssetsDelete = AssetsDelete,
            AssetsCheckin = AssetsCheckin,
            AssetsCheckout = AssetsCheckout,
            AssetsAudit = AssetsAudit,
            AssetsViewRequestable = AssetsViewRequestable,
            AssetsViewEncryptedCustomFields = AssetsViewEncryptedCustomFields,
            AccessoriesView = AccessoriesView,
            AccessoriesCreate = AccessoriesCreate,
            AccessoriesEdit = AccessoriesEdit,
            AccessoriesDelete = AccessoriesDelete,
            AccessoriesCheckout = AccessoriesCheckout,
            AccessoriesCheckin = AccessoriesCheckin,
            AccessoriesFiles = AccessoriesFiles,
            ConsumablesView = ConsumablesView,
            ConsumablesCreate = ConsumablesCreate,
            ConsumablesEdit = ConsumablesEdit,
            ConsumablesDelete = ConsumablesDelete,
            ConsumablesCheckout = ConsumablesCheckout,
            ConsumablesFiles = ConsumablesFiles,
            LicensesView = LicensesView,
            LicensesCreate = LicensesCreate,
            LicensesEdit = LicensesEdit,
            LicensesDelete = LicensesDelete,
            LicensesCheckout = LicensesCheckout,
            LicensesKeys = LicensesKeys,
            LicensesFiles = LicensesFiles,
            ComponentsView = ComponentsView,
            ComponentsCreate = ComponentsCreate,
            ComponentsEdit = ComponentsEdit,
            ComponentsDelete = ComponentsDelete,
            ComponentsCheckout = ComponentsCheckout,
            ComponentsCheckin = ComponentsCheckin,
            ComponentsFiles = ComponentsFiles,
            KitsView = KitsView,
            KitsCreate = KitsCreate,
            KitsEdit = KitsEdit,
            KitsDelete = KitsDelete,
            UsersView = UsersView,
            UsersCreate = UsersCreate,
            UsersEdit = UsersEdit,
            UsersDelete = UsersDelete,
            ModelsView = ModelsView,
            ModelsCreate = ModelsCreate,
            ModelsEdit = ModelsEdit,
            ModelsDelete = ModelsDelete,
            CategoriesView = CategoriesView,
            CategoriesCreate = CategoriesCreate,
            CategoriesEdit = CategoriesEdit,
            CategoriesDelete = CategoriesDelete,
            DepartmentsView = DepartmentsView,
            DepartmentsCreate = DepartmentsCreate,
            DepartmentsEdit = DepartmentsEdit,
            DepartmentsDelete = DepartmentsDelete,
            StatusLabelsView = StatusLabelsView,
            StatusLabelsCreate = StatusLabelsCreate,
            StatusLabelsEdit = StatusLabelsEdit,
            StatusLabelsDelete = StatusLabelsDelete,
            CustomFieldsView = CustomFieldsView,
            CustomFieldsCreate = CustomFieldsCreate,
            CustomFieldsEdit = CustomFieldsEdit,
            CustomFieldsDelete = CustomFieldsDelete,
            SuppliersView = SuppliersView,
            SuppliersCreate = SuppliersCreate,
            SuppliersEdit = SuppliersEdit,
            SuppliersDelete = SuppliersDelete,
            ManufacturersView = ManufacturersView,
            ManufacturersCreate = ManufacturersCreate,
            ManufacturersEdit = ManufacturersEdit,
            ManufacturersDelete = ManufacturersDelete,
            DepreciationsView = DepreciationsView,
            DepreciationsCreate = DepreciationsCreate,
            DepreciationsEdit = DepreciationsEdit,
            DepreciationsDelete = DepreciationsDelete,
            LocationsView = LocationsView,
            LocationsCreate = LocationsCreate,
            LocationsEdit = LocationsEdit,
            LocationsDelete = LocationsDelete,
            CompaniesView = CompaniesView,
            CompaniesCreate = CompaniesCreate,
            CompaniesEdit = CompaniesEdit,
            CompaniesDelete = CompaniesDelete,
            SelfTwoFactor = SelfTwoFactor,
            SelfApi = SelfApi,
            SelfEditLocation = SelfEditLocation,
            SelfCheckoutAssets = SelfCheckoutAssets,
            SelfViewPurchaseCost = SelfViewPurchaseCost
        };
    }

    public bool? Superuser { get; set; }
    public bool? Admin { get; set; }
    public bool? Import { get; set; }
    public bool? ReportsView { get; set; }
    public bool? AssetsView { get; set; }
    public bool? AssetsCreate { get; set; }
    public bool? AssetsEdit { get; set; }
    public bool? AssetsDelete { get; set; }
    public bool? AssetsCheckin { get; set; }
    public bool? AssetsCheckout { get; set; }
    public bool? AssetsAudit { get; set; }
    public bool? AssetsViewRequestable { get; set; }
    public bool? AssetsViewEncryptedCustomFields { get; set; }
    public bool? AccessoriesView { get; set; }
    public bool? AccessoriesCreate { get; set; }
    public bool? AccessoriesEdit { get; set; }
    public bool? AccessoriesDelete { get; set; }
    public bool? AccessoriesCheckout { get; set; }
    public bool? AccessoriesCheckin { get; set; }
    public bool? AccessoriesFiles { get; set; }
    public bool? ConsumablesView { get; set; }
    public bool? ConsumablesCreate { get; set; }
    public bool? ConsumablesEdit { get; set; }
    public bool? ConsumablesDelete { get; set; }
    public bool? ConsumablesCheckout { get; set; }
    public bool? ConsumablesFiles { get; set; }
    public bool? LicensesView { get; set; }
    public bool? LicensesCreate { get; set; }
    public bool? LicensesEdit { get; set; }
    public bool? LicensesDelete { get; set; }
    public bool? LicensesCheckout { get; set; }
    public bool? LicensesKeys { get; set; }
    public bool? LicensesFiles { get; set; }
    public bool? ComponentsView { get; set; }
    public bool? ComponentsCreate { get; set; }
    public bool? ComponentsEdit { get; set; }
    public bool? ComponentsDelete { get; set; }
    public bool? ComponentsCheckout { get; set; }
    public bool? ComponentsCheckin { get; set; }
    public bool? ComponentsFiles { get; set; }
    public bool? KitsView { get; set; }
    public bool? KitsCreate { get; set; }
    public bool? KitsEdit { get; set; }
    public bool? KitsDelete { get; set; }
    public bool? UsersView { get; set; }
    public bool? UsersCreate { get; set; }
    public bool? UsersEdit { get; set; }
    public bool? UsersDelete { get; set; }
    public bool? ModelsView { get; set; }
    public bool? ModelsCreate { get; set; }
    public bool? ModelsEdit { get; set; }
    public bool? ModelsDelete { get; set; }
    public bool? CategoriesView { get; set; }
    public bool? CategoriesCreate { get; set; }
    public bool? CategoriesEdit { get; set; }
    public bool? CategoriesDelete { get; set; }
    public bool? DepartmentsView { get; set; }
    public bool? DepartmentsCreate { get; set; }
    public bool? DepartmentsEdit { get; set; }
    public bool? DepartmentsDelete { get; set; }
    public bool? StatusLabelsView { get; set; }
    public bool? StatusLabelsCreate { get; set; }
    public bool? StatusLabelsEdit { get; set; }
    public bool? StatusLabelsDelete { get; set; }
    public bool? CustomFieldsView { get; set; }
    public bool? CustomFieldsCreate { get; set; }
    public bool? CustomFieldsEdit { get; set; }
    public bool? CustomFieldsDelete { get; set; }
    public bool? SuppliersView { get; set; }
    public bool? SuppliersCreate { get; set; }
    public bool? SuppliersEdit { get; set; }
    public bool? SuppliersDelete { get; set; }
    public bool? ManufacturersView { get; set; }
    public bool? ManufacturersCreate { get; set; }
    public bool? ManufacturersEdit { get; set; }
    public bool? ManufacturersDelete { get; set; }
    public bool? DepreciationsView { get; set; }
    public bool? DepreciationsCreate { get; set; }
    public bool? DepreciationsEdit { get; set; }
    public bool? DepreciationsDelete { get; set; }
    public bool? LocationsView { get; set; }
    public bool? LocationsCreate { get; set; }
    public bool? LocationsEdit { get; set; }
    public bool? LocationsDelete { get; set; }
    public bool? CompaniesView { get; set; }
    public bool? CompaniesCreate { get; set; }
    public bool? CompaniesEdit { get; set; }
    public bool? CompaniesDelete { get; set; }
    public bool? SelfTwoFactor { get; set; }
    public bool? SelfApi { get; set; }
    public bool? SelfEditLocation { get; set; }
    public bool? SelfCheckoutAssets { get; set; }
    public bool? SelfViewPurchaseCost { get; set; }
}
