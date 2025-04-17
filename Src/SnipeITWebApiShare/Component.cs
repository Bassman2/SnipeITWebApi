namespace SnipeITWebApi;

public class Component : BaseItem
{
    public Component()
    { }

    internal Component(ComponentModel model) : base(model) 
    {
        Serial = model.Serial;
        Location = model.Location?.CastModel<NamedItem>();
        Qty = model.Qty;
        MinAmt = model.MinAmt;
        Category = model.Category?.CastModel<NamedItem>();
        Supplier = model.Supplier?.CastModel<NamedItem>();
        Manufacturer = model.Manufacturer?.CastModel<NamedItem>();
        ModelNumber = model.ModelNumber;
        OrderNumber = model.OrderNumber;
        PurchaseDate = model.PurchaseDate;
        PurchaseCost = model.PurchaseCost;
        Remaining = model.Remaining;
        Company = model.Company?.CastModel<NamedItem>();
    }

    internal ComponentChangeModel ToCreate()
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        ArgumentNullException.ThrowIfNull(Qty, nameof(Qty));
        ArgumentNullException.ThrowIfNull(Category, nameof(Category));
        return new()
        {
            Name = Name,
            Qty = Qty,
            CategoryId = Category?.Id,
        };
    }

    internal ComponentChangeModel ToUpdate()
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    //internal ComponentModel ToPatch()
    //{
    //    ArgumentNullException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        Name = Name,
    //    };
    //}

   
    public string? Serial { get; set; }
    public NamedItem? Location { get; set; }
    public int? Qty { get; set; }
    public int? MinAmt { get; set; }
    public NamedItem? Category { get; set; }
    public NamedItem? Supplier { get; set; }
    public NamedItem? Manufacturer { get; set; }
    public string? ModelNumber { get; set; }
    public string? OrderNumber { get; set; }
    public DateTime? PurchaseDate { get; set; }
    public float? PurchaseCost { get; set; }
    public int? Remaining { get; set; }
    public NamedItem? Company { get; set; }
}
