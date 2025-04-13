namespace SnipeITWebApi;

public class Department
{
    public Department()
    { }

    internal Department(DepartmentModel model)
    {
        Id = model.Id;
        Name = model.Name;
        Phone = model.Phone;
        Fax = model.Fax;
        Image = model.Image;
        Company = model.Company;
        Manager = model.Manager;
        Location = model.Location.CastModel<NamedItem>();
        if (int.TryParse(model.UsersCount, out var usersCount))
        {
            UsersCount = usersCount;
        }
        Notes = model.Notes;
        CreatedAt = model.CreatedAt;
        UpdatedAt = model.UpdatedAt;
        AvailableActions = model.AvailableActions.CastModel<Actions>();
    }

    //internal DepartmentModel ToCreate()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        Name = Name,
    //        Phone = Phone,
    //        Fax = Fax,
    //        Notes = Notes,
    //    };
    //}

    internal DepartmentChangeModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
            Phone = Phone,
            Fax = Fax,
            Notes = Notes,
        };
    }

    //internal DepartmentModel ToPatch()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        Name = Name,
    //        Phone = Phone,
    //        Fax = Fax,
    //        Notes = Notes,
    //    };
    //}

    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? Image { get; set; }

    public string? Company { get; set; }

    public string? Manager { get; set; }

    public NamedItem? Location { get; set; }

    public int? UsersCount { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedAt { get; }

    public DateTime? UpdatedAt { get; }

    public Actions? AvailableActions { get; }
}
