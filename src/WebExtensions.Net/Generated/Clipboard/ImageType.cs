using System.Text.Json.Serialization;

namespace WebExtensions.Net.Clipboard
{
    /// <summary>The type of imageData.</summary>
    [JsonConverter(typeof(EnumStringConverter<ImageType>))]
    public enum ImageType
    {
        /// <summary>jpeg</summary>
        [EnumValue("jpeg")]
        Jpeg,

        /// <summary>png</summary>
        [EnumValue("png")]
        Png,
    }
}
