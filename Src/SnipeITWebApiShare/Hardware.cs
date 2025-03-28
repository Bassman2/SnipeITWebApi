﻿namespace SnipeITWebApi;

public class Hardware
{
    internal Hardware(HardwareModel model)
    {
        Name = model.Name;
        Model = model.Model.CastModel<NamedItem>();
        Manufacturer = model.Manufacturer.CastModel<NamedItem>();
        Category = model.Category.CastModel<NamedItem>();
        AssignedTo = model.AssignedTo.CastModel<Assigned>();
        PurchaseDate = model.PurchaseDate;
    }

    internal HardwareModel ToCreate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    internal HardwareModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    internal HardwareModel ToPatch()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    internal HardwareModel ToCheckout()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    internal HardwareModel ToCheckin()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
        };
    }

    public string? Name { get; }

    public NamedItem? Model { get; }

    public NamedItem? Manufacturer { get; }

    public NamedItem? Category { get; }

    public Assigned? AssignedTo { get; }

    public DateTime? PurchaseDate { get; }
}
