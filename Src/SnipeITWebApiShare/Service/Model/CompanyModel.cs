namespace SnipeITWebApi.Service.Model;

internal class CompanyModel : BaseModel
{
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("fax")]
    public string? Fax { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("assets_count")]
    public int AssetsCount { get; set; }

    [JsonPropertyName("accessories_count")]
    public int AccessoriesCount { get; set; }

    [JsonPropertyName("consumables_count")]
    public int ConsumablesCount { get; set; }

    [JsonPropertyName("components_count")]
    public int ComponentsCount { get; set; }

    [JsonPropertyName("users_count")]
    public int UsersCount { get; set; }
}
