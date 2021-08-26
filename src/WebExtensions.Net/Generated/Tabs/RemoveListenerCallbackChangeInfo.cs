using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary>Lists the changes to the state of the tab that was updated.</summary>
    [BindAllProperties]
    public partial class RemoveListenerCallbackChangeInfo : BaseObject
    {
        /// <summary>The tab's new attention state.</summary>
        [JsonPropertyName("attention")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Attention { get; set; }

        /// <summary>The tab's new audible state.</summary>
        [JsonPropertyName("audible")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Audible { get; set; }

        /// <summary>True while the tab is not loaded with content.</summary>
        [JsonPropertyName("discarded")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Discarded { get; set; }

        /// <summary>The tab's new favicon URL. This property is only present if the extension's manifest includes the <c>"tabs"</c> permission.</summary>
        [JsonPropertyName("favIconUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string FavIconUrl { get; set; }

        /// <summary>The tab's new hidden state.</summary>
        [JsonPropertyName("hidden")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Hidden { get; set; }

        /// <summary>Whether the document in the tab can be rendered in reader mode.</summary>
        [JsonPropertyName("isArticle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsArticle { get; set; }

        /// <summary>The tab's new muted state and the reason for the change.</summary>
        [JsonPropertyName("mutedInfo")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MutedInfo MutedInfo { get; set; }

        /// <summary>The tab's new pinned state.</summary>
        [JsonPropertyName("pinned")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Pinned { get; set; }

        /// <summary>The tab's new sharing state for screen, microphone and camera.</summary>
        [JsonPropertyName("sharingState")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SharingState SharingState { get; set; }

        /// <summary>The status of the tab. Can be either <em>loading</em> or <em>complete</em>.</summary>
        [JsonPropertyName("status")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Status { get; set; }

        /// <summary>The title of the tab if it has changed. This property is only present if the extension's manifest includes the <c>"tabs"</c> permission.</summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title { get; set; }

        /// <summary>The tab's URL if it has changed. This property is only present if the extension's manifest includes the <c>"tabs"</c> permission.</summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url { get; set; }
    }
}
