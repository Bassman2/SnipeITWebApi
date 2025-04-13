namespace SnipeITWebApi.Service.Model;

internal class LicenseChangeModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("seats")]
    public int? Seats { get; set; }


    [JsonPropertyName("category_id")]
    public int? CategoryId { get; set; }

}
