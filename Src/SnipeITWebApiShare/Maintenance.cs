namespace SnipeITWebApi;

public class Maintenance : BaseItem
{
    public Maintenance() 
    { }

    internal Maintenance(MaintenanceModel model) : base(model)
    {
        Asset = model.Asset?.CastModel<Hardware>();
        Model = model.Model?.CastModel<NamedItem>();
        StatusLabel = model.StatusLabel?.CastModel<StatusLabel>();
        Company = model.Company?.CastModel<NamedItem>();
        Title = model.Title;
        Location = model.Location?.CastModel<NamedItem>();
        RtdLocation = model.RtdLocation?.CastModel<NamedItem>();
        Supplier = model.Supplier?.CastModel<NamedItem>();
        Cost = model.Cost;
        AssetMaintenanceType = model.AssetMaintenanceType;
        StartDate = model.StartDate;
        AssetMaintenanceTime = model.AssetMaintenanceTime;
        CompletionDate = model.CompletionDate;
        UserId = model.UserId?.CastModel<NamedItem>();
        IsWarranty = model.IsWarranty;
    }

    //internal MaintenanceModel ToCreate()
    //{
    //    ArgumentNullException.ThrowIfNull(Asset?.Id, nameof(Asset.Id));
    //    ArgumentNullException.ThrowIfNull(Supplier?.Id, nameof(Supplier.Id));
    //    ArgumentNullException.ThrowIfNull(AssetMaintenanceType, nameof(AssetMaintenanceType));
    //    //ArgumentNullException.ThrowIfNullOrWhiteSpace(Title, nameof(Title));
    //    ArgumentNullException.ThrowIfNull(StartDate, nameof(StartDate));
    //    return new()
    //    {
    //        // required
    //        AssetId = Asset?.Id,
    //        SupplierId = Supplier?.Id,
    //        AssetMaintenanceType = AssetMaintenanceType,
    //        Title = Title,
    //        StartDate = StartDate,

    //        // optional
    //        Notes = Notes,
    //    };
    //}

    internal MaintenanceChangeModel ToUpdate()
    {
        //ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return FillBase<MaintenanceChangeModel>(new()
        {
            // optional
            //Name = Name,
            Title = Title,
            AssetId = Asset?.Id,
            SupplierId = Supplier?.Id,
            AssetMaintenanceType = AssetMaintenanceType,
            StartDate = StartDate,
            IsWarrenty = IsWarranty,
            Cost = Cost,
            CompletionDate = CompletionDate,

            //Notes = Notes,
            //Image = Image,

        });
    }

    //internal MaintenanceModel ToPatch()
    //{
    //    //ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        // optional
    //        Notes = Notes,
    //    };
    //}

    public Hardware? Asset { get; set; }
    public NamedItem? Model { get; set; }
    public StatusLabel? StatusLabel { get; set; }
    public NamedItem? Company { get; set; }
    public string? Title { get; set; }
    public NamedItem? Location { get; set; }
    public NamedItem? RtdLocation { get; set; }
    public NamedItem? Supplier { get; set; }
    public float? Cost { get; set; }
    public MaintenanceType? AssetMaintenanceType { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? AssetMaintenanceTime { get; set; }
    public DateTime? CompletionDate { get; set; }
    public NamedItem? UserId { get; set; }
    public bool? IsWarranty { get; set; }
}
