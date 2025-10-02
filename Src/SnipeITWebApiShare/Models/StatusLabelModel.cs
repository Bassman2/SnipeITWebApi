namespace SnipeITWebApi.Models;

internal class StatusLabelModel : BaseModel
{
    [JsonPropertyName("type")]
    [JsonConverter(typeof(JsonStringEnumConverter<StatusType>))]
    public StatusType? Type { get; set; }

    [JsonPropertyName("deployable")]
    [JsonConverter(typeof(BoolJsonConverter))]
    public bool? Deployable { get; set; }

    [JsonPropertyName("pending")]
    [JsonConverter(typeof(BoolJsonConverter))]
    public bool? Pending { get; set; }

    [JsonPropertyName("archived")]
    [JsonConverter(typeof(BoolJsonConverter))]
    public bool? Archived { get; set; }

    [JsonPropertyName("color")]
    public string? Color { get; set; }

    [JsonPropertyName("show_in_nav")]
    [JsonConverter(typeof(BoolJsonConverter))]
    public bool? ShowInNav { get; set; }

    [JsonPropertyName("default_label")]
    [JsonConverter(typeof(BoolJsonConverter))]
    public bool? DefaultLabel { get; set; }

    [JsonPropertyName("assets_count")]
    public int? AssetsCount { get; set; }
}
