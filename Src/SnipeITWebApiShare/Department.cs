namespace SnipeITWebApi;

public class Department
{
    internal Department(DepartmentModel model)
    {
        Id = model.Id;
        Name = model.Name;
        Image = model.Image;
        Company = model.Company;
        Manager = model.Manager;
        Location = model.Location.CastModel<NamedItem>();
        UsersCount = model.UsersCount;
        CreatedAt = model.CreatedAt;
        UpdatedAt = model.UpdatedAt;
        AvailableActions = model.AvailableActions.CastModel<Actions>();
    }

    internal DepartmentModel ToCreate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
            //Url = Url,
            //Image = Image,
            //SupportUrl = SupportUrl,
            //WarrantyLookupUrl = WarrantyLookupUrl,
            //SupportPhone = SupportPhone,
            //SupportEmail = SupportEmail,
            //AssetsCount = AssetsCount,
            //LicensesCount = LicensesCount,
            //ConsumablesCount = ConsumablesCount,
            //AccessoriesCount = AccessoriesCount,
            //ComponentsCount = ComponentsCount,
            //Notes = Notes,
            //CreatedBy = model.CreatedBy.CastModel<NamedItem>();
            //CreatedAt = model.CreatedAt.CastModel<DateItem>();
            //UpdatedAt = model.UpdatedAt.CastModel<DateItem>();
            //DeletedAt = model.DeletedAt.CastModel<DateItem>();
            //AvailableActions = model.AvailableActions.CastModel<Actions>();
        };
    }

    internal DepartmentModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
            //Url = Url,
            //Image = Image,
            //CreatedAt = model.CreatedAt.CastModel<DateItem>();
            //UpdatedAt = model.UpdatedAt.CastModel<DateItem>();
            //AvailableActions = model.AvailableActions.CastModel<Actions>();
        };
    }

    internal DepartmentModel ToPatch()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
            //Url = Url,
            //Image = Image,
            
            //CreatedAt = model.CreatedAt.CastModel<DateItem>();
            //UpdatedAt = model.UpdatedAt.CastModel<DateItem>();
            //AvailableActions = model.AvailableActions.CastModel<Actions>();
        };
    }

    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Image { get; set; }

    public string? Company { get; set; }

    public string? Manager { get; set; }

    public NamedItem? Location { get; set; }

    public string? UsersCount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Actions? AvailableActions { get; set; }
}
