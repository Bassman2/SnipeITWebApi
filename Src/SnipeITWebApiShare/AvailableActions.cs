namespace SnipeITWebApi;

public class AvailableActions
{
    public AvailableActions() { }

    internal AvailableActions(ActionsModel model)
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

    public static implicit operator AvailableActions(Actions item) => new()
    {
        Checkout = item.HasFlag(Actions.Checkout),
        Checkin = item.HasFlag(Actions.Checkin),
        Update = item.HasFlag(Actions.Update),
        Restore = item.HasFlag(Actions.Restore),
        Delete = item.HasFlag(Actions.Delete),
        Clone = item.HasFlag(Actions.Clone)
    };

}
