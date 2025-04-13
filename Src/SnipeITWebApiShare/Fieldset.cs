namespace SnipeITWebApi;

public class Fieldset
{
    public Fieldset()
    { }   

    internal Fieldset(FieldsetModel model)
    {
        Id = model.Id;
        Name = model.Name;
        Fields = model.Fields?.Rows.CastModel<Field>();
        Models = model.Models?.Rows.CastModel<NamedItem>();
        CreatedAt = model.CreatedAt;
        UpdatedAt = model.UpdatedAt;

    }

    //internal FieldsetModel ToCreate()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    var fields = Fields?.Select(x => x.ToUpdate()).ToList();
    //    var models = Models?.Select(x => x.ToCreate()).ToList();
    //    return new()
    //    {
    //        Name = Name,
    //        Fields = new ListModel<FieldChangeModel> { Total = fields?.Count ?? 0, Rows = fields },
    //        Models = new ListModel<NamedItemModel> { Total = fields?.Count ?? 0, Rows = models }
    //    };
    //}

    internal FieldsetChangeModel ToUpdate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        var fields = Fields?.Select(x => x.ToUpdate()).ToList();
        var models = Models?.Select(x => x.ToCreate()).ToList();
        return new()
        {
            Name = Name,
            //Fields = new ListModel<FieldModel> { Total = fields?.Count ?? 0, Rows = fields },
            //Models = new ListModel<NamedItemModel> { Total = fields?.Count ?? 0, Rows = models }
        };
    }

    //internal FieldsetModel ToPatch()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    var fields = Fields?.Select(x => x.ToUpdate()).ToList();
    //    var models = Models?.Select(x => x.ToCreate()).ToList();
    //    return new()
    //    {
    //        Name = Name,
    //        Fields = new ListModel<FieldModel> { Total = fields?.Count ?? 0, Rows = fields },
    //        Models = new ListModel<NamedItemModel> { Total = fields?.Count ?? 0, Rows = models }
    //    };
    //}

    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Field>? Fields { get; set; }
    public List<NamedItem>? Models { get; set; }
    public DateTime? CreatedAt { get; }
    public DateTime? UpdatedAt { get; }
}
