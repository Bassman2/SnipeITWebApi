using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        //CreatedBy = model.CreatedBy.CastModel<Item>();
        //CreatedAt = model.CreatedAt.CastModel<DateItem>();
        //UpdatedAt = model.UpdatedAt.CastModel<DateItem>();
        //DeletedAt = model.DeletedAt.CastModel<DateItem>();
        AvailableActions = model.AvailableActions.CastModel<Actions>();
    }

    internal ManufacturerModel ToModel() => new()
    {
        Id = Id,
        Name = Name,
        Url = Url,
        Image = Image,
        SupportUrl = SupportUrl,
        WarrantyLookupUrl = WarrantyLookupUrl,
        SupportPhone = SupportPhone,
        SupportEmail = SupportEmail,
        AssetsCount = AssetsCount,
        LicensesCount = LicensesCount,
        ConsumablesCount = ConsumablesCount,
        AccessoriesCount = AccessoriesCount,
        ComponentsCount = ComponentsCount,
        Notes = Notes,
        //CreatedBy = model.CreatedBy.CastModel<Item>();
        //CreatedAt = model.CreatedAt.CastModel<DateItem>();
        //UpdatedAt = model.UpdatedAt.CastModel<DateItem>();
        //DeletedAt = model.DeletedAt.CastModel<DateItem>();
        //AvailableActions = model.AvailableActions.CastModel<Actions>();
    };
    

    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Url { get; set; }

    public string? Image { get; set; }

    public string? SupportUrl { get; set; }

    public string? WarrantyLookupUrl { get; set; }

    public string? SupportPhone { get; set; }

    public string? SupportEmail { get; set; }

    public int AssetsCount { get; set; }

    public int LicensesCount { get; set; }

    public int ConsumablesCount { get; set; }

    public int AccessoriesCount { get; set; }

    public int ComponentsCount { get; set; }

    public string? Notes { get; set; }

    public Item? CreatedBy { get; set; }

    public DateItem? CreatedAt { get; set; }

    public DateItem? UpdatedAt { get; set; }

    public DateItem? DeletedAt { get; set; }

    public Actions? AvailableActions { get; set; }
}
