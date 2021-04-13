namespace WebExtension.Net.ExtensionTypes
{
    // Multitype Class
    /// <summary></summary>
    public class ExtensionFileOrCode
    {
        private readonly object currentValue = null;

        /// <summary>Creates a new instance of <see cref="ExtensionFileOrCode" />.</summary>
        /// <param name="value">The value.</param>
        public ExtensionFileOrCode(object value)
        {
            currentValue = value;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}
