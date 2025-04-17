namespace SnipeITWebApi;

public class Consumable : BaseItem
{
    public Consumable()
    { }   

    internal Consumable(ConsumableModel model) : base(model)
    {
        Category = model.Category.CastModel<NamedItem>();
        Company = model.Company.CastModel<NamedItem>();
        ItemNo = model.ItemNo;
        Location = model.Location.CastModel<NamedItem>();
        Manufacturer = model.Manufacturer.CastModel<NamedItem>();
        Supplier = model.Supplier.CastModel<NamedItem>();
        MinAmt = model.MinAmt;
        ModelNumber = model.ModelNumber;
        Remaining = model.Remaining;
        OrderNumber = model.OrderNumber;
        PurchaseCost = model.PurchaseCost;
        PurchaseDate = model.PurchaseDate;
        Qty = model.Qty;
    }

    //internal ConsumableChangeModel ToCreate()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    ArgumentNullException.ThrowIfNull(Qty, nameof(Qty));
    //    ArgumentNullException.ThrowIfNull(Category, nameof(Category));
    //    return new()
    //    {
    //        // required
    //        Name = Name,
    //        Qty = Qty,
    //        CategoryId = Category?.Id,
    //        // optional
    //    };

    //}

    internal ConsumableChangeModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            // required
            Name = Name,
            Qty = Qty,
            CategoryId = Category?.Id,
            // optional
            CompanyId = Company?.Id,
            OrderNumber = OrderNumber,
            ManufacturerId = Manufacturer?.Id,
            LocationId = Location?.Id,
            Requestable = Requestable,
            PurchaseDate = PurchaseDate,
            MinAmt = MinAmt,
            ModelNumber = ModelNumber,
            ItemNno = ItemNo
        };
    }

    //internal ConsumableModel ToPatch()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        Name = Name,
    //    };
    //}


    public NamedItem? Category { get; set; }
    public NamedItem? Company { get; set; }
    public string? ItemNo { get; set; }
    public NamedItem? Location { get; set; }
    public NamedItem? Manufacturer { get; set; }
    public NamedItem? Supplier { get; internal set; }
    public int? MinAmt { get; set; }
    public string? ModelNumber { get; set; }
    public int? Remaining { get; set; }
    public string? OrderNumber { get; set; }
    public string? PurchaseCost { get; internal set; }
    public DateTime? PurchaseDate { get; set; }
    public int? Qty { get; set; }
    public bool? Requestable { get; set; }
}
