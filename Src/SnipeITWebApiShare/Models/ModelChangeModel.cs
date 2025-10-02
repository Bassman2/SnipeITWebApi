namespace SnipeITWebApi.Models;

internal class ModelChangeModel : BaseChangeModel
{
    [JsonPropertyName("category_id")]
    public int? CategoryId { get; set; }

    [JsonPropertyName("model_number")]
    public string? ModelNumber { get; set; }

    [JsonPropertyName("fieldset_id")]
    public int? FieldsetId { get; set; }

    [JsonPropertyName("manufacturer_id")]
    public int? ManufacturerId { get; set; }

    [JsonPropertyName("depreciation_id")]
    public int? DepreciationId { get; set; }

    [JsonPropertyName("requestable")]
    public bool? Requestable { get; set; }

    [JsonPropertyName("eol")]
    public int? Eol { get; set; }
}
