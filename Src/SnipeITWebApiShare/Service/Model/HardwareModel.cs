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

    public static implicit operator Hardware?(HardwareModel? model)
    {
        return model is null ? null : new Hardware()
        {
            Name = model.Name,
            Model = model.Model,
            Manufacturer = model.Manufacturer,
            Category = model.Category,
            AssignedTo = model.AssignedTo,
            PurchaseDate = model.PurchaseDate
        };
    }
}
