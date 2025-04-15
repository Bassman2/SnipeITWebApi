namespace SnipeITWebApi;

public class Company : BaseItem
{
    public Company()
    { }

    internal Company(CompanyModel model) : base(model)
    {
        Phone = model.Phone;
        Fax = model.Fax;
        Email = model.Email;
        AssetsCount = model.AssetsCount;
        AccessoriesCount = model.AccessoriesCount;
        ConsumablesCount = model.ConsumablesCount;
        ComponentsCount = model.ComponentsCount;
        UsersCount = model.UsersCount;
    }

    //internal CompanyChangeModel ToCreate()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        Name = Name,
    //        Phone = Phone,
    //        Fax = Fax,
    //        Email = Email,
    //        Image = ImageConverter.ConvertImageToBase64(Image),
    //        Notes = Notes,
    //    };
    //}

    internal CompanyChangeModel ToUpdate()
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

    //internal CompanyChangeModel ToPatch()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        Name = Name,
    //        Phone = Phone,
    //        Fax = Fax,
    //        Email = Email,
    //        Image = Image,
    //        Notes = Notes,
    //    };
    //}

    

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public int AssetsCount { get; set; }

    public int AccessoriesCount { get; set; }
    
    public int ConsumablesCount { get; set; }
    
    public int ComponentsCount { get; set; }
    
    public int UsersCount { get; set; }
}
