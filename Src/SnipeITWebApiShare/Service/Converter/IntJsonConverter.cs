using System.Text.RegularExpressions;

namespace SnipeITWebApi.Service.Converter;

internal partial class IntJsonConverter : JsonConverter<int?>
{

    public override int? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }
        if (reader.TokenType == JsonTokenType.String)
        {
            string? value = reader.GetString();
            if (value != null)
            {
                // read first number of string and ignore the rest
                Match match = IntRegex().Match(value);
                if (match.Success && int.TryParse(match.Value, out int result))
                {
                    return result;
                }
            }
            return null;
        }

        if (reader.TokenType == JsonTokenType.Number)
        {
            int value = reader.GetInt32();
            return value;
        }
        return null;
    }

    public override void Write(Utf8JsonWriter writer, int? value, JsonSerializerOptions options)
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

    [GeneratedRegex(@"\d+")]
    private static partial Regex IntRegex();
}