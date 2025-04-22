namespace SnipeITWebApi;

/// <summary>
/// Represents the actions that are available for an item in the Snipe-IT system.
/// </summary>
public class AvailableActions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AvailableActions"/> class.
    /// </summary>
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

    /// <summary>
    /// Gets or sets a value indicating whether the checkout action is available.
    /// </summary>
    public bool Checkout { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the check-in action is available.
    /// </summary>
    public bool Checkin { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the update action is available.
    /// </summary>
    public bool Update { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the restore action is available.
    /// </summary>
    public bool Restore { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the delete action is available.
    /// </summary>
    public bool Delete { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the clone action is available.
    /// </summary>
    public bool Clone { get; set; }

    /// <summary>
    /// Implicitly converts an <see cref="Actions"/> enum to an <see cref="AvailableActions"/> instance.
    /// </summary>
    /// <param name="item">The <see cref="Actions"/> enum representing the available actions.</param>
    /// <returns>An <see cref="AvailableActions"/> instance with the corresponding actions set.</returns>
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
