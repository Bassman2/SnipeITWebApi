namespace SnipeITWebApi.Service.Model;

internal class HardwareModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("asset_tag")]
    public string? AssetTag { get; set; }

    [JsonPropertyName("serial")]
    public string? Serial { get; set; }

    [JsonPropertyName("model")]
    public NamedItemModel? Model { get; set; }

    [JsonPropertyName("model_id")]
    public int? ModelId { get; set; }

    [JsonPropertyName("byod")]
    [JsonConverter(typeof(BooleanJsonConverter))]
    public bool? Byod { get; set; }

    [JsonPropertyName("requestable")]
    [JsonConverter(typeof(BooleanJsonConverter))]
    public bool? Requestable { get; set; }

    [JsonPropertyName("model_number")]
    public string? ModelNumber { get; set; }

    [JsonPropertyName("eol")]
    public string? Eol { get; set; }

    [JsonPropertyName("asset_eol_date")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? AssetEolDate { get; set; }

    [JsonPropertyName("status_label")]
    public NamedItemModel? StatusLabel { get; set; }

    [JsonPropertyName("status_id")]
    public int? StatusId { get; set; }

    [JsonPropertyName("category")]
    public NamedItemModel? Category { get; set; }

    [JsonPropertyName("manufacturer")]
    public NamedItemModel? Manufacturer { get; set; }

    [JsonPropertyName("supplier")]
    public NamedItemModel? Supplier { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("order_number")]
    public string? OrderNumber { get; set; }

    [JsonPropertyName("company")]
    public NamedItemModel? Company { get; set; }

    [JsonPropertyName("location")]
    public NamedItemModel? Location { get; set; }

    [JsonPropertyName("rtd_location")]
    public NamedItemModel? RtdLocation { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }

    [JsonPropertyName("qr")]
    public string? Qr { get; set; }

    [JsonPropertyName("alt_barcode")]
    public string? AltBarcode { get; set; }

    [JsonPropertyName("assigned_to")]
    public NamedItemModel? AssignedTo { get; set; }

    [JsonPropertyName("warranty_months")]
    public string? WarrantyMonths { get; set; }

    [JsonPropertyName("warranty_expires")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? WarrantyExpires { get; set; }

    [JsonPropertyName("created_by")]
    [JsonConverter(typeof(NamedItemJsonConverter))]
    public NamedItemModel? CreatedBy { get; set; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("last_audit_date")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? LastAuditDate { get; set; }

    [JsonPropertyName("next_audit_date")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? NextAuditDate { get; set; }

    [JsonPropertyName("deleted_at")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? DeletedAt { get; set; }

    [JsonPropertyName("purchase_date")]
    [JsonConverter(typeof(DateTimeJsonConverter))]  
    public DateTime? PurchaseDate { get; set; }

    [JsonPropertyName("age")]
    public string? Age { get; set; }

    [JsonPropertyName("last_checkout")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? LastCheckout { get; set; }

    [JsonPropertyName("last_checkin")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? LastCheckin { get; set; }

    // TODO

    [JsonPropertyName("expected_checkin")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? ExpectedCheckin { get; set; }

    [JsonPropertyName("purchase_cost")]
    public string? PurchaseCost { get; set; }

    [JsonPropertyName("checkin_counter")]
    public int? CheckinCounter { get; set; }

    [JsonPropertyName("checkout_counter")]
    public int? CheckoutCounter { get; set; }

    [JsonPropertyName("requests_counter")]
    public int? RequestsCounter { get; set; }

    [JsonPropertyName("user_can_checkout")]
    public bool? UserCanCheckout { get; set; }

    [JsonPropertyName("book_value")]
    public string? BookValue { get; set; }

    [JsonPropertyName("custom_fields")]
    public Dictionary<string, CustomFieldModel>? CustomFields { get; set; }

    [JsonPropertyName("available_actions")]
    public ActionsModel? AvailableActions { get; set; }
}
