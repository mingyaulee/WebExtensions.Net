using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    /// <summary>Defines whether zoom changes will persist for the page's origin, or only take effect in this tab; defaults to <c>per-origin</c> when in <c>automatic</c> mode, and <c>per-tab</c> otherwise.</summary>
    [JsonConverter(typeof(EnumStringConverter<ZoomSettingsScope>))]
    public enum ZoomSettingsScope
    {
        /// <summary>Zoom changes will persist in the zoomed page's origin, i.e. all other tabs navigated to that same origin will be zoomed as well. Moreover, <c>per-origin</c> zoom changes are saved with the origin, meaning that when navigating to other pages in the same origin, they will all be zoomed to the same zoom factor. The <c>per-origin</c> scope is only available in the <c>automatic</c> mode.</summary>
        [EnumValue("per-origin")]
        PerOrigin,

        /// <summary>Zoom changes only take effect in this tab, and zoom changes in other tabs will not affect the zooming of this tab. Also, <c>per-tab</c> zoom changes are reset on navigation; navigating a tab will always load pages with their <c>per-origin</c> zoom factors.</summary>
        [EnumValue("per-tab")]
        PerTab,
    }
}
