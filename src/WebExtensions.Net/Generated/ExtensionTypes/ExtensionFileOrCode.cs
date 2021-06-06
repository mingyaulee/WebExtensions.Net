using System.Text.Json.Serialization;

namespace WebExtension.Net.ExtensionTypes
{
    // Multitype Class
    /// <summary></summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<ExtensionFileOrCode>))]
    public class ExtensionFileOrCode : BaseMultiTypeObject
    {
        private readonly ExtensionFile valueExtensionFile;
        private readonly ExtensionCode valueExtensionCode;

        /// <summary>Creates a new instance of <see cref="ExtensionFileOrCode" />.</summary>
        /// <param name="value">The value.</param>
        public ExtensionFileOrCode(ExtensionFile value) : base(value, typeof(ExtensionFile))
        {
            valueExtensionFile = value;
        }

        /// <summary>Creates a new instance of <see cref="ExtensionFileOrCode" />.</summary>
        /// <param name="value">The value.</param>
        public ExtensionFileOrCode(ExtensionCode value) : base(value, typeof(ExtensionCode))
        {
            valueExtensionCode = value;
        }

        /// <summary>Converts from <see cref="ExtensionFileOrCode" /> to <see cref="ExtensionFile" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator ExtensionFile(ExtensionFileOrCode value) => value.valueExtensionFile;

        /// <summary>Converts from <see cref="ExtensionFile" /> to <see cref="ExtensionFileOrCode" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator ExtensionFileOrCode(ExtensionFile value) => new(value);

        /// <summary>Converts from <see cref="ExtensionFileOrCode" /> to <see cref="ExtensionCode" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator ExtensionCode(ExtensionFileOrCode value) => value.valueExtensionCode;

        /// <summary>Converts from <see cref="ExtensionCode" /> to <see cref="ExtensionFileOrCode" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator ExtensionFileOrCode(ExtensionCode value) => new(value);
    }
}
