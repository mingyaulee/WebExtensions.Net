namespace WebExtension.Net
{
    /// <summary>
    /// Base API class.
    /// </summary>
    public class BaseAPI : BaseObject
    {
        /// <summary>
        /// Gets the WebExtensionJsRuntime instance.
        /// </summary>
        protected WebExtensionJSRuntime webExtensionJSRuntime;

        internal BaseAPI(WebExtensionJSRuntime webExtensionJSRuntime, string apiNamespace)
        {
            this.webExtensionJSRuntime = webExtensionJSRuntime;
            Initialize(webExtensionJSRuntime, "browser", apiNamespace);
        }
    }
}
