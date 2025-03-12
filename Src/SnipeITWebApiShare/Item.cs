namespace SnipeITWebApi;

public class Item
{
    internal Item(ItemModel model)
    {
        Id = model.Id;
        Name = model.Name;
    }

    public int Id { get; }

    public string? Name { get; }
}
