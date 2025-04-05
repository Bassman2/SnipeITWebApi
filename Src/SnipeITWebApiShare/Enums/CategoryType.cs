namespace SnipeITWebApi;

[JsonConverter(typeof(JsonStringEnumConverter<CategoryType>))]

public enum CategoryType
{
    [EnumMember(Value = "asset")]
    Asset,

    [EnumMember(Value = "accessory")]
    Accessory,

    [EnumMember(Value = "consumable")]
    Consumable,

    [EnumMember(Value = "component")]
    Component,

    [EnumMember(Value = "license")]
    License,
}
