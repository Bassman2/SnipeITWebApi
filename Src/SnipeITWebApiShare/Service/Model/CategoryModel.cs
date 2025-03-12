namespace SnipeITWebApi.Service.Model;

internal class CategoryModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }

    [JsonPropertyName("category_type")]
    public string? CategoryType { get; set; }

    [JsonPropertyName("has_eula")]
    public bool HasEula { get; set; }

    [JsonPropertyName("use_default_eula")]
    public bool UseDefaultEula { get; set; }

    [JsonPropertyName("eula")]
    public string? Eula { get; set; }

    [JsonPropertyName("checkin_email")]
    public bool CheckinEmail { get; set; }

    [JsonPropertyName("require_acceptance")]
    public bool RequireAcceptance { get; set; }

    [JsonPropertyName("item_count")]
    public int ItemCount { get; set; }

    [JsonPropertyName("assets_count")]
    public int AssetsCount { get; set; }

    [JsonPropertyName("accessories_count")]
    public int AccessoriesCount { get; set; }

    [JsonPropertyName("consumables_count")]
    public int ConsumablesCount { get; set; }

    [JsonPropertyName("components_count")]
    public int ComponentsCount { get; set; }

    [JsonPropertyName("licenses_count")]
    public int LicensesCount { get; set; }

    [JsonPropertyName("created_by")]
    public ItemModel? CreatedBy { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("created_at")]
    public DateItemModel? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateItemModel? UpdatedAt { get; set; }

    [JsonPropertyName("available_actions")]
    public ActionsModel? AvailableActions { get; set; }

}
