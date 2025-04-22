namespace SnipeITWebApi;

/// <summary>
/// Represents the types of maintenance activities available in the Snipe-IT system.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<MaintenanceType>))]
public enum MaintenanceType
{
    /// <summary>
    /// Represents general maintenance activities.
    /// </summary>
    [EnumMember(Value = "Maintenance")]
    Maintenance,

    /// <summary>
    /// Represents repair activities for fixing issues or damages.
    /// </summary>
    [EnumMember(Value = "Repair")]
    Repair,

    /// <summary>
    /// Represents Portable Appliance Testing (PAT) to ensure electrical safety.
    /// </summary>
    [EnumMember(Value = "PAT Test")]
    PatTest,

    /// <summary>
    /// Represents upgrade activities to improve or enhance hardware or software.
    /// </summary>
    [EnumMember(Value = "Upgrade")]
    Upgrade,

    /// <summary>
    /// Represents hardware support activities, such as troubleshooting or servicing hardware components.
    /// </summary>
    [EnumMember(Value = "Hardware Support")]
    HardwareSupport,

    /// <summary>
    /// Represents software support activities, such as troubleshooting or updating software.
    /// </summary>
    [EnumMember(Value = "Software Support")]
    SoftwareSupport
}
