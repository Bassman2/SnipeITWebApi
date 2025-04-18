using System.Diagnostics;

namespace SnipeITWebApi;

[DebuggerDisplay("{Id} : {Name} : {AssetTag}")]
public class Hardware : BaseItem
{
    public Hardware(int id)
    {
        Id = id;
    }

    public Hardware()
    { }

    internal Hardware(HardwareModel model) : base(model)
    {
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
        OrderNumber = model.OrderNumber;
        Company = model.Company.CastModel<NamedItem>();
        Location = model.Location.CastModel<NamedItem>();
        RtdLocation = model.RtdLocation.CastModel<NamedItem>();
        Qr = model.Qr;
        AltBarcode = model.AltBarcode;
        AssignedTo = model.AssignedTo.CastModel<NamedItem>();
        WarrantyMonths = model.WarrantyMonths;
        WarrantyExpires = model.WarrantyExpires;
        LastAuditDate = model.LastAuditDate;
        NextAuditDate = model.NextAuditDate;
        PurchaseDate = model.PurchaseDate;
        Age = model.Age;
        LastCheckout = model.LastCheckout;
        LastCheckin = model.LastCheckin;
        ExpectedCheckin = model.ExpectedCheckin;
        PurchaseCost = model.PurchaseCost;
        CheckinCounter = model.CheckinCounter;
        CheckoutCounter = model.CheckoutCounter;
        RequestsCounter = model.RequestsCounter;
        BookValue = model.BookValue;
        CustomFields = model.CustomFields.CastModel<CustomField>();
    }

    //internal HardwareModel ToCreate()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        Name = Name,
    //        ModelId = Model?.Id,
    //        StatusId = StatusLabel?.Id,
    //    };
    //}

    internal HardwareChangeModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            AssetTag = AssetTag,
            StatusId = StatusLabel?.Id,
            ModelId = Model?.Id,
            Name = Name,
            Image = Image,
            Serial = Serial,
            PurchaseDate = PurchaseDate,
            PurchaseCost = float.TryParse(PurchaseCost, out float res) ? res : null,
            OrderNumber = OrderNumber,
            Notes = Notes,
            //Archived = ,
            //WarrantyMonths = WarrantyMonths,
            //Depreciate = Depr
            SupplierId = Supplier?.Id,
            Requestable = Requestable,
            RtdLocationId = RtdLocation?.Id,
            LastAuditDate = LastAuditDate,
            LocationId = Location?.Id,
            Byod = Byod,


            // free
            
        };
    }

    //internal HardwareModel ToPatch()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        Name = Name,
    //    };
    //}

    //internal HardwareModel ToCheckout()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        Name = Name,
    //    };
    //}

    //internal HardwareModel ToCheckin()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        Name = Name,
    //    };
    //}
  
    public string? AssetTag { get; set; }

    public string? Serial { get; set; }

    public NamedItem? Model { get; set; }

    public bool? Byod { get; set; }

    public bool? Requestable { get; internal set; }

    /// <summary>
    /// Model number of the hardware. 
    /// </summary>
    /// <remarks>Readonly! This can only be set in the selected model.</remarks>
    public string? ModelNumber { get; internal set; } 

    public string? Eol { get; internal set; }

    public DateTime? AssetEolDate { get; internal set; }

    public NamedItem? StatusLabel { get; internal set; }

    /// <summary>
    /// Category of the hardware.
    /// </summary>
    /// <remarks>Readonly! This can only be set in the selected model.</remarks>
    public NamedItem? Category { get; internal set; }

    public NamedItem? Manufacturer { get; internal set; }

    public NamedItem? Supplier { get; set; }


    public string? OrderNumber { get; set; }

    public NamedItem? Company { get; internal set; }

    public NamedItem? Location { get; set; }

    public NamedItem? RtdLocation { get; internal set; }

    public string? Qr { get; internal set; }

    public string? AltBarcode { get; internal set; }

    public NamedItem? AssignedTo { get; internal set; }

    public string? WarrantyMonths { get; internal set; }

    public DateTime? WarrantyExpires { get; internal set; }

    public DateTime? LastAuditDate { get; set; }

    public DateTime? NextAuditDate { get; internal set; }

    
    public DateTime? PurchaseDate { get; set; }

    public string? Age { get; internal set; }

    public DateTime? LastCheckout { get; internal set; }

    public DateTime? LastCheckin { get; internal set; }

    public DateTime? ExpectedCheckin { get; internal set; }

    public string? PurchaseCost { get; set; }

    public int? CheckinCounter { get; internal set; }

    public int? CheckoutCounter { get; internal set; }

    public int? RequestsCounter { get; internal set; }

    public string? BookValue { get; internal set; }
    public Dictionary<string, CustomField>? CustomFields { get; internal set; }

    public static implicit operator Hardware(int id) => new(id);

    public static implicit operator Hardware(NamedItem item) => new(item.Id);

}
