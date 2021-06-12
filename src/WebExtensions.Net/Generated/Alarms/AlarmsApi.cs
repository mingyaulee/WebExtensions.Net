using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.Alarms
{
    /// <inheritdoc />
    public partial class AlarmsApi : BaseApi, IAlarmsApi
    {
        private OnAlarmEvent _onAlarm;

        /// <summary>Creates a new instance of <see cref="AlarmsApi" />.</summary>
        /// <param name="webExtensionsJSRuntime">Web Extension JS Runtime</param>
        public AlarmsApi(IWebExtensionsJSRuntime webExtensionsJSRuntime) : base(webExtensionsJSRuntime, "alarms")
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
                    InitializeProperty("onAlarm", _onAlarm);
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
