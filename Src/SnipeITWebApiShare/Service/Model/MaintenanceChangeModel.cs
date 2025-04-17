namespace SnipeITWebApi.Service.Model;

internal class MaintenanceChangeModel : BaseChangeModel
{
    [JsonPropertyName("asset_id")]
    public int? AssetId { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("supplier_id")]
    public int? SupplierId { get; set; }

    [JsonPropertyName("start_date")]
    [JsonConverter(typeof(DateJsonConverter))]
    public DateTime? StartDate { get; set; }

    [JsonPropertyName("asset_maintenance_type")]
    public string? AssetMaintenanceType { get; set; }
}
