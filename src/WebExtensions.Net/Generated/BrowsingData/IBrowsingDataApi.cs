using JsBind.Net;
using System.Threading.Tasks;

namespace WebExtensions.Net.BrowsingData
{
    /// <summary>Use the <c>chrome.browsingData</c> API to remove browsing data from a user's local profile.</summary>
    [JsAccessPath("browsingData")]
    public partial interface IBrowsingDataApi
    {
        /// <summary>Clears various types of browsing data stored in a user's profile.</summary>
        /// <param name="options"></param>
        /// <param name="dataToRemove">The set of data types to remove.</param>
        [JsAccessPath("remove")]
        ValueTask Remove(RemovalOptions options, DataTypeSet dataToRemove);

        /// <summary>Clears the browser's cache.</summary>
        /// <param name="options"></param>
        [JsAccessPath("removeCache")]
        ValueTask RemoveCache(RemovalOptions options);

        /// <summary>Clears the browser's cookies and server-bound certificates modified within a particular timeframe.</summary>
        /// <param name="options"></param>
        [JsAccessPath("removeCookies")]
        ValueTask RemoveCookies(RemovalOptions options);

        /// <summary>Clears the browser's list of downloaded files (<em>not</em> the downloaded files themselves).</summary>
        /// <param name="options"></param>
        [JsAccessPath("removeDownloads")]
        ValueTask RemoveDownloads(RemovalOptions options);

        /// <summary>Clears the browser's stored form data (autofill).</summary>
        /// <param name="options"></param>
        [JsAccessPath("removeFormData")]
        ValueTask RemoveFormData(RemovalOptions options);

        /// <summary>Clears the browser's history.</summary>
        /// <param name="options"></param>
        [JsAccessPath("removeHistory")]
        ValueTask RemoveHistory(RemovalOptions options);

        /// <summary>Clears websites' local storage data.</summary>
        /// <param name="options"></param>
        [JsAccessPath("removeLocalStorage")]
        ValueTask RemoveLocalStorage(RemovalOptions options);

        /// <summary>Clears the browser's stored passwords.</summary>
        /// <param name="options"></param>
        [JsAccessPath("removePasswords")]
        ValueTask RemovePasswords(RemovalOptions options);

        /// <summary>Clears plugins' data.</summary>
        /// <param name="options"></param>
        [JsAccessPath("removePluginData")]
        ValueTask RemovePluginData(RemovalOptions options);

        /// <summary>Reports which types of data are currently selected in the 'Clear browsing data' settings UI.  Note: some of the data types included in this API are not available in the settings UI, and some UI settings control more than one data type listed here.</summary>
        /// <returns></returns>
        [JsAccessPath("settings")]
        ValueTask<Result> Settings();
    }
}
