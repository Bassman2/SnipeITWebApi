namespace SnipeITWebApi.Service;

[JsonConverter(typeof(JsonStringEnumConverter<Status>))]
internal enum Status
{
    Success,
    Error
}
