namespace SnipeITWebApi.Models;

internal class ConsumableChangeModel : BaseChangeModel
{
    [JsonPropertyName("qty")]
    public int? Qty { get; set; }

    [JsonPropertyName("category_id")]
    public int? CategoryId { get; set; }

    [JsonPropertyName("company_id")]
    public int? CompanyId { get; set; }

    [JsonPropertyName("order_number")]
    public string? OrderNumber { get; set; }

    [JsonPropertyName("manufacturer_id")]
    public int? ManufacturerId { get; set; }

    [JsonPropertyName("location_id")]
    public int? LocationId { get; set; }

    [JsonPropertyName("requestable")]
    public bool? Requestable { get; set; }

    [JsonPropertyName("purchase_date")]
    [JsonConverter(typeof(DateJsonConverter))]
    public DateTime? PurchaseDate { get; set; }

    [JsonPropertyName("min_amt")]
    public int? MinAmt { get; set; }

    [JsonPropertyName("model_number")]
    public string? ModelNumber { get; set; }

    [JsonPropertyName("item_no")]
    public string? ItemNno { get; set; }
}
