/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Tabs
{
    /// Enum Definition
    /// <summary>Defines whether zoom changes will persist for the page's origin, or only take effect in this tab; defaults to <code>per-origin</code> when in <code>automatic</code> mode, and <code>per-tab</code> otherwise.</summary>
    [JsonConverter(typeof(EnumStringConverter<ZoomSettingsScope>))]
    public enum ZoomSettingsScope
    {
        /// <summary>Zoom changes will persist in the zoomed page's origin, i.e. all other tabs navigated to that same origin will be zoomed as well. Moreover, <code>per-origin</code> zoom changes are saved with the origin, meaning that when navigating to other pages in the same origin, they will all be zoomed to the same zoom factor. The <code>per-origin</code> scope is only available in the <code>automatic</code> mode.</summary>
        [EnumValue("per-origin")]
        Per_origin,
        /// <summary>Zoom changes only take effect in this tab, and zoom changes in other tabs will not affect the zooming of this tab. Also, <code>per-tab</code> zoom changes are reset on navigation; navigating a tab will always load pages with their <code>per-origin</code> zoom factors.</summary>
        [EnumValue("per-tab")]
        Per_tab,
    }
}

