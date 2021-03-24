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
    /// The state of this browser window. Under some circumstances a Window may not be assigned state property, for example when querying closed windows from the $(ref:sessions) API.
    /// </summary>
    [JsonConverter(typeof(EnumStringConverter<WindowState>))]
    public enum WindowState
    {
        /// <summary>normal</summary>
        [EnumValue("normal")]
        Normal,
        /// <summary>minimized</summary>
        [EnumValue("minimized")]
        Minimized,
        /// <summary>maximized</summary>
        [EnumValue("maximized")]
        Maximized,
        /// <summary>fullscreen</summary>
        [EnumValue("fullscreen")]
        Fullscreen,
        /// <summary>docked</summary>
        [EnumValue("docked")]
        Docked,
    }
}

