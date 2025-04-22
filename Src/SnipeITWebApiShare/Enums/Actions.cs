namespace SnipeITWebApi;

/// <summary>
/// Represents a set of actions that can be performed in the Snipe-IT system.
/// This enumeration supports bitwise operations due to the <see cref="FlagsAttribute"/>.
/// </summary>
[Flags]
public enum Actions
{
    /// <summary>
    /// Represents no action.
    /// </summary>
    Empty = 0x00,

    /// <summary>
    /// Represents the action of checking out an item.
    /// </summary>
    Checkout = 0x01,

    /// <summary>
    /// Represents the action of checking in an item.
    /// </summary>
    Checkin = 0x02,

    /// <summary>
    /// Represents the action of updating an item.
    /// </summary>
    Update = 0x04,

    /// <summary>
    /// Represents the action of restoring a deleted item.
    /// </summary>
    Restore = 0x08,

    /// <summary>
    /// Represents the action of deleting an item.
    /// </summary>
    Delete = 0x10,

    /// <summary>
    /// Represents the action of cloning an item.
    /// </summary>
    Clone = 0x20
}

