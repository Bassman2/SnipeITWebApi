namespace SnipeITWebApi;

/// <summary>
/// Represents a model in the Snipe-IT system, including details such as manufacturer, category, and associated counts.
/// </summary>
public class Model : BaseItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Model"/> class.
    /// </summary>
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

    /// <summary>
    /// Gets or sets the manufacturer associated with the model.
    /// </summary>
    public NamedItem? Manufacturer { get; set; }

    /// <summary>
    /// Gets or sets the model number.
    /// </summary>
    public string? ModelNumber { get; set; }

    /// <summary>
    /// Gets or sets the minimum amount associated with the model.
    /// </summary>
    public string? MinAmt { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether there are remaining items for the model.
    /// </summary>
    public bool? Remaining { get; set; }

    /// <summary>
    /// Gets or sets the depreciation information for the model.
    /// </summary>
    public NamedItem? Depreciation { get; set; }

    /// <summary>
    /// Gets or sets the count of assets associated with the model.
    /// </summary>
    public int? AssetsCount { get; set; }

    /// <summary>
    /// Gets or sets the category associated with the model.
    /// </summary>
    public NamedItem? Category { get; set; }

    /// <summary>
    /// Gets or sets the fieldset associated with the model.
    /// </summary>
    public NamedItem? Fieldset { get; set; }

    /// <summary>
    /// Gets or sets the end-of-life (EOL) status of the model.
    /// </summary>
    public int? Eol { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the model is requestable.
    /// </summary>
    public bool? Requestable { get; set; }
}
