namespace WebExtension.Net.Manifest
{
    // String Format Class
    /// <summary></summary>
    public class ImageDataOrExtensionURL : BaseStringFormat
    {
        private const string pattern = "imageDataOrStrictRelativeUrl";

        /// <summary>Creates a new instance of <see cref="ImageDataOrExtensionURL" />.</summary>
        public ImageDataOrExtensionURL(string value) : base(value, pattern)
        {
        }
    }
}
