namespace SnipeITWebApi.Service.Model;

internal class HardwareChangeModel : BaseChangeModel
{
    [JsonPropertyName("asset_tag")]
    public string? AssetTag { get; set; }

    [JsonPropertyName("status_id")]
    public int? StatusId { get; set; }

    [JsonPropertyName("model_id")]
    public int? ModelId { get; set; }

    [JsonPropertyName("serial")]
    public string? Serial { get; set; }

    [JsonPropertyName("purchase_date")]
    [JsonConverter(typeof(DateJsonConverter))]
    public DateTime? PurchaseDate { get; set; }

    [JsonPropertyName("purchase_cost")]
    public float? PurchaseCost { get; set; }

    [JsonPropertyName("order_number")]
    public string? OrderNumber { get; set; }

    [JsonPropertyName("archived")]
    [JsonConverter(typeof(BooleanJsonConverter))]
    public bool? Archived { get; set; }

    [JsonPropertyName("warranty_months")]
    public int? WarrantyMonths { get; set; }

    [JsonPropertyName("depreciate")]
    public bool? Depreciate { get; set; }

    [JsonPropertyName("supplier_id")]
    public int? SupplierId { get; set; }

    [JsonPropertyName("requestable")]
    [JsonConverter(typeof(BooleanJsonConverter))]
    public bool? Requestable { get; set; }

    [JsonPropertyName("rtd_location_id")]
    public int? RtdLocationId { get; set; }

    [JsonPropertyName("last_audit_date")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? LastAuditDate { get; set; }

    [JsonPropertyName("location_id")]
    public int? LocationId { get; set; }

    [JsonPropertyName("byod")]
    [JsonConverter(typeof(BooleanJsonConverter))]
    public bool? Byod { get; set; }
}
