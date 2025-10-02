namespace SnipeITWebApi.JsonConverters;

internal class BoolJsonConverter : JsonConverter<bool?>
{
    public override bool? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }
        if (reader.TokenType == JsonTokenType.True)
        {
            return reader.GetBoolean();
        }
        if (reader.TokenType == JsonTokenType.False)
        {
            return reader.GetBoolean();
        }
        if (reader.TokenType == JsonTokenType.Number)
        {
            int value = reader.GetInt32();
            return value != 0;
        }
        return null;
    }

    public override void Write(Utf8JsonWriter writer, bool? value, JsonSerializerOptions options)
    {
        if (value != null)
        {
            writer.WriteBooleanValue(value.Value);
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
