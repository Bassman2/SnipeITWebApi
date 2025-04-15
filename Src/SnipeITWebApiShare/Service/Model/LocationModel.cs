namespace SnipeITWebApi.Service.Model;

internal class LocationModel : BaseModel
{
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("address2")]
    public string? Address2 { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("zip")]
    public string? Zip { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("fax")]
    public string? Fax { get; set; }

    [JsonPropertyName("accessories_count")]
    public int? AccessoriesCount { get; set; }

    [JsonPropertyName("assigned_accessories_count")]
    public int? AssignedAccessoriesCount { get; set; }

    [JsonPropertyName("assigned_assets_count")]
    public int? AssignedAssetsCount { get; set; }

    [JsonPropertyName("assets_count")]
    public int? AssetsCount { get; set; }

    [JsonPropertyName("rtd_assets_count")]
    public int? RtdAssetsCount { get; set; }

    [JsonPropertyName("users_count")]
    public int? UsersCount { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("ldap_ou")]
    public string? LdapOu { get; set; }

    [JsonPropertyName("parent")]
    public NamedItemModel? Parent { get; set; }

    [JsonPropertyName("manager")]
    public NamedItemModel? Manager { get; set; }

    [JsonPropertyName("children")]
    public List<NamedItemModel>? Children { get; set; }
}
