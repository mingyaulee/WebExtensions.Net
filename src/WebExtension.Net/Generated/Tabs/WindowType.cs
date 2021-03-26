using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Tabs
{
    // Enum Definition
    /// <summary>
    /// The type of window.
    /// </summary>
    [JsonConverter(typeof(EnumStringConverter<WindowType>))]
    public enum WindowType
    {
        /// <summary>normal</summary>
        [EnumValue("normal")]
        Normal,
        /// <summary>popup</summary>
        [EnumValue("popup")]
        Popup,
        /// <summary>panel</summary>
        [EnumValue("panel")]
        Panel,
        /// <summary>app</summary>
        [EnumValue("app")]
        App,
        /// <summary>devtools</summary>
        [EnumValue("devtools")]
        Devtools,
    }
}

