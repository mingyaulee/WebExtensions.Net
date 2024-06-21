using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebExtensions.Net.Extension;

namespace WebExtensions.Net.Menus
{
    // Type Class
    /// <summary>Information sent when a context menu item is clicked.</summary>
    [BindAllProperties]
    public partial class OnClickData : BaseObject
    {
        /// <summary>The id of the bookmark where the context menu was clicked, if it was on a bookmark.</summary>
        [JsAccessPath("bookmarkId")]
        [JsonPropertyName("bookmarkId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string BookmarkId { get; set; }

        /// <summary>An integer value of button by which menu item was clicked.</summary>
        [JsAccessPath("button")]
        [JsonPropertyName("button")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Button { get; set; }

        /// <summary>A flag indicating the state of a checkbox or radio item after it is clicked.</summary>
        [JsAccessPath("checked")]
        [JsonPropertyName("checked")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Checked { get; set; }

        /// <summary>A flag indicating whether the element is editable (text input, textarea, etc.).</summary>
        [JsAccessPath("editable")]
        [JsonPropertyName("editable")]
        public bool Editable { get; set; }

        /// <summary>The id of the frame of the element where the context menu was clicked.</summary>
        [JsAccessPath("frameId")]
        [JsonPropertyName("frameId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? FrameId { get; set; }

        /// <summary> The URL of the frame of the element where the context menu was clicked, if it was in a frame.</summary>
        [JsAccessPath("frameUrl")]
        [JsonPropertyName("frameUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string FrameUrl { get; set; }

        /// <summary>If the element is a link, the text of that link.</summary>
        [JsAccessPath("linkText")]
        [JsonPropertyName("linkText")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string LinkText { get; set; }

        /// <summary>If the element is a link, the URL it points to.</summary>
        [JsAccessPath("linkUrl")]
        [JsonPropertyName("linkUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string LinkUrl { get; set; }

        /// <summary>One of 'image', 'video', or 'audio' if the context menu was activated on one of these types of elements.</summary>
        [JsAccessPath("mediaType")]
        [JsonPropertyName("mediaType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string MediaType { get; set; }

        /// <summary>The ID of the menu item that was clicked.</summary>
        [JsAccessPath("menuItemId")]
        [JsonPropertyName("menuItemId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public OnClickDataMenuItemId MenuItemId { get; set; }

        /// <summary>An array of keyboard modifiers that were held while the menu item was clicked.</summary>
        [JsAccessPath("modifiers")]
        [JsonPropertyName("modifiers")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> Modifiers { get; set; }

        /// <summary>The URL of the page where the menu item was clicked. This property is not set if the click occured in a context where there is no current page, such as in a launcher context menu.</summary>
        [JsAccessPath("pageUrl")]
        [JsonPropertyName("pageUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string PageUrl { get; set; }

        /// <summary>The parent ID, if any, for the item clicked.</summary>
        [JsAccessPath("parentMenuItemId")]
        [JsonPropertyName("parentMenuItemId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ParentMenuItemId ParentMenuItemId { get; set; }

        /// <summary>The text for the context selection, if any.</summary>
        [JsAccessPath("selectionText")]
        [JsonPropertyName("selectionText")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string SelectionText { get; set; }

        /// <summary>Will be present for elements with a 'src' URL.</summary>
        [JsAccessPath("srcUrl")]
        [JsonPropertyName("srcUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string SrcUrl { get; set; }

        /// <summary>An identifier of the clicked element, if any. Use menus.getTargetElement in the page to find the corresponding element.</summary>
        [JsAccessPath("targetElementId")]
        [JsonPropertyName("targetElementId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TargetElementId { get; set; }

        /// <summary>The type of view where the menu is clicked. May be unset if the menu is not associated with a view.</summary>
        [JsAccessPath("viewType")]
        [JsonPropertyName("viewType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ViewType? ViewType { get; set; }

        /// <summary>A flag indicating the state of a checkbox or radio item before it was clicked.</summary>
        [JsAccessPath("wasChecked")]
        [JsonPropertyName("wasChecked")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? WasChecked { get; set; }
    }
}
