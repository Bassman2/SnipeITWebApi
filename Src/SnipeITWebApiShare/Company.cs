namespace SnipeITWebApi;

public class Company
{
    public Company()
    { }

    internal Company(CompanyModel model)
    {
        Id = model.Id;
        Name = model.Name;
        Phone = model.Phone;
        Fax = model.Fax;
        Email = model.Email;
        Image = model.Image;
        AssetsCount = model.AssetsCount;
        AccessoriesCount = model.AccessoriesCount;
        ConsumablesCount = model.ConsumablesCount;
        ComponentsCount = model.ComponentsCount;
        UsersCount = model.UsersCount;
        CreatedBy = model.CreatedBy.CastModel<NamedItem>();
        Notes = model.Notes;
        CreatedAt = model.CreatedAt;
        UpdatedAt = model.UpdatedAt;
        AvailableActions = model.AvailableActions.CastModel<Actions>();
    }

    internal CompanyModel ToCreate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
            Phone = Phone,
            Fax = Fax,
            Email = Email,
            Image = ImageConverter.ConvertImageToBase64(Image),
            Notes = Notes,
        };
    }

    internal CompanyModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
            Phone = Phone,
            Fax = Fax,
            Email = Email,
            Image = Image,
            Notes = Notes,
        };
    }

    internal CompanyModel ToPatch()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
            Phone = Phone,
            Fax = Fax,
            Email = Email,
            Image = Image,
            Notes = Notes,
        };
    }

    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public string? Image { get; set; }

    public int AssetsCount { get; set; }

    public int AccessoriesCount { get; set; }
    
    public int ConsumablesCount { get; set; }
    
    public int ComponentsCount { get; set; }
    
    public int UsersCount { get; set; }
    
    public NamedItem? CreatedBy { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedAt { get; }

    public DateTime? UpdatedAt { get; }

    public Actions? AvailableActions { get; }
}
