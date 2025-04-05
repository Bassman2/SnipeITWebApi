namespace SnipeITWebApi.Service.Model;

internal class ResultModel
{
    [JsonPropertyName("status")]
    public Status Status { get; set; }

    [JsonPropertyName("messages")]
    public JsonElement MessagesElement { get; set; }

    [JsonIgnore]
    //public string? Messages => MessagesElement.ValueKind switch
    //{
    //    JsonValueKind.String => MessagesElement.GetString(),
    //    JsonValueKind.Object => string.Join(Environment.NewLine, MessagesElement.EnumerateObject().Select(m => $"{m.Name}: {string.Join(", ", m.Value.EnumerateArray().Select(v => v.GetString()))}")),
    //    _ => throw new NotSupportedException()
    //};

    public string? Messages
    {
        get
        {
            if (MessagesElement.ValueKind == JsonValueKind.String)
            {
                return MessagesElement.GetString();
            }
            if (MessagesElement.ValueKind == JsonValueKind.Object)
            {
                string res = string.Empty;

                var obj = MessagesElement;
                var list = obj.EnumerateObject();
                foreach (JsonProperty item in list)
                {
                    string name = item.Name;
                    JsonElement value = item.Value;
                    if (value.ValueKind == JsonValueKind.String)
                    {
                        string str = value.GetString() ?? "";
                        res += $"{name}: {str}{Environment.NewLine}";
                    }
                    else if (value.ValueKind == JsonValueKind.Array)
                    {
                        string str = string.Join(", ", value.EnumerateArray().Select(v => v.GetString()));
                        res += $"{name}: {str}{Environment.NewLine}";
                    }
                    else
                    {
                        throw new NotSupportedException();
                    }
                }
                return res;

            }
            throw new NotSupportedException();
        }
    }
    

    public override string? ToString()
    {
        return Status == Status.Success ? "Success" : $"Error:{Messages}";
    }
}

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
