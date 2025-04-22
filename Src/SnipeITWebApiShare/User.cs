namespace SnipeITWebApi;

/// <summary>
/// Represents a user in the Snipe-IT system, including personal details, permissions, and associated counts.
/// </summary>
public class User : BaseItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// </summary>
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
        Permissions = model.Permissions.CastModel<Permissions>(); 
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
        Groups = model.Groups.CastModel<NamedItem>(); 
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
        return FillBase<UserChangeModel>(new()
        {
            FirstName = FirstName,
            LastName = LastName,
            Username = Username,
            Password = Password,
            PasswordConfirmation = Password,
            Email = Email,
            Activated = Activated,
            Phone = Phone,
            Jobtitle = Jobtitle,
            ManagerId = Manager?.Id,
            EmployeeNum = EmployeeNum,
            CompanyId = Company?.Id,
            TwoFactorEnrolled = TwoFactorEnrolled,
            TwoFactorOptin = TwoFactorOptin,
            DepartmentId = Department?.Id,
            LocationId = Location?.Id,
            Remote = Remote,
            Groups = Groups?.Select(g => g.ToModel()).ToList(),
            AutoassignLicenses = AutoassignLicenses,
            Vip = Vip,
            StartDate = StartDate,
            EndDate = EndDate
        });
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

    /// <summary>
    /// Gets or sets the avatar URL of the user.
    /// </summary>
    public string? Avatar { get; set; }

    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Gets or sets the username of the user.
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// Gets or sets the password of the user.
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user is remote.
    /// </summary>
    public bool? Remote { get; set; }

    /// <summary>
    /// Gets or sets the locale of the user.
    /// </summary>
    public string? Locale { get; set; }

    /// <summary>
    /// Gets or sets the employee number of the user.
    /// </summary>
    public string? EmployeeNum { get; set; }

    /// <summary>
    /// Gets or sets the manager of the user.
    /// </summary>
    public NamedItem? Manager { get; set; }

    /// <summary>
    /// Gets or sets the job title of the user.
    /// </summary>
    public string? Jobtitle { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user is marked as VIP.
    /// </summary>
    public bool? Vip { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the user.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Gets or sets the website of the user.
    /// </summary>
    public string? Website { get; set; }

    /// <summary>
    /// Gets or sets the address of the user.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Gets or sets the city of the user.
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Gets or sets the state of the user.
    /// </summary>
    public string? State { get; set; }

    /// <summary>
    /// Gets or sets the country of the user.
    /// </summary>
    public string? Country { get; set; }

    /// <summary>
    /// Gets or sets the ZIP code of the user.
    /// </summary>
    public string? Zip { get; set; }

    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the department of the user.
    /// </summary>
    public NamedItem? Department { get; set; }

    /// <summary>
    /// Gets or sets the location of the user.
    /// </summary>
    public NamedItem? Location { get; set; }

    /// <summary>
    /// Gets or sets the permissions of the user.
    /// </summary>
    public Permissions? Permissions { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user is activated.
    /// </summary>
    public bool? Activated { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether licenses are auto-assigned to the user.
    /// </summary>
    public bool? AutoassignLicenses { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user was imported via LDAP.
    /// </summary>
    public bool? LdapImport { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user is enrolled in two-factor authentication.
    /// </summary>
    public bool? TwoFactorEnrolled { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user has opted into two-factor authentication.
    /// </summary>
    public bool? TwoFactorOptin { get; set; }

    /// <summary>
    /// Gets the count of assets associated with the user.
    /// </summary>
    public int AssetsCount { get; internal set; }

    /// <summary>
    /// Gets the count of licenses associated with the user.
    /// </summary>
    public int LicensesCount { get; internal set; }

    /// <summary>
    /// Gets the count of accessories associated with the user.
    /// </summary>
    public int AccessoriesCount { get; internal set; }

    /// <summary>
    /// Gets the count of consumables associated with the user.
    /// </summary>
    public int ConsumablesCount { get; internal set; }

    /// <summary>
    /// Gets the count of users managed by the user.
    /// </summary>
    public int ManagesUsersCount { get; internal set; }

    /// <summary>
    /// Gets the count of locations managed by the user.
    /// </summary>
    public int ManagesLocationsCount { get; internal set; }

    /// <summary>
    /// Gets or sets the company associated with the user.
    /// </summary>
    public NamedItem? Company { get; set; }

    /// <summary>
    /// Gets or sets the start date of the user's employment.
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// Gets or sets the end date of the user's employment.
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Gets the last login date and time of the user.
    /// </summary>
    public DateTime? LastLogin { get; internal set; }

    /// <summary>
    /// Gets or sets the groups associated with the user.
    /// </summary>
    public List<NamedItem>? Groups { get; set; }
}
