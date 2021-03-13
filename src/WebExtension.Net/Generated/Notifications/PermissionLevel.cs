/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Notifications
{
    /// Enum Definition
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<PermissionLevel>))]
    public enum PermissionLevel
    {
        [EnumValue("granted")]
        Granted,
        [EnumValue("denied")]
        Denied,
    }
}

