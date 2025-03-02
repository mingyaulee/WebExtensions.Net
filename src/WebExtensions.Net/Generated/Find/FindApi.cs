using JsBind.Net;

namespace WebExtensions.Net.Find
{
    /// <inheritdoc />
    public partial class FindApi : BaseApi, IFindApi
    {
        /// <summary>Creates a new instance of <see cref="FindApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public FindApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "find"))
        {
        }

        /// <inheritdoc />
        public virtual void Find(string queryphrase, FindParams @params = null)
            => InvokeVoid("find", queryphrase, @params);

        /// <inheritdoc />
        public virtual void HighlightResults(HighlightResultsParams @params = null)
            => InvokeVoid("highlightResults", @params);

        /// <inheritdoc />
        public virtual void RemoveHighlighting(int? tabId = null)
            => InvokeVoid("removeHighlighting", tabId);
    }
}
