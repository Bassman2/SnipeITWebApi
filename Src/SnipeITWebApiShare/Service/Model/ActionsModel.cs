namespace SnipeITWebApi.Service.Model;

internal class ActionsModel
{
    [JsonPropertyName("update")]
    public bool Update { get; set; }

    [JsonPropertyName("delete")]
    public bool Delete { get; set; }
}
