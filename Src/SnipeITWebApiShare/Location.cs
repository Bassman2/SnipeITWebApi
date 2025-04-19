namespace SnipeITWebApi;

public class Location : BaseItem
{
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


    public string? Address { get; set; }
    public string? Address2 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? Zip { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public int? AccessoriesCount { get; internal set; }
    public int? AssignedAccessoriesCount { get; internal set; }
    public int? AssignedAssetsCount { get; internal set; }
    public int? AssetsCount { get; internal set; }
    public int? RtdAssetsCount { get; internal set; }
    public int? UsersCount { get; internal set; }
    public string? Currency { get; set; }
    public string? LdapOu { get; set; }
    public NamedItem? Parent { get; set; }
    public NamedItem? Manager { get; set; }
    public NamedItem? Company { get; set; }
    public List<NamedItem>? Children { get; set; }
}
