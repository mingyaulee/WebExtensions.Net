using JsBind.Net;

namespace WebExtensions.Net.ActivityLog;

/// <summary>Monitor extension activity</summary>
[JsAccessPath("activityLog")]
public partial interface IActivityLogApi
{
    /// <summary>Receives an activityItem for each logging event.</summary>
    [JsAccessPath("onExtensionActivity")]
    OnExtensionActivityEvent OnExtensionActivity { get; }
}
