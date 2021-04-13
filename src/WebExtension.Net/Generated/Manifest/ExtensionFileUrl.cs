namespace WebExtension.Net.Manifest
{
    // String Format Class
    /// <summary></summary>
    public class ExtensionFileUrl : BaseStringFormat
    {
        private const string pattern = "strictRelativeUrl";

        /// <summary>Creates a new instance of <see cref="ExtensionFileUrl" />.</summary>
        public ExtensionFileUrl(string value) : base(value, pattern)
        {
        }
    }
}
