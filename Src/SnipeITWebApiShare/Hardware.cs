namespace SnipeITWebApi;

public class Hardware
{
    public string? Name { get; init; }

    public Item? Model { get; init; }

    public Item? Manufacturer { get; init; }

    public Item? Category { get; init; }

    public Assigned? AssignedTo { get; init; }

    public DateItem? PurchaseDate { get; init; }
}
