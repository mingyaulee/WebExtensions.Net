using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Runtime
{
    // Enum Definition
    /// <summary>
    /// Result of the update check.
    /// </summary>
    [JsonConverter(typeof(EnumStringConverter<RequestUpdateCheckStatus>))]
    public enum RequestUpdateCheckStatus
    {
        /// <summary>throttled</summary>
        [EnumValue("throttled")]
        Throttled,
        /// <summary>no_update</summary>
        [EnumValue("no_update")]
        No_update,
        /// <summary>update_available</summary>
        [EnumValue("update_available")]
        Update_available,
    }
}

