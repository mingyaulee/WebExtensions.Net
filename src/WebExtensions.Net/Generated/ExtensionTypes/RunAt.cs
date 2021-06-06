using System.Text.Json.Serialization;

namespace WebExtension.Net.ExtensionTypes
{
    /// <summary>The soonest that the JavaScript or CSS will be injected into the tab.</summary>
    [JsonConverter(typeof(EnumStringConverter<RunAt>))]
    public enum RunAt
    {
        /// <summary>document_start</summary>
        [EnumValue("document_start")]
        DocumentStart,

        /// <summary>document_end</summary>
        [EnumValue("document_end")]
        DocumentEnd,

        /// <summary>document_idle</summary>
        [EnumValue("document_idle")]
        DocumentIdle,
    }
}
