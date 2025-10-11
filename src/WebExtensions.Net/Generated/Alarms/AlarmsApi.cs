using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.Alarms;

/// <inheritdoc />
/// <param name="jsRuntime">The JS runtime adapter.</param>
/// <param name="accessPath">The base API access path.</param>
public partial class AlarmsApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "alarms")), IAlarmsApi
{
    private OnAlarmEvent _onAlarm;

    /// <inheritdoc />
    public OnAlarmEvent OnAlarm
    {
        get
        {
            if (_onAlarm is null)
            {
                _onAlarm = new OnAlarmEvent();
                _onAlarm.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onAlarm"));
            }
            return _onAlarm;
        }
    }

    /// <inheritdoc />
    public virtual ValueTask<bool> Clear(string name = null)
        => InvokeAsync<bool>("clear", name);

    /// <inheritdoc />
    public virtual ValueTask<bool> ClearAll()
        => InvokeAsync<bool>("clearAll");

    /// <inheritdoc />
    public virtual ValueTask Create(AlarmInfo alarmInfo)
        => InvokeVoidAsync("create", alarmInfo);

    /// <inheritdoc />
    public virtual ValueTask Create(string name, AlarmInfo alarmInfo)
        => InvokeVoidAsync("create", name, alarmInfo);

    /// <inheritdoc />
    public virtual ValueTask<Alarm> Get(string name = null)
        => InvokeAsync<Alarm>("get", name);

    /// <inheritdoc />
    public virtual ValueTask<IEnumerable<Alarm>> GetAll()
        => InvokeAsync<IEnumerable<Alarm>>("getAll");
}
