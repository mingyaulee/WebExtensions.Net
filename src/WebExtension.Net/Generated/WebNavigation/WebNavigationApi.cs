using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtension.Net.WebNavigation
{
    /// <inheritdoc />
    public class WebNavigationApi : BaseApi, IWebNavigationApi
    {
        private OnBeforeNavigateEvent _onBeforeNavigate;
        private OnCommittedEvent _onCommitted;
        private OnCompletedEvent _onCompleted;
        private OnCreatedNavigationTargetEvent _onCreatedNavigationTarget;
        private OnDomContentLoadedEvent _onDOMContentLoaded;
        private OnErrorOccurredEvent _onErrorOccurred;
        private OnHistoryStateUpdatedEvent _onHistoryStateUpdated;
        private OnReferenceFragmentUpdatedEvent _onReferenceFragmentUpdated;
        private OnTabReplacedEvent _onTabReplaced;

        /// <summary>Creates a new instance of <see cref="WebNavigationApi" />.</summary>
        /// <param name="webExtensionJSRuntime">Web Extension JS Runtime</param>
        public WebNavigationApi(WebExtensionJSRuntime webExtensionJSRuntime) : base(webExtensionJSRuntime, "webNavigation")
        {
        }

        /// <inheritdoc />
        public OnBeforeNavigateEvent OnBeforeNavigate
        {
            get
            {
                if (_onBeforeNavigate is null)
                {
                    _onBeforeNavigate = new OnBeforeNavigateEvent();
                    InitializeProperty("onBeforeNavigate", _onBeforeNavigate);
                }
                return _onBeforeNavigate;
            }
        }

        /// <inheritdoc />
        public OnCommittedEvent OnCommitted
        {
            get
            {
                if (_onCommitted is null)
                {
                    _onCommitted = new OnCommittedEvent();
                    InitializeProperty("onCommitted", _onCommitted);
                }
                return _onCommitted;
            }
        }

        /// <inheritdoc />
        public OnCompletedEvent OnCompleted
        {
            get
            {
                if (_onCompleted is null)
                {
                    _onCompleted = new OnCompletedEvent();
                    InitializeProperty("onCompleted", _onCompleted);
                }
                return _onCompleted;
            }
        }

        /// <inheritdoc />
        public OnCreatedNavigationTargetEvent OnCreatedNavigationTarget
        {
            get
            {
                if (_onCreatedNavigationTarget is null)
                {
                    _onCreatedNavigationTarget = new OnCreatedNavigationTargetEvent();
                    InitializeProperty("onCreatedNavigationTarget", _onCreatedNavigationTarget);
                }
                return _onCreatedNavigationTarget;
            }
        }

        /// <inheritdoc />
        public OnDomContentLoadedEvent OnDOMContentLoaded
        {
            get
            {
                if (_onDOMContentLoaded is null)
                {
                    _onDOMContentLoaded = new OnDomContentLoadedEvent();
                    InitializeProperty("onDOMContentLoaded", _onDOMContentLoaded);
                }
                return _onDOMContentLoaded;
            }
        }

        /// <inheritdoc />
        public OnErrorOccurredEvent OnErrorOccurred
        {
            get
            {
                if (_onErrorOccurred is null)
                {
                    _onErrorOccurred = new OnErrorOccurredEvent();
                    InitializeProperty("onErrorOccurred", _onErrorOccurred);
                }
                return _onErrorOccurred;
            }
        }

        /// <inheritdoc />
        public OnHistoryStateUpdatedEvent OnHistoryStateUpdated
        {
            get
            {
                if (_onHistoryStateUpdated is null)
                {
                    _onHistoryStateUpdated = new OnHistoryStateUpdatedEvent();
                    InitializeProperty("onHistoryStateUpdated", _onHistoryStateUpdated);
                }
                return _onHistoryStateUpdated;
            }
        }

        /// <inheritdoc />
        public OnReferenceFragmentUpdatedEvent OnReferenceFragmentUpdated
        {
            get
            {
                if (_onReferenceFragmentUpdated is null)
                {
                    _onReferenceFragmentUpdated = new OnReferenceFragmentUpdatedEvent();
                    InitializeProperty("onReferenceFragmentUpdated", _onReferenceFragmentUpdated);
                }
                return _onReferenceFragmentUpdated;
            }
        }

        /// <inheritdoc />
        public OnTabReplacedEvent OnTabReplaced
        {
            get
            {
                if (_onTabReplaced is null)
                {
                    _onTabReplaced = new OnTabReplacedEvent();
                    InitializeProperty("onTabReplaced", _onTabReplaced);
                }
                return _onTabReplaced;
            }
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<DetailsArrayItem>> GetAllFrames(GetAllFramesDetails details)
        {
            return InvokeAsync<IEnumerable<DetailsArrayItem>>("getAllFrames", details);
        }

        /// <inheritdoc />
        public virtual ValueTask<GetFrameCallbackDetails> GetFrame(GetFrameDetails details)
        {
            return InvokeAsync<GetFrameCallbackDetails>("getFrame", details);
        }
    }
}
