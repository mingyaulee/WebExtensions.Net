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
        /// <param name="webExtensionsJSRuntime">Web Extension JS Runtime</param>
        public DownloadsApi(IWebExtensionsJSRuntime webExtensionsJSRuntime) : base(webExtensionsJSRuntime, "downloads")
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
        public OnCreatedEvent OnCreated
        {
            get
            {
                if (_onCreated is null)
                {
                    _onCreated = new OnCreatedEvent();
                    InitializeProperty("onCreated", _onCreated);
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
                    InitializeProperty("onErased", _onErased);
                }
                return _onErased;
            }
        }

        /// <inheritdoc />
        public virtual ValueTask Cancel(int downloadId)
        {
            return InvokeVoidAsync("cancel", downloadId);
        }

        /// <inheritdoc />
        public virtual ValueTask<int> Download(DownloadOptions options)
        {
            return InvokeAsync<int>("download", options);
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<int>> Erase(DownloadQuery query)
        {
            return InvokeAsync<IEnumerable<int>>("erase", query);
        }

        /// <inheritdoc />
        public virtual ValueTask<string> GetFileIcon(int downloadId, GetFileIconOptions options)
        {
            return InvokeAsync<string>("getFileIcon", downloadId, options);
        }

        /// <inheritdoc />
        public virtual ValueTask Open(int downloadId)
        {
            return InvokeVoidAsync("open", downloadId);
        }

        /// <inheritdoc />
        public virtual ValueTask Pause(int downloadId)
        {
            return InvokeVoidAsync("pause", downloadId);
        }

        /// <inheritdoc />
        public virtual ValueTask RemoveFile(int downloadId)
        {
            return InvokeVoidAsync("removeFile", downloadId);
        }

        /// <inheritdoc />
        public virtual ValueTask Resume(int downloadId)
        {
            return InvokeVoidAsync("resume", downloadId);
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<DownloadItem>> Search(DownloadQuery query)
        {
            return InvokeAsync<IEnumerable<DownloadItem>>("search", query);
        }

        /// <inheritdoc />
        public virtual ValueTask<bool> Show(int downloadId)
        {
            return InvokeAsync<bool>("show", downloadId);
        }

        /// <inheritdoc />
        public virtual ValueTask ShowDefaultFolder()
        {
            return InvokeVoidAsync("showDefaultFolder");
        }
    }
}
