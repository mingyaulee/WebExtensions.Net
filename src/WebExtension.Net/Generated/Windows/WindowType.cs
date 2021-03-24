// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Windows
{
    // Enum Definition
    /// <summary>
    /// The type of browser window this is. Under some circumstances a Window may not be assigned type property, for example when querying closed windows from the $(ref:sessions) API.
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

