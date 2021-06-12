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
        /// <param name="webExtensionsJSRuntime">Web Extension JS Runtime</param>
        public OmniboxApi(IWebExtensionsJSRuntime webExtensionsJSRuntime) : base(webExtensionsJSRuntime, "omnibox")
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
                    InitializeProperty("onInputCancelled", _onInputCancelled);
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
                    InitializeProperty("onInputChanged", _onInputChanged);
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
                    InitializeProperty("onInputEntered", _onInputEntered);
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
                    InitializeProperty("onInputStarted", _onInputStarted);
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
