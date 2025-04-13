namespace SnipeITWebApi;

public class Group
{
    public Group() 
    { }
    
    internal Group(GroupModel model)
    {
        Id = model.Id;
        Name = model.Name;
        Permissions = model.Permissions.CastModel<Permissions>();
        UsersCount = model.UsersCount;
        Notes = model.Notes;
        CreatedBy = model.CreatedBy.CastModel<NamedItem>();
        CreatedAt = model.CreatedAt;
        UpdatedAt = model.UpdatedAt;
        AvailableActions = model.AvailableActions.CastModel<Actions>();
    }

    //internal GroupModel ToCreate()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        Name = Name,
    //        Notes = Notes,
    //    };
    //}

    internal GroupChangeModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Name = Name,
            Notes = Notes,
        };
    }

    //internal GroupModel ToPatch()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        Name = Name,
    //        Notes = Notes,
    //    };
    //}

    public int Id { get; set; }
    public string? Name { get; set; }
    public Permissions? Permissions { get; set; }
    public int? UsersCount { get; }
    public string? Notes { get; set; }
    public NamedItem? CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Actions? AvailableActions { get; set; }
}
