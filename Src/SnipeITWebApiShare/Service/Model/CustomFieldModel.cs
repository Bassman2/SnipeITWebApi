namespace SnipeITWebApi.Service.Model;

internal class CustomFieldModel
{
    [JsonPropertyName("field")]
    public string? Field { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }

    [JsonPropertyName("field_format")]
    public string? FieldFormat { get; set; }

    [JsonPropertyName("element")]
    public string? Element { get; set; }
}
