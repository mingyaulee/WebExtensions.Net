using System.Threading.Tasks;

namespace WebExtensions.Net.ContentScripts
{
    /// <inheritdoc />
    public partial class ContentScriptsApi : BaseApi, IContentScriptsApi
    {
        /// <summary>Creates a new instance of <see cref="ContentScriptsApi" />.</summary>
        /// <param name="webExtensionsJSRuntime">Web Extension JS Runtime</param>
        public ContentScriptsApi(IWebExtensionsJSRuntime webExtensionsJSRuntime) : base(webExtensionsJSRuntime, "contentScripts")
        {
        }

        /// <inheritdoc />
        public virtual ValueTask Register(RegisteredContentScriptOptions contentScriptOptions)
        {
            return InvokeVoidAsync("register", contentScriptOptions);
        }
    }
}
