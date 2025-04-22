namespace SnipeITWebApi;

/// <summary>
/// Represents a custom field in the Snipe-IT system, including its name, value, format, and associated element.
/// </summary>
public class CustomField
{
    internal CustomField(CustomFieldModel model)
    {
        Field = model.Field;
        Value = model.Value;
        FieldFormat = model.FieldFormat;
        Element = model.Element;
    }

    /// <summary>
    /// Gets the name of the custom field.
    /// </summary>
    public string? Field { get; }

    /// <summary>
    /// Gets the value of the custom field.
    /// </summary>
    public string? Value { get; }

    /// <summary>
    /// Gets the format of the custom field (e.g., text, number, date).
    /// </summary>
    public string? FieldFormat { get; }

    /// <summary>
    /// Gets the element type associated with the custom field (e.g., input type or UI element).
    /// </summary>
    public string? Element { get; }
}
