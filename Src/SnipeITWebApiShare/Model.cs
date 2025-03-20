using System;

namespace SnipeITWebApi;

public class Model
{
    public Model()
    { }

    internal Model(ModelModel model)
    {

        Id = model.Id;
        Name = model.Name;
        Manufacturer = model.Manufacturer.CastModel<NamedItem>();
        Image = model.Image;
    }

    internal ModelModel ToCreate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        ArgumentOutOfRangeException.ThrowIfZero(CategoryId, nameof(CategoryId));
        return new()
        {

            //Id = Id,
            Name = Name,
            CategoryId = CategoryId,
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

    internal ModelModel ToUpdate()
    {
        ArgumentOutOfRangeException.ThrowIfZero(Id, nameof(Id));
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        ArgumentOutOfRangeException.ThrowIfZero(CategoryId, nameof(CategoryId));
        return new()
        {
            Id = Id,
            Name = Name,
            CategoryId = CategoryId,
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

    internal ModelModel ToPatch()
    {
        ArgumentOutOfRangeException.ThrowIfZero(Id, nameof(Id));
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        ArgumentOutOfRangeException.ThrowIfZero(CategoryId, nameof(CategoryId));
        return new()
        {
            Id = Id,
            Name = Name,
            CategoryId = CategoryId,
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

    public int Id { get; }

    public string? Name { get; set; }

    public NamedItem? Manufacturer { get; set; }

    public string? Image { get; set; }

    public int CategoryId { get; set; }
}
