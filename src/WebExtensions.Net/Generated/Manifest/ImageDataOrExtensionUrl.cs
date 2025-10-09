using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest
{
    // String Format Class
    /// <summary></summary>
    [JsonConverter(typeof(StringFormatJsonConverter<ImageDataOrExtensionUrl>))]
    public partial class ImageDataOrExtensionUrl(string value) : BaseStringFormat(value, FORMAT, PATTERN)
    {
        private const string FORMAT = "imageDataOrStrictRelativeUrl";
        private const string PATTERN = "";

        /// <summary>Converts from <see cref="ImageDataOrExtensionUrl" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(ImageDataOrExtensionUrl value) => value.Value;

        /// <summary>Converts from <see cref="string" /> to <see cref="ImageDataOrExtensionUrl" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator ImageDataOrExtensionUrl(string value) => new(value);
    }
}
