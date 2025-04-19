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
        LicenseCount = model.LicenseCount;
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

    //internal CompanyChangeModel ToPatch()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return FillBase<CompanyChangeModel>(new()
    //    {
    //        Name = Name,
    //        Phone = Phone,
    //        Fax = Fax,
    //        Email = Email,
    //        Image = Image,
    //        Notes = Notes,
    //    });
    //}



    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public int AssetsCount { get; internal set; }

    public int LicenseCount { get; internal set; }

    public int AccessoriesCount { get; internal set; }
    
    public int ConsumablesCount { get; internal set; }
    
    public int ComponentsCount { get; internal set; }
    
    public int UsersCount { get; internal set; }
}
