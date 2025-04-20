namespace SnipeITWebApi.Service.Converter;

internal class FloatJsonConverter : JsonConverter<float?>
{
    private static readonly CultureInfo culture = new CultureInfo("en-US");
    //private static readonly CultureInfo culture = new CultureInfo("de-DE");

    public override float? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }
        if (reader.TokenType == JsonTokenType.String)
        {
            string? value = reader.GetString();
            if (value != null && float.TryParse(value, culture, out float result))
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
            //writer.WriteNumberValue(value.Value);
            string str = value.Value.ToString(culture);
            writer.WriteStringValue(str);
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}

/* problem 
Maintenance Costs

Field      JSON post       JSON post return   JSON get
3000.5  => 3000.5       => 30005            => "30.005,00"
3000,5  => "3000,5"     => 3000.5           => "3.000,50"
*/
