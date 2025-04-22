namespace SnipeITWebApi;

/// <summary>
/// Represents a manufacturer in the Snipe-IT system, including details such as URLs, support information, and associated item counts.
/// </summary>
public class Manufacturer : BaseItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Manufacturer"/> class.
    /// </summary>
    public Manufacturer()
    { }

    internal Manufacturer(ManufacturerModel model) : base(model)
    {
        Url = model.Url;
        SupportUrl = model.SupportUrl;
        WarrantyLookupUrl = model.WarrantyLookupUrl;
        SupportPhone = model.SupportPhone;
        SupportEmail = model.SupportEmail;
        AssetsCount = model.AssetsCount;
        LicensesCount = model.LicensesCount;
        ConsumablesCount = model.ConsumablesCount;
        AccessoriesCount = model.AccessoriesCount;
        ComponentsCount = model.ComponentsCount;
    }

    //internal ManufacturerModel ToCreate()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        
    //    };
    //}

    internal ManufacturerChangeModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return FillBase<ManufacturerChangeModel>(new()
        {
            
        });
    }

    //internal ManufacturerModel ToPatch()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        //Id = Id,
    //        Name = Name,
    //        Url = Url,
    //        Image = Image,
    //        SupportUrl = SupportUrl,
    //        WarrantyLookupUrl = WarrantyLookupUrl,
    //        SupportPhone = SupportPhone,
    //        SupportEmail = SupportEmail,
    //        AssetsCount = AssetsCount,
    //        LicensesCount = LicensesCount,
    //        ConsumablesCount = ConsumablesCount,
    //        AccessoriesCount = AccessoriesCount,
    //        ComponentsCount = ComponentsCount,
    //        Notes = Notes,
    //        //CreatedBy = model.CreatedBy.CastModel<NamedItem>();
    //        //CreatedAt = model.CreatedAt.CastModel<DateItem>();
    //        //UpdatedAt = model.UpdatedAt.CastModel<DateItem>();
    //        //DeletedAt = model.DeletedAt.CastModel<DateItem>();
    //        //AvailableActions = model.AvailableActions.CastModel<AvailableActions>();
    //    };
    //}


    /// <summary>
    /// Gets or sets the URL of the manufacturer.
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    /// Gets or sets the support URL of the manufacturer.
    /// </summary>
    public string? SupportUrl { get; set; }

    /// <summary>
    /// Gets or sets the warranty lookup URL of the manufacturer.
    /// </summary>
    public string? WarrantyLookupUrl { get; set; }

    /// <summary>
    /// Gets or sets the support phone number of the manufacturer.
    /// </summary>
    public string? SupportPhone { get; set; }

    /// <summary>
    /// Gets or sets the support email address of the manufacturer.
    /// </summary>
    public string? SupportEmail { get; set; }

    /// <summary>
    /// Gets the count of assets associated with the manufacturer.
    /// </summary>
    public int AssetsCount { get; }

    /// <summary>
    /// Gets the count of licenses associated with the manufacturer.
    /// </summary>
    public int LicensesCount { get; }

    /// <summary>
    /// Gets the count of consumables associated with the manufacturer.
    /// </summary>
    public int ConsumablesCount { get; }

    /// <summary>
    /// Gets the count of accessories associated with the manufacturer.
    /// </summary>
    public int AccessoriesCount { get; }

    /// <summary>
    /// Gets the count of components associated with the manufacturer.
    /// </summary>
    public int ComponentsCount { get; }
}
