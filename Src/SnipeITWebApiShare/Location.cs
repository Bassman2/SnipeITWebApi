namespace SnipeITWebApi;

/// <summary>
/// Represents a location in the Snipe-IT system, including address, contact information, and related counts.
/// </summary>
public class Location : BaseItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Location"/> class.
    /// </summary>
    public Location()
    { }   

    internal Location(LocationModel model) : base(model)
    {
        Address = model.Address;
        Address2 = model.Address2;
        City = model.City;
        State = model.State;
        Country = model.Country;
        Zip = model.Zip;
        Phone = model.Phone;
        Fax = model.Fax;
        AccessoriesCount = model.AccessoriesCount;
        AssignedAccessoriesCount = model.AssignedAccessoriesCount;
        AssignedAssetsCount = model.AssignedAssetsCount;
        AssetsCount = model.AssetsCount;
        RtdAssetsCount = model.RtdAssetsCount;
        UsersCount = model.UsersCount;
        Currency = model.Currency;
        LdapOu = model.LdapOu;
        Parent = model.Parent.CastModel<NamedItem>();
        Manager = model.Manager.CastModel<NamedItem>();
        Company = model.Company.CastModel<NamedItem>();
        Children = model.Children.CastModel<NamedItem>(); 
    }

    //internal LocationModel ToCreate()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        Name = Name,
    //        Image = Image,
    //        Address = Address,
    //        Address2 = Address2,
    //        City = City,
    //        State = State,
    //        Country = Country,
    //        Zip = Zip,
    //        Phone = Phone,
    //        Fax = Fax,
    //        Currency = Currency,
    //        LdapOu = LdapOu,
    //        Notes = Notes,
    //        Parent = Parent?.ToCreate(),
    //        Manager = Manager?.ToCreate(),
    //        Children = Children?.Select(x => x.ToCreate()).ToList(),
    //    };
    //}

    internal LocationChangeModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return FillBase<LocationChangeModel>(new()
        {
            Name = Name,
            Image = Image,
            Address = Address,
            Address2 = Address2,
            City = City,
            State = State,
            Country = Country,
            Zip = Zip,
            Phone = Phone,
            Fax = Fax,
            Currency = Currency,
            LdapOu = LdapOu,
            Notes = Notes,
            ParentId = Parent?.Id,
            ManagerId = Manager?.Id,
            //Children = Children?.Select(x => x.ToUpdate()).ToList(),
        });
    }

    //internal LocationModel ToPatch()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        Name = Name,
    //        Image = Image,
    //        Address = Address,
    //        Address2 = Address2,
    //        City = City,
    //        State = State,
    //        Country = Country,
    //        Zip = Zip,
    //        Phone = Phone,
    //        Fax = Fax,
    //        Currency = Currency,
    //        LdapOu = LdapOu,
    //        Notes = Notes,
    //        Parent = Parent?.ToPatch(),
    //        Manager = Manager?.ToPatch(),
    //        Children = Children?.Select(x => x.ToPatch()).ToList(),
    //    };
    //}


    /// <summary>
    /// Gets or sets the primary address of the location.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Gets or sets the secondary address of the location.
    /// </summary>
    public string? Address2 { get; set; }

    /// <summary>
    /// Gets or sets the city of the location.
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Gets or sets the state of the location.
    /// </summary>
    public string? State { get; set; }

    /// <summary>
    /// Gets or sets the country of the location.
    /// </summary>
    public string? Country { get; set; }

    /// <summary>
    /// Gets or sets the ZIP code of the location.
    /// </summary>
    public string? Zip { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the location.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Gets or sets the fax number of the location.
    /// </summary>
    public string? Fax { get; set; }

    /// <summary>
    /// Gets the count of accessories at the location.
    /// </summary>
    public int? AccessoriesCount { get; internal set; }

    /// <summary>
    /// Gets the count of assigned accessories at the location.
    /// </summary>
    public int? AssignedAccessoriesCount { get; internal set; }

    /// <summary>
    /// Gets the count of assigned assets at the location.
    /// </summary>
    public int? AssignedAssetsCount { get; internal set; }

    /// <summary>
    /// Gets the total count of assets at the location.
    /// </summary>
    public int? AssetsCount { get; internal set; }

    /// <summary>
    /// Gets the count of returned-to-depot (RTD) assets at the location.
    /// </summary>
    public int? RtdAssetsCount { get; internal set; }

    /// <summary>
    /// Gets the count of users associated with the location.
    /// </summary>
    public int? UsersCount { get; internal set; }

    /// <summary>
    /// Gets or sets the currency used at the location.
    /// </summary>
    public string? Currency { get; set; }

    /// <summary>
    /// Gets or sets the LDAP organizational unit associated with the location.
    /// </summary>
    public string? LdapOu { get; set; }

    /// <summary>
    /// Gets or sets the parent location.
    /// </summary>
    public NamedItem? Parent { get; set; }

    /// <summary>
    /// Gets or sets the manager of the location.
    /// </summary>
    public NamedItem? Manager { get; set; }

    /// <summary>
    /// Gets or sets the company associated with the location.
    /// </summary>
    public NamedItem? Company { get; set; }

    /// <summary>
    /// Gets or sets the child locations of this location.
    /// </summary>
    public List<NamedItem>? Children { get; set; }
}
