namespace SnipeITWebApi.Service.Model;

internal class ListModel<T>
{
    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("rows")]
    public List<T>? Rows { get; set; }
}
