namespace SnipeITWebApi;

[DebuggerDisplay("{this.GetType().Name}: {Id} : {Name}")]
public abstract class BaseItem
{
    internal BaseItem()
    { }

    internal BaseItem(BaseModel model)
    {
        Id = model.Id;
        Name = model.Name;
        Image = model.Image;
        Notes = model.Notes;
        CreatedBy = model.CreatedBy?.CastModel<NamedItem>();
        CreatedAt = model.CreatedAt;
        UpdatedAt = model.UpdatedAt;
        DeletedAt = model.DeletedAt;
        UserCanCheckout = model.UserCanCheckout;
        AvailableActions = model.AvailableActions?.CastModel<AvailableActions>();
    }
    
    internal T FillBase<T>(T item) where T : BaseChangeModel
    {
        item.Name = Name;
        item.Image = Image;
        item.Notes = Notes;
        return item;
    }
    
    public int Id { get; internal set; }
    public string? Name { get; set; }
    public string? Image { get; set; }
    public string? Notes { get; set; }
    public NamedItem? CreatedBy { get; internal set; }
    public DateTime? CreatedAt { get; internal set; }
    public DateTime? UpdatedAt { get; internal set; }
    public DateTime? DeletedAt { get; internal set; }
    public bool? UserCanCheckout { get; internal set; }
    public AvailableActions? AvailableActions { get; internal set; }

    public override bool Equals(object? obj) => obj is BaseItem item && Id == item.Id && Name == item.Name;
    public override int GetHashCode() => base.GetHashCode();
    public override string ToString() => $"{Id} : {Name}";
}
