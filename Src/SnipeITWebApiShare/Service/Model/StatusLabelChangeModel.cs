﻿namespace SnipeITWebApi.Service.Model;

internal class StatusLabelChangeModel : BaseChangeModel
{
    [JsonPropertyName("type")]
    [JsonConverter(typeof(JsonStringEnumConverter<StatusType>))]
    public StatusType? Type { get; set; }

    [JsonPropertyName("color")]
    public string? Color { get; set; }

    [JsonPropertyName("show_in_nav")]
    [JsonConverter(typeof(BooleanJsonConverter))]
    public bool? ShowInNav { get; set; }

    [JsonPropertyName("default_label")]
    [JsonConverter(typeof(BooleanJsonConverter))]
    public bool? DefaultLabel { get; set; }
}
