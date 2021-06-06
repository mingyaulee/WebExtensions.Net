namespace WebExtensions.Net
{
    /// <summary>
    /// Base API class.
    /// </summary>
    public class BaseApi : BaseObject
    {
        /// <summary>
        /// Gets the WebExtensionsJsRuntime instance.
        /// </summary>
        protected new IWebExtensionsJSRuntime webExtensionsJSRuntime;

        internal BaseApi(IWebExtensionsJSRuntime webExtensionsJSRuntime, string apiNamespace)
        {
            this.webExtensionsJSRuntime = webExtensionsJSRuntime;
            Initialize(webExtensionsJSRuntime, "browser", apiNamespace);
        }
    }
}
