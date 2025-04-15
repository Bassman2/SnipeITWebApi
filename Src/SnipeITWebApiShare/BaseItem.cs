namespace SnipeITWebApi;

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
        AvailableActions = model.AvailableActions?.CastModel<AvailableActions>();
    }

    public int Id { get; internal set; }
    public string? Name { get; set; }
    public string? Image { get; set; }
    public string? Notes { get; set; }
    public NamedItem? CreatedBy { get; internal set; }
    public DateTime? CreatedAt { get; internal set; }
    public DateTime? UpdatedAt { get; internal set; }
    public DateTime? DeletedAt { get; internal set; }
    public AvailableActions? AvailableActions { get; internal set; }

}
