using JsBind.Net;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtensions.Net.Extension
{
    /// <summary>The <c>browser.extension</c> API has utilities that can be used by any extension page. It includes support for exchanging messages between an extension and its content scripts or between extensions, as described in detail in $(topic:messaging)[Message Passing].</summary>
    [JsAccessPath("extension")]
    public partial interface IExtensionApi
    {
        /// <summary>True for content scripts running inside incognito tabs, and for extension pages running inside an incognito process. The latter only applies to extensions with 'split' incognito_behavior.</summary>
        [JsAccessPath("inIncognitoContext")]
        bool? InIncognitoContext { get; }

        /// <summary>Set for the lifetime of a callback if an ansychronous extension api has resulted in an error. If no error has occured lastError will be <c>undefined</c>.</summary>
        [JsAccessPath("lastError")]
        [Obsolete("Please use $(ref:runtime.lastError).")]
        LastError LastError { get; }

        /// <summary>Returns the JavaScript 'window' object for the background page running inside the current extension. Returns null if the extension has no background page.</summary>
        /// <returns></returns>
        [JsAccessPath("getBackgroundPage")]
        JsonElement GetBackgroundPage();

        /// <summary>Converts a relative path within an extension install directory to a fully-qualified URL.</summary>
        /// <param name="path">A path to a resource within an extension expressed relative to its install directory.</param>
        /// <returns>The fully-qualified URL to the resource.</returns>
        [JsAccessPath("getURL")]
        [Obsolete("Please use $(ref:runtime.getURL).")]
        string GetURL(string path);

        /// <summary>Returns an array of the JavaScript 'window' objects for each of the pages running inside the current extension.</summary>
        /// <param name="fetchProperties"></param>
        /// <returns>Array of global objects</returns>
        [JsAccessPath("getViews")]
        IEnumerable<object> GetViews(FetchProperties fetchProperties = null);

        /// <summary>Retrieves the state of the extension's access to the 'file://' scheme (as determined by the user-controlled 'Allow access to File URLs' checkbox.</summary>
        /// <returns>True if the extension can access the 'file://' scheme, false otherwise.</returns>
        [JsAccessPath("isAllowedFileSchemeAccess")]
        ValueTask<bool> IsAllowedFileSchemeAccess();

        /// <summary>Retrieves the state of the extension's access to Incognito-mode (as determined by the user-controlled 'Allowed in Incognito' checkbox.</summary>
        /// <returns>True if the extension has access to Incognito mode, false otherwise.</returns>
        [JsAccessPath("isAllowedIncognitoAccess")]
        ValueTask<bool> IsAllowedIncognitoAccess();
    }
}
