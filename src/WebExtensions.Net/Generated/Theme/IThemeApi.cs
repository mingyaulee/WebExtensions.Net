using JsBind.Net;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Theme
{
    /// <summary>The theme API allows customizing of visual elements of the browser.</summary>
    [JsAccessPath("theme")]
    public partial interface IThemeApi
    {
        /// <summary>Fired when a new theme has been applied</summary>
        [JsAccessPath("onUpdated")]
        OnUpdatedEvent OnUpdated { get; }

        /// <summary>Returns the current theme for the specified window or the last focused window.</summary>
        /// <param name="windowId">The window for which we want the theme.</param>
        [JsAccessPath("getCurrent")]
        void GetCurrent(int? windowId = null);

        /// <summary>Removes the updates made to the theme.</summary>
        /// <param name="windowId">The id of the window to reset. No id resets all windows.</param>
        [JsAccessPath("reset")]
        void Reset(int? windowId = null);

        /// <summary>Make complete updates to the theme. Resolves when the update has completed.</summary>
        /// <param name="details">The properties of the theme to update.</param>
        [JsAccessPath("update")]
        void Update(ThemeType details);

        /// <summary>Make complete updates to the theme. Resolves when the update has completed.</summary>
        /// <param name="windowId">The id of the window to update. No id updates all windows.</param>
        /// <param name="details">The properties of the theme to update.</param>
        [JsAccessPath("update")]
        void Update(int? windowId, ThemeType details);
    }
}
