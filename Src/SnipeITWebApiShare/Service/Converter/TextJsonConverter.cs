namespace SnipeITWebApi.Service.Converter;

internal class TextJsonConverter : JsonConverter<string?>
{
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? str = reader.GetString();
        if (str != null) 
        {

        }
        return str;
    }

    public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }
}
