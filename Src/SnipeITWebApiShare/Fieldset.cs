namespace SnipeITWebApi;

public class Fieldset
{
    internal Fieldset(FieldsetModel model)
    {
        Id = model.Id;
        Name = model.Name;
    }

    internal FieldsetModel ToCreate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    internal FieldsetModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    internal FieldsetModel ToPatch()
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
