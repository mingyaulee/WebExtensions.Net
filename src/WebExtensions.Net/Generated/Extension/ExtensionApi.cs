using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtensions.Net.Extension
{
    /// <inheritdoc />
    public partial class ExtensionApi : BaseApi, IExtensionApi
    {
        /// <summary>Creates a new instance of <see cref="ExtensionApi" />.</summary>
        /// <param name="webExtensionsJSRuntime">Web Extension JS Runtime</param>
        public ExtensionApi(IWebExtensionsJSRuntime webExtensionsJSRuntime) : base(webExtensionsJSRuntime, "extension")
        {
        }

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> GetBackgroundPage()
        {
            return InvokeAsync<JsonElement>("getBackgroundPage");
        }

        /// <inheritdoc />
        [Obsolete("Please use $(ref:runtime.getURL).")]
        public virtual ValueTask<string> GetURL(string path)
        {
            return InvokeAsync<string>("getURL", path);
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<object>> GetViews(FetchProperties fetchProperties)
        {
            return InvokeAsync<IEnumerable<object>>("getViews", fetchProperties);
        }

        /// <inheritdoc />
        public virtual ValueTask<bool> GetInIncognitoContext()
        {
            return GetPropertyAsync<bool>("inIncognitoContext");
        }

        /// <inheritdoc />
        public virtual ValueTask<bool> IsAllowedFileSchemeAccess()
        {
            return InvokeAsync<bool>("isAllowedFileSchemeAccess");
        }

        /// <inheritdoc />
        public virtual ValueTask<bool> IsAllowedIncognitoAccess()
        {
            return InvokeAsync<bool>("isAllowedIncognitoAccess");
        }

        /// <inheritdoc />
        [Obsolete("Please use $(ref:runtime.lastError).")]
        public virtual ValueTask<LastError> GetLastError()
        {
            return GetPropertyAsync<LastError>("lastError");
        }
    }
}
