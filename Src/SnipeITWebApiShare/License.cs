namespace SnipeITWebApi;

/// <summary>
/// Represents a software license in the Snipe-IT system, including its details such as company, manufacturer, product key, and other metadata.
/// </summary>
public class License : BaseItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="License"/> class.
    /// </summary>
    public License()
    { }

    internal License(LicenseModel model) : base(model)
    {
        Company = model.Company.CastModel<NamedItem>();
        Manufacturer = model.Manufacturer.CastModel<NamedItem>();
        ProductKey = model.ProductKey;
        OrderNumber = model.OrderNumber;
        PurchaseOrder = model.PurchaseOrder;
        PurchaseDate = model.PurchaseDate;
        TerminationDate = model.TerminationDate;
        Depreciation = model.Depreciation;
        PurchaseCost = model.PurchaseCost;
        PurchaseCostNumeric = model.PurchaseCostNumeric;
        ExpirationDate = model.ExpirationDate;
        Seats = model.Seats;
        FreeSeatsCount = model.FreeSeatsCount;
        Remaining = model.Remaining;
        MinAmt = model.MinAmt;
        LicenseName = model.LicenseName;
        LicenseEmail = model.LicenseEmail;
        Reassignable = model.Reassignable;
        Maintained = model.Maintained;
        Supplier = model.Supplier.CastModel<NamedItem>();
        Category = model.Category.CastModel<NamedItem>();
    }

    //internal LicenseModel ToCreate()
    //{
    //    ArgumentNullException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    ArgumentNullException.ThrowIfNull(Seats, nameof(Seats));
    //    ArgumentNullException.ThrowIfNull(Category?.Id, nameof(Category.Id));
    //    return new()
    //    {
    //        // required
    //        Name = Name,
    //        Seats = Seats,
    //        CategoryId = Category?.Id,
    //        //Category = Category?.ToCreate(),

    //        // optional
    //        Notes = Notes,
    //    };
    //}

    internal LicenseChangeModel ToUpdate()
    {
        //ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return FillBase<LicenseChangeModel>(new()
        {
            // optional
            Name = Name,
            Notes = Notes,
            Seats = Seats,
            CategoryId = Category?.Id,

        });
    }

    //internal LicenseModel ToPatch()
    //{
    //    //ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        // optional
    //        Name = Name,
    //        Notes = Notes,

    //    };
    //}

    /// <summary>
    /// Gets or sets the company associated with the license.
    /// </summary>
    public NamedItem? Company { get; set; }

    /// <summary>
    /// Gets or sets the manufacturer of the license.
    /// </summary>
    public NamedItem? Manufacturer { get; set; }

    /// <summary>
    /// Gets or sets the product key of the license.
    /// </summary>
    public string? ProductKey { get; set; }

    /// <summary>
    /// Gets or sets the order number associated with the license.
    /// </summary>
    public string? OrderNumber { get; set; }

    /// <summary>
    /// Gets or sets the purchase order associated with the license.
    /// </summary>
    public string? PurchaseOrder { get; set; }

    /// <summary>
    /// Gets or sets the purchase date of the license.
    /// </summary>
    public DateTime? PurchaseDate { get; set; }

    /// <summary>
    /// Gets or sets the termination date of the license.
    /// </summary>
    public DateTime? TerminationDate { get; set; }

    /// <summary>
    /// Gets or sets the depreciation value of the license.
    /// </summary>
    public string? Depreciation { get; set; }

    /// <summary>
    /// Gets or sets the purchase cost of the license.
    /// </summary>
    public string? PurchaseCost { get; set; }

    /// <summary>
    /// Gets or sets the numeric representation of the purchase cost of the license.
    /// </summary>
    public string? PurchaseCostNumeric { get; set; }

    /// <summary>
    /// Gets or sets the expiration date of the license.
    /// </summary>
    public DateTime? ExpirationDate { get; set; }

    /// <summary>
    /// Gets or sets the total number of seats available for the license.
    /// </summary>
    public int? Seats { get; set; }

    /// <summary>
    /// Gets the number of free seats available for the license.
    /// </summary>
    public int? FreeSeatsCount { get; set; }

    /// <summary>
    /// Gets the remaining quantity of the license.
    /// </summary>
    public int? Remaining { get; set; }

    /// <summary>
    /// Gets or sets the minimum amount threshold for the license.
    /// </summary>
    public int? MinAmt { get; set; }

    /// <summary>
    /// Gets or sets the name of the license.
    /// </summary>
    public string? LicenseName { get; set; }

    /// <summary>
    /// Gets or sets the email associated with the license.
    /// </summary>
    public string? LicenseEmail { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the license is reassignable.
    /// </summary>
    public bool? Reassignable { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the license is maintained.
    /// </summary>
    public bool? Maintained { get; set; }

    /// <summary>
    /// Gets or sets the supplier of the license.
    /// </summary>
    public NamedItem? Supplier { get; set; }

    /// <summary>
    /// Gets or sets the category of the license.
    /// </summary>
    public NamedItem? Category { get; set; }
}
