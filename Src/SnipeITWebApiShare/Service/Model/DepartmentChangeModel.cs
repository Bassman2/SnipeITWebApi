namespace SnipeITWebApi.Service.Model;

internal class DepartmentChangeModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("fax")]
    public string? Fax { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }
}
