namespace SnipeITWebApi;

public class DateItem
{
    internal DateItem(DateItemModel model)
    {
        Date = model.Date;
        Formatted = model.Formatted;
    }

    public string? Date { get; }

    public string? Formatted { get; }
}
