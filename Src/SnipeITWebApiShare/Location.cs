namespace SnipeITWebApi;

public class Location
{
    internal Location(LocationModel model)
    {
        Id = model.Id;
        Name = model.Name;
        Image = model.Image;
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
        Notes = model.Notes;
        CreatedAt = model.CreatedAt;
        UpdatedAt = model.UpdatedAt;
        Parent = model.Parent.CastModel<NamedItem>();
        Manager = model.Manager.CastModel<NamedItem>();
        Children = model.Children.CastModel<NamedItem>(); 
        AvailableActions = model.AvailableActions.CastModel<Actions>();
    }

    internal LocationModel ToCreate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
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
            Parent = Parent?.ToCreate(),
            Manager = Manager?.ToCreate(),
            Children = Children?.Select(x => x.ToCreate()).ToList(),
        };
    }

    internal LocationModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
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
            Parent = Parent?.ToUpdate(),
            Manager = Manager?.ToUpdate(),
            Children = Children?.Select(x => x.ToUpdate()).ToList(),
        };
    }

    internal LocationModel ToPatch()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
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
            Parent = Parent?.ToPatch(),
            Manager = Manager?.ToPatch(),
            Children = Children?.Select(x => x.ToPatch()).ToList(),
        };
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Image { get; set; }
    public string? Address { get; set; }
    public string? Address2 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? Zip { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public int? AccessoriesCount { get; }
    public int? AssignedAccessoriesCount { get; }
    public int? AssignedAssetsCount { get; }
    public int? AssetsCount { get; }
    public int? RtdAssetsCount { get; }
    public int? UsersCount { get; }
    public string? Currency { get; set; }
    public string? LdapOu { get; set; }
    public string? Notes { get; set; }
    public DateTime? CreatedAt { get; }
    public DateTime? UpdatedAt { get; }
    public NamedItem? Parent { get; set; }
    public NamedItem? Manager { get; set; }
    public List<NamedItem>? Children { get; set; }
    public Actions? AvailableActions { get; }
}
