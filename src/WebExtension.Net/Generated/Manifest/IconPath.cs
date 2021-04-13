namespace WebExtension.Net.Manifest
{
    // Multitype Class
    /// <summary></summary>
    public class IconPath
    {
        private readonly object currentValue = null;

        /// <summary>Creates a new instance of <see cref="IconPath" />.</summary>
        public IconPath()
        {
        }

        /// <summary>Creates a new instance of <see cref="IconPath" />.</summary>
        /// <param name="value">The value.</param>
        public IconPath(object value)
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
