using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<OptionalDataCollectionPermissionType2>))]
    public enum OptionalDataCollectionPermissionType2
    {
        /// <summary>technicalAndInteraction</summary>
        [EnumValue("technicalAndInteraction")]
        TechnicalAndInteraction,
    }
}
