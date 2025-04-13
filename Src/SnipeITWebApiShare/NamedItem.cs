namespace SnipeITWebApi;

public class NamedItem 
{
    public NamedItem(int id, string? name = null)
    {
        Id = id;
        Name = name;
    }

    internal NamedItem(NamedItemModel model)
    {
        Id = model.Id;
        Name = model.Name;
    }

    internal NamedItemModel ToCreate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    internal NamedItemModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    internal NamedItemModel ToPatch()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    public int Id { get; }
    public string? Name { get; }

    public override string ToString() => $"{Id} : {Name}";
    public override bool Equals(object? obj) => obj is NamedItem item && Id == item.Id && Name == item.Name;
    public override int GetHashCode() => base.GetHashCode();

    public static implicit operator NamedItem(int id) => new(id);

    public static implicit operator NamedItem((int, string) item) => new(item.Item1, item.Item2);

}
