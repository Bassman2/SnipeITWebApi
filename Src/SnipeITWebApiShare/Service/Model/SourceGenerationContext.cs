﻿namespace SnipeITWebApi.Service.Model;

[JsonSourceGenerationOptions(
    JsonSerializerDefaults.Web,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, 
    WriteIndented = true, 
    AllowTrailingCommas = true,
    Converters = [ 
        //typeof(TextJsonConverter), 
        typeof(BooleanJsonConverter) ])]

[JsonSerializable(typeof(ResultModel))]
[JsonSerializable(typeof(PermissionsModel))]

[JsonSerializable(typeof(ListModel<NamedItemModel>))]

[JsonSerializable(typeof(ListModel<AccessoryModel>))]
//[JsonSerializable(typeof(ListModel<AssignedModel>))]
[JsonSerializable(typeof(ListModel<CategoryModel>))]
[JsonSerializable(typeof(ListModel<CompanyModel>))]
[JsonSerializable(typeof(ListModel<ComponentModel>))]
[JsonSerializable(typeof(ListModel<ConsumableModel>))]
[JsonSerializable(typeof(ListModel<DepartmentModel>))]
[JsonSerializable(typeof(ListModel<FieldModel>))]
[JsonSerializable(typeof(ListModel<FieldsetModel>))]
[JsonSerializable(typeof(ListModel<GroupModel>))]
[JsonSerializable(typeof(ListModel<HardwareModel>))]
[JsonSerializable(typeof(ListModel<LicenseModel>))]
[JsonSerializable(typeof(ListModel<LocationModel>))]
[JsonSerializable(typeof(ListModel<MaintenanceModel>))]
[JsonSerializable(typeof(ListModel<ManufacturerModel>))]
[JsonSerializable(typeof(ListModel<ModelModel>))]
[JsonSerializable(typeof(ListModel<StatusLabelModel>))]
[JsonSerializable(typeof(ListModel<SupplierModel>))]
[JsonSerializable(typeof(ListModel<UserModel>))]

//[JsonSerializable(typeof(ResultModel<AccessoryModel>))]
////[JsonSerializable(typeof(ResultModel<AssignedModel>))]
//[JsonSerializable(typeof(ResultModel<CategoryModel>))]
//[JsonSerializable(typeof(ResultModel<CompanyModel>))]
//[JsonSerializable(typeof(ResultModel<ComponentModel>))]
//[JsonSerializable(typeof(ResultModel<ConsumableModel>))]
//[JsonSerializable(typeof(ResultModel<DepartmentModel>))]
//[JsonSerializable(typeof(ResultModel<FieldModel>))]
//[JsonSerializable(typeof(ResultModel<FieldsetModel>))]
//[JsonSerializable(typeof(ResultModel<GroupModel>))]
//[JsonSerializable(typeof(ResultModel<HardwareModel>))]
//[JsonSerializable(typeof(ResultModel<LicenseModel>))]
//[JsonSerializable(typeof(ResultModel<LocationModel>))]
//[JsonSerializable(typeof(ResultModel<MaintenanceModel>))]
//[JsonSerializable(typeof(ResultModel<ManufacturerModel>))]
//[JsonSerializable(typeof(ResultModel<ModelModel>))]
//[JsonSerializable(typeof(ResultModel<StatusLabelModel>))]
//[JsonSerializable(typeof(ResultModel<SupplierModel>))]
//[JsonSerializable(typeof(ResultModel<UserModel>))]

[JsonSerializable(typeof(ResultModel<AccessoryChangeModel>))]
[JsonSerializable(typeof(ResultModel<CategoryChangeModel>))]
[JsonSerializable(typeof(ResultModel<CompanyChangeModel>))]
[JsonSerializable(typeof(ResultModel<ComponentChangeModel>))]
[JsonSerializable(typeof(ResultModel<ConsumableChangeModel>))]
[JsonSerializable(typeof(ResultModel<DepartmentChangeModel>))]
[JsonSerializable(typeof(ResultModel<FieldChangeModel>))]
[JsonSerializable(typeof(ResultModel<FieldsetChangeModel>))]
[JsonSerializable(typeof(ResultModel<GroupChangeModel>))]
[JsonSerializable(typeof(ResultModel<HardwareChangeModel>))]
[JsonSerializable(typeof(ResultModel<LicenseChangeModel>))]
[JsonSerializable(typeof(ResultModel<LocationChangeModel>))]
[JsonSerializable(typeof(ResultModel<MaintenanceChangeModel>))]
[JsonSerializable(typeof(ResultModel<ManufacturerChangeModel>))]
[JsonSerializable(typeof(ResultModel<ModelChangeModel>))]
[JsonSerializable(typeof(ResultModel<StatusLabelChangeModel>))]
[JsonSerializable(typeof(ResultModel<SupplierChangeModel>))]
[JsonSerializable(typeof(ResultModel<UserChangeModel>))]

[JsonSerializable(typeof(ResultModel<BaseChangeModel>))]

internal partial class SourceGenerationContext  : JsonSerializerContext
{ }
