namespace SnipeITWebApi.Models;

internal class FieldChangeModel : BaseChangeModel
{
    [JsonPropertyName("element")]
    public Elements? Element { get; set; }

    [JsonPropertyName("db_column_name")]
    public string? DbColumnName { get; set; }

    [JsonPropertyName("format")]
    public string? Format { get; set; }

    [JsonPropertyName("field_values")]
    public string? FieldValues { get; set; }

    [JsonPropertyName("field_values_array")]
    public List<string>? FieldValuesArray { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("required")]
    public bool? Required { get; set; }

    [JsonPropertyName("display_in_user_view")]
    [JsonConverter(typeof(BoolJsonConverter))]
    public bool? DisplayInUserView { get; set; }

    [JsonPropertyName("auto_add_to_fieldsets")]
    [JsonConverter(typeof(BoolJsonConverter))]
    public bool? AutoAddToFieldsets { get; set; }

    [JsonPropertyName("show_in_listview")]
    [JsonConverter(typeof(BoolJsonConverter))]
    public bool? ShowInListview { get; set; }
}
