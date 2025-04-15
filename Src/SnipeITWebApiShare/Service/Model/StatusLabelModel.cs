namespace SnipeITWebApi.Service.Model;

internal class StatusLabelModel : BaseModel
{
    [JsonPropertyName("type")]
    [JsonConverter(typeof(JsonStringEnumConverter<StatusType>))]
    public StatusType? Type { get; set; }

    [JsonPropertyName("deployable")]
    [JsonConverter(typeof(BooleanJsonConverter))]
    public bool? Deployable { get; set; }

    [JsonPropertyName("pending")]
    [JsonConverter(typeof(BooleanJsonConverter))]
    public bool? Pending { get; set; }

    [JsonPropertyName("archived")]
    [JsonConverter(typeof(BooleanJsonConverter))]
    public bool? Archived { get; set; }

    [JsonPropertyName("color")]
    public string? Color { get; set; }

    [JsonPropertyName("show_in_nav")]
    [JsonConverter(typeof(BooleanJsonConverter))]
    public bool? ShowInNav { get; set; }

    [JsonPropertyName("default_label")]
    [JsonConverter(typeof(BooleanJsonConverter))]
    public bool? DefaultLabel { get; set; }

    [JsonPropertyName("assets_count")]
    public int? AssetsCount { get; set; }
}
