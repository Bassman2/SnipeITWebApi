namespace SnipeITWebApi.Service.Model;

internal class MaintenanceModel : BaseModel
{
    [JsonPropertyName("asset")]
    public HardwareModel? Asset { get; set; }

    [JsonPropertyName("asset_id")]
    public int? AssetId { get; set; }

    [JsonPropertyName("model")]
    public NamedItemModel? Model { get; set; }

    [JsonPropertyName("status_label")]
    public StatusLabelModel? StatusLabel { get; set; }

    [JsonPropertyName("company")]
    public NamedItemModel? Company { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("location")]
    public NamedItemModel? Location { get; set; }

    [JsonPropertyName("rtd_location")]
    public NamedItemModel? RtdLocation { get; set; }

    [JsonPropertyName("supplier")]
    public NamedItemModel? Supplier { get; set; }

    [JsonPropertyName("supplier_id")]
    public int? SupplierId { get; set; }

    [JsonPropertyName("cost")]
    public string? Cost { get; set; }

    [JsonPropertyName("asset_maintenance_type")]
    public string? AssetMaintenanceType { get; set; }

    [JsonPropertyName("start_date")]
    [JsonConverter(typeof(DateJsonConverter))]
    public DateTime? StartDate { get; set; }

    [JsonPropertyName("asset_maintenance_time")]
    [JsonConverter(typeof(DateJsonConverter))]
    public DateTime? AssetMaintenanceTime { get; set; }

    [JsonPropertyName("completion_date")]
    [JsonConverter(typeof(DateJsonConverter))]
    public DateTime? CompletionDate { get; set; }

    [JsonPropertyName("user_id")]
    public NamedItemModel? UserId { get; set; }

    [JsonPropertyName("is_warranty")]
    public int? IsWarranty { get; set; }
}
