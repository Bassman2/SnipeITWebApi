namespace SnipeITWebApi.Service.Model;

internal class PermissionsModel
{
    [JsonPropertyName("superuser")]
    public string? Superuser { get; set; }

    [JsonPropertyName("admin")]
    public string? Admin { get; set; }

    [JsonPropertyName("import")]
    public string? Import { get; set; }

    [JsonPropertyName("reports.view")]
    public string? ReportsView { get; set; }

    [JsonPropertyName("assets.view")]
    public string? AssetsView { get; set; }

    [JsonPropertyName("assets.create")]
    public string? AssetsCreate { get; set; }

    [JsonPropertyName("assets.edit")]
    public string? AssetsEdit { get; set; }

    [JsonPropertyName("assets.delete")]
    public string? AssetsDelete { get; set; }

    [JsonPropertyName("assets.checkin")]
    public string? AssetsCheckin { get; set; }

    [JsonPropertyName("assets.checkout")]
    public string? AssetsCheckout { get; set; }

    [JsonPropertyName("assets.audit")]
    public string? AssetsAudit { get; set; }

    [JsonPropertyName("assets.view.requestable")]
    public string? AssetsViewRequestable { get; set; }

    [JsonPropertyName("assets.view.encrypted_custom_fields")]
    public string? AssetsViewEncryptedCustomFields { get; set; }

    [JsonPropertyName("accessories.view")]
    public string? AccessoriesView { get; set; }

    [JsonPropertyName("accessories.create")]
    public string? AccessoriesCreate { get; set; }

    [JsonPropertyName("accessories.edit")]
    public string? AccessoriesEdit { get; set; }

    [JsonPropertyName("accessories.delete")]
    public string? AccessoriesDelete { get; set; }

    [JsonPropertyName("accessories.checkout")]
    public string? AccessoriesCheckout { get; set; }

    [JsonPropertyName("accessories.checkin")]
    public string? AccessoriesCheckin { get; set; }

    [JsonPropertyName("accessories.files")]
    public string? AccessoriesFiles { get; set; }

    [JsonPropertyName("consumables.view")]
    public string? ConsumablesView { get; set; }

    [JsonPropertyName("consumables.create")]
    public string? ConsumablesCreate { get; set; }

    [JsonPropertyName("consumables.edit")]
    public string? ConsumablesEdit { get; set; }

    [JsonPropertyName("consumables.delete")]
    public string? ConsumablesDelete { get; set; }

    [JsonPropertyName("consumables.checkout")]
    public string? ConsumablesCheckout { get; set; }

    [JsonPropertyName("consumables.files")]
    public string? ConsumablesFiles { get; set; }

    [JsonPropertyName("licenses.view")]
    public string? LicensesView { get; set; }

    [JsonPropertyName("licenses.create")]
    public string? LicensesCreate { get; set; }

    [JsonPropertyName("licenses.edit")]
    public string? LicensesEdit { get; set; }

    [JsonPropertyName("licenses.delete")]
    public string? LicensesDelete { get; set; }

    [JsonPropertyName("licenses.checkout")]
    public string? LicensesCheckout { get; set; }

    [JsonPropertyName("licenses.keys")]
    public string? LicensesKeys { get; set; }

    [JsonPropertyName("licenses.files")]
    public string? LicensesFiles { get; set; }

    [JsonPropertyName("components.view")]
    public string? ComponentsView { get; set; }

    [JsonPropertyName("components.create")]
    public string? ComponentsCreate { get; set; }

    [JsonPropertyName("components.edit")]
    public string? ComponentsEdit { get; set; }

    [JsonPropertyName("components.delete")]
    public string? ComponentsDelete { get; set; }

    [JsonPropertyName("components.checkout")]
    public string? ComponentsCheckout { get; set; }

    [JsonPropertyName("components.checkin")]
    public string? ComponentsCheckin { get; set; }

    [JsonPropertyName("components.files")]
    public string? ComponentsFiles { get; set; }

    [JsonPropertyName("kits.view")]
    public string? KitsView { get; set; }

    [JsonPropertyName("kits.create")]
    public string? KitsCreate { get; set; }

    [JsonPropertyName("kits.edit")]
    public string? KitsEdit { get; set; }

    [JsonPropertyName("kits.delete")]
    public string? KitsDelete { get; set; }

    [JsonPropertyName("users.view")]
    public string? UsersView { get; set; }

    [JsonPropertyName("users.create")]
    public string? UsersCreate { get; set; }

    [JsonPropertyName("users.edit")]
    public string? UsersEdit { get; set; }

    [JsonPropertyName("users.delete")]
    public string? UsersDelete { get; set; }

    [JsonPropertyName("models.view")]
    public string? ModelsView { get; set; }

    [JsonPropertyName("models.create")]
    public string? ModelsCreate { get; set; }

    [JsonPropertyName("models.edit")]
    public string? ModelsEdit { get; set; }

    [JsonPropertyName("models.delete")]
    public string? ModelsDelete { get; set; }

    [JsonPropertyName("categories.view")]
    public string? CategoriesView { get; set; }

    [JsonPropertyName("categories.create")]
    public string? CategoriesCreate { get; set; }

    [JsonPropertyName("categories.edit")]
    public string? CategoriesEdit { get; set; }

    [JsonPropertyName("categories.delete")]
    public string? CategoriesDelete { get; set; }

    [JsonPropertyName("departments.view")]
    public string? DepartmentsView { get; set; }

    [JsonPropertyName("departments.create")]
    public string? DepartmentsCreate { get; set; }

    [JsonPropertyName("departments.edit")]
    public string? DepartmentsEdit { get; set; }

    [JsonPropertyName("departments.delete")]
    public string? DepartmentsDelete { get; set; }

    [JsonPropertyName("statuslabels.view")]
    public string? StatusLabelsView { get; set; }

    [JsonPropertyName("statuslabels.create")]
    public string? StatusLabelsCreate { get; set; }

    [JsonPropertyName("statuslabels.edit")]
    public string? StatusLabelsEdit { get; set; }

    [JsonPropertyName("statuslabels.delete")]
    public string? StatusLabelsDelete { get; set; }

    [JsonPropertyName("customfields.view")]
    public string? CustomFieldsView { get; set; }

    [JsonPropertyName("customfields.create")]
    public string? CustomFieldsCreate { get; set; }

    [JsonPropertyName("customfields.edit")]
    public string? CustomFieldsEdit { get; set; }

    [JsonPropertyName("customfields.delete")]
    public string? CustomFieldsDelete { get; set; }

    [JsonPropertyName("suppliers.view")]
    public string? SuppliersView { get; set; }

    [JsonPropertyName("suppliers.create")]
    public string? SuppliersCreate { get; set; }

    [JsonPropertyName("suppliers.edit")]
    public string? SuppliersEdit { get; set; }

    [JsonPropertyName("suppliers.delete")]
    public string? SuppliersDelete { get; set; }

    [JsonPropertyName("manufacturers.view")]
    public string? ManufacturersView { get; set; }

    [JsonPropertyName("manufacturers.create")]
    public string? ManufacturersCreate { get; set; }

    [JsonPropertyName("manufacturers.edit")]
    public string? ManufacturersEdit { get; set; }

    [JsonPropertyName("manufacturers.delete")]
    public string? ManufacturersDelete { get; set; }

    [JsonPropertyName("depreciations.view")]
    public string? DepreciationsView { get; set; }

    [JsonPropertyName("depreciations.create")]
    public string? DepreciationsCreate { get; set; }

    [JsonPropertyName("depreciations.edit")]
    public string? DepreciationsEdit { get; set; }

    [JsonPropertyName("depreciations.delete")]
    public string? DepreciationsDelete { get; set; }

    [JsonPropertyName("locations.view")]
    public string? LocationsView { get; set; }

    [JsonPropertyName("locations.create")]
    public string? LocationsCreate { get; set; }

    [JsonPropertyName("locations.edit")]
    public string? LocationsEdit { get; set; }

    [JsonPropertyName("locations.delete")]
    public string? LocationsDelete { get; set; }

    [JsonPropertyName("companies.view")]
    public string? CompaniesView { get; set; }

    [JsonPropertyName("companies.create")]
    public string? CompaniesCreate { get; set; }

    [JsonPropertyName("companies.edit")]
    public string? CompaniesEdit { get; set; }

    [JsonPropertyName("companies.delete")]
    public string? CompaniesDelete { get; set; }

    [JsonPropertyName("self.two_factor")]
    public string? SelfTwoFactor { get; set; }

    [JsonPropertyName("self.api")]
    public string? SelfApi { get; set; }

    [JsonPropertyName("self.edit_location")]
    public string? SelfEditLocation { get; set; }

    [JsonPropertyName("self.checkout_assets")]
    public string? SelfCheckoutAssets { get; set; }

    [JsonPropertyName("self.view_purchase_cost")]
    public string? SelfViewPurchaseCost { get; set; }
}
