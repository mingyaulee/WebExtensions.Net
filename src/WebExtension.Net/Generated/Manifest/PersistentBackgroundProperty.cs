namespace WebExtension.Net.Manifest
{
    // Multitype Class
    /// <summary></summary>
    public class PersistentBackgroundProperty
    {
        private readonly bool valueBool;
        private readonly object currentValue = null;

        /// <summary>Creates a new instance of <see cref="PersistentBackgroundProperty" />.</summary>
        /// <param name="value">The value.</param>
        public PersistentBackgroundProperty(bool value)
        {
            valueBool = value;
            currentValue = value;
        }

        /// <summary>Converts from <see cref="PersistentBackgroundProperty" /> to <see cref="bool" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator bool(PersistentBackgroundProperty value) => value.valueBool;

        /// <summary>Converts from <see cref="bool" /> to <see cref="PersistentBackgroundProperty" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator PersistentBackgroundProperty(bool value) => new(value);

        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}
