namespace WebExtension.Net.Manifest
{
    // Multitype Class
    /// <summary></summary>
    public class IconImageData
    {
        private readonly object currentValue = null;

        /// <summary>Creates a new instance of <see cref="IconImageData" />.</summary>
        public IconImageData()
        {
        }

        /// <summary>Creates a new instance of <see cref="IconImageData" />.</summary>
        /// <param name="value">The value.</param>
        public IconImageData(object value)
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
