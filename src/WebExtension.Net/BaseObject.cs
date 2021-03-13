namespace WebExtension.Net
{
    public class BaseObject
    {
        protected WebExtensionJSRuntime webExtensionJSRuntime;
        public void SetClient(WebExtensionJSRuntime webExtensionJSRuntime)
        {
            this.webExtensionJSRuntime = webExtensionJSRuntime;
        }
    }
}
