﻿namespace SnipeITWebApi.Service.Model;

internal class AccessoryChangeModel : BaseChangeModel
{
    [JsonPropertyName("qty")]
    public int? Qty { get; set; }

    [JsonPropertyName("category_id")]
    public int? CategoryId { get; set; }

    [JsonPropertyName("order_number")]
    public string? OrderNumber { get; set; }

    [JsonPropertyName("purchase_cost")]
    public float? PurchaseCost { get; set; }

    [JsonPropertyName("purchase_date")]
    [JsonConverter(typeof(DateJsonConverter))]
    public DateTime? PurchaseDate { get; set; }

    [JsonPropertyName("model_number")]
    public string? ModelNumber { get; set; }

    [JsonPropertyName("company_id")]
    public int? CompanyId { get; set; }

    [JsonPropertyName("location_id")]
    public int? LocationId { get; set; }

    [JsonPropertyName("manufacturer_id")]
    public int? ManufacturerId { get; set; }

    [JsonPropertyName("supplier_id")]
    public int? SupplierId { get; set; }
}
