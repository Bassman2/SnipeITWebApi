namespace SnipeITWebApi.Service.Model;

internal class LocationChangeModel : BaseChangeModel
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

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("ldap_ou")]
    public string? LdapOu { get; set; }

    [JsonPropertyName("parent_id")]
    public int? ParentId { get; set; }

    [JsonPropertyName("manager_id")]
    public int? ManagerId { get; set; }

    //[JsonPropertyName("children")]
    //public List<NamedItemModel>? Children { get; set; }
}
