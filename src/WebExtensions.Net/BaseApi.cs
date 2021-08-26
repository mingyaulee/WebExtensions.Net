﻿using JsBind.Net;

namespace WebExtensions.Net
{
    /// <summary>
    /// Base API class.
    /// </summary>
    public class BaseApi : ObjectBindingBase<BaseApi>
    {
        internal BaseApi(IJsRuntimeAdapter jsRuntime, string apiNamespace)
        {
            SetAccessPath(apiNamespace);
            Initialize(jsRuntime);
        }
    }
}
