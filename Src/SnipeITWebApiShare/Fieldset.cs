namespace SnipeITWebApi;

/// <summary>
/// Represents a fieldset in the Snipe-IT system, which groups related fields and models.
/// </summary>
public class Fieldset : BaseItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Fieldset"/> class.
    /// </summary>
    public Fieldset()
    { }   

    internal Fieldset(FieldsetModel model) : base(model)
    {
        Fields = model.Fields?.Rows.CastModel<Field>();
        Models = model.Models?.Rows.CastModel<NamedItem>();
    }

    internal FieldsetChangeModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        var fields = Fields?.Select(x => x.ToUpdate()).ToList();
        //var models = Models?.Select(x => x.ToCreate()).ToList();
        return FillBase<FieldsetChangeModel>(new()
        {
            //Fields = new ListModel<FieldModel> { Total = fields?.Count ?? 0, Rows = fields },
            //Models = new ListModel<NamedItemModel> { Total = fields?.Count ?? 0, Rows = models }
        });
    }


    /// <summary>
    /// Gets or sets the list of fields associated with the fieldset.
    /// </summary>
    public List<Field>? Fields { get; set; }

    /// <summary>
    /// Gets or sets the list of models associated with the fieldset.
    /// </summary>
    public List<NamedItem>? Models { get; set; }
}
