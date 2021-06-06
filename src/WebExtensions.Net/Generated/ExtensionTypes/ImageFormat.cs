using System.Text.Json.Serialization;

namespace WebExtensions.Net.ExtensionTypes
{
    /// <summary>The format of an image.</summary>
    [JsonConverter(typeof(EnumStringConverter<ImageFormat>))]
    public enum ImageFormat
    {
        /// <summary>jpeg</summary>
        [EnumValue("jpeg")]
        Jpeg,

        /// <summary>png</summary>
        [EnumValue("png")]
        Png,
    }
}
