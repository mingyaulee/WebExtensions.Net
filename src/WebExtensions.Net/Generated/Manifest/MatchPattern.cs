using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest
{
    // Multitype Class
    /// <summary></summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<MatchPattern>))]
    public class MatchPattern : BaseMultiTypeObject
    {
        private readonly string valueString;
        private readonly MatchPatternRestricted valueMatchPatternRestricted;
        private readonly MatchPatternUnestricted valueMatchPatternUnestricted;

        /// <summary>Creates a new instance of <see cref="MatchPattern" />.</summary>
        /// <param name="value">The value.</param>
        public MatchPattern(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Creates a new instance of <see cref="MatchPattern" />.</summary>
        /// <param name="value">The value.</param>
        public MatchPattern(MatchPatternRestricted value) : base(value, typeof(MatchPatternRestricted))
        {
            valueMatchPatternRestricted = value;
        }

        /// <summary>Creates a new instance of <see cref="MatchPattern" />.</summary>
        /// <param name="value">The value.</param>
        public MatchPattern(MatchPatternUnestricted value) : base(value, typeof(MatchPatternUnestricted))
        {
            valueMatchPatternUnestricted = value;
        }

        /// <summary>Converts from <see cref="MatchPattern" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(MatchPattern value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="MatchPattern" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator MatchPattern(string value) => new(value);

        /// <summary>Converts from <see cref="MatchPattern" /> to <see cref="MatchPatternRestricted" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator MatchPatternRestricted(MatchPattern value) => value.valueMatchPatternRestricted;

        /// <summary>Converts from <see cref="MatchPatternRestricted" /> to <see cref="MatchPattern" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator MatchPattern(MatchPatternRestricted value) => new(value);

        /// <summary>Converts from <see cref="MatchPattern" /> to <see cref="MatchPatternUnestricted" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator MatchPatternUnestricted(MatchPattern value) => value.valueMatchPatternUnestricted;

        /// <summary>Converts from <see cref="MatchPatternUnestricted" /> to <see cref="MatchPattern" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator MatchPattern(MatchPatternUnestricted value) => new(value);
    }
}
