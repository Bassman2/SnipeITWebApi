namespace SnipeITWebApi.Service.Model;

internal class ComponentModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }

    [JsonPropertyName("serial")]
    public string? Serial { get; set; }

    [JsonPropertyName("location")]
    public NamedItemModel? Location { get; set; }

    [JsonPropertyName("qty")]
    public int? Qty { get; set; }

    [JsonPropertyName("min_amt")]
    public int? MinAmt { get; set; }

    [JsonPropertyName("category")]
    public NamedItemModel? Category { get; set; }   

    [JsonPropertyName("supplier")]
    public NamedItemModel? Supplier { get; set; }

    [JsonPropertyName("manufacturer")]
    public NamedItemModel? Manufacturer { get; set; }

    [JsonPropertyName("model_number")]
    public string? ModelNumber { get; set; }

    [JsonPropertyName("order_number")]
    public string? OrderNumber { get; set; }

    [JsonPropertyName("purchase_date")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? PurchaseDate { get; set; }

    [JsonPropertyName("purchase_cost")]
    public string? PurchaseCost { get; set; }

    [JsonPropertyName("remaining")]
    public int? Remaining { get; set; }

    [JsonPropertyName("company")]
    public NamedItemModel? Company { get; set; }
    
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

    [JsonPropertyName("user_can_checkout")]
    public int? UserCanCheckout { get; set; }

    [JsonPropertyName("available_actions")]
    public ActionsModel? AvailableActions { get; set; }
}

