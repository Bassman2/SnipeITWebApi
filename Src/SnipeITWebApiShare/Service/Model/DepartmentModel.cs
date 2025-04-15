namespace SnipeITWebApi.Service.Model;

internal class DepartmentModel : BaseModel
{
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("fax")]
    public string? Fax { get; set; }

    [JsonPropertyName("company")]
    public string? Company { get; set; }

    [JsonPropertyName("manager")]
    public string? Manager { get; set; }

    [JsonPropertyName("location")]
    public NamedItemModel? Location { get; set; }

    [JsonPropertyName("users_count")]
    public string? UsersCount { get; set; }
}

