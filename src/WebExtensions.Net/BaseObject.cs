using JsBind.Net;

namespace WebExtensions.Net
{
    /// <summary>
    /// Base object returned from JavaScript.
    /// </summary>
    public class BaseObject : ObjectBindingBase<BaseObject>
    {
        internal void Initialize(IJsRuntimeAdapter jsRuntime, string accessPath)
        {
            SetAccessPath(accessPath);
            Initialize(jsRuntime);
        }
    }
}
