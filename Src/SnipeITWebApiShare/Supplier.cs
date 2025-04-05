namespace SnipeITWebApi;

public class Supplier
{
    public Supplier() 
    { }

    internal Supplier(SupplierModel model)
    {
        Id = model.Id;
        Name = model.Name;
    }

    internal SupplierModel ToCreate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    internal SupplierModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    internal SupplierModel ToPatch()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Fax { get; set; }
    public string? Phone { get; set; }
    public string? Notes { get; set; }
}
