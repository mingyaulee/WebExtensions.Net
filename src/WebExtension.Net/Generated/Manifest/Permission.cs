namespace WebExtension.Net.Manifest
{
    // Multitype Class
    /// <summary></summary>
    public class Permission
    {
        private readonly object currentValue = null;

        /// <summary>Creates a new instance of <see cref="Permission" />.</summary>
        public Permission()
        {
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}
