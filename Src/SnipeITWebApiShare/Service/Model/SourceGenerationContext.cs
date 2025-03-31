namespace SnipeITWebApi.Service.Model;

[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, WriteIndented = true, AllowTrailingCommas = true)]
//[JsonSerializable(typeof(ErrorMessageModel))]

[JsonSerializable(typeof(ListModel<HardwareModel>))]
[JsonSerializable(typeof(ListModel<CategoryModel>))]
[JsonSerializable(typeof(ListModel<CompanyModel>))]
[JsonSerializable(typeof(ListModel<DepartmentModel>))]
[JsonSerializable(typeof(ListModel<ManufacturerModel>))]
[JsonSerializable(typeof(ListModel<ModelModel>))]
[JsonSerializable(typeof(ListModel<UserModel>))]

[JsonSerializable(typeof(ResultModel<HardwareModel>))]
[JsonSerializable(typeof(ResultModel<CategoryModel>))]
[JsonSerializable(typeof(ResultModel<CompanyModel>))]
[JsonSerializable(typeof(ResultModel<DepartmentModel>))]
[JsonSerializable(typeof(ResultModel<ManufacturerModel>))]
[JsonSerializable(typeof(ResultModel<ModelModel>))]
[JsonSerializable(typeof(ResultModel<UserModel>))]

internal partial class SourceGenerationContext  : JsonSerializerContext
{ }
