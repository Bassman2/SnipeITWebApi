namespace SnipeITWebApi.Service.Converter;

internal class PermissionsJsonConverter : JsonConverter<PermissionsModel?>
{
    public override PermissionsModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }
        if (reader.TokenType == JsonTokenType.String)
        {
            return null;
        }
        if (reader.TokenType == JsonTokenType.StartObject)
        {
            JsonTypeInfo<PermissionsModel> jsonTypeInfo = (JsonTypeInfo<PermissionsModel>)SourceGenerationContext.Default.GetTypeInfo(typeof(PermissionsModel))!;
            return JsonSerializer. Deserialize<PermissionsModel>(ref reader, jsonTypeInfo);
        }
        if (reader.TokenType == JsonTokenType.StartArray)
        {
            reader.Skip();
        }
        return null;
    }

    public override void Write(Utf8JsonWriter writer, PermissionsModel? value, JsonSerializerOptions options)
    {
        
    }
}
