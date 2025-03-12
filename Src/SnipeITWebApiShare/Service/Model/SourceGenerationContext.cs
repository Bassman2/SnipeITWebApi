namespace SnipeITWebApi.Service.Model;

[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, WriteIndented = true, AllowTrailingCommas = true)]
[JsonSerializable(typeof(ErrorMessageModel))]
[JsonSerializable(typeof(ListModel<HardwareModel>))]
[JsonSerializable(typeof(ListModel<CategoryModel>))]
internal partial class SourceGenerationContext  : JsonSerializerContext
{ }
