namespace SnipeITWebApi.Service.Model;

internal class GroupModel : BaseModel
{
    [JsonPropertyName("permissions")]
    [JsonConverter(typeof(PermissionsJsonConverter))]
    public PermissionsModel? Permissions { get; set; }

    [JsonPropertyName("users_count")]
    public int? UsersCount { get; set; }
}
