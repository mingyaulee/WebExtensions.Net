using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.I18n
{
    [JsonConverter(typeof(MultiTypeJsonConverter<LanguageCode>))]
    public sealed partial class LanguageCode : BaseMultiTypeObject, IEquatable<LanguageCode>
    {
        private readonly string valueString;

        /// <summary>The ISO-639-1 code for the language.</summary>
        public string Code1
        {
            get;
        }

        /// <summary>The ISO-639-2 code for the language.</summary>
        public string Code2
        {
            get;
        }

        /// <summary>Some nonstandard code for the language.</summary>
        public string CodeOther
        {
            get;
        }

        /// <summary>The name of the language.</summary>
        public string Name
        {
            get;
        }

        /// <summary>Creates a new instance of <see cref="LanguageCode" />.</summary>
        /// <param name="value">The value.</param>
        public LanguageCode(string value) : base(value, typeof(string))
        {
            valueString = value;
            var matchingLanguageCode = GetMatchingLanguageCode(value);
            Code1 = matchingLanguageCode?.Code1;
            Code2 = matchingLanguageCode?.Code2;
            CodeOther = matchingLanguageCode?.CodeOther;
            Name = matchingLanguageCode?.Name ?? value;
        }

        internal LanguageCode(string code1, string code2, string codeOther, string name) : base(code1 ?? code2 ?? codeOther ?? name, typeof(string))
        {
            valueString = code1;
            Code1 = code1;
            Code2 = code2;
            CodeOther = codeOther;
            Name = name;
        }

        /// <summary>Converts from <see cref="LanguageCode" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(LanguageCode value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="LanguageCode" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator LanguageCode(string value) => new(value);

        /// <summary>
        /// Determines if the language codes are equal.
        /// </summary>
        /// <param name="languageCode1">The first language code.</param>
        /// <param name="languageCode2">The second language code.</param>
        /// <returns>True if the language codes are equal, otherwise false.</returns>
        public static bool operator ==(LanguageCode languageCode1, LanguageCode languageCode2) => LanguageCodesEqual(languageCode1, languageCode2);

        /// <summary>
        /// Determines if the language codes are not equal.
        /// </summary>
        /// <param name="languageCode1">The first language code.</param>
        /// <param name="languageCode2">The second language code.</param>
        /// <returns>True if the language codes are not equal, otherwise false.</returns>
        public static bool operator !=(LanguageCode languageCode1, LanguageCode languageCode2) => !LanguageCodesEqual(languageCode1, languageCode2);

        /// <inheritdoc />
        public override bool Equals(object obj)
            => obj is LanguageCode languageCode && LanguageCodesEqual(this, languageCode);

        /// <inheritdoc />
        public bool Equals(LanguageCode other) => LanguageCodesEqual(this, other);

        /// <inheritdoc />
        public override int GetHashCode() => Name.GetHashCode();

        private static bool LanguageCodesEqual(LanguageCode languageCode1, LanguageCode languageCode2) => languageCode1.Name == languageCode2.Name;

        private static LanguageCode GetMatchingLanguageCode(string value)
            => LanguageDictionary.Values.FirstOrDefault(languageCode => (languageCode.Code1 is not null && languageCode.Code1.Equals(value, StringComparison.OrdinalIgnoreCase)) ||
                (languageCode.Code2 is not null && languageCode.Code2.Equals(value, StringComparison.OrdinalIgnoreCase)) ||
                (languageCode.CodeOther is not null && languageCode.CodeOther.Equals(value, StringComparison.OrdinalIgnoreCase)) ||
                (languageCode.Name is not null && languageCode.Name.Equals(value, StringComparison.OrdinalIgnoreCase)));
    }
}
