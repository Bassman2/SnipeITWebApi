namespace SnipeITWebApi;

public class Field
{
    internal Field(FieldModel model)
    {
        Id = model.Id;
        Name = model.Name;
        DbColumnName = model.DbColumnName;
        Format = model.Format;
        FieldValues = model.FieldValues;
        FieldValuesArray = model.FieldValuesArray;
        Type = model.Type;
        Required = model.Required;
        DisplayInUserView = model.DisplayInUserView;
        AutoAddToFieldsets = model.AutoAddToFieldsets;
        ShowInListview = model.ShowInListview;
        CreatedAt = model.CreatedAt;
        UpdatedAt = model.UpdatedAt;
    }

    internal FieldModel ToCreate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
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
        };
    }

    internal FieldModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
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
        };
    }

    internal FieldModel ToPatch()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
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
        };
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public string? DbColumnName { get; set; }
    public string? Format { get; set; }
    public string? FieldValues { get; set; }
    public List<string>? FieldValuesArray { get; set; }
    public string? Type { get; set; }
    public bool? Required { get; set; }
    public bool? DisplayInUserView { get; set; }
    public bool? AutoAddToFieldsets { get; set; }
    public bool? ShowInListview { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
