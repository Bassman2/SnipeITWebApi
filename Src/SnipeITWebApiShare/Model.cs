namespace SnipeITWebApi;

public class Model : BaseItem
{
    public Model()
    { }

    internal Model(ModelModel model) : base(model)
    {
        Manufacturer = model.Manufacturer.CastModel<NamedItem>();
        ModelNumber = model.ModelNumber;
        MinAmt = model.MinAmt;
        Remaining = model.Remaining;
        Depreciation = model.Depreciation.CastModel<NamedItem>();
        AssetsCount = model.AssetsCount;    
        Category = model.Category.CastModel<NamedItem>();
        Fieldset = model.Fieldset.CastModel<NamedItem>();
        Eol = model.Eol;
        Requestable = model.Requestable;
    }

    //internal ModelModel ToCreate()
    //{
    //    return new()
    //    {

   
    //    };
    //}

    internal ModelChangeModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        ArgumentOutOfRangeException.ThrowIfZero(Category?.Id ?? 0, nameof(Category.Id));
        return FillBase<ModelChangeModel>(new()
        {
            CategoryId = Category?.Id,
            ModelNumber = ModelNumber,
            FieldsetId = Fieldset?.Id,
            ManufacturerId = Manufacturer?.Id,
            DepreciationId = Depreciation?.Id,
            Requestable = Requestable,
            Eol = Eol
        });
    }

    //internal ModelModel ToPatch()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    ArgumentOutOfRangeException.ThrowIfZero(Category?.Id ?? 0, nameof(Category.Id));
    //    return new()
    //    {
    
    //    };
    //}

    public NamedItem? Manufacturer { get; set; }

    public string? ModelNumber { get; set; }

    public string? MinAmt { get; set; }

    public bool? Remaining { get; set; }

    public NamedItem? Depreciation { get; set; }

    public int? AssetsCount { get; set; }

    public NamedItem? Category { get; set; }

    public NamedItem? Fieldset { get; set; }

    // TODO : default_fieldset_values

    public int? Eol { get; set; }

    public bool? Requestable { get; set; }
}
