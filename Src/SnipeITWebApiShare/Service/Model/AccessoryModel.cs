namespace SnipeITWebApi.Service.Model;

internal class AccessoryModel : BaseModel
{
    [JsonPropertyName("company")]
    public NamedItemModel? Company { get; set; }   

    [JsonPropertyName("manufacturer")]
    public NamedItemModel? Manufacturer { get; set; }    

    [JsonPropertyName("supplier")]
    public NamedItemModel? Supplier { get; set; }   

    [JsonPropertyName("model_number")]
    public string? ModelNumber { get; set; }

    [JsonPropertyName("category")]
    public NamedItemModel? Category { get; set; }

    [JsonPropertyName("location")]
    public NamedItemModel? Location { get; set; }    

    [JsonPropertyName("qty")]
    public int? Qty { get; set; }

    [JsonPropertyName("purchase_date")]
    [JsonConverter(typeof(DateJsonConverter))]
    public DateTime? PurchaseDate { get; set; }

    [JsonPropertyName("purchase_cost")]
    [JsonConverter(typeof(FloatJsonConverter))]
    public float? PurchaseCost { get; set; }

    [JsonPropertyName("order_number")]
    public string? OrderNumber { get; set; }

    [JsonPropertyName("min_qty")]
    public int? MinQty { get; set; }

    [JsonPropertyName("min_amt")]
    public int? MinAmt { get; set; }

    [JsonPropertyName("remaining_qty")]
    public int? RemainingQty { get; set; }

    [JsonPropertyName("remaining")]
    public int? Remaining { get; set; }

    [JsonPropertyName("checkouts_count")]
    public int? CheckoutsCount { get; set; }
}
