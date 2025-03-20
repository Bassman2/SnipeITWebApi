namespace SnipeITWebApi.Service.Model;

internal class ModelModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("manufacturer")]
    public NamedItemModel? Manufacturer { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }

    [JsonPropertyName("category_id")]
    public int? CategoryId { get; set; }
}
