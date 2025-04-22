namespace SnipeITWebApi;

/// <summary>
/// Represents a component in the Snipe-IT system, including its details such as serial number, location, quantity, and associated metadata.
/// </summary>
public class Component : BaseItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Component"/> class.
    /// </summary>
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
        return FillBase<ComponentChangeModel>(new()
        {
            Name = Name,
            Qty = Qty,
            CategoryId = Category?.Id,
            LocationId = Location?.Id,
            CompanyId = Company?.Id,
            OrderNumber = OrderNumber,
            PurchaseDate = PurchaseDate,
            PurchaseCost = PurchaseCost,
            MinAmt = MinAmt,
            Serial = Serial,
            Notes = Notes,
            Image = Image

        });
    }

    internal ComponentChangeModel ToUpdate()
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return FillBase<ComponentChangeModel>(new()
        {
            Name = Name,
            Qty = Qty,
            CategoryId = Category?.Id,
            LocationId = Location?.Id,
            CompanyId = Company?.Id,
            OrderNumber = OrderNumber,
            PurchaseDate = PurchaseDate,
            PurchaseCost = PurchaseCost,
            MinAmt = MinAmt,
            Serial = Serial,
            Notes = Notes,
            Image = Image

        });
    }

    /// <summary>
    /// Gets or sets the serial number of the component.
    /// </summary>
    public string? Serial { get; set; }

    /// <summary>
    /// Gets or sets the location of the component.
    /// </summary>
    public NamedItem? Location { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the component.
    /// </summary>
    public int? Qty { get; set; }

    /// <summary>
    /// Gets or sets the minimum amount threshold for the component.
    /// </summary>
    public int? MinAmt { get; set; }

    /// <summary>
    /// Gets or sets the category of the component.
    /// </summary>
    public NamedItem? Category { get; set; }

    /// <summary>
    /// Gets the supplier of the component.
    /// </summary>
    public NamedItem? Supplier { get; internal set; }

    /// <summary>
    /// Gets the manufacturer of the component.
    /// </summary>
    public NamedItem? Manufacturer { get; internal set; }

    /// <summary>
    /// Gets the model number of the component.
    /// </summary>
    public string? ModelNumber { get; internal set; }

    /// <summary>
    /// Gets or sets the order number associated with the component.
    /// </summary>
    public string? OrderNumber { get; set; }

    /// <summary>
    /// Gets or sets the purchase date of the component.
    /// </summary>
    public DateTime? PurchaseDate { get; set; }

    /// <summary>
    /// Gets or sets the purchase cost of the component.
    /// </summary>
    public float? PurchaseCost { get; set; }

    /// <summary>
    /// Gets or sets the remaining quantity of the component.
    /// </summary>
    public int? Remaining { get; set; }

    /// <summary>
    /// Gets or sets the company associated with the component.
    /// </summary>
    public NamedItem? Company { get; set; }
}
