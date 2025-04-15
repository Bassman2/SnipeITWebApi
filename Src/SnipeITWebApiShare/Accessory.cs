namespace SnipeITWebApi;

public class Accessory
{
    public Accessory()
    { }

    internal Accessory(AccessoryModel model)
    {
        Id = model.Id;
        Name = model.Name;
        Image = model.Image;
        Company = model.Company.CastModel<NamedItem>();
        Manufacturer = model.Manufacturer.CastModel<NamedItem>();
        Supplier = model.Supplier.CastModel<NamedItem>();
        ModelNumber = model.ModelNumber;
        Category = model.Category.CastModel<NamedItem>();
        Location = model.Location.CastModel<NamedItem>();
        Notes = model.Notes;
        Qty = model.Qty;
        PurchaseDate = model.PurchaseDate;
        PurchaseCost = model.PurchaseCost;
        OrderNumber = model.OrderNumber;
        MinQty = model.MinQty;
        MinAmt = model.MinAmt;
        RemainingQty = model.RemainingQty;
        Remaining = model.Remaining;
        CheckoutsCount = model.CheckoutsCount;
        CreatedBy = model.CreatedBy.CastModel<NamedItem>();
        CreatedAt = model.CreatedAt;
        UpdatedAt = model.UpdatedAt;
        AvailableActions = model.AvailableActions.CastModel<Actions>();
    }

    internal AccessoryChangeModel ToChange()
    {
        return new()
        {
            // required
            Name = Name,
            Qty = Qty,
            CategoryId = Category?.Id,
            OrderNumber = OrderNumber,
            PurchaseCost = PurchaseCost,
            PurchaseDate = PurchaseDate,
            ModelNumber = ModelNumber,
            CompanyId = Company?.Id,
            LocationId = Location?.Id,
            ManufacturerId = Manufacturer?.Id,
            SupplierId = Supplier?.Id,
            Notes = Notes
        };
    }

    //internal AccessoryModel ToCreate()
    //{
    //    ArgumentNullException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    ArgumentNullException.ThrowIfNull(Qty, nameof(Qty));
    //    ArgumentNullException.ThrowIfNull(Category?.Id, nameof(Category.Id));
    //    return new()
    //    {
    //        // required
    //        Name = Name,
    //        Qty = Qty,
    //        CategoryId = Category?.Id,

    //        // optional
    //        Image = Image,
    //        ModelNumber = ModelNumber,
    //        Notes = Notes,
    //        PurchaseDate = PurchaseDate,
    //        PurchaseCost = PurchaseCost,
    //        OrderNumber = OrderNumber,
    //        MinQty = MinQty,
    //        MinAmt = MinAmt,
    //        RemainingQty = RemainingQty,
    //        Remaining = Remaining,
    //    };
    //}

    //internal AccessoryModel ToUpdate()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        Name = Name,
    //        Image = Image,
    //        ModelNumber = ModelNumber,
    //        Notes = Notes,
    //        Qty = Qty,
    //        PurchaseDate = PurchaseDate,
    //        PurchaseCost = PurchaseCost,
    //        OrderNumber = OrderNumber,
    //        MinQty = MinQty,
    //        MinAmt = MinAmt,
    //        RemainingQty = RemainingQty,
    //        Remaining = Remaining,
    //    };
    //}

    //internal AccessoryModel ToPatch()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        Name = Name,
    //        Image = Image,
    //        ModelNumber = ModelNumber,
    //        Notes = Notes,
    //        Qty = Qty,
    //        PurchaseDate = PurchaseDate,
    //        PurchaseCost = PurchaseCost,
    //        OrderNumber = OrderNumber,
    //        MinQty = MinQty,
    //        MinAmt = MinAmt,
    //        RemainingQty = RemainingQty,
    //        Remaining = Remaining,
    //    };
    //}

    public int Id { get; }
    public string? Name { get; set; }
    public string? Image { get; set; }
    public NamedItem? Company { get; set; }
    public NamedItem? Manufacturer { get; set; }
    public NamedItem? Supplier { get; set; }
    public string? ModelNumber { get; set; }
    public NamedItem? Category { get; set; }
    public NamedItem? Location { get; set; }
    public string? Notes { get; set; }
    public int? Qty { get; set; }
    public DateTime? PurchaseDate { get; set; }
    public string? PurchaseCost { get; set; }
    public string? OrderNumber { get; set; }
    public int? MinQty { get; set; }
    public int? MinAmt { get; set; }
    public int? RemainingQty { get; set; }
    public int? Remaining { get; set; }
    public int? CheckoutsCount { get; }
    public NamedItem? CreatedBy { get; }
    public DateTime? CreatedAt { get; }
    public DateTime? UpdatedAt { get; }
    public Actions? AvailableActions { get; }
}
