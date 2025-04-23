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

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj != null && obj is Permissions perm)
        {
            return
                Superuser == perm.Superuser &&
                Admin == perm.Admin &&
                Import == perm.Import &&
                ReportsView == perm.ReportsView &&
                AssetsView == perm.AssetsView &&
                AssetsCreate == perm.AssetsCreate &&
                AssetsEdit == perm.AssetsEdit &&
                AssetsDelete == perm.AssetsDelete &&
                AssetsCheckin == perm.AssetsCheckin &&
                AssetsCheckout == perm.AssetsCheckout &&
                AssetsAudit == perm.AssetsAudit &&
                AssetsViewRequestable == perm.AssetsViewRequestable &&
                AssetsViewEncryptedCustomFields == perm.AssetsViewEncryptedCustomFields &&
                AccessoriesView == perm.AccessoriesView &&
                AccessoriesCreate == perm.AccessoriesCreate &&
                AccessoriesEdit == perm.AccessoriesEdit &&
                AccessoriesDelete == perm.AccessoriesDelete &&
                AccessoriesCheckout == perm.AccessoriesCheckout &&
                AccessoriesCheckin == perm.AccessoriesCheckin &&
                AccessoriesFiles == perm.AccessoriesFiles &&
                ConsumablesView == perm.ConsumablesView &&
                ConsumablesCreate == perm.ConsumablesCreate &&
                ConsumablesEdit == perm.ConsumablesEdit &&
                ConsumablesDelete == perm.ConsumablesDelete &&
                ConsumablesCheckout == perm.ConsumablesCheckout &&
                ConsumablesFiles == perm.ConsumablesFiles &&
                LicensesView == perm.LicensesView &&
                LicensesCreate == perm.LicensesCreate &&
                LicensesEdit == perm.LicensesEdit &&
                LicensesDelete == perm.LicensesDelete &&
                LicensesCheckout == perm.LicensesCheckout &&
                LicensesKeys == perm.LicensesKeys &&
                LicensesFiles == perm.LicensesFiles &&
                ComponentsView == perm.ComponentsView &&
                ComponentsCreate == perm.ComponentsCreate &&
                ComponentsEdit == perm.ComponentsEdit &&
                ComponentsDelete == perm.ComponentsDelete &&
                ComponentsCheckout == perm.ComponentsCheckout &&
                ComponentsCheckin == perm.ComponentsCheckin &&
                ComponentsFiles == perm.ComponentsFiles &&
                KitsView == perm.KitsView &&
                KitsCreate == perm.KitsCreate &&
                KitsEdit == perm.KitsEdit &&
                KitsDelete == perm.KitsDelete &&
                UsersView == perm.UsersView &&
                UsersCreate == perm.UsersCreate &&
                UsersEdit == perm.UsersEdit &&
                UsersDelete == perm.UsersDelete &&
                ModelsView == perm.ModelsView &&
                ModelsCreate == perm.ModelsCreate &&
                ModelsEdit == perm.ModelsEdit &&
                ModelsDelete == perm.ModelsDelete &&
                CategoriesView == perm.CategoriesView &&
                CategoriesCreate == perm.CategoriesCreate &&
                CategoriesEdit == perm.CategoriesEdit &&
                CategoriesDelete == perm.CategoriesDelete &&

                DepartmentsView == perm.DepartmentsView &&
                DepartmentsCreate == perm.DepartmentsCreate &&
                DepartmentsEdit == perm.DepartmentsEdit &&

                DepartmentsDelete == perm.DepartmentsDelete &&
                StatusLabelsView == perm.StatusLabelsView &&
                StatusLabelsCreate == perm.StatusLabelsCreate &&
                StatusLabelsEdit == perm.StatusLabelsEdit &&
                StatusLabelsDelete == perm.StatusLabelsDelete &&
                CustomFieldsView == perm.CustomFieldsView &&
                CustomFieldsCreate == perm.CustomFieldsCreate &&
                CustomFieldsEdit == perm.CustomFieldsEdit &&
                CustomFieldsDelete == perm.CustomFieldsDelete &&
                SuppliersView == perm.SuppliersView &&
                SuppliersCreate == perm.SuppliersCreate &&
                SuppliersEdit == perm.SuppliersEdit &&
                SuppliersDelete == perm.SuppliersDelete &&
                ManufacturersView == perm.ManufacturersView &&
                ManufacturersCreate == perm.ManufacturersCreate &&
                ManufacturersEdit == perm.ManufacturersEdit &&
                ManufacturersDelete == perm.ManufacturersDelete &&
                DepreciationsView == perm.DepreciationsView &&
                DepreciationsCreate == perm.DepreciationsCreate &&
                DepreciationsEdit == perm.DepreciationsEdit &&
                DepreciationsDelete == perm.DepreciationsDelete &&
                LocationsView == perm.LocationsView &&
                LocationsCreate == perm.LocationsCreate &&
                LocationsEdit == perm.LocationsEdit &&
                LocationsDelete == perm.LocationsDelete &&
                CompaniesView == perm.CompaniesView &&
                CompaniesCreate == perm.CompaniesCreate &&
                CompaniesEdit == perm.CompaniesEdit &&
                CompaniesDelete == perm.CompaniesDelete &&
                SelfTwoFactor == perm.SelfTwoFactor &&
                SelfApi == perm.SelfApi &&
                SelfEditLocation == perm.SelfEditLocation &&

                SelfCheckoutAssets == perm.SelfCheckoutAssets &&
                SelfViewPurchaseCost == perm.SelfViewPurchaseCost;
        }
        return false;

    }

    /// <summary>
    /// Indicates if the user has superuser privileges.
    /// </summary>
    public bool? Superuser { get; set; }

    /// <summary>
    /// Indicates if the user has administrative privileges.
    /// </summary>
    public bool? Admin { get; set; }

    /// <summary>
    /// Indicates if the user can import data.
    /// </summary>
    public bool? Import { get; set; }

    /// <summary>
    /// Indicates if the user can view reports.
    /// </summary>
    public bool? ReportsView { get; set; }

    /// <summary>
    /// Indicates if the user can view assets.
    /// </summary>
    public bool? AssetsView { get; set; }

    /// <summary>
    /// Indicates if the user can create assets.
    /// </summary>
    public bool? AssetsCreate { get; set; }

    /// <summary>
    /// Indicates if the user can edit assets.
    /// </summary>
    public bool? AssetsEdit { get; set; }

    /// <summary>
    /// Indicates if the user can delete assets.
    /// </summary>
    public bool? AssetsDelete { get; set; }

    /// <summary>
    /// Indicates if the user can check in assets.
    /// </summary>
    public bool? AssetsCheckin { get; set; }

    /// <summary>
    /// Indicates if the user can check out assets.
    /// </summary>
    public bool? AssetsCheckout { get; set; }

    /// <summary>
    /// Indicates if the user can audit assets.
    /// </summary>
    public bool? AssetsAudit { get; set; }

    /// <summary>
    /// Indicates if the user can view requestable assets.
    /// </summary>
    public bool? AssetsViewRequestable { get; set; }

    /// <summary>
    /// Indicates if the user can view encrypted custom fields of assets.
    /// </summary>
    public bool? AssetsViewEncryptedCustomFields { get; set; }

    /// <summary>
    /// Indicates if the user can view accessories.
    /// </summary>
    public bool? AccessoriesView { get; set; }

    /// <summary>
    /// Indicates if the user can create accessories.
    /// </summary>
    public bool? AccessoriesCreate { get; set; }

    /// <summary>
    /// Indicates if the user can edit accessories.
    /// </summary>
    public bool? AccessoriesEdit { get; set; }

    /// <summary>
    /// Indicates if the user can delete accessories.
    /// </summary>
    public bool? AccessoriesDelete { get; set; }

    /// <summary>
    /// Indicates if the user can check out accessories.
    /// </summary>
    public bool? AccessoriesCheckout { get; set; }

    /// <summary>
    /// Indicates if the user can check in accessories.
    /// </summary>
    public bool? AccessoriesCheckin { get; set; }

    /// <summary>
    /// Indicates if the user can manage files for accessories.
    /// </summary>
    public bool? AccessoriesFiles { get; set; }

    /// <summary>
    /// Indicates if the user can view consumables.
    /// </summary>
    public bool? ConsumablesView { get; set; }

    /// <summary>
    /// Indicates if the user can create consumables.
    /// </summary>
    public bool? ConsumablesCreate { get; set; }

    /// <summary>
    /// Indicates if the user can edit consumables.
    /// </summary>
    public bool? ConsumablesEdit { get; set; }

    /// <summary>
    /// Indicates if the user can delete consumables.
    /// </summary>
    public bool? ConsumablesDelete { get; set; }

    /// <summary>
    /// Indicates if the user can check out consumables.
    /// </summary>
    public bool? ConsumablesCheckout { get; set; }

    /// <summary>
    /// Indicates if the user can manage files for consumables.
    /// </summary>
    public bool? ConsumablesFiles { get; set; }

    /// <summary>
    /// Indicates if the user can view licenses.
    /// </summary>
    public bool? LicensesView { get; set; }

    /// <summary>
    /// Indicates if the user can create licenses.
    /// </summary>
    public bool? LicensesCreate { get; set; }

    /// <summary>
    /// Indicates if the user can edit licenses.
    /// </summary>
    public bool? LicensesEdit { get; set; }

    /// <summary>
    /// Indicates if the user can delete licenses.
    /// </summary>
    public bool? LicensesDelete { get; set; }

    /// <summary>
    /// Indicates if the user can check out licenses.
    /// </summary>
    public bool? LicensesCheckout { get; set; }

    /// <summary>
    /// Indicates if the user can manage license keys.
    /// </summary>
    public bool? LicensesKeys { get; set; }

    /// <summary>
    /// Indicates if the user can manage files for licenses.
    /// </summary>
    public bool? LicensesFiles { get; set; }

    /// <summary>
    /// Indicates if the user can view components.
    /// </summary>
    public bool? ComponentsView { get; set; }

    /// <summary>
    /// Indicates if the user can create components.
    /// </summary>
    public bool? ComponentsCreate { get; set; }

    /// <summary>
    /// Indicates if the user can edit components.
    /// </summary>
    public bool? ComponentsEdit { get; set; }

    /// <summary>
    /// Indicates if the user can delete components.
    /// </summary>
    public bool? ComponentsDelete { get; set; }

    /// <summary>
    /// Indicates if the user can check out components.
    /// </summary>
    public bool? ComponentsCheckout { get; set; }

    /// <summary>
    /// Indicates if the user can check in components.
    /// </summary>
    public bool? ComponentsCheckin { get; set; }

    /// <summary>
    /// Indicates if the user can manage files for components.
    /// </summary>
    public bool? ComponentsFiles { get; set; }

    /// <summary>
    /// Indicates if the user can view kits.
    /// </summary>
    public bool? KitsView { get; set; }

    /// <summary>
    /// Indicates if the user can create kits.
    /// </summary>
    public bool? KitsCreate { get; set; }

    /// <summary>
    /// Indicates if the user can edit kits.
    /// </summary>
    public bool? KitsEdit { get; set; }

    /// <summary>
    /// Indicates if the user can delete kits.
    /// </summary>
    public bool? KitsDelete { get; set; }

    /// <summary>
    /// Indicates if the user can view users.
    /// </summary>
    public bool? UsersView { get; set; }

    /// <summary>
    /// Indicates if the user can create users.
    /// </summary>
    public bool? UsersCreate { get; set; }

    /// <summary>
    /// Indicates if the user can edit users.
    /// </summary>
    public bool? UsersEdit { get; set; }

    /// <summary>
    /// Indicates if the user can delete users.
    /// </summary>
    public bool? UsersDelete { get; set; }

    /// <summary>
    /// Indicates if the user can view models.
    /// </summary>
    public bool? ModelsView { get; set; }

    /// <summary>
    /// Indicates if the user can create models.
    /// </summary>
    public bool? ModelsCreate { get; set; }

    /// <summary>
    /// Indicates if the user can edit models.
    /// </summary>
    public bool? ModelsEdit { get; set; }

    /// <summary>
    /// Indicates if the user can delete models.
    /// </summary>
    public bool? ModelsDelete { get; set; }

    /// <summary>
    /// Indicates if the user can view categories.
    /// </summary>
    public bool? CategoriesView { get; set; }

    /// <summary>
    /// Indicates if the user can create categories.
    /// </summary>
    public bool? CategoriesCreate { get; set; }

    /// <summary>
    /// Indicates if the user can edit categories.
    /// </summary>
    public bool? CategoriesEdit { get; set; }

    /// <summary>
    /// Indicates if the user can delete categories.
    /// </summary>
    public bool? CategoriesDelete { get; set; }

    /// <summary>
    /// Indicates if the user can view departments.
    /// </summary>
    public bool? DepartmentsView { get; set; }

    /// <summary>
    /// Indicates if the user can create departments.
    /// </summary>
    public bool? DepartmentsCreate { get; set; }

    /// <summary>
    /// Indicates if the user can edit departments.
    /// </summary>
    public bool? DepartmentsEdit { get; set; }

    /// <summary>
    /// Indicates if the user can delete departments.
    /// </summary>
    public bool? DepartmentsDelete { get; set; }

    /// <summary>
    /// Indicates if the user can view status labels.
    /// </summary>
    public bool? StatusLabelsView { get; set; }

    /// <summary>
    /// Indicates if the user can create status labels.
    /// </summary>
    public bool? StatusLabelsCreate { get; set; }

    /// <summary>
    /// Indicates if the user can edit status labels.
    /// </summary>
    public bool? StatusLabelsEdit { get; set; }

    /// <summary>
    /// Indicates if the user can delete status labels.
    /// </summary>
    public bool? StatusLabelsDelete { get; set; }

    /// <summary>
    /// Indicates if the user can view custom fields.
    /// </summary>
    public bool? CustomFieldsView { get; set; }

    /// <summary>
    /// Indicates if the user can create custom fields.
    /// </summary>
    public bool? CustomFieldsCreate { get; set; }

    /// <summary>
    /// Indicates if the user can edit custom fields.
    /// </summary>
    public bool? CustomFieldsEdit { get; set; }

    /// <summary>
    /// Indicates if the user can delete custom fields.
    /// </summary>
    public bool? CustomFieldsDelete { get; set; }

    /// <summary>
    /// Indicates if the user can view suppliers.
    /// </summary>
    public bool? SuppliersView { get; set; }

    /// <summary>
    /// Indicates if the user can create suppliers.
    /// </summary>
    public bool? SuppliersCreate { get; set; }

    /// <summary>
    /// Indicates if the user can edit suppliers.
    /// </summary>
    public bool? SuppliersEdit { get; set; }

    /// <summary>
    /// Indicates if the user can delete suppliers.
    /// </summary>
    public bool? SuppliersDelete { get; set; }

    /// <summary>
    /// Indicates if the user can view manufacturers.
    /// </summary>
    public bool? ManufacturersView { get; set; }

    /// <summary>
    /// Indicates if the user can create manufacturers.
    /// </summary>
    public bool? ManufacturersCreate { get; set; }

    /// <summary>
    /// Indicates if the user can edit manufacturers.
    /// </summary>
    public bool? ManufacturersEdit { get; set; }

    /// <summary>
    /// Indicates if the user can delete manufacturers.
    /// </summary>
    public bool? ManufacturersDelete { get; set; }

    /// <summary>
    /// Indicates if the user can view depreciations.
    /// </summary>
    public bool? DepreciationsView { get; set; }

    /// <summary>
    /// Indicates if the user can create depreciations.
    /// </summary>
    public bool? DepreciationsCreate { get; set; }

    /// <summary>
    /// Indicates if the user can edit depreciations.
    /// </summary>
    public bool? DepreciationsEdit { get; set; }

    /// <summary>
    /// Indicates if the user can delete depreciations.
    /// </summary>
    public bool? DepreciationsDelete { get; set; }

    /// <summary>
    /// Indicates if the user can view locations.
    /// </summary>
    public bool? LocationsView { get; set; }

    /// <summary>
    /// Indicates if the user can create locations.
    /// </summary>
    public bool? LocationsCreate { get; set; }

    /// <summary>
    /// Indicates if the user can edit locations.
    /// </summary>
    public bool? LocationsEdit { get; set; }

    /// <summary>
    /// Indicates if the user can delete locations.
    /// </summary>
    public bool? LocationsDelete { get; set; }

    /// <summary>
    /// Indicates if the user can view companies.
    /// </summary>
    public bool? CompaniesView { get; set; }

    /// <summary>
    /// Indicates if the user can create companies.
    /// </summary>
    public bool? CompaniesCreate { get; set; }

    /// <summary>
    /// Indicates if the user can edit companies.
    /// </summary>
    public bool? CompaniesEdit { get; set; }

    /// <summary>
    /// Indicates if the user can delete companies.
    /// </summary>
    public bool? CompaniesDelete { get; set; }

    /// <summary>
    /// Indicates if the user can enable two-factor authentication for themselves.
    /// </summary>
    public bool? SelfTwoFactor { get; set; }

    /// <summary>
    /// Indicates if the user can manage their own API keys.
    /// </summary>
    public bool? SelfApi { get; set; }

    /// <summary>
    /// Indicates if the user can edit their own location.
    /// </summary>
    public bool? SelfEditLocation { get; set; }

    /// <summary>
    /// Indicates if the user can check out assets for themselves.
    /// </summary>
    public bool? SelfCheckoutAssets { get; set; }

    /// <summary>
    /// Indicates if the user can view the purchase cost of assets for themselves.
    /// </summary>
    public bool? SelfViewPurchaseCost { get; set; }
}
