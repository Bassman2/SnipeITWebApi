namespace SnipeITWebApi.Models;

internal static class CastExtentions
{
    public static NamedItem? CastNamedItem(this NamedItemModel? model, int? id)
    {
        NamedItem? res = model.CastModel<NamedItem>();

        if ( res == null && id != null && id > 0)
        {
            res = new NamedItem(id.Value);

        }
        return res;
    }
}
