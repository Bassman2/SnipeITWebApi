namespace SnipeITWebApi.Models;

internal class ManufacturerModel : BaseModel
{
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("support_url")]
    public string? SupportUrl { get; set; }

    [JsonPropertyName("warranty_lookup_url")]
    public string? WarrantyLookupUrl { get; set; }

    [JsonPropertyName("support_phone")]
    public string? SupportPhone { get; set; }

    [JsonPropertyName("support_email")]
    public string? SupportEmail { get; set; }

    [JsonPropertyName("assets_count")]
    public int AssetsCount { get; set; }

    [JsonPropertyName("licenses_count")]
    public int LicensesCount { get; set; }

    [JsonPropertyName("consumables_count")]
    public int ConsumablesCount { get; set; }

    [JsonPropertyName("accessories_count")]
    public int AccessoriesCount { get; set; }

    [JsonPropertyName("components_count")]
    public int ComponentsCount { get; set; }
}
