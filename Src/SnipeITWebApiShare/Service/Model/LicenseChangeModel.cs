namespace SnipeITWebApi.Service.Model;

internal class LicenseChangeModel : BaseChangeModel
{
    [JsonPropertyName("seats")]
    public int? Seats { get; set; }

    [JsonPropertyName("category_id")]
    public int? CategoryId { get; set; }
}
