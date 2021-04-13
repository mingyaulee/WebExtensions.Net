namespace WebExtension.Net.Manifest
{
    // String Format Class
    /// <summary></summary>
    public class KeyName : BaseStringFormat
    {
        private const string pattern = "manifestShortcutKey";

        /// <summary>Creates a new instance of <see cref="KeyName" />.</summary>
        public KeyName(string value) : base(value, pattern)
        {
        }
    }
}
