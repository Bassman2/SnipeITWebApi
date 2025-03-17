namespace SnipeITWebApi.Service.Model;

internal class ManufacturerCreateModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
