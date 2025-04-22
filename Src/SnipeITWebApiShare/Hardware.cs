namespace SnipeITWebApi;

/// <summary>
/// Represents a hardware item in the Snipe-IT system, including its details such as asset tag, serial number, model, and other metadata.
/// </summary>
[DebuggerDisplay("{Id} : {Name} : {AssetTag}")]
public class Hardware : BaseItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Hardware"/> class with a specified ID.
    /// </summary>
    /// <param name="id">The unique identifier of the hardware.</param>
    public Hardware(int id)
    {
        Id = id;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Hardware"/> class.
    /// </summary>
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
        return FillBase<HardwareChangeModel>(new()
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
            
        });
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

    /// <summary>
    /// Implicitly converts a tuple to a <see cref="Hardware"/> instance.
    /// </summary>
    /// <param name="item">A tuple containing the hardware ID, name, and asset tag.</param>
    /// <returns>A <see cref="Hardware"/> instance populated with the tuple's data.</returns>
    public static implicit operator Hardware((int, string?, string) item) => new() { Id = item.Item1, Name = item.Item2, AssetTag = item.Item3 };

    /// <summary>
    /// Returns a string representation of the hardware.
    /// </summary>
    /// <returns>A string containing the hardware's ID, name, and asset tag.</returns>
    public override string ToString() => $"{Id} : {Name} : {AssetTag}";

    /// <summary>
    /// Gets the hash code for the hardware.
    /// </summary>
    /// <returns>The hash code for the hardware.</returns>
    public override int GetHashCode() => base.GetHashCode();

    /// <summary>
    /// Determines whether the specified object is equal to the current hardware.
    /// </summary>
    /// <param name="obj">The object to compare with the current hardware.</param>
    /// <returns><c>true</c> if the specified object is equal to the current hardware; otherwise, <c>false</c>.</returns>
    override public bool Equals(object? obj)
    {
        if (obj is Hardware item)
        {
            bool x = item.Name == null ? true : Name == item.Name;
            return Id == item.Id && (item.Name == null ? true : Name == item.Name) && AssetTag == item.AssetTag;
        }
        if (obj is NamedItem item2)
        {
            return Id == item2.Id && Name == item2.Name;
        }
        return false;
    }




    /// <summary>
    /// Gets or sets the asset tag of the hardware.
    /// </summary>
    public string? AssetTag { get; set; }

    /// <summary>
    /// Gets or sets the serial number of the hardware.
    /// </summary>
    public string? Serial { get; set; }

    /// <summary>
    /// Gets or sets the model of the hardware.
    /// </summary>
    public NamedItem? Model { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the hardware is a Bring Your Own Device (BYOD).
    /// </summary>
    public bool? Byod { get; set; }

    /// <summary>
    /// Gets a value indicating whether the hardware is requestable.
    /// </summary>
    public bool? Requestable { get; internal set; }

    /// <summary>
    /// Gets the model number of the hardware. 
    /// </summary>
    /// <remarks>Readonly! This can only be set in the selected model.</remarks>
    public string? ModelNumber { get; internal set; }

    /// <summary>
    /// Gets the end-of-life (EOL) status of the hardware.
    /// </summary>
    public string? Eol { get; internal set; }

    /// <summary>
    /// Gets the end-of-life (EOL) date of the hardware.
    /// </summary>
    public DateTime? AssetEolDate { get; internal set; }

    /// <summary>
    /// Gets the status label of the hardware.
    /// </summary>
    public NamedItem? StatusLabel { get; internal set; }

    /// <summary>
    /// Gets the category of the hardware. This is readonly and can only be set in the selected model.
    /// </summary>
    /// <remarks>Readonly! This can only be set in the selected model.</remarks>
    public NamedItem? Category { get; internal set; }

    /// <summary>
    /// Gets the manufacturer of the hardware.
    /// </summary>
    public NamedItem? Manufacturer { get; internal set; }

    /// <summary>
    /// Gets or sets the supplier of the hardware.
    /// </summary>
    public NamedItem? Supplier { get; set; }

    /// <summary>
    /// Gets or sets the order number associated with the hardware.
    /// </summary>
    public string? OrderNumber { get; set; }

    /// <summary>
    /// Gets the company associated with the hardware.
    /// </summary>
    public NamedItem? Company { get; internal set; }

    /// <summary>
    /// Gets or sets the location of the hardware.
    /// </summary>
    public NamedItem? Location { get; set; }

    /// <summary>
    /// Gets the ready-to-deploy (RTD) location of the hardware.
    /// </summary>
    public NamedItem? RtdLocation { get; internal set; }

    /// <summary>
    /// Gets the QR code of the hardware.
    /// </summary>
    public string? Qr { get; internal set; }

    /// <summary>
    /// Gets the alternate barcode of the hardware.
    /// </summary>
    public string? AltBarcode { get; internal set; }

    /// <summary>
    /// Gets the user or entity to whom the hardware is assigned.
    /// </summary>
    public NamedItem? AssignedTo { get; internal set; }

    /// <summary>
    /// Gets the warranty period of the hardware in months.
    /// </summary>
    public string? WarrantyMonths { get; internal set; }

    /// <summary>
    /// Gets the warranty expiration date of the hardware.
    /// </summary>
    public DateTime? WarrantyExpires { get; internal set; }

    /// <summary>
    /// Gets or sets the last audit date of the hardware.
    /// </summary>
    public DateTime? LastAuditDate { get; set; }

    /// <summary>
    /// Gets the next audit date of the hardware.
    /// </summary>
    public DateTime? NextAuditDate { get; internal set; }

    /// <summary>
    /// Gets or sets the purchase date of the hardware.
    /// </summary>
    public DateTime? PurchaseDate { get; set; }

    /// <summary>
    /// Gets the age of the hardware.
    /// </summary>
    public string? Age { get; internal set; }

    /// <summary>
    /// Gets the last checkout date of the hardware.
    /// </summary>
    public DateTime? LastCheckout { get; internal set; }

    /// <summary>
    /// Gets the last check-in date of the hardware.
    /// </summary>
    public DateTime? LastCheckin { get; internal set; }

    /// <summary>
    /// Gets the expected check-in date of the hardware.
    /// </summary>
    public DateTime? ExpectedCheckin { get; internal set; }

    /// <summary>
    /// Gets or sets the purchase cost of the hardware.
    /// </summary>
    public string? PurchaseCost { get; set; }

    /// <summary>
    /// Gets the number of times the hardware has been checked in.
    /// </summary>
    public int? CheckinCounter { get; internal set; }

    /// <summary>
    /// Gets the number of times the hardware has been checked out.
    /// </summary>
    public int? CheckoutCounter { get; internal set; }

    /// <summary>
    /// Gets the number of requests made for the hardware.
    /// </summary>
    public int? RequestsCounter { get; internal set; }

    /// <summary>
    /// Gets the book value of the hardware.
    /// </summary>
    public string? BookValue { get; internal set; }

    /// <summary>
    /// Gets the custom fields associated with the hardware.
    /// </summary>
    public Dictionary<string, CustomField>? CustomFields { get; internal set; }
}
