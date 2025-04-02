namespace SnipeITWebApi.Service.Model;

internal class HardwareModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("model")]
    public NamedItemModel? Model { get; set; }

    [JsonPropertyName("manufacturer")]
    public NamedItemModel? Manufacturer { get; set; }

    [JsonPropertyName("category")]
    public NamedItemModel? Category { get; set; }

    [JsonPropertyName("assigned_to")]
    public AssignedModel? AssignedTo { get; set; }

    [JsonPropertyName("purchase_date")]
    [JsonConverter(typeof(DateTimeJsonConverter))]  
    public DateTime? PurchaseDate { get; set; }
}
