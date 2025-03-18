namespace SnipeITWebApi.Service.Model;

internal class ErrorMessageModel
{
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    //[JsonPropertyName("message")]
    //public string? Message { get; set; }

    [JsonPropertyName("messages")]
    public Dictionary<string, string[]>? Messages { get; set; }

    [JsonPropertyName("payload")]
    public string? Payload { get; set; }

}
