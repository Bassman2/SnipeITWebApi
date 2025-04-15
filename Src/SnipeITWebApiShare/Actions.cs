namespace SnipeITWebApi;

public class Actions
{
    public Actions() { }

    internal Actions(ActionsModel model)
    {
        Checkout = model.Checkout;
        Checkin = model.Checkin;
        Update = model.Update;
        Restore = model.Restore;
        Delete = model.Delete;
        Clone = model.Clone;
    }

    public bool Checkout { get; set; }

    public bool Checkin { get; set; }

    public bool Update { get; set; }

    public bool Restore { get; set; }

    public bool Delete { get; set; }

    public bool Clone { get; set; }
}
