namespace SnipeITWebApi;

public class License
{
    public License()
    { }

    internal License(LicenseModel model)
    {
        Id = model.Id;
        Name = model.Name;
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
        Notes = model.Notes;
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
        CreatedBy = model.CreatedBy.CastModel<NamedItem>();
        CreatedAt = model.CreatedAt;
        UpdatedAt = model.UpdatedAt;
        DeletedAt = model.DeletedAt;
        UserCanCheckout = model.UserCanCheckout;
        AvailableActions = model.AvailableActions.CastModel<Actions>();
    }

    internal LicenseModel ToCreate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    internal LicenseModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    internal LicenseModel ToPatch()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    public int Id { get; set; }
    public string? Name { get; set; }
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
    public string? Notes { get; set; }
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
    public NamedItem? CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool? UserCanCheckout { get; set; }
    public Actions? AvailableActions { get; set; }
}
