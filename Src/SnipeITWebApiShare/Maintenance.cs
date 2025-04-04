namespace SnipeITWebApi;

public class Maintenance
{
    internal Maintenance(MaintenanceModel model)
    {
        Id = model.Id;
        Name = model.Name;
    }

    internal MaintenanceModel ToCreate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    internal MaintenanceModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    internal MaintenanceModel ToPatch()
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
