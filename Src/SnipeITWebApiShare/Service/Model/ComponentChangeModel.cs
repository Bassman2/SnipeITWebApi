namespace SnipeITWebApi.Service.Model;

internal class ComponentChangeModel : BaseChangeModel
{
    [JsonPropertyName("qty")]
    public int? Qty { get; set; }

    [JsonPropertyName("category_id")]
    public int? CategoryId { get; set; }

    [JsonPropertyName("location_id")]
    public int? LocationId { get; set; }

    [JsonPropertyName("company_id")]
    public int? CompanyId { get; set; }

    [JsonPropertyName("order_number")]
    public string? OrderNumber { get; set; }

    [JsonPropertyName("purchase_date")]
    [JsonConverter(typeof(DateJsonConverter))]
    public DateTime? PurchaseDate { get; set; }

    [JsonPropertyName("purchase_cost")]
    public float? PurchaseCost { get; set; }

    [JsonPropertyName("min_amt")]
    public int? MinAmt { get; set; }

    [JsonPropertyName("serial")]
    public string? Serial { get; set; }
}
