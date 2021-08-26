using JsBind.Net;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebExtensions.Net.Extension;
using WebExtensions.Net.Tabs;

namespace WebExtensions.Net.Menus
{
    // Type Class
    /// <summary>The properties to update. Accepts the same values as the create function.</summary>
    [BindAllProperties]
    public partial class UpdateProperties : BaseObject
    {
        /// <summary></summary>
        [JsonPropertyName("checked")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Checked { get; set; }

        /// <summary></summary>
        [JsonPropertyName("contexts")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<ContextType> Contexts { get; set; }

        /// <summary></summary>
        [JsonPropertyName("documentUrlPatterns")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> DocumentUrlPatterns { get; set; }

        /// <summary></summary>
        [JsonPropertyName("enabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Enabled { get; set; }

        /// <summary></summary>
        [JsonPropertyName("icons")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object Icons { get; set; }

        /// <summary></summary>
        [JsonPropertyName("onclick")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Action<OnClickData, Tab> Onclick { get; set; }

        /// <summary>Note: You cannot change an item to be a child of one of its own descendants.</summary>
        [JsonPropertyName("parentId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UpdatePropertiesParentId ParentId { get; set; }

        /// <summary></summary>
        [JsonPropertyName("targetUrlPatterns")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> TargetUrlPatterns { get; set; }

        /// <summary></summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title { get; set; }

        /// <summary></summary>
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ItemType? Type { get; set; }

        /// <summary></summary>
        [JsonPropertyName("viewTypes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<ViewType> ViewTypes { get; set; }

        /// <summary>Whether the item is visible in the menu.</summary>
        [JsonPropertyName("visible")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Visible { get; set; }
    }
}
