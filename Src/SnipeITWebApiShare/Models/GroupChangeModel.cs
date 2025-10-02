namespace SnipeITWebApi.Models;

internal class GroupChangeModel : BaseChangeModel
{
    [JsonPropertyName("permissions")]
    [JsonConverter(typeof(PermissionsJsonConverter))]
    public PermissionsModel? Permissions { get; set; }
}
   