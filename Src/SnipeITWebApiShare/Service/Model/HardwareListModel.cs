namespace SnipeITWebApi.Service.Model;

internal class HardwareListModel
{
    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("rows")]
    public List<HardwareModel>? Hardwares { get; set; }
}
