using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.Cookies
{
    /// <inheritdoc />
    /// <param name="jsRuntime">The JS runtime adapter.</param>
    /// <param name="accessPath">The base API access path.</param>
    public partial class CookiesApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "cookies")), ICookiesApi
    {
        private OnChangedEvent _onChanged;

        /// <inheritdoc />
        public OnChangedEvent OnChanged
        {
            get
            {
                if (_onChanged is null)
                {
                    _onChanged = new OnChangedEvent();
                    _onChanged.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onChanged"));
                }
                return _onChanged;
            }
        }

        /// <inheritdoc />
        public virtual ValueTask<Cookie> Get(GetDetails details)
            => InvokeAsync<Cookie>("get", details);

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<Cookie>> GetAll(GetAllDetails details)
            => InvokeAsync<IEnumerable<Cookie>>("getAll", details);

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<CookieStore>> GetAllCookieStores()
            => InvokeAsync<IEnumerable<CookieStore>>("getAllCookieStores");

        /// <inheritdoc />
        public virtual ValueTask<CallbackDetails> Remove(RemoveDetails details)
            => InvokeAsync<CallbackDetails>("remove", details);

        /// <inheritdoc />
        public virtual ValueTask<Cookie> Set(SetDetails details)
            => InvokeAsync<Cookie>("set", details);
    }
}
