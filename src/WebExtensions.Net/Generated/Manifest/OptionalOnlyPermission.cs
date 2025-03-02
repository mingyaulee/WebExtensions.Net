using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<OptionalOnlyPermission>))]
    public enum OptionalOnlyPermission
    {
    }
}
