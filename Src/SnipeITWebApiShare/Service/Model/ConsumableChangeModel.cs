namespace SnipeITWebApi.Service.Model;

internal class ConsumableChangeModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("qty")]
    public int? Qty { get; set; }

    [JsonPropertyName("category_id")]
    public int? CategoryId { get; set; }

    [JsonPropertyName("company_id")]
    public int? CompanyId { get; set; }

    [JsonPropertyName("order_number")]
    public int? OrderNumber { get; set; }

    [JsonPropertyName("manufacturer_id")]
    public int? ManufacturerId { get; set; }

    [JsonPropertyName("location_id")]
    public int? LocationId { get; set; }

    [JsonPropertyName("requestable")]
    public bool? Requestable { get; set; }

    [JsonPropertyName("purchase_date")]
    public DateTime? PurchaseDate { get; set; }

    [JsonPropertyName("min_amt")]
    public int? MinAmt { get; set; }

    [JsonPropertyName("model_number")]
    public string? ModelNumber { get; set; }

    [JsonPropertyName("item_no")]
    public string? ItemNno { get; set; }
}
