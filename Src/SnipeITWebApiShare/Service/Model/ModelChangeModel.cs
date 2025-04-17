namespace SnipeITWebApi.Service.Model;

internal class ModelChangeModel : BaseChangeModel
{
    [JsonPropertyName("category_id")]
    public int? CategoryId { get; set; }

}
