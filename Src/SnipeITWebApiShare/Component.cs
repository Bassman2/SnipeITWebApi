namespace SnipeITWebApi;

public class Component
{
    public Component()
    { }

    internal Component(ComponentModel model)
    {
        Id = model.Id;
        Name = model.Name;
        Image = model.Image;
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
        Notes = model.Notes;
        CreatedBy = model.CreatedBy?.CastModel<NamedItem>();
        CreatedAt = model.CreatedAt;
        UpdatedAt = model.UpdatedAt;
        UserCanCheckout = model.UserCanCheckout;
        AvailableActions = model.AvailableActions.CastModel<Actions>();
    }

    internal ComponentModel ToCreate()
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

    internal ComponentModel ToUpdate()
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    internal ComponentModel ToPatch()
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Image { get; set; }
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
    public string? PurchaseCost { get; set; }
    public int? Remaining { get; set; }
    public NamedItem? Company { get; set; }
    public string? Notes { get; set; }
    public NamedItem? CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? UserCanCheckout { get; set; }
    public Actions? AvailableActions { get; set; }
}
