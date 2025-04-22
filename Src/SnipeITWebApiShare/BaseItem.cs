namespace SnipeITWebApi;

/// <summary>
/// Represents a base class for items in the Snipe-IT system, providing common properties and functionality.
/// </summary>
[DebuggerDisplay("{this.GetType().Name}: {Id} : {Name}")]
public abstract class BaseItem : NamedItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseItem"/> class.
    /// </summary>
    internal BaseItem()
    { }

    internal BaseItem(BaseModel model) : base(model)
    {
        Id = model.Id;
        Name = model.Name;
        Image = model.Image;
        Notes = model.Notes;
        CreatedBy = model.CreatedBy?.CastModel<NamedItem>();
        CreatedAt = model.CreatedAt;
        UpdatedAt = model.UpdatedAt;
        DeletedAt = model.DeletedAt;
        UserCanCheckout = model.UserCanCheckout;
        AvailableActions = model.AvailableActions?.CastModel<AvailableActions>();
    }
    
    internal T FillBase<T>(T item) where T : BaseChangeModel
    {
        item.Name = Name;
        item.Image = Image;
        item.Notes = Notes;
        return item;
    }

    /// <summary>
    /// Gets or sets the image associated with the item.
    /// </summary>
    public string? Image { get; set; }

    /// <summary>
    /// Gets or sets the notes associated with the item.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets the user who created the item.
    /// </summary>
    public NamedItem? CreatedBy { get; internal set; }

    /// <summary>
    /// Gets the date and time when the item was created.
    /// </summary>
    public DateTime? CreatedAt { get; internal set; }

    /// <summary>
    /// Gets the date and time when the item was last updated.
    /// </summary>
    public DateTime? UpdatedAt { get; internal set; }

    /// <summary>
    /// Gets the date and time when the item was deleted, if applicable.
    /// </summary>
    public DateTime? DeletedAt { get; internal set; }

    /// <summary>
    /// Gets a value indicating whether the user can check out the item.
    /// </summary>
    public bool? UserCanCheckout { get; internal set; }

    /// <summary>
    /// Gets the actions that are available for the item.
    /// </summary>
    public AvailableActions? AvailableActions { get; internal set; }
}
