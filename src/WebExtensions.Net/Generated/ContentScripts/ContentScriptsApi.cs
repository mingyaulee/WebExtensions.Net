using System.Threading.Tasks;

namespace WebExtension.Net.ContentScripts
{
    /// <inheritdoc />
    public partial class ContentScriptsApi : BaseApi, IContentScriptsApi
    {
        /// <summary>Creates a new instance of <see cref="ContentScriptsApi" />.</summary>
        /// <param name="webExtensionJSRuntime">Web Extension JS Runtime</param>
        public ContentScriptsApi(IWebExtensionJSRuntime webExtensionJSRuntime) : base(webExtensionJSRuntime, "contentScripts")
        {
        }

        /// <inheritdoc />
        public virtual ValueTask Register(RegisteredContentScriptOptions contentScriptOptions)
        {
            return InvokeVoidAsync("register", contentScriptOptions);
        }
    }
}
