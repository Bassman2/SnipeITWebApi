namespace SnipeITWebApi.Models;

internal class ActionsModel
{
    [JsonPropertyName("checkout")]
    public bool Checkout { get; set; }

    [JsonPropertyName("checkin")]
    public bool Checkin { get; set; }
    
    [JsonPropertyName("update")]
    public bool Update { get; set; }

    [JsonPropertyName("restore")]
    public bool Restore { get; set; }

    [JsonPropertyName("delete")]
    public bool Delete { get; set; }

    [JsonPropertyName("clone")]
    public bool Clone { get; set; }

    [JsonPropertyName("bulk_selectable")]
    public ActionsModel? BulkSelectable { get; set; }
}
