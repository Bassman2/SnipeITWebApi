namespace SnipeITWebApi.Service.Model;

internal class MaintenanceModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

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

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("supplier")]
    public NamedItemModel? Supplier { get; set; }

    [JsonPropertyName("supplier_id")]
    public int? SupplierId { get; set; }

    [JsonPropertyName("cost")]
    public string? Cost { get; set; }

    [JsonPropertyName("asset_maintenance_type")]
    public string? AssetMaintenanceType { get; set; }

    [JsonPropertyName("start_date")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? StartDate { get; set; }

    [JsonPropertyName("asset_maintenance_time")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? AssetMaintenanceTime { get; set; }

    [JsonPropertyName("completion_date")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? CompletionDate { get; set; }

    [JsonPropertyName("user_id")]
    public NamedItemModel? UserId { get; set; }

    [JsonPropertyName("created_by")]
    public NamedItemModel? CreatedBy { get; set; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("is_warranty")]
    public int? IsWarranty { get; set; }

    [JsonPropertyName("available_actions")]
    public ActionsModel? AvailableActions { get; set; }

}
