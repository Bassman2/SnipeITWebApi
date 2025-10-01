namespace SnipeITWebApi.Service.Converter;


/// <summary>
/// Custom converter for deserializing a Dictionary&lt;TKey, TValue&gt; that might be provided as an empty array.
/// If the JSON token is an empty array, returns an empty dictionary.
/// Otherwise, if the token is an object, deserializes it normally.
/// </summary>
public class DictionaryOrEmptyArrayConverter<TKey, TValue> : JsonConverter<Dictionary<TKey, TValue>> where TKey : notnull
{
    /// <summary>
    /// Reads and deserializes a <see cref="Dictionary{TKey, TValue}"/> from JSON.
    /// If the JSON token is an empty array, returns an empty dictionary.
    /// If the token is an object, deserializes it normally.
    /// </summary>
    /// <param name="reader">The reader to read from.</param>
    /// <param name="typeToConvert">The type to convert.</param>
    /// <param name="options">Serializer options.</param>
    /// <returns>The deserialized dictionary.</returns>
    public override Dictionary<TKey, TValue> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.StartObject)
        {
            JsonTypeInfo<Dictionary<TKey, TValue>> jsonTypeInfo = (JsonTypeInfo<Dictionary<TKey, TValue>>)SourceGenerationContext.Default.GetTypeInfo(typeof(Dictionary<TKey, TValue>))!;
            var dictionary = JsonSerializer.Deserialize< Dictionary < TKey, TValue>> (ref reader, jsonTypeInfo);


            //var dictionary = JsonSerializer.Deserialize<Dictionary<TKey, TValue>>(ref reader, options);
            return dictionary ?? [];
        }
        else if (reader.TokenType == JsonTokenType.StartArray)
        {
            //// Deserialize the array. If non-empty, throw exception to indicate unexpected format.
            //var list = JsonSerializer.Deserialize<List<TValue>>(ref reader, options);

            JsonTypeInfo<List<TValue>> jsonTypeInfo = (JsonTypeInfo<List<TValue>>)SourceGenerationContext.Default.GetTypeInfo(typeof(List<TValue>))!;
            var _ = JsonSerializer.Deserialize<List<TValue>>(ref reader, jsonTypeInfo);


            //if (list != null && list.Count > 0)
            //{
            //    throw new JsonException("Expected empty array when converting to dictionary.");
            //}
            return [];
        }
        else
        {
            throw new JsonException($"Unexpected token {reader.TokenType} when parsing dictionary.");
        }
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, Dictionary<TKey, TValue> value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
