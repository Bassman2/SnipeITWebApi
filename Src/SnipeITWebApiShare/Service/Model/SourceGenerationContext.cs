namespace SnipeITWebApi.Service.Model;

[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, WriteIndented = true, AllowTrailingCommas = true)]
//[JsonSerializable(typeof(ErrorMessageModel))]

[JsonSerializable(typeof(ListModel<HardwareModel>))]
[JsonSerializable(typeof(ListModel<CategoryModel>))]
[JsonSerializable(typeof(ListModel<ManufacturerModel>))]
[JsonSerializable(typeof(ListModel<ModelModel>))]

[JsonSerializable(typeof(ResultModel<HardwareModel>))]
[JsonSerializable(typeof(ResultModel<CategoryModel>))]
[JsonSerializable(typeof(ResultModel<ManufacturerModel>))]
[JsonSerializable(typeof(ResultModel<ModelModel>))]

internal partial class SourceGenerationContext  : JsonSerializerContext
{ }
