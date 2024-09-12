using JsBind.Net;
using System.Threading.Tasks;

namespace WebExtensions.Net.BrowsingData
{
    /// <inheritdoc />
    public partial class BrowsingDataApi : BaseApi, IBrowsingDataApi
    {
        /// <summary>Creates a new instance of <see cref="BrowsingDataApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public BrowsingDataApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "browsingData"))
        {
        }

        /// <inheritdoc />
        public virtual ValueTask Remove(RemovalOptions options, DataTypeSet dataToRemove)
            => InvokeVoidAsync("remove", options, dataToRemove);

        /// <inheritdoc />
        public virtual ValueTask RemoveCache(RemovalOptions options)
            => InvokeVoidAsync("removeCache", options);

        /// <inheritdoc />
        public virtual ValueTask RemoveCookies(RemovalOptions options)
            => InvokeVoidAsync("removeCookies", options);

        /// <inheritdoc />
        public virtual ValueTask RemoveDownloads(RemovalOptions options)
            => InvokeVoidAsync("removeDownloads", options);

        /// <inheritdoc />
        public virtual ValueTask RemoveFormData(RemovalOptions options)
            => InvokeVoidAsync("removeFormData", options);

        /// <inheritdoc />
        public virtual ValueTask RemoveHistory(RemovalOptions options)
            => InvokeVoidAsync("removeHistory", options);

        /// <inheritdoc />
        public virtual ValueTask RemoveLocalStorage(RemovalOptions options)
            => InvokeVoidAsync("removeLocalStorage", options);

        /// <inheritdoc />
        public virtual ValueTask RemovePasswords(RemovalOptions options)
            => InvokeVoidAsync("removePasswords", options);

        /// <inheritdoc />
        public virtual ValueTask RemovePluginData(RemovalOptions options)
            => InvokeVoidAsync("removePluginData", options);

        /// <inheritdoc />
        public virtual ValueTask<Result> Settings()
            => InvokeAsync<Result>("settings");
    }
}
