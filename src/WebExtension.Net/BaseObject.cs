namespace WebExtension.Net
{
    /// <summary>
    /// Base object returned from JavaScript.
    /// </summary>
    public class BaseObject
    {
        /// <summary>
        /// Gets the WebExtensionJsRuntime instance.
        /// </summary>
        protected WebExtensionJSRuntime webExtensionJSRuntime;
        /// <summary>
        /// Sets the WebExtensionJsRuntime instance.
        /// </summary>
        /// <param name="webExtensionJSRuntime">The WebExtensionJsRuntime instance.</param>
        public void SetClient(WebExtensionJSRuntime webExtensionJSRuntime)
        {
            this.webExtensionJSRuntime = webExtensionJSRuntime;
        }
    }
}
