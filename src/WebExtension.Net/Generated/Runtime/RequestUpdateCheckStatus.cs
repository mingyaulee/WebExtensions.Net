/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Runtime
{
    /// Enum Definition
    /// <summary>Result of the update check.</summary>
    [JsonConverter(typeof(EnumStringConverter<RequestUpdateCheckStatus>))]
    public enum RequestUpdateCheckStatus
    {
        [EnumValue("throttled")]
        Throttled,
        [EnumValue("no_update")]
        No_update,
        [EnumValue("update_available")]
        Update_available,
    }
}

