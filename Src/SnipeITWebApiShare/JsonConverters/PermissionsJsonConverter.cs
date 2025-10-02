namespace SnipeITWebApi.JsonConverters;

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
        if (value == null)
        {
            writer.WriteNullValue();
        }
        else
        {
            writer.WriteStartObject();

            writer.WriteBoolean("superuser", value?.Superuser ?? false);
            writer.WriteBoolean("admin", value?.Admin ?? false);
            writer.WriteBoolean("import", value?.Import ?? false);
            writer.WriteBoolean("reports.view", value?.ReportsView ?? false);
            writer.WriteBoolean("assets.view", value?.AssetsView ?? false);
            writer.WriteBoolean("assets.create", value?.AssetsCreate ?? false);
            writer.WriteBoolean("assets.edit", value?.AssetsEdit ?? false);
            writer.WriteBoolean("assets.delete", value?.AssetsDelete ?? false);
            writer.WriteBoolean("assets.checkin", value?.AssetsCheckin ?? false);
            writer.WriteBoolean("assets.checkout", value?.AssetsCheckout ?? false);
            writer.WriteBoolean("assets.audit", value?.AssetsAudit ?? false);
            writer.WriteBoolean("assets.view.requestable", value?.AssetsViewRequestable ?? false);
            writer.WriteBoolean("assets.view.encrypted_custom_fields", value?.AssetsViewEncryptedCustomFields ?? false);
            writer.WriteBoolean("accessories.view", value?.AccessoriesView ?? false);
            writer.WriteBoolean("accessories.create", value?.AccessoriesCreate ?? false);
            writer.WriteBoolean("accessories.edit", value?.AccessoriesEdit ?? false);
            writer.WriteBoolean("accessories.delete", value?.AccessoriesDelete ?? false);
            writer.WriteBoolean("accessories.checkout", value?.AccessoriesCheckout ?? false);
            writer.WriteBoolean("accessories.checkin", value?.AccessoriesCheckin ?? false);
            writer.WriteBoolean("accessories.files", value?.AccessoriesFiles ?? false);
            writer.WriteBoolean("consumables.view", value?.ConsumablesView ?? false);
            writer.WriteBoolean("consumables.create", value?.ConsumablesCreate ?? false);
            writer.WriteBoolean("consumables.edit", value?.ConsumablesEdit ?? false);
            writer.WriteBoolean("consumables.delete", value?.ConsumablesDelete ?? false);
            writer.WriteBoolean("consumables.checkout", value?.ConsumablesCheckout ?? false);
            writer.WriteBoolean("consumables.files", value?.ConsumablesFiles ?? false);
            writer.WriteBoolean("licenses.view", value?.LicensesView ?? false);
            writer.WriteBoolean("licenses.create", value?.LicensesCreate ?? false);
            writer.WriteBoolean("licenses.edit", value?.LicensesEdit ?? false);
            writer.WriteBoolean("licenses.delete", value?.LicensesDelete ?? false);
            writer.WriteBoolean("licenses.checkout", value?.LicensesCheckout ?? false);
            writer.WriteBoolean("licenses.keys", value?.LicensesKeys ?? false);
            writer.WriteBoolean("licenses.files", value?.LicensesFiles ?? false);
            writer.WriteBoolean("components.view", value?.ComponentsView ?? false);
            writer.WriteBoolean("components.create", value?.ComponentsCreate ?? false);
            writer.WriteBoolean("components.edit", value?.ComponentsEdit ?? false);
            writer.WriteBoolean("components.delete", value?.ComponentsDelete ?? false);
            writer.WriteBoolean("components.checkout", value?.ComponentsCheckout ?? false);
            writer.WriteBoolean("components.checkin", value?.ComponentsCheckin ?? false);
            writer.WriteBoolean("components.files", value?.ComponentsFiles ?? false);
            writer.WriteBoolean("kits.view", value?.KitsView ?? false);
            writer.WriteBoolean("kits.create", value?.KitsCreate ?? false);
            writer.WriteBoolean("kits.edit", value?.KitsEdit ?? false);
            writer.WriteBoolean("kits.delete", value?.KitsDelete ?? false);
            writer.WriteBoolean("users.view", value?.UsersView ?? false);

            // TODO



            writer.WriteEndObject();
        }
    }
}
