/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Windows
{
    /// Enum Definition
    /// <summary>The state of this browser window. Under some circumstances a Window may not be assigned state property, for example when querying closed windows from the $(ref:sessions) API.</summary>
    [JsonConverter(typeof(EnumStringConverter<WindowState>))]
    public enum WindowState
    {
        [EnumValue("normal")]
        Normal,
        [EnumValue("minimized")]
        Minimized,
        [EnumValue("maximized")]
        Maximized,
        [EnumValue("fullscreen")]
        Fullscreen,
        [EnumValue("docked")]
        Docked,
    }
}

