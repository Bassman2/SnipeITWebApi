namespace SnipeITWebApi;

/// <summary>
/// Represents the status types for items in the Snipe-IT system.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<StatusType>))]
public enum StatusType
{
    /// <summary>
    /// Indicates that the item is deployable and ready for use.
    /// </summary>
    [EnumMember(Value = "deployable")]
    deployable,

    /// <summary>
    /// Indicates that the item is pending and not yet ready for deployment.
    /// </summary>
    [EnumMember(Value = "pending")]
    pending,

    /// <summary>
    /// Indicates that the item is archived and no longer actively used.
    /// </summary>
    [EnumMember(Value = "archived")]
    archived,

    /// <summary>
    /// Indicates that the item is undeployable and cannot be used.
    /// </summary>
    [EnumMember(Value = "undeployable")]
    undeployable
}
