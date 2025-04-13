namespace SnipeITWebApi;

public class Model
{
    public Model()
    { }

    internal Model(ModelModel model)
    {
        Id = model.Id;
        Name = model.Name;
        Manufacturer = model.Manufacturer.CastModel<NamedItem>();
        Image = model.Image;
        ModelNumber = model.ModelNumber;
        MinAmt = model.MinAmt;
        Remaining = model.Remaining;
        Depreciation = model.Depreciation.CastModel<NamedItem>();
        AssetsCount = model.AssetsCount;    
        Category = model.Category.CastModel<NamedItem>();
        Fieldset = model.Fieldset.CastModel<NamedItem>();
        Eol = model.Eol;
        Requestable = model.Requestable;
        Notes = model.Notes;
        CreatedBy = model.CreatedBy.CastModel<NamedItem>();
        CreatedAt = model.CreatedAt;
        UpdatedAt = model.UpdatedAt;
        DeletedAt = model.DeletedAt;
        AvailableActions = model.AvailableActions.CastModel<Actions>();
    }

    //internal ModelModel ToCreate()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    ArgumentOutOfRangeException.ThrowIfZero(Category?.Id ?? 0, nameof(Category.Id));
    //    return new()
    //    {

    //        //Id = Id,
    //        Name = Name,
    //        CategoryId = Category?.Id,
    //        //Url = Url,
    //        //Image = Image,
    //        //SupportUrl = SupportUrl,
    //        //WarrantyLookupUrl = WarrantyLookupUrl,
    //        //SupportPhone = SupportPhone,
    //        //SupportEmail = SupportEmail,
    //        //AssetsCount = AssetsCount,
    //        //LicensesCount = LicensesCount,
    //        //ConsumablesCount = ConsumablesCount,
    //        //AccessoriesCount = AccessoriesCount,
    //        //ComponentsCount = ComponentsCount,
    //        //Notes = Notes,
    //        //CreatedBy = model.CreatedBy.CastModel<NamedItem>();
    //        //CreatedAt = model.CreatedAt.CastModel<DateItem>();
    //        //UpdatedAt = model.UpdatedAt.CastModel<DateItem>();
    //        //DeletedAt = model.DeletedAt.CastModel<DateItem>();
    //        //AvailableActions = model.AvailableActions.CastModel<Actions>();
    //    };
    //}

    internal ModelChangeModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        ArgumentOutOfRangeException.ThrowIfZero(Category?.Id ?? 0, nameof(Category.Id));
        return new()
        {
            Name = Name,
            CategoryId = Category?.Id,
            //Url = Url,
            //Image = Image,
            //SupportUrl = SupportUrl,
            //WarrantyLookupUrl = WarrantyLookupUrl,
            //SupportPhone = SupportPhone,
            //SupportEmail = SupportEmail,
            //AssetsCount = AssetsCount,
            //LicensesCount = LicensesCount,
            //ConsumablesCount = ConsumablesCount,
            //AccessoriesCount = AccessoriesCount,
            //ComponentsCount = ComponentsCount,
            //Notes = Notes,
            //CreatedBy = model.CreatedBy.CastModel<NamedItem>();
            //CreatedAt = model.CreatedAt.CastModel<DateItem>();
            //UpdatedAt = model.UpdatedAt.CastModel<DateItem>();
            //DeletedAt = model.DeletedAt.CastModel<DateItem>();
            //AvailableActions = model.AvailableActions.CastModel<Actions>();
        };
    }

    //internal ModelModel ToPatch()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    ArgumentOutOfRangeException.ThrowIfZero(Category?.Id ?? 0, nameof(Category.Id));
    //    return new()
    //    {
    //        Name = Name,
    //        CategoryId = Category?.Id,
    //        //Url = Url,
    //        //Image = Image,
    //        //SupportUrl = SupportUrl,
    //        //WarrantyLookupUrl = WarrantyLookupUrl,
    //        //SupportPhone = SupportPhone,
    //        //SupportEmail = SupportEmail,
    //        //AssetsCount = AssetsCount,
    //        //LicensesCount = LicensesCount,
    //        //ConsumablesCount = ConsumablesCount,
    //        //AccessoriesCount = AccessoriesCount,
    //        //ComponentsCount = ComponentsCount,
    //        //Notes = Notes,
    //        //CreatedBy = model.CreatedBy.CastModel<NamedItem>();
    //        //CreatedAt = model.CreatedAt.CastModel<DateItem>();
    //        //UpdatedAt = model.UpdatedAt.CastModel<DateItem>();
    //        //DeletedAt = model.DeletedAt.CastModel<DateItem>();
    //        //AvailableActions = model.AvailableActions.CastModel<Actions>();
    //    };
    //}

    public int Id { get; }

    public string? Name { get; set; }

    public NamedItem? Manufacturer { get; set; }

    public string? Image { get; set; }

    public string? ModelNumber { get; set; }

    public string? MinAmt { get; set; }

    public int? Remaining { get; set; }

    public NamedItem? Depreciation { get; set; }

    public int? AssetsCount { get; set; }

    public NamedItem? Category { get; set; }

    public NamedItem? Fieldset { get; set; }

    // TODO : default_fieldset_values

    public string? Eol { get; set; }

    public bool? Requestable { get; set; }

    public string? Notes { get; set; }

    public NamedItem? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; }

    public DateTime? UpdatedAt { get; }

    public DateTime? DeletedAt { get; }

    public Actions? AvailableActions { get; }
}
