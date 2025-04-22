namespace SnipeITWebApi;

/// <summary>
/// Represents a maintenance record in the Snipe-IT system, including details about the asset, supplier, cost, and maintenance type.
/// </summary>
public class Maintenance : BaseItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Maintenance"/> class.
    /// </summary>
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

    /// <summary>
    /// Gets or sets the hardware asset associated with the maintenance.
    /// </summary>
    public Hardware? Asset { get; set; }

    /// <summary>
    /// Gets or sets the model associated with the maintenance.
    /// </summary>
    public NamedItem? Model { get; set; }

    /// <summary>
    /// Gets or sets the status label of the maintenance.
    /// </summary>
    public StatusLabel? StatusLabel { get; set; }

    /// <summary>
    /// Gets or sets the company associated with the maintenance.
    /// </summary>
    public NamedItem? Company { get; set; }

    /// <summary>
    /// Gets or sets the title of the maintenance record.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the location where the maintenance is performed.
    /// </summary>
    public NamedItem? Location { get; set; }

    /// <summary>
    /// Gets or sets the ready-to-deploy (RTD) location associated with the maintenance.
    /// </summary>
    public NamedItem? RtdLocation { get; set; }

    /// <summary>
    /// Gets or sets the supplier associated with the maintenance.
    /// </summary>
    public NamedItem? Supplier { get; set; }

    /// <summary>
    /// Gets or sets the cost of the maintenance.
    /// </summary>
    public float? Cost { get; set; }

    /// <summary>
    /// Gets or sets the type of maintenance activity.
    /// </summary>
    public MaintenanceType? AssetMaintenanceType { get; set; }

    /// <summary>
    /// Gets or sets the start date of the maintenance.
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// Gets or sets the time associated with the maintenance activity.
    /// </summary>
    public DateTime? AssetMaintenanceTime { get; set; }

    /// <summary>
    /// Gets or sets the completion date of the maintenance.
    /// </summary>
    public DateTime? CompletionDate { get; set; }

    /// <summary>
    /// Gets or sets the user associated with the maintenance.
    /// </summary>
    public NamedItem? UserId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the maintenance is covered under warranty.
    /// </summary>
    public bool? IsWarranty { get; set; }
}
