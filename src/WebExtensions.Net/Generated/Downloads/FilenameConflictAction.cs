using System.Text.Json.Serialization;

namespace WebExtensions.Net.Downloads
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<FilenameConflictAction>))]
    public enum FilenameConflictAction
    {
        /// <summary>uniquify</summary>
        [EnumValue("uniquify")]
        Uniquify,

        /// <summary>overwrite</summary>
        [EnumValue("overwrite")]
        Overwrite,

        /// <summary>prompt</summary>
        [EnumValue("prompt")]
        Prompt,
    }
}
