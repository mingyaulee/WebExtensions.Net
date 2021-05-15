using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.WebNavigation
{
    /// <summary>Use the <c>browser.webNavigation</c> API to receive notifications about the status of navigation requests in-flight.</summary>
    public interface IWebNavigationApi
    {
        /// <summary>Fired when a navigation is about to occur.</summary>
        OnBeforeNavigateEvent OnBeforeNavigate { get; }

        /// <summary>Fired when a navigation is committed. The document (and the resources it refers to, such as images and subframes) might still be downloading, but at least part of the document has been received from the server and the browser has decided to switch to the new document.</summary>
        OnCommittedEvent OnCommitted { get; }

        /// <summary>Fired when a document, including the resources it refers to, is completely loaded and initialized.</summary>
        OnCompletedEvent OnCompleted { get; }

        /// <summary>Fired when a new window, or a new tab in an existing window, is created to host a navigation.</summary>
        OnCreatedNavigationTargetEvent OnCreatedNavigationTarget { get; }

        /// <summary>Fired when the page's DOM is fully constructed, but the referenced resources may not finish loading.</summary>
        OnDOMContentLoadedEvent OnDOMContentLoaded { get; }

        /// <summary>Fired when an error occurs and the navigation is aborted. This can happen if either a network error occurred, or the user aborted the navigation.</summary>
        OnErrorOccurredEvent OnErrorOccurred { get; }

        /// <summary>Fired when the frame's history was updated to a new URL. All future events for that frame will use the updated URL.</summary>
        OnHistoryStateUpdatedEvent OnHistoryStateUpdated { get; }

        /// <summary>Fired when the reference fragment of a frame was updated. All future events for that frame will use the updated URL.</summary>
        OnReferenceFragmentUpdatedEvent OnReferenceFragmentUpdated { get; }

        /// <summary>Fired when the contents of the tab is replaced by a different (usually previously pre-rendered) tab.</summary>
        OnTabReplacedEvent OnTabReplaced { get; }

        /// <summary>Retrieves information about all frames of a given tab.</summary>
        /// <param name="details">Information about the tab to retrieve all frames from.</param>
        /// <returns>A list of frames in the given tab, null if the specified tab ID is invalid.</returns>
        ValueTask<IEnumerable<object>> GetAllFrames(object details);

        /// <summary>Retrieves information about the given frame. A frame refers to an &amp;lt;iframe&amp;gt; or a &amp;lt;frame&amp;gt; of a web page and is identified by a tab ID and a frame ID.</summary>
        /// <param name="details">Information about the frame to retrieve information about.</param>
        /// <returns>Information about the requested frame, null if the specified frame ID and/or tab ID are invalid.</returns>
        ValueTask<JsonElement> GetFrame(object details);
    }
}
