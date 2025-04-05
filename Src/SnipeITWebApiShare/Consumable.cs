namespace SnipeITWebApi;

public class Consumable
{
    public Consumable()
    { }   

    internal Consumable(ConsumableModel model)
    {
        Id = model.Id;
        Name = model.Name;
        Qty = model.Qty;
        Category = model.Category?.CastModel<NamedItem>();
    }

    internal ConsumableModel ToCreate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        ArgumentNullException.ThrowIfNull(Qty, nameof(Qty));
        ArgumentNullException.ThrowIfNull(Category, nameof(Category));
        return new()
        {
            Name = Name,
            Qty = Qty,
            CategoryId = Category?.Id,
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

    public int? Qty { get; set; }

    public NamedItem? Category { get; set; }
}
