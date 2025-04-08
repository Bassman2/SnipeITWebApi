namespace SnipeITWebApi;

[JsonConverter(typeof(JsonStringEnumConverter<StatusType>))]
public enum StatusType
{
    [EnumMember(Value = "deployable")]
    deployable,

    [EnumMember(Value = "pending")]
    pending,

    [EnumMember(Value = "archived")]
    archived,

    [EnumMember(Value = "undeployable")]
    undeployable
}
