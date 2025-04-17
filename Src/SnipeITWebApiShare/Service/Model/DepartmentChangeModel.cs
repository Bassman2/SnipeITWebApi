namespace SnipeITWebApi.Service.Model;

internal class DepartmentChangeModel : BaseChangeModel
{
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("fax")]
    public string? Fax { get; set; }
}
