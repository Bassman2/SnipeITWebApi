namespace SnipeITWebApi;

/// <summary>
/// Represents a category in the Snipe-IT system, including its type, counts, and related properties.
/// </summary>
public class Category : BaseItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Category"/> class.
    /// </summary>
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
    
    /// <summary>
    /// Gets or sets the type of the category (e.g., Asset, Accessory, Consumable, etc.).
    /// </summary>
    public CategoryType? CategoryType { get; set; }

    /// <summary>
    /// Gets a value indicating whether the category has an End User License Agreement (EULA).
    /// </summary>
    public bool HasEula { get; internal set; }

    /// <summary>
    /// Gets or sets a value indicating whether the default EULA should be used for this category.
    /// </summary>
    public bool UseDefaultEula { get; set; }

    /// <summary>
    /// Gets the EULA text associated with this category, if any.
    /// </summary>
    public string? Eula { get; internal set; }

    /// <summary>
    /// Gets or sets a value indicating whether check-in emails are required for this category.
    /// </summary>
    public bool? CheckinEmail { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether acceptance of the category's terms is required.
    /// </summary>
    public bool RequireAcceptance { get; set; }

    /// <summary>
    /// Gets the total number of items in this category.
    /// </summary>
    public int ItemCount { get; internal set; }

    /// <summary>
    /// Gets the total number of assets in this category.
    /// </summary>
    public int AssetsCount { get; internal set; }

    /// <summary>
    /// Gets the total number of accessories in this category.
    /// </summary>
    public int AccessoriesCount { get; internal set; }

    /// <summary>
    /// Gets the total number of consumables in this category.
    /// </summary>
    public int ConsumablesCount { get; internal set; }

    /// <summary>
    /// Gets the total number of components in this category.
    /// </summary>
    public int ComponentsCount { get; internal set; }

    /// <summary>
    /// Gets the total number of licenses in this category.
    /// </summary>
    public int LicensesCount { get; internal set; }
}
