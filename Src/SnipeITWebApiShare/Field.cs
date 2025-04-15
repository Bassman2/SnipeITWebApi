namespace SnipeITWebApi;

public class Field : BaseItem
{
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

    //internal FieldModel ToCreate()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        Name = Name,
    //        DbColumnName = DbColumnName,
    //        Format = Format,
    //        FieldValues = FieldValues,
    //        FieldValuesArray = FieldValuesArray,
    //        Type = Type,
    //        Required = Required,
    //        DisplayInUserView = DisplayInUserView,
    //        AutoAddToFieldsets = AutoAddToFieldsets,
    //        ShowInListview = ShowInListview
    //    };
    //}

    internal FieldChangeModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
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
        };
    }

    //internal FieldModel ToPatch()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        Name = Name,
    //        DbColumnName = DbColumnName,
    //        Format = Format,
    //        FieldValues = FieldValues,
    //        FieldValuesArray = FieldValuesArray,
    //        Type = Type,
    //        Required = Required,
    //        DisplayInUserView = DisplayInUserView,
    //        AutoAddToFieldsets = AutoAddToFieldsets,
    //        ShowInListview = ShowInListview
    //    };
    //}

    public Elements? Element { get; set; } 
    public string? DbColumnName { get; set; }
    public string? Format { get; set; }
    public string? FieldValues { get; set; }
    public List<string>? FieldValuesArray { get; set; }
    public string? Type { get; set; }
    public bool? Required { get; set; }
    public bool? DisplayInUserView { get; set; }
    public bool? AutoAddToFieldsets { get; set; }
    public bool? ShowInListview { get; set; }
}
