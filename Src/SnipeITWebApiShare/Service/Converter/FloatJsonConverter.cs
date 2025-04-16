namespace SnipeITWebApi.Service.Converter;

internal class FloatJsonConverter : JsonConverter<float?>
{
    public override float? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }
        if (reader.TokenType == JsonTokenType.String)
        {
            string? value = reader.GetString();
            if (value != null && float.TryParse(value, out float result))
            {
                return result;
            }
            return null;
        }
        
        if (reader.TokenType == JsonTokenType.Number)
        {
            float value = reader.GetSingle();
            return value;
        }
        return null;
    }

    public override void Write(Utf8JsonWriter writer, float? value, JsonSerializerOptions options)
    {
        if (value != null)
        {
            writer.WriteNumberValue(value.Value);
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
