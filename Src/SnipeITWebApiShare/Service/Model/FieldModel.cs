namespace SnipeITWebApi.Service.Model;

internal class FieldModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("db_column_name")]
    public string? DbColumnName { get; set; }

    [JsonPropertyName("format")]
    public string? Format { get; set; }

    [JsonPropertyName("field_values")]
    public string? FieldValues { get; set; }

    [JsonPropertyName("field_values_array")]
    public string? FieldValuesArray { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("required")]
    public bool? Required { get; set; }

    [JsonPropertyName("display_in_user_view")]
    public bool? DisplayInUserView { get; set; }

    [JsonPropertyName("auto_add_to_fieldsets")]
    public bool? AutoAddToFieldsets { get; set; }

    [JsonPropertyName("show_in_listview")]
    public bool? ShowInListview { get; set; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? UpdatedAt { get; set; }
}
