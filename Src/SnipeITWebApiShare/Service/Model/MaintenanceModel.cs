namespace SnipeITWebApi.Service.Model;

internal class MaintenanceModel : BaseModel
{
    [JsonPropertyName("asset")]
    public HardwareModel? Asset { get; set; }    

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
    
    [JsonPropertyName("cost")]
    [JsonConverter(typeof(FloatJsonConverter))]
    public float? Cost { get; set; }

    [JsonPropertyName("asset_maintenance_type")]
    [JsonConverter(typeof(JsonStringEnumConverter<MaintenanceType>))]
    public MaintenanceType? AssetMaintenanceType { get; set; }

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
    [JsonConverter(typeof(BooleanJsonConverter))]
    public bool? IsWarranty { get; set; }
}
