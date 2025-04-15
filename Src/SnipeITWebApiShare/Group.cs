namespace SnipeITWebApi;

public class Group : BaseItem
{
    public Group() 
    { }
    
    internal Group(GroupModel model) : base(model)
    {
        Permissions = model.Permissions.CastModel<Permissions>();
        UsersCount = model.UsersCount;
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

    public Permissions? Permissions { get; set; }
    public int? UsersCount { get; }
    
}
