namespace SnipeITWebApi.Models;

internal class MaintenanceChangeModel : BaseChangeModel
{
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("asset_id")]
    public int? AssetId { get; set; }

    [JsonPropertyName("supplier_id")]
    public int? SupplierId { get; set; }

    [JsonPropertyName("asset_maintenance_type")]
    [JsonConverter(typeof(JsonStringEnumConverter<MaintenanceType>))]
    public MaintenanceType? AssetMaintenanceType { get; set; }

    [JsonPropertyName("start_date")]
    [JsonConverter(typeof(DateJsonConverter))]
    public DateTime? StartDate { get; set; }

    [JsonPropertyName("is_warranty")]
    public bool? IsWarrenty { get; set; }

    [JsonPropertyName("cost")]
    [JsonConverter(typeof(FloatJsonConverter))]
    public float? Cost { get; set; }

    [JsonPropertyName("completion_date")]
    [JsonConverter(typeof(DateJsonConverter))]
    public DateTime? CompletionDate { get; set; }

}
