namespace SnipeITWebApi;

public class Supplier : BaseItem
{
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

    public string? Url { get; set; }
    public string? Address { get; set; }
    public string? Address2 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? Zip { get; set; }
    public string? Fax { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Contact { get; set; }
    public int? AssetsCount { get; set; }
    public int? AccessoriesCount { get; set; }
    public int? LicensesCount { get; set; }
    public int? ConsumablesCount { get; set; }
    public int? ComponentsCount { get; set; }
}
