namespace SnipeITWebApi.Service.Model;

internal class StatusLabelModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("status_type")]
    public string? StatusType { get; set; }

    [JsonPropertyName("status_meta")]
    public string? StatusMeta { get; set; }
}
