using System.Collections.Generic;

namespace WebExtension.Net.Manifest
{
    // Multitype Class
    /// <summary></summary>
    public class ThemeColor
    {
        private readonly string valueString;
        private readonly object currentValue = null;

        /// <summary>Creates a new instance of <see cref="ThemeColor" />.</summary>
        /// <param name="value">The value.</param>
        public ThemeColor(string value)
        {
            valueString = value;
            currentValue = value;
        }

        /// <summary>Creates a new instance of <see cref="ThemeColor" />.</summary>
        /// <param name="value">The value.</param>
        public ThemeColor(IEnumerable<int> value)
        {
            currentValue = value;
        }

        /// <summary>Creates a new instance of <see cref="ThemeColor" />.</summary>
        /// <param name="value">The value.</param>
        public ThemeColor(IEnumerable<double> value)
        {
            currentValue = value;
        }

        /// <summary>Converts from <see cref="ThemeColor" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(ThemeColor value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="ThemeColor" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator ThemeColor(string value) => new(value);

        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}
