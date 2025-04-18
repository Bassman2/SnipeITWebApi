namespace SnipeITWebApi;

[JsonConverter(typeof(JsonStringEnumConverter<MaintenanceType>))]

public enum MaintenanceType
{

    [EnumMember(Value = "Maintenance")]
    Maintenance,

    [EnumMember(Value = "Repair")]
    Repair,

    [EnumMember(Value = "PAT Test")]
    PatTest,

    [EnumMember(Value = "Upgrade")]
    Upgrade,

    [EnumMember(Value = "Hardware Support")]
    HardwareSupport,

    [EnumMember(Value = "Software Support")]
    SoftwareSupport
}
