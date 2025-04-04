namespace SnipeITWebApi.Service.Model;

internal class FieldsetModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
