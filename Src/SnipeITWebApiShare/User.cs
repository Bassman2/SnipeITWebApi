namespace SnipeITWebApi;

public class User
{
    public User()
    { }

    internal User(UserModel model)
    {
        Id = model.Id;
        Avatar = model.Avatar;
        Name = model.Name;
        FirstName = model.FirstName;
        LastName = model.LastName;
        Username = model.Username;
        Company = model.Company.CastModel<NamedItem>();
        CreatedBy = model.CreatedBy.CastModel<NamedItem>();
        //CreatedAt = model.CreatedAt;
        //UpdatedAt = model.UpdatedAt;
        //DeletedAt = model.DeletedAt;
        AvailableActions = model.AvailableActions.CastModel<Actions>();
    }

    internal UserModel ToCreate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            //Id = Id,
            Name = Name
        };
    }

    internal UserModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            //Id = Id,
            Name = Name
        };
    }

    internal UserModel ToPatch()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            //Id = Id,
            Name = Name
        };
    }


    public int Id { get; set; }

    public string? Avatar { get; set; }

    public string? Name { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Username { get; set; }


    // TODO ...

    public NamedItem? Company { get; set; }

    public NamedItem? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public Actions? AvailableActions { get; set; }
}
