namespace SnipeITWebApi;

/// <summary>
/// Represents a group in the Snipe-IT system, including its permissions and user count.
/// </summary>
public class Group : BaseItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Group"/> class.
    /// </summary>
    public Group() 
    { }
    
    internal Group(GroupModel model) : base(model)
    {
        Permissions = model.Permissions.CastModel<Permissions>();
        UsersCount = model.UsersCount;
    }

    internal GroupChangeModel ToUpdate()
    {
        //ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return FillBase<GroupChangeModel>(new()
        {
            Permissions = Permissions?.ToUpdate(),
        });
    }


    /// <summary>
    /// Gets or sets the permissions associated with the group.
    /// </summary>
    public Permissions? Permissions { get; set; }

    /// <summary>
    /// Gets the number of users in the group.
    /// </summary>
    public int? UsersCount { get; internal set; }
}
