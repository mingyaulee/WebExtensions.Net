using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.Downloads
{
    /// <inheritdoc />
    public partial class DownloadsApi : BaseApi, IDownloadsApi
    {
        private OnChangedEvent _onChanged;
        private OnCreatedEvent _onCreated;
        private OnErasedEvent _onErased;

        /// <summary>Creates a new instance of <see cref="DownloadsApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public DownloadsApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "downloads"))
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
                    _onChanged.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onChanged"));
                }
                return _onChanged;
            }
        }

        /// <inheritdoc />
        public OnCreatedEvent OnCreated
        {
            get
            {
                if (_onCreated is null)
                {
                    _onCreated = new OnCreatedEvent();
                    _onCreated.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onCreated"));
                }
                return _onCreated;
            }
        }

        /// <inheritdoc />
        public OnErasedEvent OnErased
        {
            get
            {
                if (_onErased is null)
                {
                    _onErased = new OnErasedEvent();
                    _onErased.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onErased"));
                }
                return _onErased;
            }
        }

        /// <inheritdoc />
        public virtual ValueTask Cancel(int downloadId)
            => InvokeVoidAsync("cancel", downloadId);

        /// <inheritdoc />
        public virtual ValueTask<int> Download(DownloadOptions options)
            => InvokeAsync<int>("download", options);

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<int>> Erase(DownloadQuery query)
            => InvokeAsync<IEnumerable<int>>("erase", query);

        /// <inheritdoc />
        public virtual ValueTask<string> GetFileIcon(int downloadId, GetFileIconOptions options = null)
            => InvokeAsync<string>("getFileIcon", downloadId, options);

        /// <inheritdoc />
        public virtual ValueTask Open(int downloadId)
            => InvokeVoidAsync("open", downloadId);

        /// <inheritdoc />
        public virtual ValueTask Pause(int downloadId)
            => InvokeVoidAsync("pause", downloadId);

        /// <inheritdoc />
        public virtual ValueTask RemoveFile(int downloadId)
            => InvokeVoidAsync("removeFile", downloadId);

        /// <inheritdoc />
        public virtual ValueTask Resume(int downloadId)
            => InvokeVoidAsync("resume", downloadId);

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<DownloadItem>> Search(DownloadQuery query)
            => InvokeAsync<IEnumerable<DownloadItem>>("search", query);

        /// <inheritdoc />
        public virtual ValueTask<bool> Show(int downloadId)
            => InvokeAsync<bool>("show", downloadId);

        /// <inheritdoc />
        public virtual void ShowDefaultFolder()
            => InvokeVoid("showDefaultFolder");
    }
}
