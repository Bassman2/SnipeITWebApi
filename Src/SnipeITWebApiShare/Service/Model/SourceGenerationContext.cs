namespace SnipeITWebApi.Service.Model;

[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, WriteIndented = true, AllowTrailingCommas = true)]
[JsonSerializable(typeof(ListModel<HardwareModel>))]
[JsonSerializable(typeof(HardwareModel))]

internal partial class SourceGenerationContext  : JsonSerializerContext
{ }
