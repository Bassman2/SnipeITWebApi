namespace SnipeITWebApi.Service.Model;

internal class DateItemModel
{
    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("formatted")]
    public string? Formatted { get; set; }

    public static implicit operator DateItem?(DateItemModel? model)
    {
        return model is null ? null : new DateItem()
        {
            Date = model.Date,
            Formatted = model.Formatted
        };
    }
}
