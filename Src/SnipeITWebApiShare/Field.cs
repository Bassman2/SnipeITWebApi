namespace SnipeITWebApi;

/// <summary>
/// Represents a custom field in the Snipe-IT system, including its database column name, format, type, and other metadata.
/// </summary>
public class Field : BaseItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Field"/> class.
    /// </summary>
    public Field()
    { } 

    internal Field(FieldModel model) : base(model)
    {
        DbColumnName = model.DbColumnName;
        Format = model.Format;
        FieldValues = model.FieldValues;
        FieldValuesArray = model.FieldValuesArray;
        Type = model.Type;
        Required = model.Required;
        DisplayInUserView = model.DisplayInUserView;
        AutoAddToFieldsets = model.AutoAddToFieldsets;
        ShowInListview = model.ShowInListview;
    }

    internal FieldChangeModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return FillBase<FieldChangeModel>(new()
        {
            Element = Element,
            Name = Name,
            DbColumnName = DbColumnName,
            Format = Format,
            FieldValues = FieldValues,
            FieldValuesArray = FieldValuesArray,
            Type = Type,
            Required = Required,
            DisplayInUserView = DisplayInUserView,
            AutoAddToFieldsets = AutoAddToFieldsets,
            ShowInListview = ShowInListview
        });
    }

    /// <summary>
    /// Gets or sets the type of form element associated with the field (e.g., text, checkbox, radio).
    /// </summary>
    public Elements? Element { get; set; }

    /// <summary>
    /// Gets or sets the database column name associated with the field.
    /// </summary>
    public string? DbColumnName { get; set; }

    /// <summary>
    /// Gets or sets the format of the field (e.g., text, number, date).
    /// </summary>
    public string? Format { get; set; }

    /// <summary>
    /// Gets or sets the field values as a single string.
    /// </summary>
    public string? FieldValues { get; set; }

    /// <summary>
    /// Gets or sets the field values as an array of strings.
    /// </summary>
    public List<string>? FieldValuesArray { get; set; }

    /// <summary>
    /// Gets or sets the type of the field (e.g., custom, predefined).
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the field is required.
    /// </summary>
    public bool? Required { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the field is displayed in the user view.
    /// </summary>
    public bool? DisplayInUserView { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the field is automatically added to fieldsets.
    /// </summary>
    public bool? AutoAddToFieldsets { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the field is shown in the list view.
    /// </summary>
    public bool? ShowInListview { get; set; }
}
