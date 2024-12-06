namespace SnipeITWebApi.Service.Model;

internal class AssignedModel
{
    [JsonPropertyName("username")]
    public string? Username { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    public static implicit operator Assigned?(AssignedModel? model)
    {
        return model is null ? null : new Assigned()
        {
            Username = model.Username,
            Name = model.Name,
            Email = model.Email
        };
    }
}
