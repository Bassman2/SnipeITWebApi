namespace SnipeITWebApi.Service.Converter;

internal class DateTimeJsonConverter : JsonConverter<DateTime?>
{
    // "purchase_date": { "date": "2028-01-01",  "formatted": "Sat Jan 01, 2028" },
    // "created_at": { "datetime": "2025-02-20 11:59:38", "formatted": "Thu Feb 20, 2025 11:59AM" }

    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var text = reader.GetString();
            if (DateTime.TryParse(reader.GetString(), out DateTime dateTime))
            {
                return dateTime;
            }
        }
        else if (reader.TokenType == JsonTokenType.StartObject)
        {
            DateTime? res = null;
            string? propertyName = null;
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                case JsonTokenType.PropertyName:
                    propertyName = reader.GetString();
                    break;
                case JsonTokenType.String:
                    var text = reader.GetString();
                    if ((propertyName == "date" || propertyName == "datetime") && DateTime.TryParse(text, out DateTime dateTime))
                    {
                        res = dateTime;
                    }
                    break;
                case JsonTokenType.EndObject:
                    return res;
                default:
                    break;
                }
            }
        }
        return null;
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value != null)
        {
            writer.WriteStringValue(value.Value.ToString("yyyy-MM-dd HH:mm:ss"));
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
