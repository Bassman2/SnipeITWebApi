namespace SnipeITWebApi;

public class StatusLabel
{
    public StatusLabel()
    { }

    internal StatusLabel(StatusLabelModel model)
    {
        Id = model.Id;
        Name = model.Name;
        //Type = model.Type;
        Color = model.Color;
        ShowInNav = model.ShowInNav;
        DefaultLabel = model.DefaultLabel;
        AssetsCount = model.AssetsCount;
        Notes = model.Notes;
        CreatedBy = model.CreatedBy.CastModel<NamedItem>();
        CreatedAt = model.CreatedAt;
        UpdatedAt = model.UpdatedAt;
        AvailableActions = model.AvailableActions.CastModel<Actions>();

        if (model.Type != null)
        {
            Type = model.Type;
        }
        if (model.Deployable == true)
        {
            Type = StatusType.deployable;
        }
        else if (model.Pending == true)
        {
            Type = StatusType.pending;
        }
        else if (model.Archived == true)
        {
            Type = StatusType.archived;
        }
        else
        {
            Type = StatusType.undeployable;
        }
    }

    internal StatusLabelModel ToCreate()
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

    internal StatusLabelModel ToUpdate()
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

    internal StatusLabelModel ToPatch()
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

    public int Id { get; set; }
    public string? Name { get; set; }
    public StatusType? Type { get; set; }
    public string? Color { get; set; }
    public bool? ShowInNav { get; set; }
    public bool? DefaultLabel { get; set; }
    public int? AssetsCount { get; set; }
    public string? Notes { get; set; }
    public NamedItem? CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Actions? AvailableActions { get; set; }
}
