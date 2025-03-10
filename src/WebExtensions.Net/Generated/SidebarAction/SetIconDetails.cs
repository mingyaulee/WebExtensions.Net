using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.SidebarAction
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class SetIconDetails : BaseObject
    {
        /// <summary>Either an ImageData object or a dictionary {size -> ImageData} representing icon to be set. If the icon is specified as a dictionary, the actual image to be used is chosen depending on screen's pixel density. If the number of image pixels that fit into one screen space unit equals <c>scale</c>, then image with size <c>scale</c> * 19 will be selected. Initially only scales 1 and 2 will be supported. At least one image must be specified. Note that 'details.imageData = foo' is equivalent to 'details.imageData = {'19': foo}'</summary>
        [JsAccessPath("imageData")]
        [JsonPropertyName("imageData")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ImageData ImageData { get; set; }

        /// <summary>Either a relative image path or a dictionary {size -> relative image path} pointing to icon to be set. If the icon is specified as a dictionary, the actual image to be used is chosen depending on screen's pixel density. If the number of image pixels that fit into one screen space unit equals <c>scale</c>, then image with size <c>scale</c> * 19 will be selected. Initially only scales 1 and 2 will be supported. At least one image must be specified. Note that 'details.path = foo' is equivalent to 'details.imageData = {'19': foo}'</summary>
        [JsAccessPath("path")]
        [JsonPropertyName("path")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Path Path { get; set; }

        /// <summary>Sets the sidebar icon for the tab specified by tabId. Automatically resets when the tab is closed.</summary>
        [JsAccessPath("tabId")]
        [JsonPropertyName("tabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId { get; set; }

        /// <summary>Sets the sidebar icon for the window specified by windowId.</summary>
        [JsAccessPath("windowId")]
        [JsonPropertyName("windowId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId { get; set; }
    }
}
