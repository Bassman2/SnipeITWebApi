namespace SnipeITWebApi.Service.Model;

internal class UserModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("avatar")]
    public string? Avatar { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }


    // TODO ...

    [JsonPropertyName("company")]
    public NamedItemModel? Company { get; set; }

    [JsonPropertyName("created_by")]
    public NamedItemModel? CreatedBy { get; set; }

    //[JsonPropertyName("created_at")]
    //[JsonConverter(typeof(JsonDateTimeConverter))]
    //public DateTime? CreatedAt { get; set; }

    //[JsonPropertyName("updated_at")]
    //[JsonConverter(typeof(JsonDateTimeConverter))]
    //public DateTime? UpdatedAt { get; set; }

    //[JsonPropertyName("deleted_at")]
    //[JsonConverter(typeof(JsonDateTimeConverter))]
    //public DateTime? DeletedAt { get; set; }

    [JsonPropertyName("available_actions")]
    public ActionsModel? AvailableActions { get; set; }
}
