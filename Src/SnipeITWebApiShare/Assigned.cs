namespace SnipeITWebApi;

public class Assigned
{
    internal Assigned(AssignedModel model)
    {
        Username = model.Username;
        Name = model.Name;
        Email = model.Email;
    }

    public string? Username { get; init; }

    public string? Name { get; init; }

    public string? Email { get; init; }
}
