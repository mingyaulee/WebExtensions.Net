using System.Text.Json.Serialization;

namespace WebExtension.Net.WebRequest
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<TransportWeaknessReasons>))]
    public enum TransportWeaknessReasons
    {
        /// <summary>cipher</summary>
        [EnumValue("cipher")]
        Cipher,
    }
}
