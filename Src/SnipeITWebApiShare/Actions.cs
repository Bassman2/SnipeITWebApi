namespace SnipeITWebApi;

public class Actions
{
    internal Actions(ActionsModel model)
    {
        Checkout = model.Checkout;
        Checkin = model.Checkin;
        Update = model.Update;
        Restore = model.Restore;
        Delete = model.Delete;
        Clone = model.Clone;
    }

    public bool Checkout { get;}

    public bool Checkin { get; }

    public bool Update { get; }

    public bool Restore { get; }

    public bool Delete { get; }

    public bool Clone { get; }

}
