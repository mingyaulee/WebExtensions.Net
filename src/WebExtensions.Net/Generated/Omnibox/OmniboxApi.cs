using JsBind.Net;
using System.Threading.Tasks;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Omnibox
{
    /// <inheritdoc />
    public partial class OmniboxApi : BaseApi, IOmniboxApi
    {
        private Event _onInputCancelled;
        private OnInputChangedEvent _onInputChanged;
        private OnInputEnteredEvent _onInputEntered;
        private Event _onInputStarted;

        /// <summary>Creates a new instance of <see cref="OmniboxApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public OmniboxApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "omnibox"))
        {
        }

        /// <inheritdoc />
        public Event OnInputCancelled
        {
            get
            {
                if (_onInputCancelled is null)
                {
                    _onInputCancelled = new Event();
                    _onInputCancelled.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onInputCancelled"));
                }
                return _onInputCancelled;
            }
        }

        /// <inheritdoc />
        public OnInputChangedEvent OnInputChanged
        {
            get
            {
                if (_onInputChanged is null)
                {
                    _onInputChanged = new OnInputChangedEvent();
                    _onInputChanged.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onInputChanged"));
                }
                return _onInputChanged;
            }
        }

        /// <inheritdoc />
        public OnInputEnteredEvent OnInputEntered
        {
            get
            {
                if (_onInputEntered is null)
                {
                    _onInputEntered = new OnInputEnteredEvent();
                    _onInputEntered.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onInputEntered"));
                }
                return _onInputEntered;
            }
        }

        /// <inheritdoc />
        public Event OnInputStarted
        {
            get
            {
                if (_onInputStarted is null)
                {
                    _onInputStarted = new Event();
                    _onInputStarted.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onInputStarted"));
                }
                return _onInputStarted;
            }
        }

        /// <inheritdoc />
        public virtual ValueTask SetDefaultSuggestion(DefaultSuggestResult suggestion)
        {
            return InvokeVoidAsync("setDefaultSuggestion", suggestion);
        }
    }
}
