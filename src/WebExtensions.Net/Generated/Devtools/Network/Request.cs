using JsBind.Net;
using System;
using System.Threading.Tasks;

namespace WebExtensions.Net.Devtools.Network;

// Type Class
/// <summary>Represents a network request for a document resource (script, image and so on). See HAR Specification for reference.</summary>
[BindAllProperties]
public partial class Request : BaseObject
{
    /// <summary>Returns content of the response body.</summary>
    /// <param name="callback">A function that receives the response body when the request completes.</param>
    [JsAccessPath("getContent")]
    public virtual ValueTask GetContent(Action<string, string> callback)
        => InvokeVoidAsync("getContent", callback);
}
