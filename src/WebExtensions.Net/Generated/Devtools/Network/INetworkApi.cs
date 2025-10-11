using JsBind.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtensions.Net.Devtools.Network;

/// <summary>Use the <c>chrome.devtools.network</c> API to retrieve the information about network requests displayed by the Developer Tools in the Network panel.</summary>
[JsAccessPath("network")]
public partial interface INetworkApi
{
    /// <summary>Fired when the inspected window navigates to a new page.</summary>
    [JsAccessPath("onNavigated")]
    OnNavigatedEvent OnNavigated { get; }

    /// <summary>Fired when a network request is finished and all request data are available.</summary>
    [JsAccessPath("onRequestFinished")]
    OnRequestFinishedEvent OnRequestFinished { get; }

    /// <summary>Returns HAR log that contains all known network requests.</summary>
    /// <returns>A HAR log. See HAR specification for details.</returns>
    [JsAccessPath("getHAR")]
    ValueTask<JsonElement> GetHAR();
}
