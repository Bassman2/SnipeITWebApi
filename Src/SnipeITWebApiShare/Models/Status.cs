namespace SnipeITWebApi.Models;

[JsonConverter(typeof(JsonStringEnumConverter<Status>))]
internal enum Status
{
    Success,
    Error
}
