namespace WebExtension.Net.Manifest
{
    // Multitype Class
    /// <summary></summary>
    public class ExtensionID
    {
        private readonly string valueString;
        private readonly object currentValue = null;

        /// <summary>Creates a new instance of <see cref="ExtensionID" />.</summary>
        /// <param name="value">The value.</param>
        public ExtensionID(string value)
        {
            valueString = value;
            currentValue = value;
        }

        /// <summary>Converts from <see cref="ExtensionID" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(ExtensionID value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="ExtensionID" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator ExtensionID(string value) => new(value);

        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}
