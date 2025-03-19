namespace SnipeITWebApi.Service.Model;

internal class ResultModel<T>
{
    [JsonPropertyName("status")]
    public Status Status { get; set; }

    [JsonPropertyName("messages")]
    public JsonElement MessagesElement { get; set; }
    
    [JsonPropertyName("payload")]
    public T? Payload { get; set; }

    [JsonIgnore]
    public string? Messages => MessagesElement.ValueKind switch
    {
        JsonValueKind.String => MessagesElement.GetString(),
        JsonValueKind.Object => string.Join(Environment.NewLine, MessagesElement.EnumerateObject().Select(m => $"{m.Name}: {string.Join(", ", m.Value.EnumerateArray().Select(v => v.GetString()))}")),
        _ => throw new NotSupportedException()
    }; 
    
    public override string? ToString()
    {
        return Status == Status.Success ? "Success" : $"Error:{Messages}";
    }
}
