namespace SnipeITWebApi;

public class Category : BaseItem
{
    public Category()
    { } 

    internal Category(CategoryModel model) : base(model)
    {
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
    }

    internal CategoryChangeModel ToCreate()
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        //ArgumentNullException.ThrowIfNull(CategoryType, nameof(CategoryType));
        return FillBase<CategoryChangeModel>(new()
        {
            Name = Name,
            CategoryType = CategoryType,
            UseDefaultEula = UseDefaultEula,
            RequireAcceptance = RequireAcceptance,
            CheckinEmail = CheckinEmail,
            Notes = Notes,
            Image = Image,
        });
    }

    internal CategoryChangeModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return FillBase<CategoryChangeModel>(new()
        {
            Name = Name,
            //CategoryType = CategoryType,      // cannot be changed
            UseDefaultEula = UseDefaultEula,
            RequireAcceptance = RequireAcceptance,
            CheckinEmail = CheckinEmail,
            Notes = Notes,
            Image = Image,
        });
    }

    //internal CategoryModel ToPatch()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    if (CategoryType != null) throw new ArgumentException("You cannot change the category type once it has been created");

    //    return FillBase<CategoryChangeModel>(new()
    //    {
    //        Name = Name,

    //        //Url = Url,
    //        //Image = Image,
    //        //SupportUrl = SupportUrl,
    //        //WarrantyLookupUrl = WarrantyLookupUrl,
    //        //SupportPhone = SupportPhone,
    //        //SupportEmail = SupportEmail,
    //        //AssetsCount = AssetsCount,
    //        //LicensesCount = LicensesCount,
    //        //ConsumablesCount = ConsumablesCount,
    //        //AccessoriesCount = AccessoriesCount,
    //        //ComponentsCount = ComponentsCount,
    //        Notes = Notes,
    //        //CreatedBy = model.CreatedBy.CastModel<NamedItem>();
    //        //CreatedAt = model.CreatedAt.CastModel<DateItem>();
    //        //UpdatedAt = model.UpdatedAt.CastModel<DateItem>();
    //        //DeletedAt = model.DeletedAt.CastModel<DateItem>();
    //        //AvailableActions = model.AvailableActions.CastModel<AvailableActions>();
    //    });
    //}

    public CategoryType? CategoryType { get; set; }

    public bool HasEula { get; internal set; }

    public bool UseDefaultEula { get; set; }

    public string? Eula { get; internal set; }

    public bool? CheckinEmail { get; set; }

    public bool RequireAcceptance { get; set; }

    public int ItemCount { get; internal set; }

    public int AssetsCount { get; internal set; }

    public int AccessoriesCount { get; internal set; }

    public int ConsumablesCount { get; internal set; }

    public int ComponentsCount { get; internal set; }

    public int LicensesCount { get; internal set; }
}
