/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Runtime
{
    /// Enum Definition
    /// <summary>The reason that this event is being dispatched.</summary>
    [JsonConverter(typeof(EnumStringConverter<OnInstalledReason>))]
    public enum OnInstalledReason
    {
        [EnumValue("install")]
        Install,
        [EnumValue("update")]
        Update,
        [EnumValue("browser_update")]
        Browser_update,
    }
}

