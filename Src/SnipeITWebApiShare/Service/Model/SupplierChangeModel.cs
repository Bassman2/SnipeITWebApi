namespace SnipeITWebApi.Service.Model;

internal class SupplierChangeModel : BaseChangeModel
{
    [JsonPropertyName("url")]
    public string? Url { get; set; }

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

    [JsonPropertyName("fax")]
    public string? Fax { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("contact")]
    public string? Contact { get; set; }
}
