namespace WebExtension.Net.ExtensionTypes
{
    // Multitype Class
    /// <summary></summary>
    public class Date
    {
        private readonly string valueString;
        private readonly int valueInt;
        private readonly object currentValue = null;

        /// <summary>Creates a new instance of <see cref="Date" />.</summary>
        /// <param name="value">The value.</param>
        public Date(string value)
        {
            valueString = value;
            currentValue = value;
        }

        /// <summary>Creates a new instance of <see cref="Date" />.</summary>
        /// <param name="value">The value.</param>
        public Date(int value)
        {
            valueInt = value;
            currentValue = value;
        }

        /// <summary>Creates a new instance of <see cref="Date" />.</summary>
        /// <param name="value">The value.</param>
        public Date(object value)
        {
            currentValue = value;
        }

        /// <summary>Converts from <see cref="Date" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(Date value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="Date" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator Date(string value) => new(value);

        /// <summary>Converts from <see cref="Date" /> to <see cref="int" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator int(Date value) => value.valueInt;

        /// <summary>Converts from <see cref="int" /> to <see cref="Date" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator Date(int value) => new(value);

        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}
