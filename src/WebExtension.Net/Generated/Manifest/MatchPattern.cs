namespace WebExtension.Net.Manifest
{
    // Multitype Class
    /// <summary></summary>
    public class MatchPattern
    {
        private readonly string valueString;
        private readonly object currentValue = null;

        /// <summary>Creates a new instance of <see cref="MatchPattern" />.</summary>
        public MatchPattern()
        {
        }

        /// <summary>Creates a new instance of <see cref="MatchPattern" />.</summary>
        /// <param name="value">The value.</param>
        public MatchPattern(string value)
        {
            valueString = value;
            currentValue = value;
        }

        /// <summary>Converts from <see cref="MatchPattern" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(MatchPattern value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="MatchPattern" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator MatchPattern(string value) => new(value);

        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}
