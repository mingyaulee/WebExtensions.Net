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
        [JsAccessPath("checked")]
        [JsonPropertyName("checked")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Checked { get; set; }

        /// <summary></summary>
        [JsAccessPath("contexts")]
        [JsonPropertyName("contexts")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<ContextType> Contexts { get; set; }

        /// <summary></summary>
        [JsAccessPath("documentUrlPatterns")]
        [JsonPropertyName("documentUrlPatterns")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> DocumentUrlPatterns { get; set; }

        /// <summary></summary>
        [JsAccessPath("enabled")]
        [JsonPropertyName("enabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Enabled { get; set; }

        /// <summary></summary>
        [JsAccessPath("icons")]
        [JsonPropertyName("icons")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object Icons { get; set; }

        /// <summary></summary>
        [JsAccessPath("onclick")]
        [JsonPropertyName("onclick")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Action<OnClickData, Tab> Onclick { get; set; }

        /// <summary>Note: You cannot change an item to be a child of one of its own descendants.</summary>
        [JsAccessPath("parentId")]
        [JsonPropertyName("parentId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UpdatePropertiesParentId ParentId { get; set; }

        /// <summary></summary>
        [JsAccessPath("targetUrlPatterns")]
        [JsonPropertyName("targetUrlPatterns")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> TargetUrlPatterns { get; set; }

        /// <summary></summary>
        [JsAccessPath("title")]
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title { get; set; }

        /// <summary></summary>
        [JsAccessPath("type")]
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ItemType? Type { get; set; }

        /// <summary></summary>
        [JsAccessPath("viewTypes")]
        [JsonPropertyName("viewTypes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<ViewType> ViewTypes { get; set; }

        /// <summary>Whether the item is visible in the menu.</summary>
        [JsAccessPath("visible")]
        [JsonPropertyName("visible")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Visible { get; set; }
    }
}
