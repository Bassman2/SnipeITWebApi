namespace SnipeITWebApi;

/// <summary>
/// Represents the types of form elements available in the Snipe-IT system.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<Elements>))]
public enum Elements
{
    /// <summary>
    /// Represents a single-line text input field.
    /// </summary>
    text,

    /// <summary>
    /// Represents a multi-line text input field.
    /// </summary>
    Textarea,

    /// <summary>
    /// Represents a checkbox input field.
    /// </summary>
    Checkbox,

    /// <summary>
    /// Represents a radio button input field.
    /// </summary>
    Radio,

    /// <summary>
    /// Represents a listbox input field.
    /// </summary>
    Listbox
}
