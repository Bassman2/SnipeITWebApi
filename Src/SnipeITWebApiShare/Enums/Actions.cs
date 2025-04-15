namespace SnipeITWebApi;

[Flags]
public enum Actions
{
    Checkout = 0x01,
    Checkin = 0x02,
    Update = 0x04,
    Restore = 0x08,
    Delete = 0x10,
    Clone = 0x20
}
