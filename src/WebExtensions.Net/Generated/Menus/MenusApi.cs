using System;
using System.Text.Json;
using System.Threading.Tasks;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Menus
{
    /// <inheritdoc />
    public partial class MenusApi : BaseApi, IMenusApi
    {
        private OnClickedEvent _onClicked;
        private Event _onHidden;
        private OnShownEvent _onShown;

        /// <summary>Creates a new instance of <see cref="MenusApi" />.</summary>
        /// <param name="webExtensionsJSRuntime">Web Extension JS Runtime</param>
        public MenusApi(IWebExtensionsJSRuntime webExtensionsJSRuntime) : base(webExtensionsJSRuntime, "menus")
        {
        }

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
                    InitializeProperty("onClicked", _onClicked);
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
                    InitializeProperty("onHidden", _onHidden);
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
                    InitializeProperty("onShown", _onShown);
                }
                return _onShown;
            }
        }

        /// <inheritdoc />
        public virtual ValueTask<CreateReturnType> Create(CreateProperties createProperties, Action callback)
        {
            return InvokeAsync<CreateReturnType>("create", createProperties, callback);
        }

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> GetTargetElement(int targetElementId)
        {
            return InvokeAsync<JsonElement>("getTargetElement", targetElementId);
        }

        /// <inheritdoc />
        public virtual ValueTask OverrideContext(ContextOptions contextOptions)
        {
            return InvokeVoidAsync("overrideContext", contextOptions);
        }

        /// <inheritdoc />
        public virtual ValueTask Refresh()
        {
            return InvokeVoidAsync("refresh");
        }

        /// <inheritdoc />
        public virtual ValueTask Remove(int menuItemId)
        {
            return InvokeVoidAsync("remove", menuItemId);
        }

        /// <inheritdoc />
        public virtual ValueTask Remove(string menuItemId)
        {
            return InvokeVoidAsync("remove", menuItemId);
        }

        /// <inheritdoc />
        public virtual ValueTask RemoveAll()
        {
            return InvokeVoidAsync("removeAll");
        }

        /// <inheritdoc />
        public virtual ValueTask Update(int id, UpdateProperties updateProperties)
        {
            return InvokeVoidAsync("update", id, updateProperties);
        }

        /// <inheritdoc />
        public virtual ValueTask Update(string id, UpdateProperties updateProperties)
        {
            return InvokeVoidAsync("update", id, updateProperties);
        }
    }
}
