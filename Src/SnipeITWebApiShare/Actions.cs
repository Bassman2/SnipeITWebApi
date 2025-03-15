namespace SnipeITWebApi;

public class Actions
{
    internal Actions(ActionsModel model)
    {
        Update = model.Update;
        Restore = model.Restore;
        Delete = model.Delete;
    }

    public bool Update { get; }

    public bool Restore { get; }

    public bool Delete { get; }
}
