namespace SnipeITWebApi.Service.Model;

[DebuggerDisplay("{this.GetType().Name}: {Id} : { {Name}")]
internal class BaseModel : NamedItemModel
{
    [JsonPropertyName("image")]
    public string? Image { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("created_by")]
    public NamedItemModel? CreatedBy { get; set; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("deleted_at")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? DeletedAt { get; set; }

    [JsonPropertyName("user_can_checkout")]
    [JsonConverter(typeof(BooleanJsonConverter))]
    public bool? UserCanCheckout { get; set; }

    [JsonPropertyName("available_actions")]
    public ActionsModel? AvailableActions { get; set; }
}
