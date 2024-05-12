using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.Alarms
{
    /// <summary></summary>
    public partial interface IAlarmsApi
    {
        /// <summary>Fired when an alarm has expired. Useful for transient background pages.</summary>
        OnAlarmEvent OnAlarm { get; }

        /// <summary>Clears the alarm with the given name.</summary>
        /// <param name="name">The name of the alarm to clear. Defaults to the empty string.</param>
        /// <returns>Whether an alarm of the given name was found to clear.</returns>
        ValueTask<bool> Clear(string name = null);

        /// <summary>Clears all alarms.</summary>
        /// <returns>Whether any alarm was found to clear.</returns>
        ValueTask<bool> ClearAll();

        /// <summary>Creates an alarm. After the delay is expired, the onAlarm event is fired. If there is another alarm with the same name (or no name if none is specified), it will be cancelled and replaced by this alarm.</summary>
        /// <param name="alarmInfo">Details about the alarm. The alarm first fires either at 'when' milliseconds past the epoch (if 'when' is provided), after 'delayInMinutes' minutes from the current time (if 'delayInMinutes' is provided instead), or after 'periodInMinutes' minutes from the current time (if only 'periodInMinutes' is provided). Users should never provide both 'when' and 'delayInMinutes'. If 'periodInMinutes' is provided, then the alarm recurs repeatedly after that many minutes.</param>
        ValueTask Create(AlarmInfo alarmInfo);

        /// <summary>Creates an alarm. After the delay is expired, the onAlarm event is fired. If there is another alarm with the same name (or no name if none is specified), it will be cancelled and replaced by this alarm.</summary>
        /// <param name="name">Optional name to identify this alarm. Defaults to the empty string.</param>
        /// <param name="alarmInfo">Details about the alarm. The alarm first fires either at 'when' milliseconds past the epoch (if 'when' is provided), after 'delayInMinutes' minutes from the current time (if 'delayInMinutes' is provided instead), or after 'periodInMinutes' minutes from the current time (if only 'periodInMinutes' is provided). Users should never provide both 'when' and 'delayInMinutes'. If 'periodInMinutes' is provided, then the alarm recurs repeatedly after that many minutes.</param>
        ValueTask Create(string name, AlarmInfo alarmInfo);

        /// <summary>Retrieves details about the specified alarm.</summary>
        /// <param name="name">The name of the alarm to get. Defaults to the empty string.</param>
        /// <returns></returns>
        ValueTask<Alarm> Get(string name = null);

        /// <summary>Gets an array of all the alarms.</summary>
        /// <returns></returns>
        ValueTask<IEnumerable<Alarm>> GetAll();
    }
}
