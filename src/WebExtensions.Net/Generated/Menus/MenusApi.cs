using JsBind.Net;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Menus
{
    /// <inheritdoc />
    /// <param name="jsRuntime">The JS runtime adapter.</param>
    /// <param name="accessPath">The base API access path.</param>
    public partial class MenusApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "menus")), IMenusApi
    {
        private OnClickedEvent _onClicked;
        private Event _onHidden;
        private OnShownEvent _onShown;

        /// <inheritdoc />
        public int ACTION_MENU_TOP_LEVEL_LIMIT => 6;

        /// <inheritdoc />
        public OnClickedEvent OnClicked
        {
            get
            {
                if (_onClicked is null)
                {
                    _onClicked = new OnClickedEvent();
                    _onClicked.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onClicked"));
                }
                return _onClicked;
            }
        }

        /// <inheritdoc />
        public Event OnHidden
        {
            get
            {
                if (_onHidden is null)
                {
                    _onHidden = new Event();
                    _onHidden.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onHidden"));
                }
                return _onHidden;
            }
        }

        /// <inheritdoc />
        public OnShownEvent OnShown
        {
            get
            {
                if (_onShown is null)
                {
                    _onShown = new OnShownEvent();
                    _onShown.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onShown"));
                }
                return _onShown;
            }
        }

        /// <inheritdoc />
        public virtual CreateReturnType Create(CreateProperties createProperties, Action callback = null)
            => Invoke<CreateReturnType>("create", createProperties, callback);

        /// <inheritdoc />
        public virtual JsonElement GetTargetElement(int targetElementId)
            => Invoke<JsonElement>("getTargetElement", targetElementId);

        /// <inheritdoc />
        public virtual void OverrideContext(ContextOptions contextOptions)
            => InvokeVoid("overrideContext", contextOptions);

        /// <inheritdoc />
        public virtual void Refresh()
            => InvokeVoid("refresh");

        /// <inheritdoc />
        public virtual ValueTask Remove(int menuItemId)
            => InvokeVoidAsync("remove", menuItemId);

        /// <inheritdoc />
        public virtual ValueTask Remove(string menuItemId)
            => InvokeVoidAsync("remove", menuItemId);

        /// <inheritdoc />
        public virtual ValueTask RemoveAll()
            => InvokeVoidAsync("removeAll");

        /// <inheritdoc />
        public virtual ValueTask Update(int id, UpdateProperties updateProperties)
            => InvokeVoidAsync("update", id, updateProperties);

        /// <inheritdoc />
        public virtual ValueTask Update(string id, UpdateProperties updateProperties)
            => InvokeVoidAsync("update", id, updateProperties);
    }
}
