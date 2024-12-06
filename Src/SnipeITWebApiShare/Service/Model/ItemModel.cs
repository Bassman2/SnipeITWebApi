namespace SnipeITWebApi.Service.Model;

internal class ItemModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    public static implicit operator Item?(ItemModel? model)
    {
        return model is null ? null : new Item()
        {
            Id = model.Id,
            Name = model.Name
        };
    }
}
