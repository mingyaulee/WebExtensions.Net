using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.Downloads
{
    /// <summary></summary>
    [JsAccessPath("downloads")]
    public partial interface IDownloadsApi
    {
        /// <summary>When any of a <see href='#type-DownloadItem'>DownloadItem</see>'s properties except <c>bytesReceived</c> changes, this event fires with the <c>downloadId</c> and an object containing the properties that changed.</summary>
        [JsAccessPath("onChanged")]
        OnChangedEvent OnChanged { get; }

        /// <summary>This event fires with the <see href='#type-DownloadItem'>DownloadItem</see> object when a download begins.</summary>
        [JsAccessPath("onCreated")]
        OnCreatedEvent OnCreated { get; }

        /// <summary>Fires with the <c>downloadId</c> when a download is erased from history.</summary>
        [JsAccessPath("onErased")]
        OnErasedEvent OnErased { get; }

        /// <summary>Cancel a download. When <c>callback</c> is run, the download is cancelled, completed, interrupted or doesn't exist anymore.</summary>
        /// <param name="downloadId">The id of the download to cancel.</param>
        [JsAccessPath("cancel")]
        ValueTask Cancel(int downloadId);

        /// <summary>Download a URL. If the URL uses the HTTP[S] protocol, then the request will include all cookies currently set for its hostname. If both <c>filename</c> and <c>saveAs</c> are specified, then the Save As dialog will be displayed, pre-populated with the specified <c>filename</c>. If the download started successfully, <c>callback</c> will be called with the new <see href='#type-DownloadItem'>DownloadItem</see>'s <c>downloadId</c>. If there was an error starting the download, then <c>callback</c> will be called with <c>downloadId=undefined</c> and <see href='extension.html#property-lastError'>chrome.extension.lastError</see> will contain a descriptive string. The error strings are not guaranteed to remain backwards compatible between releases. You must not parse it.</summary>
        /// <param name="options">What to download and how.</param>
        /// <returns></returns>
        [JsAccessPath("download")]
        ValueTask<int> Download(DownloadOptions options);

        /// <summary>Erase matching <see href='#type-DownloadItem'>DownloadItems</see> from history</summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [JsAccessPath("erase")]
        ValueTask<IEnumerable<int>> Erase(DownloadQuery query);

        /// <summary>Retrieve an icon for the specified download. For new downloads, file icons are available after the <see href='#event-onCreated'>onCreated</see> event has been received. The image returned by this function while a download is in progress may be different from the image returned after the download is complete. Icon retrieval is done by querying the underlying operating system or toolkit depending on the platform. The icon that is returned will therefore depend on a number of factors including state of the download, platform, registered file types and visual theme. If a file icon cannot be determined, <see href='extension.html#property-lastError'>chrome.extension.lastError</see> will contain an error message.</summary>
        /// <param name="downloadId">The identifier for the download.</param>
        /// <param name="options"></param>
        /// <returns></returns>
        [JsAccessPath("getFileIcon")]
        ValueTask<string> GetFileIcon(int downloadId, GetFileIconOptions options = null);

        /// <summary>Open the downloaded file.</summary>
        /// <param name="downloadId"></param>
        [JsAccessPath("open")]
        ValueTask Open(int downloadId);

        /// <summary>Pause the download. If the request was successful the download is in a paused state. Otherwise <see href='extension.html#property-lastError'>chrome.extension.lastError</see> contains an error message. The request will fail if the download is not active.</summary>
        /// <param name="downloadId">The id of the download to pause.</param>
        [JsAccessPath("pause")]
        ValueTask Pause(int downloadId);

        /// <summary></summary>
        /// <param name="downloadId"></param>
        [JsAccessPath("removeFile")]
        ValueTask RemoveFile(int downloadId);

        /// <summary>Resume a paused download. If the request was successful the download is in progress and unpaused. Otherwise <see href='extension.html#property-lastError'>chrome.extension.lastError</see> contains an error message. The request will fail if the download is not active.</summary>
        /// <param name="downloadId">The id of the download to resume.</param>
        [JsAccessPath("resume")]
        ValueTask Resume(int downloadId);

        /// <summary>Find <see href='#type-DownloadItem'>DownloadItems</see>. Set <c>query</c> to the empty object to get all <see href='#type-DownloadItem'>DownloadItems</see>. To get a specific <see href='#type-DownloadItem'>DownloadItem</see>, set only the <c>id</c> field.</summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [JsAccessPath("search")]
        ValueTask<IEnumerable<DownloadItem>> Search(DownloadQuery query);

        /// <summary>Show the downloaded file in its folder in a file manager.</summary>
        /// <param name="downloadId"></param>
        /// <returns></returns>
        [JsAccessPath("show")]
        ValueTask<bool> Show(int downloadId);

        /// <summary></summary>
        [JsAccessPath("showDefaultFolder")]
        void ShowDefaultFolder();
    }
}
