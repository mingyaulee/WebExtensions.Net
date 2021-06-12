using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest
{
    // Multitype Class
    /// <summary></summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<ExtensionID>))]
    public partial class ExtensionID : BaseMultiTypeObject
    {
        private readonly string valueString;

        /// <summary>Creates a new instance of <see cref="ExtensionID" />.</summary>
        /// <param name="value">The value.</param>
        public ExtensionID(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Converts from <see cref="ExtensionID" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(ExtensionID value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="ExtensionID" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator ExtensionID(string value) => new(value);
    }
}
