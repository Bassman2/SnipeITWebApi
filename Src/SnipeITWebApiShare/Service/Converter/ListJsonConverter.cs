namespace SnipeITWebApi.Service.Converter;

internal class ListJsonConverter : JsonConverter<List<NamedItemModel>?>
{
    public override List<NamedItemModel>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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
            JsonTypeInfo<ListModel<NamedItemModel>> jsonTypeInfo = (JsonTypeInfo<ListModel<NamedItemModel>>)SourceGenerationContext.Default.GetTypeInfo(typeof(ListModel<NamedItemModel>))!;
            var res = JsonSerializer.Deserialize<ListModel<NamedItemModel>>(ref reader, jsonTypeInfo);
            return res?.Rows;
        }
        if (reader.TokenType == JsonTokenType.StartArray)
        {
            reader.Skip();
        }
        return null;
    }

    public override void Write(Utf8JsonWriter writer, List<NamedItemModel>? values, JsonSerializerOptions options)
    {
        if (values == null)
        {
            writer.WriteNullValue();
        }
        else
        {
            // write as array: "groups": [ 1, 4, 5 ]
            writer.WriteStartArray();
            foreach (var id in values.Select(i => i.Id))
            {
                writer.WriteNumberValue(id);
            }
            writer.WriteEndArray();
        }

    }
}
