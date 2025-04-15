namespace SnipeITWebApi.Service.Model;

internal class CategoryModel : BaseModel
{
    [JsonPropertyName("category_type")]
    public CategoryType? CategoryType { get; set; }

    [JsonPropertyName("has_eula")]
    public bool HasEula { get; set; }

    [JsonPropertyName("use_default_eula")]
    public bool UseDefaultEula { get; set; }

    [JsonPropertyName("eula")]
    public string? Eula { get; set; }

    [JsonPropertyName("checkin_email")]
    [JsonConverter(typeof(BooleanJsonConverter))]
    public bool? CheckinEmail { get; set; }

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
}
