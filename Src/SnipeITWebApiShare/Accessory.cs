namespace SnipeITWebApi;

public class Accessory : BaseItem
{
    internal Accessory()
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

    public NamedItem? Company { get; set; }
    public NamedItem? Manufacturer { get; set; }
    public NamedItem? Supplier { get; set; }
    public string? ModelNumber { get; set; }
    public NamedItem? Category { get; set; }
    public NamedItem? Location { get; set; }
    public int? Qty { get; set; }
    public DateTime? PurchaseDate { get; set; }
    public float? PurchaseCost { get; set; }
    public string? OrderNumber { get; set; }
    public int? MinQty { get; internal set; }
    public int? MinAmt { get; internal set; }
    public int? RemainingQty { get; internal set; }
    public int? Remaining { get; internal set; }
    public int? CheckoutsCount { get; internal set; }
}
