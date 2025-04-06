using System.Diagnostics;

namespace SnipeITWebApi;

[DebuggerDisplay("{Id} : {Name} : {AssetTag}")]
public class Hardware
{
    public Hardware(int id)
    {
        Id = id;
    }

    public Hardware()
    { }

    internal Hardware(HardwareModel model)
    {
        Id = model.Id;
        Name = model.Name;
        AssetTag = model.AssetTag;
        Serial = model.Serial;
        Model = model.Model.CastModel<NamedItem>();
        Byod = model.Byod;
        Requestable = model.Requestable;
        ModelNumber = model.ModelNumber;
        Eol = model.Eol;
        AssetEolDate = model.AssetEolDate;
        StatusLabel = model.StatusLabel.CastModel<NamedItem>();
        Category = model.Category.CastModel<NamedItem>();
        Manufacturer = model.Manufacturer.CastModel<NamedItem>();
        Supplier = model.Supplier.CastModel<NamedItem>();
        Notes = model.Notes;
        OrderNumber = model.OrderNumber;
        Company = model.Company.CastModel<NamedItem>();
        Location = model.Location.CastModel<NamedItem>();
        RtdLocation = model.RtdLocation.CastModel<NamedItem>();
        Image = model.Image;
        Qr = model.Qr;
        AltBarcode = model.AltBarcode;
        AssignedTo = model.AssignedTo.CastModel<NamedItem>();
        WarrantyMonths = model.WarrantyMonths;
        WarrantyExpires = model.WarrantyExpires;
        CreatedBy = model.CreatedBy.CastModel<NamedItem>();
        CreatedAt = model.CreatedAt;
        UpdatedAt = model.UpdatedAt;
        LastAuditDate = model.LastAuditDate;
        NextAuditDate = model.NextAuditDate;
        DeletedAt = model.DeletedAt;
        PurchaseDate = model.PurchaseDate;
        Age = model.Age;
        LastCheckout = model.LastCheckout;
        LastCheckin = model.LastCheckin;
        ExpectedCheckin = model.ExpectedCheckin;
        PurchaseCost = model.PurchaseCost;
        CheckinCounter = model.CheckinCounter;
        CheckoutCounter = model.CheckoutCounter;
        RequestsCounter = model.RequestsCounter;
        UserCanCheckout = model.UserCanCheckout;
        BookValue = model.BookValue;
        CustomFields = model.CustomFields.CastModel<CustomField>();
        AvailableActions = model.AvailableActions.CastModel<Actions>();
    }

    internal HardwareModel ToCreate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
            ModelId = Model?.Id,
            StatusId = StatusLabel?.Id,
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
    public int Id { get; }

    public string? Name { get; set; }

    public string? AssetTag { get; set; }

    public string? Serial { get; set; }

    public NamedItem? Model { get; set; }

    public bool? Byod { get; set; }

    public bool? Requestable { get; set; }

    public string? ModelNumber { get; set; }

    public string? Eol { get; set; }

    public DateTime? AssetEolDate { get; set; }

    public NamedItem? StatusLabel { get; set; }

    public NamedItem? Category { get; set; }

    public NamedItem? Manufacturer { get; }

    public NamedItem? Supplier { get; set; }

    public string? Notes { get; set; }

    public string? OrderNumber { get; set; }

    public NamedItem? Company { get; set; }

    public NamedItem? Location { get; set; }

    public NamedItem? RtdLocation { get; set; }

    public string? Image { get; set; }

    public string? Qr { get; set; }

    public string? AltBarcode { get; set; }

    public NamedItem? AssignedTo { get; }

    public string? WarrantyMonths { get; set; }

    public DateTime? WarrantyExpires { get; set; }

    public NamedItem? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? LastAuditDate { get; set; }

    public DateTime? NextAuditDate { get; set; }

    public DateTime? DeletedAt { get; set; }

    public DateTime? PurchaseDate { get; }

    public string? Age { get; set; }

    public DateTime? LastCheckout { get; set; }

    public DateTime? LastCheckin { get; set; }

    public DateTime? ExpectedCheckin { get; set; }

    public string? PurchaseCost { get; set; }

    public int? CheckinCounter { get; set; }

    public int? CheckoutCounter { get; set; }

    public int? RequestsCounter { get; set; }

    public bool? UserCanCheckout { get; set; }
    public string? BookValue { get; set; }
    public Dictionary<string, CustomField>? CustomFields { get; set; }
    public Actions? AvailableActions { get; set; }

    public static implicit operator Hardware(int id) => new(id);

}
