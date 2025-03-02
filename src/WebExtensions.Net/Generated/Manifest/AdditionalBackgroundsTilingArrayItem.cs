using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<AdditionalBackgroundsTilingArrayItem>))]
    public enum AdditionalBackgroundsTilingArrayItem
    {
        /// <summary>no-repeat</summary>
        [EnumValue("no-repeat")]
        NoRepeat,

        /// <summary>repeat</summary>
        [EnumValue("repeat")]
        Repeat,

        /// <summary>repeat-x</summary>
        [EnumValue("repeat-x")]
        RepeatX,

        /// <summary>repeat-y</summary>
        [EnumValue("repeat-y")]
        RepeatY,
    }
}
