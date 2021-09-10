using JsBind.Net;

namespace WebExtensions.Net
{
    /// <summary>
    /// Base object returned from JavaScript.
    /// </summary>
    public class BaseObject : ObjectBindingBase
    {
        internal void Initialize(IJsRuntimeAdapter jsRuntime, string accessPath)
        {
            SetAccessPath(accessPath);
            Initialize(jsRuntime);
        }
    }
}
