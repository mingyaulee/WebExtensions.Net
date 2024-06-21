using JsBind.Net;
using System.Threading.Tasks;

namespace WebExtensions.Net.ContentScripts
{
    /// <summary></summary>
    [JsAccessPath("contentScripts")]
    public partial interface IContentScriptsApi
    {
        /// <summary>Register a content script programmatically</summary>
        /// <param name="contentScriptOptions"></param>
        [JsAccessPath("register")]
        ValueTask Register(RegisteredContentScriptOptions contentScriptOptions);
    }
}
