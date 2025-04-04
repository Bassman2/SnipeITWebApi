namespace SnipeITWebApi;

public class Field
{
    internal Field(FieldModel model)
    {
        Id = model.Id;
        Name = model.Name;
    }

    internal FieldModel ToCreate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    internal FieldModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    internal FieldModel ToPatch()
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
