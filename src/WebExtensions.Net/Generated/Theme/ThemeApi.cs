using JsBind.Net;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Theme
{
    /// <inheritdoc />
    public partial class ThemeApi : BaseApi, IThemeApi
    {
        private OnUpdatedEvent _onUpdated;

        /// <summary>Creates a new instance of <see cref="ThemeApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public ThemeApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "theme"))
        {
        }

        /// <inheritdoc />
        public OnUpdatedEvent OnUpdated
        {
            get
            {
                if (_onUpdated is null)
                {
                    _onUpdated = new OnUpdatedEvent();
                    _onUpdated.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onUpdated"));
                }
                return _onUpdated;
            }
        }

        /// <inheritdoc />
        public virtual void GetCurrent(int? windowId = null)
            => InvokeVoid("getCurrent", windowId);

        /// <inheritdoc />
        public virtual void Reset(int? windowId = null)
            => InvokeVoid("reset", windowId);

        /// <inheritdoc />
        public virtual void Update(ThemeType details)
            => InvokeVoid("update", details);

        /// <inheritdoc />
        public virtual void Update(int? windowId, ThemeType details)
            => InvokeVoid("update", windowId, details);
    }
}
