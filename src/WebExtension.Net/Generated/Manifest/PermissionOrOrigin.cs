namespace WebExtension.Net.Manifest
{
    // Multitype Class
    /// <summary></summary>
    public class PermissionOrOrigin
    {
        private readonly object currentValue = null;

        /// <summary>Creates a new instance of <see cref="PermissionOrOrigin" />.</summary>
        public PermissionOrOrigin()
        {
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}
