namespace WebExtension.Net.Manifest
{
    // Multitype Class
    /// <summary>Mostly unrestricted match patterns for privileged add-ons. This should technically be rejected for unprivileged add-ons, but, reasons. The MatchPattern class will still refuse privileged schemes for those extensions.</summary>
    public class MatchPatternUnestricted
    {
        private readonly string valueString;
        private readonly object currentValue = null;

        /// <summary>Creates a new instance of <see cref="MatchPatternUnestricted" />.</summary>
        /// <param name="value">The value.</param>
        public MatchPatternUnestricted(string value)
        {
            valueString = value;
            currentValue = value;
        }

        /// <summary>Converts from <see cref="MatchPatternUnestricted" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(MatchPatternUnestricted value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="MatchPatternUnestricted" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator MatchPatternUnestricted(string value) => new(value);

        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}
