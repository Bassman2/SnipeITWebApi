namespace SnipeITWebApi;

public class Actions
{
    internal Actions(ActionsModel model)
    {
        Update = model.Update;
        Delete = model.Delete;
    }

    public bool Update { get; }

    public bool Delete { get; }
}
