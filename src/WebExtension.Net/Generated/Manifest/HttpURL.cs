namespace WebExtension.Net.Manifest
{
    // String Format Class
    /// <summary></summary>
    public class HttpURL : BaseStringFormat
    {
        private const string pattern = "url";

        /// <summary>Creates a new instance of <see cref="HttpURL" />.</summary>
        public HttpURL(string value) : base(value, pattern)
        {
        }
    }
}
