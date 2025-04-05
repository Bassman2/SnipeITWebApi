namespace SnipeITWebApi;

public class Category
{
    public Category()
    { } 

    internal Category(CategoryModel model)
    {
        Id = model.Id;
        Name = model.Name;
        Image = model.Image;
        CategoryType = model.CategoryType;
        HasEula = model.HasEula;
        UseDefaultEula = model.UseDefaultEula;
        Eula = model.Eula;
        CheckinEmail = model.CheckinEmail;
        RequireAcceptance = model.RequireAcceptance;
        ItemCount = model.ItemCount;
        AssetsCount = model.AssetsCount;
        AccessoriesCount = model.AccessoriesCount;
        ConsumablesCount = model.ConsumablesCount;
        ComponentsCount = model.ComponentsCount;
        LicensesCount = model.LicensesCount;
        CreatedBy = model.CreatedBy.CastModel<NamedItem>();
        Notes = model.Notes;
        CreatedAt = model.CreatedAt;
        UpdatedAt = model.UpdatedAt;
        AvailableActions = model.AvailableActions.CastModel<Actions>();
    }

    internal CategoryModel ToCreate()
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        ArgumentNullException.ThrowIfNull(CategoryType, nameof(CategoryType));
        return new()
        {
            Name = Name,
            CategoryType = CategoryType,

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
            Notes = Notes,
            //CreatedBy = model.CreatedBy.CastModel<NamedItem>();
            //CreatedAt = model.CreatedAt.CastModel<DateItem>();
            //UpdatedAt = model.UpdatedAt.CastModel<DateItem>();
            //DeletedAt = model.DeletedAt.CastModel<DateItem>();
            //AvailableActions = model.AvailableActions.CastModel<Actions>();
        };
    }

    internal CategoryModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        if (CategoryType != null) throw new ArgumentException("You cannot change the category type once it has been created");
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
            Notes = Notes,
            //CreatedBy = model.CreatedBy.CastModel<NamedItem>();
            //CreatedAt = model.CreatedAt.CastModel<DateItem>();
            //UpdatedAt = model.UpdatedAt.CastModel<DateItem>();
            //DeletedAt = model.DeletedAt.CastModel<DateItem>();
            //AvailableActions = model.AvailableActions.CastModel<Actions>();
        };
    }

    internal CategoryModel ToPatch()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        if (CategoryType != null) throw new ArgumentException("You cannot change the category type once it has been created");

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
            Notes = Notes,
            //CreatedBy = model.CreatedBy.CastModel<NamedItem>();
            //CreatedAt = model.CreatedAt.CastModel<DateItem>();
            //UpdatedAt = model.UpdatedAt.CastModel<DateItem>();
            //DeletedAt = model.DeletedAt.CastModel<DateItem>();
            //AvailableActions = model.AvailableActions.CastModel<Actions>();
        };
    }

    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Image { get; set; }

    public CategoryType? CategoryType { get; set; }

    public bool HasEula { get; set; }

    public bool UseDefaultEula { get; set; }

    public string? Eula { get; set; }

    public bool? CheckinEmail { get; set; }

    public bool RequireAcceptance { get; set; }

    public int ItemCount { get; set; }

    public int AssetsCount { get; set; }

    public int AccessoriesCount { get; set; }

    public int ConsumablesCount { get; set; }

    public int ComponentsCount { get; set; }

    public int LicensesCount { get; set; }

    public NamedItem? CreatedBy { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Actions? AvailableActions { get; set; }
}
