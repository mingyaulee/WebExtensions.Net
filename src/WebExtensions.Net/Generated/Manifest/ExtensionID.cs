using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest
{
    // Multitype Class
    /// <summary></summary>
    /// <param name="value">The value.</param>
    [JsonConverter(typeof(MultiTypeJsonConverter<ExtensionID>))]
    public partial class ExtensionID(string value) : BaseMultiTypeObject(value, typeof(string))
    {
        private readonly string valueString;

        /// <summary>Converts from <see cref="ExtensionID" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(ExtensionID value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="ExtensionID" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator ExtensionID(string value) => new(value);
    }
}
