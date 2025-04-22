namespace SnipeITWebApi;

/// <summary>
/// Represents a department in the Snipe-IT system, including its contact information, company, manager, and location.
/// </summary>
public class Department : BaseItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Department"/> class.
    /// </summary>
    public Department()
    { }

    internal Department(DepartmentModel model) : base(model)
    {
        Phone = model.Phone;
        Fax = model.Fax;
        Company = model.Company;
        Manager = model.Manager;
        Location = model.Location.CastModel<NamedItem>();
        if (int.TryParse(model.UsersCount, out var usersCount))
        {
            UsersCount = usersCount;
        }
    }

    internal DepartmentChangeModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return FillBase<DepartmentChangeModel>(new()
        {
            Name = Name,
            Phone = Phone,
            Fax = Fax,
            Notes = Notes,
        });
    }

    /// <summary>
    /// Gets or sets the phone number of the department.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Gets or sets the fax number of the department.
    /// </summary>
    public string? Fax { get; set; }

    /// <summary>
    /// Gets or sets the company associated with the department.
    /// </summary>
    public string? Company { get; set; }

    /// <summary>
    /// Gets or sets the manager of the department.
    /// </summary>
    public string? Manager { get; set; }

    /// <summary>
    /// Gets or sets the location of the department.
    /// </summary>
    public NamedItem? Location { get; set; }

    /// <summary>
    /// Gets or sets the number of users in the department.
    /// </summary>
    public int? UsersCount { get; set; }
}
