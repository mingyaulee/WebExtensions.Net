namespace WebExtension.Net.Manifest
{
    // String Format Class
    /// <summary></summary>
    public class ExtensionURL : BaseStringFormat
    {
        private const string pattern = "strictRelativeUrl";

        /// <summary>Creates a new instance of <see cref="ExtensionURL" />.</summary>
        public ExtensionURL(string value) : base(value, pattern)
        {
        }
    }
}
