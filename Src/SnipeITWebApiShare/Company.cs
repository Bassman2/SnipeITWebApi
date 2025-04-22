namespace SnipeITWebApi;

/// <summary>
/// Represents a company in the Snipe-IT system, including its contact information and associated item counts.
/// </summary>
public class Company : BaseItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Company"/> class.
    /// </summary>
    public Company()
    { }

    internal Company(CompanyModel model) : base(model)
    {
        Phone = model.Phone;
        Fax = model.Fax;
        Email = model.Email;
        AssetsCount = model.AssetsCount;
        LicenseCount = model.LicenseCount;
        AccessoriesCount = model.AccessoriesCount;
        ConsumablesCount = model.ConsumablesCount;
        ComponentsCount = model.ComponentsCount;
        UsersCount = model.UsersCount;
    }

    internal CompanyChangeModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return FillBase<CompanyChangeModel>(new()
        {
            Name = Name,
            Phone = Phone,
            Fax = Fax,
            Email = Email,
            Image = Image,
            Notes = Notes,
        });
    }

    /// <summary>
    /// Gets or sets the phone number of the company.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Gets or sets the fax number of the company.
    /// </summary>
    public string? Fax { get; set; }

    /// <summary>
    /// Gets or sets the email address of the company.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Gets the total number of assets associated with the company.
    /// </summary>
    public int AssetsCount { get; internal set; }

    /// <summary>
    /// Gets the total number of licenses associated with the company.
    /// </summary>
    public int LicenseCount { get; internal set; }

    /// <summary>
    /// Gets the total number of accessories associated with the company.
    /// </summary>
    public int AccessoriesCount { get; internal set; }

    /// <summary>
    /// Gets the total number of consumables associated with the company.
    /// </summary>
    public int ConsumablesCount { get; internal set; }

    /// <summary>
    /// Gets the total number of components associated with the company.
    /// </summary>
    public int ComponentsCount { get; internal set; }

    /// <summary>
    /// Gets the total number of users associated with the company.
    /// </summary>
    public int UsersCount { get; internal set; }
}
