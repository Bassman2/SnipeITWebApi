namespace SnipeITWebApi.Service.Model;

//[JsonConverter(typeof(NamedItemConverter))]
internal class NamedItemModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
