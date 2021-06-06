using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    /// <summary>Defines how zoom changes are handled, i.e. which entity is responsible for the actual scaling of the page; defaults to <c>automatic</c>.</summary>
    [JsonConverter(typeof(EnumStringConverter<ZoomSettingsMode>))]
    public enum ZoomSettingsMode
    {
        /// <summary>Zoom changes are handled automatically by the browser.</summary>
        [EnumValue("automatic")]
        Automatic,

        /// <summary>Overrides the automatic handling of zoom changes. The <c>onZoomChange</c> event will still be dispatched, and it is the responsibility of the extension to listen for this event and manually scale the page. This mode does not support <c>per-origin</c> zooming, and will thus ignore the <c>scope</c> zoom setting and assume <c>per-tab</c>.</summary>
        [EnumValue("manual")]
        Manual,

        /// <summary>Disables all zooming in the tab. The tab will revert to the default zoom level, and all attempted zoom changes will be ignored.</summary>
        [EnumValue("disabled")]
        Disabled,
    }
}
