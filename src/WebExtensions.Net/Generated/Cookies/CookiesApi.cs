using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.Cookies
{
    /// <inheritdoc />
    public partial class CookiesApi : BaseApi, ICookiesApi
    {
        private OnChangedEvent _onChanged;

        /// <summary>Creates a new instance of <see cref="CookiesApi" />.</summary>
        /// <param name="webExtensionsJSRuntime">Web Extension JS Runtime</param>
        public CookiesApi(IWebExtensionsJSRuntime webExtensionsJSRuntime) : base(webExtensionsJSRuntime, "cookies")
        {
        }

        /// <inheritdoc />
        public OnChangedEvent OnChanged
        {
            get
            {
                if (_onChanged is null)
                {
                    _onChanged = new OnChangedEvent();
                    InitializeProperty("onChanged", _onChanged);
                }
                return _onChanged;
            }
        }

        /// <inheritdoc />
        public virtual ValueTask<Cookie> Get(GetDetails details)
        {
            return InvokeAsync<Cookie>("get", details);
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<Cookie>> GetAll(GetAllDetails details)
        {
            return InvokeAsync<IEnumerable<Cookie>>("getAll", details);
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<CookieStore>> GetAllCookieStores()
        {
            return InvokeAsync<IEnumerable<CookieStore>>("getAllCookieStores");
        }

        /// <inheritdoc />
        public virtual ValueTask<CallbackDetails> Remove(RemoveDetails details)
        {
            return InvokeAsync<CallbackDetails>("remove", details);
        }

        /// <inheritdoc />
        public virtual ValueTask<Cookie> Set(SetDetails details)
        {
            return InvokeAsync<Cookie>("set", details);
        }
    }
}
