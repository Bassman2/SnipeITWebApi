namespace SnipeITWebApi.Service.Model;

internal class HardwareChangeModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }
}
