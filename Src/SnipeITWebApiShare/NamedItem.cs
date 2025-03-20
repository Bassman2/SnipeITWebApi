namespace SnipeITWebApi;

public class NamedItem
{
    internal NamedItem(NamedItemModel model)
    {
        Id = model.Id;
        Name = model.Name;
    }

    public int Id { get; }

    public string? Name { get; }
}
