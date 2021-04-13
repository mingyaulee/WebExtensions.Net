namespace WebExtension.Net.Manifest
{
    // Multitype Class
    /// <summary></summary>
    public class OptionalPermissionOrOrigin
    {
        private readonly object currentValue = null;

        /// <summary>Creates a new instance of <see cref="OptionalPermissionOrOrigin" />.</summary>
        public OptionalPermissionOrOrigin()
        {
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}
