namespace SnipeITWebApi.Service.Model;

internal class ModelModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("manufacturer")]
    public NamedItemModel? Manufacturer { get; set; }

    [JsonPropertyName("manufacturer_id")]
    public int? ManufacturerId { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }

    [JsonPropertyName("model_number")]
    public string? ModelNumber { get; set; }

    [JsonPropertyName("min_amt")]
    public string? MinAmt { get; set; }

    [JsonPropertyName("remaining")]
    public int? Remaining { get; set; }

    [JsonPropertyName("depreciation")]
    public NamedItemModel? Depreciation { get; set; }

    [JsonPropertyName("assets_count")]
    public int? AssetsCount { get; set; }

    [JsonPropertyName("category")]
    public NamedItemModel? Category { get; set; }

    [JsonPropertyName("category_id")]
    public int? CategoryId { get; set; }

    [JsonPropertyName("fieldset")]
    public NamedItemModel? Fieldset { get; set; }

    [JsonPropertyName("fieldset_id")]
    public int? FieldsetId { get; set; }

    // TODO : default_fieldset_values

    [JsonPropertyName("eol")]
    public string? Eol { get; set; }

    [JsonPropertyName("requestable")]
    [JsonConverter(typeof(BoolJsonConverter))]
    public bool? Requestable { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("created_by")]
    public NamedItemModel? CreatedBy { get; set; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("deleted_at")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? DeletedAt { get; set; }

    [JsonPropertyName("available_actions")]
    public ActionsModel? AvailableActions { get; set; }
}
