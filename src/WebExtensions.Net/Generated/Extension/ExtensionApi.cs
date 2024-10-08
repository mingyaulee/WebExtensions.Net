using JsBind.Net;
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
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public ExtensionApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "extension"))
        {
        }

        /// <inheritdoc />
        public bool? InIncognitoContext => GetProperty<bool?>("inIncognitoContext");

        /// <inheritdoc />
        [Obsolete("Please use $(ref:runtime.lastError).")]
        public LastError LastError => GetProperty<LastError>("lastError");

        /// <inheritdoc />
        public virtual JsonElement GetBackgroundPage()
            => Invoke<JsonElement>("getBackgroundPage");

        /// <inheritdoc />
        [Obsolete("Please use $(ref:runtime.getURL).")]
        public virtual string GetURL(string path)
            => Invoke<string>("getURL", path);

        /// <inheritdoc />
        public virtual IEnumerable<object> GetViews(FetchProperties fetchProperties = null)
            => Invoke<IEnumerable<object>>("getViews", fetchProperties);

        /// <inheritdoc />
        public virtual ValueTask<bool> IsAllowedFileSchemeAccess()
            => InvokeAsync<bool>("isAllowedFileSchemeAccess");

        /// <inheritdoc />
        public virtual ValueTask<bool> IsAllowedIncognitoAccess()
            => InvokeAsync<bool>("isAllowedIncognitoAccess");
    }
}
