namespace SnipeITWebApi;

[JsonConverter(typeof(JsonStringEnumConverter<StatusType>))]
public enum StatusType
{
    [EnumMember(Value = "deployable")]
    Deployable,

    [EnumMember(Value = "pending")]
    Pending,

    [EnumMember(Value = "archived")]
    Archived,

    [EnumMember(Value = "undeployable")]
    Undeployable
}
