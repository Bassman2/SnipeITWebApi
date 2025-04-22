namespace SnipeITWebApi;

/// <summary>
/// Represents a supplier in the Snipe-IT system, including details such as address, contact information, and associated item counts.
/// </summary>
public class Supplier : BaseItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Supplier"/> class.
    /// </summary>
    public Supplier() 
    { }

    internal Supplier(SupplierModel model) : base(model)
    {
        Url = model.Url;
        Address = model.Address;
        Address2 = model.Address2;
        City = model.City;
        State = model.State;
        Country = model.Country;
        Zip = model.Zip;
        Fax = model.Fax;
        Phone = model.Phone;
        Email = model.Email;
        Contact = model.Contact;
        AssetsCount = model.AssetsCount;
        AccessoriesCount = model.AccessoriesCount;
        LicensesCount = model.LicensesCount;
        ConsumablesCount = model.ConsumablesCount;
        ComponentsCount = model.ComponentsCount;
    }

    //internal SupplierModel ToCreate()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        Name = Name,
    //        Url = Url,
    //        Address = Address,
    //        Address2 = Address2,
    //        City = City,
    //        State = State,
    //        Country = Country,
    //        Zip = Zip,
    //        Fax = Fax,
    //        Phone = Phone,
    //        Email = Email,
    //        Contact = Contact,
    //        Notes = Notes
    //    };
    //}

    internal SupplierChangeModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return FillBase<SupplierChangeModel>(new()
        {
            Name = Name,
            Url = Url,
            Address = Address,
            Address2 = Address2,
            City = City,
            State = State,
            Country = Country,
            Zip = Zip,
            Fax = Fax,
            Phone = Phone,
            Email = Email,
            Contact = Contact,
            Notes = Notes
        });
    }

    //internal SupplierModel ToPatch()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        Name = Name,
    //        Url = Url,
    //        Address = Address,
    //        Address2 = Address2,
    //        City = City,
    //        State = State,
    //        Country = Country,
    //        Zip = Zip,
    //        Fax = Fax,
    //        Phone = Phone,
    //        Email = Email,
    //        Contact = Contact,
    //        Notes = Notes
    //    };
    //}

    /// <summary>
    /// Gets or sets the URL of the supplier.
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    /// Gets or sets the primary address of the supplier.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Gets or sets the secondary address of the supplier.
    /// </summary>
    public string? Address2 { get; set; }

    /// <summary>
    /// Gets or sets the city of the supplier.
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Gets or sets the state of the supplier.
    /// </summary>
    public string? State { get; set; }

    /// <summary>
    /// Gets or sets the country of the supplier.
    /// </summary>
    public string? Country { get; set; }

    /// <summary>
    /// Gets or sets the ZIP code of the supplier.
    /// </summary>
    public string? Zip { get; set; }

    /// <summary>
    /// Gets or sets the fax number of the supplier.
    /// </summary>
    public string? Fax { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the supplier.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Gets or sets the email address of the supplier.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the contact person for the supplier.
    /// </summary>
    public string? Contact { get; set; }

    /// <summary>
    /// Gets or sets the count of assets associated with the supplier.
    /// </summary>
    public int? AssetsCount { get; set; }

    /// <summary>
    /// Gets or sets the count of accessories associated with the supplier.
    /// </summary>
    public int? AccessoriesCount { get; set; }

    /// <summary>
    /// Gets or sets the count of licenses associated with the supplier.
    /// </summary>
    public int? LicensesCount { get; set; }

    /// <summary>
    /// Gets or sets the count of consumables associated with the supplier.
    /// </summary>
    public int? ConsumablesCount { get; set; }

    /// <summary>
    /// Gets or sets the count of components associated with the supplier.
    /// </summary>
    public int? ComponentsCount { get; set; }
}
