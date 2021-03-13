/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Windows
{
    /// Enum Definition
    /// <summary>The type of browser window this is. Under some circumstances a Window may not be assigned type property, for example when querying closed windows from the $(ref:sessions) API.</summary>
    [JsonConverter(typeof(EnumStringConverter<WindowType>))]
    public enum WindowType
    {
        [EnumValue("normal")]
        Normal,
        [EnumValue("popup")]
        Popup,
        [EnumValue("panel")]
        Panel,
        [EnumValue("app")]
        App,
        [EnumValue("devtools")]
        Devtools,
    }
}

