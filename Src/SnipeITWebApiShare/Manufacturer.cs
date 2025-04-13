namespace SnipeITWebApi;

public class Manufacturer
{
    public Manufacturer()
    { }

    internal Manufacturer(ManufacturerModel model)
    {
        Id = model.Id;
        Name = model.Name;
        Url = model.Url;
        Image = model.Image;
        SupportUrl = model.SupportUrl;
        WarrantyLookupUrl = model.WarrantyLookupUrl;
        SupportPhone = model.SupportPhone;
        SupportEmail = model.SupportEmail;
        AssetsCount = model.AssetsCount;
        LicensesCount = model.LicensesCount;
        ConsumablesCount = model.ConsumablesCount;
        AccessoriesCount = model.AccessoriesCount;
        ComponentsCount = model.ComponentsCount;
        Notes = model.Notes;
        CreatedBy = model.CreatedBy.CastModel<NamedItem>();
        CreatedAt = model.CreatedAt;
        UpdatedAt = model.UpdatedAt;
        DeletedAt = model.DeletedAt;
        AvailableActions = model.AvailableActions.CastModel<Actions>();
    }

    //internal ManufacturerModel ToCreate()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        //Id = Id,
    //        Name = Name,
    //        Url = Url,
    //        Image = Image,
    //        SupportUrl = SupportUrl,
    //        WarrantyLookupUrl = WarrantyLookupUrl,
    //        SupportPhone = SupportPhone,
    //        SupportEmail = SupportEmail,
    //        AssetsCount = AssetsCount,
    //        LicensesCount = LicensesCount,
    //        ConsumablesCount = ConsumablesCount,
    //        AccessoriesCount = AccessoriesCount,
    //        ComponentsCount = ComponentsCount,
    //        Notes = Notes,
    //        //CreatedBy = model.CreatedBy.CastModel<NamedItem>();
    //        //CreatedAt = model.CreatedAt.CastModel<DateItem>();
    //        //UpdatedAt = model.UpdatedAt.CastModel<DateItem>();
    //        //DeletedAt = model.DeletedAt.CastModel<DateItem>();
    //        //AvailableActions = model.AvailableActions.CastModel<Actions>();
    //    };
    //}

    internal ManufacturerChangeModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            //Id = Id,
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

    //internal ManufacturerModel ToPatch()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        //Id = Id,
    //        Name = Name,
    //        Url = Url,
    //        Image = Image,
    //        SupportUrl = SupportUrl,
    //        WarrantyLookupUrl = WarrantyLookupUrl,
    //        SupportPhone = SupportPhone,
    //        SupportEmail = SupportEmail,
    //        AssetsCount = AssetsCount,
    //        LicensesCount = LicensesCount,
    //        ConsumablesCount = ConsumablesCount,
    //        AccessoriesCount = AccessoriesCount,
    //        ComponentsCount = ComponentsCount,
    //        Notes = Notes,
    //        //CreatedBy = model.CreatedBy.CastModel<NamedItem>();
    //        //CreatedAt = model.CreatedAt.CastModel<DateItem>();
    //        //UpdatedAt = model.UpdatedAt.CastModel<DateItem>();
    //        //DeletedAt = model.DeletedAt.CastModel<DateItem>();
    //        //AvailableActions = model.AvailableActions.CastModel<Actions>();
    //    };
    //}


    public int Id { get; }

    public string? Name { get; set; }

    public string? Url { get; set; }

    public string? Image { get; set; }

    public string? SupportUrl { get; set; }

    public string? WarrantyLookupUrl { get; set; }

    public string? SupportPhone { get; set; }

    public string? SupportEmail { get; set; }

    public int AssetsCount { get; }

    public int LicensesCount { get; }

    public int ConsumablesCount { get; }

    public int AccessoriesCount { get; }

    public int ComponentsCount { get; }

    public string? Notes { get; set; }

    public NamedItem? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; }

    public DateTime? UpdatedAt { get; }

    public DateTime? DeletedAt { get; }

    public Actions? AvailableActions { get; }
}
