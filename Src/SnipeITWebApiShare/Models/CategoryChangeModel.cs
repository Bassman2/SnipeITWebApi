namespace SnipeITWebApi.Models;

internal class CategoryChangeModel : BaseChangeModel
{
    [JsonPropertyName("category_type")]
    public CategoryType? CategoryType { get; set; }

    [JsonPropertyName("use_default_eula")]
    public bool UseDefaultEula { get; set; }

    [JsonPropertyName("require_acceptance")]
    public bool RequireAcceptance { get; set; }

    [JsonPropertyName("checkin_email")]
    [JsonConverter(typeof(BoolJsonConverter))]
    public bool? CheckinEmail { get; set; }
}
