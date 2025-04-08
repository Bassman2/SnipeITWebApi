namespace SnipeITWebApi.Service.Model;

internal class LicenseModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("company")]
    [JsonConverter(typeof(NamedItemJsonConverter))]
    public NamedItemModel? Company { get; set; }

    [JsonPropertyName("manufacturer")]
    public NamedItemModel? Manufacturer { get; set; }

    [JsonPropertyName("product_key")]
    public string? ProductKey { get; set; }

    [JsonPropertyName("order_number")]
    public string? OrderNumber { get; set; }

    [JsonPropertyName("purchase_order")]
    public string? PurchaseOrder { get; set; }

    [JsonPropertyName("purchase_date")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? PurchaseDate { get; set; }

    [JsonPropertyName("termination_date")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? TerminationDate { get; set; }

    [JsonPropertyName("depreciation")]
    public string? Depreciation { get; set; }

    [JsonPropertyName("purchase_cost")]
    public string? PurchaseCost { get; set; }

    [JsonPropertyName("purchase_cost_numeric")]
    public string? PurchaseCostNumeric { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("expiration_date")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? ExpirationDate { get; set; }

    [JsonPropertyName("seats")]
    public int? Seats { get; set; }

    [JsonPropertyName("free_seats_count")]
    public int? FreeSeatsCount { get; set; }

    [JsonPropertyName("remaining")]
    public int? Remaining { get; set; }

    [JsonPropertyName("min_amt")]
    public int? MinAmt { get; set; }

    [JsonPropertyName("license_name")]
    public string? LicenseName { get; set; }

    [JsonPropertyName("license_email")]
    public string? LicenseEmail { get; set; }

    [JsonPropertyName("reassignable")]
    [JsonConverter(typeof(BooleanJsonConverter))]
    public bool? Reassignable { get; set; }

    [JsonPropertyName("maintained")]
    public bool? Maintained { get; set; }

    [JsonPropertyName("supplier")]
    public NamedItemModel? Supplier { get; set; }

    [JsonPropertyName("category")]
    public NamedItemModel? Category { get; set; }

    [JsonPropertyName("category_id")]
    public int? CategoryId { get; set; }

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

    [JsonPropertyName("user_can_checkout")]
    public bool UserCanCheckout { get; set; }

    [JsonPropertyName("available_actions")]
    public ActionsModel? AvailableActions { get; set; }

}

