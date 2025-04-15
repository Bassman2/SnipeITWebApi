namespace SnipeITWebApi;

[JsonConverter(typeof(JsonStringEnumConverter<Elements>))]
public enum Elements
{
    text,
    Textarea,
    Checkbox,
    Radio,
    Listbox
}
