using JsBind.Net;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebExtensions.Net.Extension;
using WebExtensions.Net.Tabs;

namespace WebExtensions.Net.Menus
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class CreateProperties : BaseObject
    {
        /// <summary>The initial state of a checkbox or radio item: true for selected and false for unselected. Only one radio item can be selected at a time in a given group of radio items.</summary>
        [JsAccessPath("checked")]
        [JsonPropertyName("checked")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Checked { get; set; }

        /// <summary>Specifies a command to issue for the context click.</summary>
        [JsAccessPath("command")]
        [JsonPropertyName("command")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Command Command { get; set; }

        /// <summary>List of contexts this menu item will appear in. Defaults to ['page'] if not specified.</summary>
        [JsAccessPath("contexts")]
        [JsonPropertyName("contexts")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<ContextType> Contexts { get; set; }

        /// <summary>Lets you restrict the item to apply only to documents whose URL matches one of the given patterns. (This applies to frames as well.) For details on the format of a pattern, see $(topic:match_patterns)[Match Patterns].</summary>
        [JsAccessPath("documentUrlPatterns")]
        [JsonPropertyName("documentUrlPatterns")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> DocumentUrlPatterns { get; set; }

        /// <summary>Whether this context menu item is enabled or disabled. Defaults to true.</summary>
        [JsAccessPath("enabled")]
        [JsonPropertyName("enabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Enabled { get; set; }

        /// <summary></summary>
        [JsAccessPath("icons")]
        [JsonPropertyName("icons")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object Icons { get; set; }

        /// <summary>The unique ID to assign to this item. Mandatory for event pages. Cannot be the same as another ID for this extension.</summary>
        [JsAccessPath("id")]
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Id { get; set; }

        /// <summary>A function that will be called back when the menu item is clicked. Event pages cannot use this; instead, they should register a listener for $(ref:contextMenus.onClicked).</summary>
        [JsAccessPath("onclick")]
        [JsonPropertyName("onclick")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Action<OnClickData, Tab> Onclick { get; set; }

        /// <summary>The ID of a parent menu item; this makes the item a child of a previously added item.</summary>
        [JsAccessPath("parentId")]
        [JsonPropertyName("parentId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CreatePropertiesParentId ParentId { get; set; }

        /// <summary>Similar to documentUrlPatterns, but lets you filter based on the src attribute of img/audio/video tags and the href of anchor tags.</summary>
        [JsAccessPath("targetUrlPatterns")]
        [JsonPropertyName("targetUrlPatterns")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> TargetUrlPatterns { get; set; }

        /// <summary>The text to be displayed in the item; this is <em>required</em> unless <c>type</c> is 'separator'. When the context is 'selection', you can use <c>%s</c> within the string to show the selected text. For example, if this parameter's value is "Translate '%s' to Pig Latin" and the user selects the word "cool", the context menu item for the selection is "Translate 'cool' to Pig Latin".</summary>
        [JsAccessPath("title")]
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title { get; set; }

        /// <summary>The type of menu item. Defaults to 'normal' if not specified.</summary>
        [JsAccessPath("type")]
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ItemType? Type { get; set; }

        /// <summary>List of view types where the menu item will be shown. Defaults to any view, including those without a viewType.</summary>
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
