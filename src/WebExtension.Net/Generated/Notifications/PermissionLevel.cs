using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Notifications
{
    // Enum Definition
    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(EnumStringConverter<PermissionLevel>))]
    public enum PermissionLevel
    {
        /// <summary>granted</summary>
        [EnumValue("granted")]
        Granted,
        /// <summary>denied</summary>
        [EnumValue("denied")]
        Denied,
    }
}

