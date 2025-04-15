namespace SnipeITWebApi;

public class StatusLabel : BaseItem
{
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
        return new()
        {
            Name = Name,
            Type = Type,
            Color = Color,
            ShowInNav = ShowInNav,
            DefaultLabel = DefaultLabel,
            Notes = Notes,
        };
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

    public StatusType? Type { get; set; }
    public string? Color { get; set; }
    public bool? ShowInNav { get; set; }
    public bool? DefaultLabel { get; set; }
    public int? AssetsCount { get; set; }
}
