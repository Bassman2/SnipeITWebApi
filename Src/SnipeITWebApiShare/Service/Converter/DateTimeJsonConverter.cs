

namespace SnipeITWebApi.Service.Converter;

internal class DateTimeJsonConverter : JsonConverter<DateTime?>
{
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            // Handle "created_at": "2025-03-18T21:05:08.000000Z"

            if (DateTime.TryParse(reader.GetString(), out DateTime dateTime))
            {
                return dateTime;
            }
        }
        else if (reader.TokenType == JsonTokenType.StartObject)
        {
            // Handle "created_at": { "datetime": "2025-02-20 11:59:38", "formatted": "Thu Feb 20, 2025 11:59AM" }
            
            using (JsonDocument document = JsonDocument.ParseValue(ref reader))
            {
                if (document.RootElement.TryGetProperty("datetime", out JsonElement datetimeElement) &&
                    datetimeElement.ValueKind == JsonValueKind.String &&
                    DateTime.TryParse(datetimeElement.GetString(), out DateTime dateTime))
                {
                    return dateTime;
                }
            }
        }
        return null;
    }



    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        
    }
}
