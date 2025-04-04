namespace SnipeITWebApi;

public class Accessory
{
    internal Accessory(AccessoryModel model)
    {
        Id = model.Id;
        Name = model.Name;
    }

    internal AccessoryModel ToCreate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    internal AccessoryModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    internal AccessoryModel ToPatch()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    public int Id { get; set; }

    public string? Name { get; set; }
}
