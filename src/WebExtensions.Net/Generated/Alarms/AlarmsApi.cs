using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.Alarms
{
    /// <inheritdoc />
    public partial class AlarmsApi : BaseApi, IAlarmsApi
    {
        private OnAlarmEvent _onAlarm;

        /// <summary>Creates a new instance of <see cref="AlarmsApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public AlarmsApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "alarms"))
        {
        }

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
        public virtual ValueTask<bool> Clear(string name)
        {
            return InvokeAsync<bool>("clear", name);
        }

        /// <inheritdoc />
        public virtual ValueTask<bool> ClearAll()
        {
            return InvokeAsync<bool>("clearAll");
        }

        /// <inheritdoc />
        public virtual ValueTask Create(string name, AlarmInfo alarmInfo)
        {
            return InvokeVoidAsync("create", name, alarmInfo);
        }

        /// <inheritdoc />
        public virtual ValueTask<Alarm> Get(string name)
        {
            return InvokeAsync<Alarm>("get", name);
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<Alarm>> GetAll()
        {
            return InvokeAsync<IEnumerable<Alarm>>("getAll");
        }
    }
}
