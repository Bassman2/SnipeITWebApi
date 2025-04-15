namespace SnipeITWebApi;

public class License : BaseItem
{
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
        UserCanCheckout = model.UserCanCheckout;
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
        return new()
        {
            // optional
            Name = Name,
            Notes = Notes,

        };
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

    public NamedItem? Company { get; set; }
    public NamedItem? Manufacturer { get; set; }
    public string? ProductKey { get; set; }
    public string? OrderNumber { get; set; }
    public string? PurchaseOrder { get; set; }
    public DateTime? PurchaseDate { get; set; }
    public DateTime? TerminationDate { get; set; }
    public string? Depreciation { get; set; }
    public string? PurchaseCost { get; set; }
    public string? PurchaseCostNumeric { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public int? Seats { get; set; }
    public int? FreeSeatsCount { get; set; }
    public int? Remaining { get; set; }
    public int? MinAmt { get; set; }
    public string? LicenseName { get; set; }
    public string? LicenseEmail { get; set; }
    public bool? Reassignable { get; set; }
    public bool? Maintained { get; set; }
    public NamedItem? Supplier { get; set; }
    public NamedItem? Category { get; set; }
    
    public bool? UserCanCheckout { get; set; }
}
