namespace SnipeITWebApi;

public class Consumable
{
    public Consumable()
    { }   

    internal Consumable(ConsumableModel model)
    {
        Id = model.Id;
        Name = model.Name;
        Image = model.Image;
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
        Notes = model.Notes;
        CreatedBy = model.CreatedBy.CastModel<NamedItem>();
        CreatedAt = model.CreatedAt;
        UpdatedAt = model.UpdatedAt;
        UserCanCheckout = model.UserCanCheckout;
        AvailableActions = model.AvailableActions.CastModel<Actions>();
    }

    internal ConsumableModel ToCreate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        ArgumentNullException.ThrowIfNull(Qty, nameof(Qty));
        ArgumentNullException.ThrowIfNull(Category, nameof(Category));
        return new()
        {
            // required
            Name = Name,
            Qty = Qty,
            CategoryId = Category?.Id,
            // optional
        };

    }

    internal ConsumableModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    internal ConsumableModel ToPatch()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Image { get; set; }
    public NamedItem? Category { get; set; }
    public NamedItem? Company { get; set; }
    public string? ItemNo { get; set; }
    public NamedItem? Location { get; set; }
    public NamedItem? Manufacturer { get; set; }
    public NamedItem? Supplier { get; set; }
    public int? MinAmt { get; set; }
    public string? ModelNumber { get; set; }
    public int? Remaining { get; set; }
    public string? OrderNumber { get; set; }
    public string? PurchaseCost { get; set; }
    public DateTime? PurchaseDate { get; set; }
    public int? Qty { get; set; }
    public string? Notes { get; set; }
    public NamedItem? CreatedBy { get; set; }   
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool? UserCanCheckout { get; set; }
    public Actions? AvailableActions { get; set; }
}
