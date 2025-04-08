namespace SnipeITWebApi.Service.Converter;

internal class NamedItemConverter : JsonConverter<NamedItemModel?>
{
    public override NamedItemModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }
        if (reader.TokenType == JsonTokenType.Number)
        {
            return new NamedItemModel() { Id = reader.GetInt32() };
        }
        if (reader.TokenType == JsonTokenType.StartObject)
        {
            JsonTypeInfo<NamedItemModel> jsonTypeInfo = (JsonTypeInfo<NamedItemModel>)SourceGenerationContext.Default.GetTypeInfo(typeof(NamedItemModel))!;
            return JsonSerializer.Deserialize<NamedItemModel>(ref reader, jsonTypeInfo);
        }
        return null;
    }

    public override void Write(Utf8JsonWriter writer, NamedItemModel? value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    //public override void WriteAsPropertyName(Utf8JsonWriter writer, NamedItemModel? value, JsonSerializerOptions options)
    //{
    //    //if (value != null)
    //    //{
    //    //    writer.WriteStartObject();
    //    //    writer.WriteNumber("id", value.Id);
    //    //    writer.WriteString("name", value.Name);
    //    //    writer.WriteEndObject();
    //    //}
    //}

}
