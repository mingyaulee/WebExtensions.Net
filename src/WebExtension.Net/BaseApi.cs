namespace WebExtension.Net
{
    /// <summary>
    /// Base API class.
    /// </summary>
    public class BaseApi : BaseObject
    {
        /// <summary>
        /// Gets the WebExtensionJsRuntime instance.
        /// </summary>
        protected new IWebExtensionJSRuntime webExtensionJSRuntime;

        internal BaseApi(IWebExtensionJSRuntime webExtensionJSRuntime, string apiNamespace)
        {
            this.webExtensionJSRuntime = webExtensionJSRuntime;
            Initialize(webExtensionJSRuntime, "browser", apiNamespace);
        }
    }
}
