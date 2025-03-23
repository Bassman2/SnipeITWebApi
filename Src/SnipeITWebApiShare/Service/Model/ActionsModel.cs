namespace SnipeITWebApi.Service.Model;

internal class ActionsModel
{
    [JsonPropertyName("update")]
    public bool Update { get; set; }

    [JsonPropertyName("restore")]
    public bool Restore { get; set; }

    [JsonPropertyName("delete")]
    public bool Delete { get; set; }

    [JsonPropertyName("clone")]
    public bool Clone { get; set; }
}
