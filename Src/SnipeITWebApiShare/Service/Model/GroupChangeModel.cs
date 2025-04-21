namespace SnipeITWebApi.Service.Model;

internal class GroupChangeModel : BaseChangeModel
{
    [JsonPropertyName("permissions")]
    [JsonConverter(typeof(PermissionsJsonConverter))]
    public PermissionsModel? Permissions { get; set; }
}
   