namespace SnipeITWebApi.Service.Model;

internal class HardwareModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("model")]
    public ItemModel? Model { get; set; }

    [JsonPropertyName("manufacturer")]
    public ItemModel? Manufacturer { get; set; }

    [JsonPropertyName("category")]
    public ItemModel? Category { get; set; }

    [JsonPropertyName("assigned_to")]
    public AssignedModel? AssignedTo { get; set; }

    [JsonPropertyName("purchase_date")]
    public DateItemModel? PurchaseDate { get; set; }
}
