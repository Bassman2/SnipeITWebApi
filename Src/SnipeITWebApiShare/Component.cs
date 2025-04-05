namespace SnipeITWebApi;

public class Component
{
    public Component()
    { }

    internal Component(ComponentModel model)
    {
        Id = model.Id;
        Name = model.Name;
        Qty = model.Qty;
        Category = model.Category?.CastModel<NamedItem>();
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

    public int? Qty { get; set; }

    public NamedItem? Category { get; set; }

}
