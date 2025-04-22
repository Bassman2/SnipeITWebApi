namespace SnipeITWebApi;

/// <summary>
/// Represents an accessory in the Snipe-IT system, including its company, manufacturer, supplier, and other related properties.
/// </summary>
public class Accessory : BaseItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Accessory"/> class.
    /// </summary>
    public Accessory()
    { }

    internal Accessory(AccessoryModel model) : base(model)
    {
        Company = model.Company.CastModel<NamedItem>();
        Manufacturer = model.Manufacturer.CastModel<NamedItem>();
        Supplier = model.Supplier.CastModel<NamedItem>();
        ModelNumber = model.ModelNumber;
        Category = model.Category.CastModel<NamedItem>();
        Location = model.Location.CastModel<NamedItem>();
        Qty = model.Qty;
        PurchaseDate = model.PurchaseDate;
        PurchaseCost = model.PurchaseCost;
        OrderNumber = model.OrderNumber;
        MinQty = model.MinQty;
        MinAmt = model.MinAmt;
        RemainingQty = model.RemainingQty;
        Remaining = model.Remaining;
        CheckoutsCount = model.CheckoutsCount;
    }

    internal AccessoryChangeModel ToChange()
    {
        return FillBase<AccessoryChangeModel>(new()
        {
            // required
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
        });
    }

    /// <summary>
    /// Gets or sets the company associated with the accessory.
    /// </summary>
    public NamedItem? Company { get; set; }

    /// <summary>
    /// Gets or sets the manufacturer of the accessory.
    /// </summary>
    public NamedItem? Manufacturer { get; set; }

    /// <summary>
    /// Gets or sets the supplier of the accessory.
    /// </summary>
    public NamedItem? Supplier { get; set; }

    /// <summary>
    /// Gets or sets the model number of the accessory.
    /// </summary>
    public string? ModelNumber { get; set; }

    /// <summary>
    /// Gets or sets the category of the accessory.
    /// </summary>
    public NamedItem? Category { get; set; }

    /// <summary>
    /// Gets or sets the location of the accessory.
    /// </summary>
    public NamedItem? Location { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the accessory.
    /// </summary>
    public int? Qty { get; set; }

    /// <summary>
    /// Gets or sets the purchase date of the accessory.
    /// </summary>
    public DateTime? PurchaseDate { get; set; }

    /// <summary>
    /// Gets or sets the purchase cost of the accessory.
    /// </summary>
    public float? PurchaseCost { get; set; }

    /// <summary>
    /// Gets or sets the order number associated with the accessory.
    /// </summary>
    public string? OrderNumber { get; set; }

    /// <summary>
    /// Gets the minimum quantity threshold for the accessory.
    /// </summary>
    public int? MinQty { get; internal set; }

    /// <summary>
    /// Gets the minimum amount threshold for the accessory.
    /// </summary>
    public int? MinAmt { get; internal set; }

    /// <summary>
    /// Gets the remaining quantity of the accessory.
    /// </summary>
    public int? RemainingQty { get; internal set; }

    /// <summary>
    /// Gets the remaining amount of the accessory.
    /// </summary>
    public int? Remaining { get; internal set; }

    /// <summary>
    /// Gets the total number of checkouts for the accessory.
    /// </summary>
    public int? CheckoutsCount { get; internal set; }
}
