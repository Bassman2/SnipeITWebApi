namespace SnipeITWebApi;

public class Department : BaseItem
{
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


    public string? Phone { get; set; }

    public string? Fax { get; set; }


    public string? Company { get; set; }

    public string? Manager { get; set; }

    public NamedItem? Location { get; set; }

    public int? UsersCount { get; set; }

    
}
