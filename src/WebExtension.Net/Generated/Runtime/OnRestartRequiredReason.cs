// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Runtime
{
    // Enum Definition
    /// <summary>
    /// The reason that the event is being dispatched. 'app_update' is used when the restart is needed because the application is updated to a newer version. 'os_update' is used when the restart is needed because the browser/OS is updated to a newer version. 'periodic' is used when the system runs for more than the permitted uptime set in the enterprise policy.
    /// </summary>
    [JsonConverter(typeof(EnumStringConverter<OnRestartRequiredReason>))]
    public enum OnRestartRequiredReason
    {
        /// <summary>app_update</summary>
        [EnumValue("app_update")]
        App_update,
        /// <summary>os_update</summary>
        [EnumValue("os_update")]
        Os_update,
        /// <summary>periodic</summary>
        [EnumValue("periodic")]
        Periodic,
    }
}

