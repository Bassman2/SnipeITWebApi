namespace SnipeITWebApi.Service.Model;

internal class ConsumableModel : BaseModel
{
    [JsonPropertyName("category")]
    public NamedItemModel? Category { get; set; }

    [JsonPropertyName("company")]
    public NamedItemModel? Company { get; set; }
    
    [JsonPropertyName("item_no")]
    public string? ItemNo { get; set; }

    [JsonPropertyName("location")]
    public NamedItemModel? Location { get; set; }

    [JsonPropertyName("manufacturer")]
    public NamedItemModel? Manufacturer { get; set; }

    [JsonPropertyName("supplier")]
    public NamedItemModel? Supplier { get; set; }

    [JsonPropertyName("min_amt")]
    public int? MinAmt { get; set; }

    [JsonPropertyName("model_number")]
    public string? ModelNumber { get; set; }

    [JsonPropertyName("remaining")]
    public int? Remaining { get; set; }

    [JsonPropertyName("order_number")]
    public string? OrderNumber { get; set; }

    [JsonPropertyName("purchase_cost")]
    public string? PurchaseCost { get; set; }

    [JsonPropertyName("purchase_date")]
    [JsonConverter(typeof(DateJsonConverter))]
    public DateTime? PurchaseDate { get; set; }

    [JsonPropertyName("qty")]
    public int? Qty { get; set; }

}
