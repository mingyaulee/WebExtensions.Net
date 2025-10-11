using System.Text.Json.Serialization;

namespace WebExtensions.Net.NetworkStatus;

/// <summary>If known, the type of network connection that is avialable.</summary>
[JsonConverter(typeof(EnumStringConverter<NetworkLinkInfoType>))]
public enum NetworkLinkInfoType
{
    /// <summary>unknown</summary>
    [EnumValue("unknown")]
    Unknown,

    /// <summary>ethernet</summary>
    [EnumValue("ethernet")]
    Ethernet,

    /// <summary>usb</summary>
    [EnumValue("usb")]
    Usb,

    /// <summary>wifi</summary>
    [EnumValue("wifi")]
    Wifi,

    /// <summary>wimax</summary>
    [EnumValue("wimax")]
    Wimax,

    /// <summary>mobile</summary>
    [EnumValue("mobile")]
    Mobile,
}
