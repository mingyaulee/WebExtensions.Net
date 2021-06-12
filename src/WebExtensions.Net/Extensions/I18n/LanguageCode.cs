using System.Text.Json.Serialization;

namespace WebExtensions.Net.I18n
{
    [JsonConverter(typeof(MultiTypeJsonConverter<LanguageCode>))]
    public partial class LanguageCode : BaseMultiTypeObject
    {
        private readonly string valueString;

        /// <summary>Creates a new instance of <see cref="LanguageCode" />.</summary>
        /// <param name="value">The value.</param>
        public LanguageCode(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Converts from <see cref="LanguageCode" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(LanguageCode value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="LanguageCode" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator LanguageCode(string value) => new(value);
    }
}
