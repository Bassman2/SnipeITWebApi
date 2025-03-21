namespace SnipeITWebApi.Service.Model;

internal class DepartmentModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }

    [JsonPropertyName("company")]
    public string? Company { get; set; }

    [JsonPropertyName("manager")]
    public string? Manager { get; set; }

    [JsonPropertyName("location")]
    public NamedItemModel? Location { get; set; }

    [JsonPropertyName("users_count")]
    public string? UsersCount { get; set; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(JsonDateTimeConverter))]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(JsonDateTimeConverter))]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("available_actions")]
    public ActionsModel? AvailableActions { get; set; }
}

