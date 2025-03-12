namespace SnipeITWebApi;

public class Hardware
{
    internal Hardware(HardwareModel model)
    {
        Name = model.Name;
        Model = model.Model.CastModel<Item>();
        Manufacturer = model.Manufacturer.CastModel<Item>();
        Category = model.Category.CastModel<Item>();
        AssignedTo = model.AssignedTo.CastModel<Assigned>();
        PurchaseDate = model.PurchaseDate.CastModel<DateItem>();
    }

    public string? Name { get; }

    public Item? Model { get; }

    public Item? Manufacturer { get; }

    public Item? Category { get; }

    public Assigned? AssignedTo { get; }

    public DateItem? PurchaseDate { get; }
}
