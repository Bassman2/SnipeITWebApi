namespace SnipeITWebApi.Models;

internal class BaseChangeModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }       // "data:@[mime];base64,[base64encodeddata]"
}
