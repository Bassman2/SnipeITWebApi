namespace SnipeITWebApi.Service.Model;

internal class ModelChangeModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("category_id")]
    public int? CategoryId { get; set; }

}
