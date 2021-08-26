using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.WebNavigation
{
    /// <inheritdoc />
    public partial class WebNavigationApi : BaseApi, IWebNavigationApi
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
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public WebNavigationApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "webNavigation"))
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
                    _onBeforeNavigate.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onBeforeNavigate"));
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
                    _onCommitted.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onCommitted"));
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
                    _onCompleted.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onCompleted"));
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
                    _onCreatedNavigationTarget.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onCreatedNavigationTarget"));
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
                    _onDOMContentLoaded.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onDOMContentLoaded"));
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
                    _onErrorOccurred.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onErrorOccurred"));
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
                    _onHistoryStateUpdated.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onHistoryStateUpdated"));
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
                    _onReferenceFragmentUpdated.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onReferenceFragmentUpdated"));
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
                    _onTabReplaced.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onTabReplaced"));
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
