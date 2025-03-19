namespace SnipeITWebApi.Service.Model;

internal class ManufacturerModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }

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

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("created_by")]
    public ItemModel? CreatedBy { get; set; }

    //[JsonPropertyName("created_at")]
    //public DateItemModel? CreatedAt { get; set; }

    //[JsonPropertyName("updated_at")]
    //public DateItemModel? UpdatedAt { get; set; }

    //[JsonPropertyName("deleted_at")]
    //public DateItemModel? DeletedAt { get; set; }

    [JsonPropertyName("available_actions")]
    public ActionsModel? AvailableActions { get; set; }

}
