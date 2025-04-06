namespace SnipeITWebApi;

public class Maintenance
{
    public Maintenance() 
    { }

    internal Maintenance(MaintenanceModel model)
    {
        Id = model.Id;
        Asset = model.Asset?.CastModel<Hardware>();
        Model = model.Model?.CastModel<NamedItem>();
        StatusLabel = model.StatusLabel?.CastModel<StatusLabel>();
        Company = model.Company?.CastModel<NamedItem>();
        Title = model.Title;
        Location = model.Location?.CastModel<NamedItem>();
        RtdLocation = model.RtdLocation?.CastModel<NamedItem>();
        Notes = model.Notes;
        Supplier = model.Supplier?.CastModel<NamedItem>();
        Cost = model.Cost;
        AssetMaintenanceType = model.AssetMaintenanceType;
        StartDate = model.StartDate;
        AssetMaintenanceTime = model.AssetMaintenanceTime;
        CompletionDate = model.CompletionDate;
        UserId = model.UserId?.CastModel<NamedItem>();
        CreatedBy = model.CreatedBy?.CastModel<NamedItem>();
        CreatedAt = model.CreatedAt;
        UpdatedAt = model.UpdatedAt;
        IsWarranty = model.IsWarranty;
        AvailableActions = model.AvailableActions?.CastModel<Actions>();
    }

    internal MaintenanceModel ToCreate()
    {
        //ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        ArgumentNullException.ThrowIfNull(Asset?.Id, nameof(Asset.Id));
        ArgumentNullException.ThrowIfNull(Supplier?.Id, nameof(Supplier.Id));
        ArgumentNullException.ThrowIfNull(AssetMaintenanceType, nameof(AssetMaintenanceType));
        ArgumentNullException.ThrowIfNullOrWhiteSpace(Title, nameof(Title));
        ArgumentNullException.ThrowIfNull(StartDate, nameof(StartDate));
        return new()
        {
            AssetId = Asset?.Id,
            SupplierId = Supplier?.Id,
            AssetMaintenanceType = AssetMaintenanceType,
            Title = Title,
            StartDate = StartDate,
        };
    }

    internal MaintenanceModel ToUpdate()
    {
        //ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            //Name = Name,
        };
    }

    internal MaintenanceModel ToPatch()
    {
        //ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            //Name = Name,
        };
    }

    public int Id { get; set; }
    public Hardware? Asset { get; set; }
    public NamedItem? Model { get; set; }
    public StatusLabel? StatusLabel { get; set; }
    public NamedItem? Company { get; set; }
    public string? Title { get; set; }
    public NamedItem? Location { get; set; }
    public NamedItem? RtdLocation { get; set; }
    public string? Notes { get; set; }
    public NamedItem? Supplier { get; set; }
    public string? Cost { get; set; }
    public string? AssetMaintenanceType { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? AssetMaintenanceTime { get; set; }
    public DateTime? CompletionDate { get; set; }
    public NamedItem? UserId { get; set; }
    public NamedItem? CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? IsWarranty { get; set; }
    public Actions? AvailableActions { get; set; }   
}
