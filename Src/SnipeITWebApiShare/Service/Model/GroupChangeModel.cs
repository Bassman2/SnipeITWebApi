namespace SnipeITWebApi.Service.Model;

internal class GroupChangeModel : BaseChangeModel
{
    [JsonPropertyName("permissions")]
    public Permissions? Permissions { get; set; }
}
   