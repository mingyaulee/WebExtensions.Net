using JsBind.Net;
using WebExtensions.Net.Types;

namespace WebExtensions.Net.CaptivePortal;

/// <summary>This API provides the ability detect the captive portal state of the users connection.</summary>
[JsAccessPath("captivePortal")]
public partial interface ICaptivePortalApi
{
    /// <summary>Return the canonical captive-portal detection URL. Read-only.</summary>
    [JsAccessPath("canonicalURL")]
    Setting CanonicalURL { get; }

    /// <summary>This notification will be emitted when the captive portal service has determined that we can connect to the internet. The service will pass either `captive` if there is an unlocked captive portal present, or `clear` if no captive portal was detected.</summary>
    [JsAccessPath("onConnectivityAvailable")]
    OnConnectivityAvailableEvent OnConnectivityAvailable { get; }

    /// <summary>Fired when the captive portal state changes.</summary>
    [JsAccessPath("onStateChanged")]
    OnStateChangedEvent OnStateChanged { get; }

    /// <summary>Returns the time difference between NOW and the last time a request was completed in milliseconds.</summary>
    [JsAccessPath("getLastChecked")]
    void GetLastChecked();

    /// <summary>Returns the current portal state, one of `unknown`, `not_captive`, `unlocked_portal`, `locked_portal`.</summary>
    [JsAccessPath("getState")]
    void GetState();
}
