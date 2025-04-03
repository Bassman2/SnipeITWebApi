namespace SnipeITWebApi;

public class CustomField
{
    internal CustomField(CustomFieldModel model)
    {
        Field = model.Field;
        Value = model.Value;
        FieldFormat = model.FieldFormat;
        Element = model.Element;
    }

    public string? Field { get; }

    public string? Value { get; }

    public string? FieldFormat { get; }

    public string? Element { get; }
}
