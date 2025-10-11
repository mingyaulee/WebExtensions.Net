using JsBind.Net;

namespace WebExtensions.Net.ContentScripts;

/// <summary></summary>
[JsAccessPath("contentScripts")]
public partial interface IContentScriptsApi
{
    /// <summary>Register a content script programmatically</summary>
    /// <param name="contentScriptOptions"></param>
    [JsAccessPath("register")]
    void Register(RegisteredContentScriptOptions contentScriptOptions);
}
