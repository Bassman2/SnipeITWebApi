namespace SnipeITWebApi;

public class Fieldset : BaseItem
{
    public Fieldset()
    { }   

    internal Fieldset(FieldsetModel model) : base(model)
    {
        Fields = model.Fields?.Rows.CastModel<Field>();
        Models = model.Models?.Rows.CastModel<NamedItem>();
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
        //var models = Models?.Select(x => x.ToCreate()).ToList();
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

    
    public List<Field>? Fields { get; set; }
    public List<NamedItem>? Models { get; set; }
}
