namespace SnipeITWebApi.Models;

internal class DepartmentChangeModel : BaseChangeModel
{
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("fax")]
    public string? Fax { get; set; }
}
