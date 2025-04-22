namespace SnipeITWebApi;

/// <summary>
/// Represents a consumable item in the Snipe-IT system, including its details such as category, company, location, and other metadata.
/// </summary>
public class Consumable : BaseItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Consumable"/> class.
    /// </summary>
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

    internal ConsumableChangeModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return FillBase<ConsumableChangeModel>(new()
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
            ItemNno = ItemNo,
            Notes = Notes,
            Image = Image

        });
    }

    /// <summary>
    /// Gets or sets the category of the consumable.
    /// </summary>
    public NamedItem? Category { get; set; }

    /// <summary>
    /// Gets or sets the company associated with the consumable.
    /// </summary>
    public NamedItem? Company { get; set; }

    /// <summary>
    /// Gets or sets the item number of the consumable.
    /// </summary>
    public string? ItemNo { get; set; }

    /// <summary>
    /// Gets or sets the location of the consumable.
    /// </summary>
    public NamedItem? Location { get; set; }

    /// <summary>
    /// Gets or sets the manufacturer of the consumable.
    /// </summary>
    public NamedItem? Manufacturer { get; set; }

    /// <summary>
    /// Gets the supplier of the consumable.
    /// </summary>
    public NamedItem? Supplier { get; internal set; }

    /// <summary>
    /// Gets or sets the minimum amount threshold for the consumable.
    /// </summary>
    public int? MinAmt { get; set; }

    /// <summary>
    /// Gets or sets the model number of the consumable.
    /// </summary>
    public string? ModelNumber { get; set; }

    /// <summary>
    /// Gets or sets the remaining quantity of the consumable.
    /// </summary>
    public int? Remaining { get; set; }

    /// <summary>
    /// Gets or sets the order number associated with the consumable.
    /// </summary>
    public string? OrderNumber { get; set; }

    /// <summary>
    /// Gets the purchase cost of the consumable.
    /// </summary>
    public string? PurchaseCost { get; internal set; }

    /// <summary>
    /// Gets or sets the purchase date of the consumable.
    /// </summary>
    public DateTime? PurchaseDate { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the consumable.
    /// </summary>
    public int? Qty { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the consumable is requestable.
    /// </summary>
    public bool? Requestable { get; set; }
}
