
using static System.Runtime.InteropServices.JavaScript.JSType;

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

    public int Id { get; }

    public string? Name { get; }

    public override string ToString() => $"{Id} : {Name}";

    public override bool Equals(object? obj) => obj is NamedItem item && Id == item.Id && Name == item.Name;

    public override int GetHashCode() => base.GetHashCode();

    public static implicit operator NamedItem(int id) => new(id);
}
