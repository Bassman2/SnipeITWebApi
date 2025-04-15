namespace SnipeITWebApi;

public class User : BaseItem
{
    public User()
    { }

    internal User(UserModel model) : base(model)
    {
        Avatar = model.Avatar;
        FirstName = model.FirstName;
        LastName = model.LastName;
        Username = model.Username;
        Remote = model.Remote;
        Locale = model.Locale;
        EmployeeNum = model.EmployeeNum;
        Manager = model.Manager.CastModel<NamedItem>();
        Jobtitle = model.Jobtitle;
        Vip = model.Vip;
        Phone = model.Phone;
        Website = model.Website;
        Address = model.Address;
        City = model.City;
        State = model.State;
        Country = model.Country;
        Zip = model.Zip;
        Email = model.Email;
        Department = model.Department.CastModel<NamedItem>();
        Location = model.Location.CastModel<NamedItem>();
        Permissions = model.Permissions.CastModel<NamedItem>();
        Activated = model.Activated;
        AutoassignLicenses = model.AutoassignLicenses;
        LdapImport = model.LdapImport;
        TwoFactorEnrolled = model.TwoFactorEnrolled;
        TwoFactorOptin = model.TwoFactorOptin;
        AssetsCount = model.AssetsCount;
        LicensesCount = model.LicensesCount;
        AccessoriesCount = model.AccessoriesCount;
        ConsumablesCount = model.ConsumablesCount;
        ManagesUsersCount = model.AssetsCount;
        ManagesLocationsCount = model.AssetsCount;
        Company = model.Company.CastModel<NamedItem>();
        StartDate = model.StartDate;
        EndDate = model.EndDate;
        LastLogin = model.LastLogin;
        Groups = model.Groups;
    }

    //internal UserModel ToCreate()
    //{
    //    if (LdapImport != true)
    //    {
    //        ArgumentException.ThrowIfNullOrWhiteSpace(FirstName, nameof(FirstName));
    //        ArgumentException.ThrowIfNullOrWhiteSpace(Username, nameof(Username));
    //        ArgumentException.ThrowIfNullOrWhiteSpace(Password, nameof(Password));
    //    }
    //    return new()
    //    {
    //        FirstName = FirstName,
    //        LastName = LastName,
    //        Username = Username,
    //        Password = Password,
    //        PasswordConfirmation = Password,
    //        Phone = Phone,
    //        Email = Email,
    //        Notes = Notes,
    //    };
    //}

    internal UserChangeModel ToUpdate()
    {
        if (LdapImport != true)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(FirstName, nameof(FirstName));
            ArgumentException.ThrowIfNullOrWhiteSpace(Username, nameof(Username));
            ArgumentException.ThrowIfNullOrWhiteSpace(Password, nameof(Password));
        }
        return new()
        {
            FirstName = FirstName,
            LastName = LastName,
            Username = Username,
            Password = Password,
            PasswordConfirmation = Password,
            Phone = Phone,
            Email = Email,
            Notes = Notes,
        };
    }

    //internal UserModel ToPatch()
    //{
    //    if (LdapImport != true)
    //    {
    //        ArgumentException.ThrowIfNullOrWhiteSpace(FirstName, nameof(FirstName));
    //        ArgumentException.ThrowIfNullOrWhiteSpace(Username, nameof(Username));
    //        ArgumentException.ThrowIfNullOrWhiteSpace(Password, nameof(Password));
    //    }
    //    return new()
    //    {
    //        FirstName = FirstName,
    //        LastName = LastName,
    //        Username = Username,
    //        Password = Password,
    //        PasswordConfirmation = Password,
    //        Phone = Phone,
    //        Email = Email,
    //        Notes = Notes,

    //    };
    //}

    public string? Avatar { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public bool? Remote { get; set; }

    public string? Locale { get; set; }

    public string? EmployeeNum { get; set; }

    public NamedItem? Manager { get; set; }

    public string? Jobtitle { get; set; }

    public bool? Vip { get; set; }

    public string? Phone { get; set; }

    public string? Website { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? Zip { get; set; }

    public string? Email { get; set; }

    public NamedItem? Department { get; set; }

    public NamedItem? Location { get; set; }

    public NamedItem? Permissions { get; set; }

    public bool? Activated { get; set; }

    public bool? AutoassignLicenses { get; set; }

    public bool? LdapImport { get; set; }

    public bool? TwoFactorEnrolled { get; set; }

    public bool? TwoFactorOptin { get; set; }

    public int AssetsCount { get; }

    public int LicensesCount { get; }

    public int AccessoriesCount { get; }

    public int ConsumablesCount { get; }

    public int ManagesUsersCount { get; }

    public int ManagesLocationsCount { get; }

    public NamedItem? Company { get; }

    public DateTime? StartDate { get; }

    public DateTime? EndDate { get; }

    public DateTime? LastLogin { get; }

    public string? Groups { get; set; }
}
