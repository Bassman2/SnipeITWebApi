namespace SnipeITWebApi;

/// <summary>
/// Represents the types of categories available in the Snipe-IT system.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<CategoryType>))]
public enum CategoryType
{
    /// <summary>
    /// Represents a category for assets, such as physical items that can be assigned to users.
    /// </summary>
    [EnumMember(Value = "asset")]
    Asset,

    /// <summary>
    /// Represents a category for accessories, such as peripherals or add-ons for assets.
    /// </summary>
    [EnumMember(Value = "accessory")]
    Accessory,

    /// <summary>
    /// Represents a category for consumables, such as items that are used up over time (e.g., printer ink).
    /// </summary>
    [EnumMember(Value = "consumable")]
    Consumable,

    /// <summary>
    /// Represents a category for components, such as parts that can be used to build or repair assets.
    /// </summary>
    [EnumMember(Value = "component")]
    Component,

    /// <summary>
    /// Represents a category for licenses, such as software licenses or subscriptions.
    /// </summary>
    [EnumMember(Value = "license")]
    License,
}
