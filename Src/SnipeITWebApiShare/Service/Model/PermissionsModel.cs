namespace SnipeITWebApi.Service.Model;

internal class PermissionsModel
{
    [JsonPropertyName("superuser")]
    public bool? Superuser { get; set; }

    [JsonPropertyName("admin")]
    public bool? Admin { get; set; }

    [JsonPropertyName("import")]
    public bool? Import { get; set; }

    [JsonPropertyName("reports.view")]
    public bool? ReportsView { get; set; }

    [JsonPropertyName("assets.view")]
    public bool? AssetsView { get; set; }

    [JsonPropertyName("assets.create")]
    public bool? AssetsCreate { get; set; }

    [JsonPropertyName("assets.edit")]
    public bool? AssetsEdit { get; set; }

    [JsonPropertyName("assets.delete")]
    public bool? AssetsDelete { get; set; }

    [JsonPropertyName("assets.checkin")]
    public bool? AssetsCheckin { get; set; }

    [JsonPropertyName("assets.checkout")]
    public bool? AssetsCheckout { get; set; }

    [JsonPropertyName("assets.audit")]
    public bool? AssetsAudit { get; set; }

    [JsonPropertyName("assets.view.requestable")]
    public bool? AssetsViewRequestable { get; set; }

    [JsonPropertyName("assets.view.encrypted_custom_fields")]
    public bool? AssetsViewEncryptedCustomFields { get; set; }

    [JsonPropertyName("accessories.view")]
    public bool? AccessoriesView { get; set; }

    [JsonPropertyName("accessories.create")]
    public bool? AccessoriesCreate { get; set; }

    [JsonPropertyName("accessories.edit")]
    public bool? AccessoriesEdit { get; set; }

    [JsonPropertyName("accessories.delete")]
    public bool? AccessoriesDelete { get; set; }

    [JsonPropertyName("accessories.checkout")]
    public bool? AccessoriesCheckout { get; set; }

    [JsonPropertyName("accessories.checkin")]
    public bool? AccessoriesCheckin { get; set; }

    [JsonPropertyName("accessories.files")]
    public bool? AccessoriesFiles { get; set; }

    [JsonPropertyName("consumables.view")]
    public bool? ConsumablesView { get; set; }

    [JsonPropertyName("consumables.create")]
    public bool? ConsumablesCreate { get; set; }

    [JsonPropertyName("consumables.edit")]
    public bool? ConsumablesEdit { get; set; }

    [JsonPropertyName("consumables.delete")]
    public bool? ConsumablesDelete { get; set; }

    [JsonPropertyName("consumables.checkout")]
    public bool? ConsumablesCheckout { get; set; }

    [JsonPropertyName("consumables.files")]
    public bool? ConsumablesFiles { get; set; }

    [JsonPropertyName("licenses.view")]
    public bool? LicensesView { get; set; }

    [JsonPropertyName("licenses.create")]
    public bool? LicensesCreate { get; set; }

    [JsonPropertyName("licenses.edit")]
    public bool? LicensesEdit { get; set; }

    [JsonPropertyName("licenses.delete")]
    public bool? LicensesDelete { get; set; }

    [JsonPropertyName("licenses.checkout")]
    public bool? LicensesCheckout { get; set; }

    [JsonPropertyName("licenses.keys")]
    public bool? LicensesKeys { get; set; }

    [JsonPropertyName("licenses.files")]
    public bool? LicensesFiles { get; set; }

    [JsonPropertyName("components.view")]
    public bool? ComponentsView { get; set; }

    [JsonPropertyName("components.create")]
    public bool? ComponentsCreate { get; set; }

    [JsonPropertyName("components.edit")]
    public bool? ComponentsEdit { get; set; }

    [JsonPropertyName("components.delete")]
    public bool? ComponentsDelete { get; set; }

    [JsonPropertyName("components.checkout")]
    public bool? ComponentsCheckout { get; set; }

    [JsonPropertyName("components.checkin")]
    public bool? ComponentsCheckin { get; set; }

    [JsonPropertyName("components.files")]
    public bool? ComponentsFiles { get; set; }

    [JsonPropertyName("kits.view")]
    public bool? KitsView { get; set; }

    [JsonPropertyName("kits.create")]
    public bool? KitsCreate { get; set; }

    [JsonPropertyName("kits.edit")]
    public bool? KitsEdit { get; set; }

    [JsonPropertyName("kits.delete")]
    public bool? KitsDelete { get; set; }

    [JsonPropertyName("users.view")]
    public bool? UsersView { get; set; }

    [JsonPropertyName("users.create")]
    public bool? UsersCreate { get; set; }

    [JsonPropertyName("users.edit")]
    public bool? UsersEdit { get; set; }

    [JsonPropertyName("users.delete")]
    public bool? UsersDelete { get; set; }

    [JsonPropertyName("models.view")]
    public bool? ModelsView { get; set; }

    [JsonPropertyName("models.create")]
    public bool? ModelsCreate { get; set; }

    [JsonPropertyName("models.edit")]
    public bool? ModelsEdit { get; set; }

    [JsonPropertyName("models.delete")]
    public bool? ModelsDelete { get; set; }

    [JsonPropertyName("categories.view")]
    public bool? CategoriesView { get; set; }

    [JsonPropertyName("categories.create")]
    public bool? CategoriesCreate { get; set; }

    [JsonPropertyName("categories.edit")]
    public bool? CategoriesEdit { get; set; }

    [JsonPropertyName("categories.delete")]
    public bool? CategoriesDelete { get; set; }

    [JsonPropertyName("departments.view")]
    public bool? DepartmentsView { get; set; }

    [JsonPropertyName("departments.create")]
    public bool? DepartmentsCreate { get; set; }

    [JsonPropertyName("departments.edit")]
    public bool? DepartmentsEdit { get; set; }

    [JsonPropertyName("departments.delete")]
    public bool? DepartmentsDelete { get; set; }

    [JsonPropertyName("statuslabels.view")]
    public bool? StatusLabelsView { get; set; }

    [JsonPropertyName("statuslabels.create")]
    public bool? StatusLabelsCreate { get; set; }

    [JsonPropertyName("statuslabels.edit")]
    public bool? StatusLabelsEdit { get; set; }

    [JsonPropertyName("statuslabels.delete")]
    public bool? StatusLabelsDelete { get; set; }

    [JsonPropertyName("customfields.view")]
    public bool? CustomFieldsView { get; set; }

    [JsonPropertyName("customfields.create")]
    public bool? CustomFieldsCreate { get; set; }

    [JsonPropertyName("customfields.edit")]
    public bool? CustomFieldsEdit { get; set; }

    [JsonPropertyName("customfields.delete")]
    public bool? CustomFieldsDelete { get; set; }

    [JsonPropertyName("suppliers.view")]
    public bool? SuppliersView { get; set; }

    [JsonPropertyName("suppliers.create")]
    public bool? SuppliersCreate { get; set; }

    [JsonPropertyName("suppliers.edit")]
    public bool? SuppliersEdit { get; set; }

    [JsonPropertyName("suppliers.delete")]
    public bool? SuppliersDelete { get; set; }

    [JsonPropertyName("manufacturers.view")]
    public bool? ManufacturersView { get; set; }

    [JsonPropertyName("manufacturers.create")]
    public bool? ManufacturersCreate { get; set; }

    [JsonPropertyName("manufacturers.edit")]
    public bool? ManufacturersEdit { get; set; }

    [JsonPropertyName("manufacturers.delete")]
    public bool? ManufacturersDelete { get; set; }

    [JsonPropertyName("depreciations.view")]
    public bool? DepreciationsView { get; set; }

    [JsonPropertyName("depreciations.create")]
    public bool? DepreciationsCreate { get; set; }

    [JsonPropertyName("depreciations.edit")]
    public bool? DepreciationsEdit { get; set; }

    [JsonPropertyName("depreciations.delete")]
    public bool? DepreciationsDelete { get; set; }

    [JsonPropertyName("locations.view")]
    public bool? LocationsView { get; set; }

    [JsonPropertyName("locations.create")]
    public bool? LocationsCreate { get; set; }

    [JsonPropertyName("locations.edit")]
    public bool? LocationsEdit { get; set; }

    [JsonPropertyName("locations.delete")]
    public bool? LocationsDelete { get; set; }

    [JsonPropertyName("companies.view")]
    public bool? CompaniesView { get; set; }

    [JsonPropertyName("companies.create")]
    public bool? CompaniesCreate { get; set; }

    [JsonPropertyName("companies.edit")]
    public bool? CompaniesEdit { get; set; }

    [JsonPropertyName("companies.delete")]
    public bool? CompaniesDelete { get; set; }

    [JsonPropertyName("self.two_factor")]
    public bool? SelfTwoFactor { get; set; }

    [JsonPropertyName("self.api")]
    public bool? SelfApi { get; set; }

    [JsonPropertyName("self.edit_location")]
    public bool? SelfEditLocation { get; set; }

    [JsonPropertyName("self.checkout_assets")]
    public bool? SelfCheckoutAssets { get; set; }

    [JsonPropertyName("self.view_purchase_cost")]
    public bool? SelfViewPurchaseCost { get; set; }
}
