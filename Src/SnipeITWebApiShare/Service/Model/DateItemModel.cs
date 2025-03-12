namespace SnipeITWebApi.Service.Model;

internal class DateItemModel
{
    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("formatted")]
    public string? Formatted { get; set; }
}
