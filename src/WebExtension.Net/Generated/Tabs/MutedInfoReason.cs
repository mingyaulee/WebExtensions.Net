using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Tabs
{
    // Enum Definition
    /// <summary>
    /// An event that caused a muted state change.
    /// </summary>
    [JsonConverter(typeof(EnumStringConverter<MutedInfoReason>))]
    public enum MutedInfoReason
    {
        /// <summary>
        /// A user input action has set/overridden the muted state.
        /// </summary>
        [EnumValue("user")]
        User,
        /// <summary>
        /// Tab capture started, forcing a muted state change.
        /// </summary>
        [EnumValue("capture")]
        Capture,
        /// <summary>
        /// An extension, identified by the extensionId field, set the muted state.
        /// </summary>
        [EnumValue("extension")]
        Extension,
    }
}

