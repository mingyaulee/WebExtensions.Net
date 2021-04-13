namespace WebExtension.Net.Manifest
{
    // Multitype Class
    /// <summary>Same as MatchPattern above, but excludes 'all_urls'</summary>
    public class MatchPatternRestricted
    {
        private readonly string valueString;
        private readonly object currentValue = null;

        /// <summary>Creates a new instance of <see cref="MatchPatternRestricted" />.</summary>
        /// <param name="value">The value.</param>
        public MatchPatternRestricted(string value)
        {
            valueString = value;
            currentValue = value;
        }

        /// <summary>Converts from <see cref="MatchPatternRestricted" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(MatchPatternRestricted value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="MatchPatternRestricted" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator MatchPatternRestricted(string value) => new(value);

        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}
