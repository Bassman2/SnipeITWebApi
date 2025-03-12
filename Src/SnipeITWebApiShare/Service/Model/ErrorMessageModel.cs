namespace SnipeITWebApi.Service.Model;

internal class ErrorMessageModel
{
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}
