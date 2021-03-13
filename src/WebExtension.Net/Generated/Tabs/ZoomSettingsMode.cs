/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Tabs
{
    /// Enum Definition
    /// <summary>Defines how zoom changes are handled, i.e. which entity is responsible for the actual scaling of the page; defaults to <code>automatic</code>.</summary>
    [JsonConverter(typeof(EnumStringConverter<ZoomSettingsMode>))]
    public enum ZoomSettingsMode
    {
        /// <summary>Zoom changes are handled automatically by the browser.</summary>
        [EnumValue("automatic")]
        Automatic,
        /// <summary>Overrides the automatic handling of zoom changes. The <code>onZoomChange</code> event will still be dispatched, and it is the responsibility of the extension to listen for this event and manually scale the page. This mode does not support <code>per-origin</code> zooming, and will thus ignore the <code>scope</code> zoom setting and assume <code>per-tab</code>.</summary>
        [EnumValue("manual")]
        Manual,
        /// <summary>Disables all zooming in the tab. The tab will revert to the default zoom level, and all attempted zoom changes will be ignored.</summary>
        [EnumValue("disabled")]
        Disabled,
    }
}

