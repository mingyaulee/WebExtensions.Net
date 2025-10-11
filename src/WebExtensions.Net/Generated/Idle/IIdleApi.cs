using JsBind.Net;
using System.Threading.Tasks;

namespace WebExtensions.Net.Idle;

/// <summary>Use the <c>browser.idle</c> API to detect when the machine's idle state changes.</summary>
[JsAccessPath("idle")]
public partial interface IIdleApi
{
    /// <summary>Fired when the system changes to an active or idle state. The event fires with "idle" if the the user has not generated any input for a specified number of seconds, and "active" when the user generates input on an idle system.</summary>
    [JsAccessPath("onStateChanged")]
    OnStateChangedEvent OnStateChanged { get; }

    /// <summary>Returns "idle" if the user has not generated any input for a specified number of seconds, or "active" otherwise.</summary>
    /// <param name="detectionIntervalInSeconds">The system is considered idle if detectionIntervalInSeconds seconds have elapsed since the last user input detected.</param>
    /// <returns></returns>
    [JsAccessPath("queryState")]
    ValueTask<IdleState> QueryState(int detectionIntervalInSeconds);

    /// <summary>Sets the interval, in seconds, used to determine when the system is in an idle state for onStateChanged events. The default interval is 60 seconds.</summary>
    /// <param name="intervalInSeconds">Threshold, in seconds, used to determine when the system is in an idle state.</param>
    [JsAccessPath("setDetectionInterval")]
    void SetDetectionInterval(int intervalInSeconds);
}
