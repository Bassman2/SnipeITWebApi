namespace SnipeITWebApi;

/// <summary>
/// Represents a status label in the Snipe-IT system, including properties such as type, color, and visibility in navigation.
/// </summary>
public class StatusLabel : BaseItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StatusLabel"/> class.
    /// </summary>
    public StatusLabel()
    { }

    internal StatusLabel(StatusLabelModel model) : base(model)
    {
        //Type = model.Type;
        Color = model.Color;
        ShowInNav = model.ShowInNav;
        DefaultLabel = model.DefaultLabel;
        AssetsCount = model.AssetsCount;
    }

    //internal StatusLabelModel ToCreate()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        Name = Name,
    //        Type = Type,
    //        Color = Color,
    //        ShowInNav = ShowInNav,
    //        DefaultLabel = DefaultLabel,
    //        Notes = Notes,
    //    };
    //}

    internal StatusLabelChangeModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return FillBase<StatusLabelChangeModel>(new()
        {
            Name = Name,
            Type = Type,
            Color = Color,
            ShowInNav = ShowInNav,
            DefaultLabel = DefaultLabel,
            Notes = Notes,
        });
    }

    //internal StatusLabelModel ToPatch()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        Name = Name,
    //        Type = Type,
    //        Color = Color,
    //        ShowInNav = ShowInNav,
    //        DefaultLabel = DefaultLabel,
    //        Notes = Notes,
    //    };
    //}

    /// <summary>
    /// Implicitly converts a tuple containing an ID and name to a <see cref="StatusLabel"/>.
    /// </summary>
    /// <param name="item">A tuple containing the ID and name of the status label.</param>
    /// <returns>A new <see cref="StatusLabel"/> instance with the specified ID and name.</returns>
    public static implicit operator StatusLabel((int, string) item) => new() { Id = item.Item1, Name = item.Item2 };

    /// <summary>
    /// Gets or sets the type of the status label.
    /// </summary>
    public StatusType? Type { get; set; }

    /// <summary>
    /// Gets or sets the color of the status label.
    /// </summary>
    public string? Color { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the status label is visible in navigation.
    /// </summary>
    public bool? ShowInNav { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the status label is the default label.
    /// </summary>
    public bool? DefaultLabel { get; set; }

    /// <summary>
    /// Gets or sets the count of assets associated with the status label.
    /// </summary>
    public int? AssetsCount { get; set; }
}
