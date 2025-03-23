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

    [JsonPropertyName("remote")]
    public bool Remote { get; set; }

    [JsonPropertyName("locale")]
    public string? Locale { get; set; }

    [JsonPropertyName("employee_num")]
    public string? EmployeeNum { get; set; }

    [JsonPropertyName("manager")]
    public NamedItemModel? Manager { get; set; }

    [JsonPropertyName("jobtitle")]
    public string? Jobtitle { get; set; }

    [JsonPropertyName("vip")]
    public bool Vip { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("website")]
    public string? Website { get; set; }

    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("zip")]
    public string? Zip { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("department")]
    public NamedItemModel? Department { get; set; }

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
