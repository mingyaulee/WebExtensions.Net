using JsBind.Net;

namespace WebExtensions.Net.Find;

/// <inheritdoc />
/// <param name="jsRuntime">The JS runtime adapter.</param>
/// <param name="accessPath">The base API access path.</param>
public partial class FindApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "find")), IFindApi
{
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
