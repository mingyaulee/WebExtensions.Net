using System.Text.Json.Serialization;

namespace WebExtensions.Net.Omnibox
{
    /// <summary>The window disposition for the omnibox query. This is the recommended context to display results. For example, if the omnibox command is to navigate to a certain URL, a disposition of 'newForegroundTab' means the navigation should take place in a new selected tab.</summary>
    [JsonConverter(typeof(EnumStringConverter<OnInputEnteredDisposition>))]
    public enum OnInputEnteredDisposition
    {
        /// <summary>currentTab</summary>
        [EnumValue("currentTab")]
        CurrentTab,

        /// <summary>newForegroundTab</summary>
        [EnumValue("newForegroundTab")]
        NewForegroundTab,

        /// <summary>newBackgroundTab</summary>
        [EnumValue("newBackgroundTab")]
        NewBackgroundTab,
    }
}
