namespace SnipeITWebApi.Service.Model;

internal class FieldsetModel : BaseModel
{
    [JsonPropertyName("fields")]
    public ListModel<FieldModel>? Fields { get; set; }

    [JsonPropertyName("models")]
    public ListModel<NamedItemModel>? Models { get; set; }
}
