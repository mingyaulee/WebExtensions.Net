using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary>Defines the page settings to be used when saving a page as a pdf file.</summary>
    [BindAllProperties]
    public partial class PageSettings : BaseObject
    {
        /// <summary>The spacing between the bottom of the footers and the bottom edge of the paper (inches). Default: 0.</summary>
        [JsAccessPath("edgeBottom")]
        [JsonPropertyName("edgeBottom")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? EdgeBottom { get; set; }

        /// <summary>The spacing between the left header/footer and the left edge of the paper (inches). Default: 0.</summary>
        [JsAccessPath("edgeLeft")]
        [JsonPropertyName("edgeLeft")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? EdgeLeft { get; set; }

        /// <summary>The spacing between the right header/footer and the right edge of the paper (inches). Default: 0.</summary>
        [JsAccessPath("edgeRight")]
        [JsonPropertyName("edgeRight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? EdgeRight { get; set; }

        /// <summary>The spacing between the top of the headers and the top edge of the paper (inches). Default: 0</summary>
        [JsAccessPath("edgeTop")]
        [JsonPropertyName("edgeTop")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? EdgeTop { get; set; }

        /// <summary>The text for the page's center footer. Default: ''.</summary>
        [JsAccessPath("footerCenter")]
        [JsonPropertyName("footerCenter")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string FooterCenter { get; set; }

        /// <summary>The text for the page's left footer. Default: '&amp;PT'.</summary>
        [JsAccessPath("footerLeft")]
        [JsonPropertyName("footerLeft")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string FooterLeft { get; set; }

        /// <summary>The text for the page's right footer. Default: '&amp;D'.</summary>
        [JsAccessPath("footerRight")]
        [JsonPropertyName("footerRight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string FooterRight { get; set; }

        /// <summary>The text for the page's center header. Default: ''.</summary>
        [JsAccessPath("headerCenter")]
        [JsonPropertyName("headerCenter")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string HeaderCenter { get; set; }

        /// <summary>The text for the page's left header. Default: '&amp;T'.</summary>
        [JsAccessPath("headerLeft")]
        [JsonPropertyName("headerLeft")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string HeaderLeft { get; set; }

        /// <summary>The text for the page's right header. Default: '&amp;U'.</summary>
        [JsAccessPath("headerRight")]
        [JsonPropertyName("headerRight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string HeaderRight { get; set; }

        /// <summary>The margin between the page content and the bottom edge of the paper (inches). Default: 0.5.</summary>
        [JsAccessPath("marginBottom")]
        [JsonPropertyName("marginBottom")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? MarginBottom { get; set; }

        /// <summary>The margin between the page content and the left edge of the paper (inches). Default: 0.5.</summary>
        [JsAccessPath("marginLeft")]
        [JsonPropertyName("marginLeft")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? MarginLeft { get; set; }

        /// <summary>The margin between the page content and the right edge of the paper (inches). Default: 0.5.</summary>
        [JsAccessPath("marginRight")]
        [JsonPropertyName("marginRight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? MarginRight { get; set; }

        /// <summary>The margin between the page content and the top edge of the paper (inches). Default: 0.5.</summary>
        [JsAccessPath("marginTop")]
        [JsonPropertyName("marginTop")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? MarginTop { get; set; }

        /// <summary>The page content orientation: 0 = portrait, 1 = landscape. Default: 0.</summary>
        [JsAccessPath("orientation")]
        [JsonPropertyName("orientation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Orientation { get; set; }

        /// <summary>The paper height in paper size units. Default: 11.0.</summary>
        [JsAccessPath("paperHeight")]
        [JsonPropertyName("paperHeight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? PaperHeight { get; set; }

        /// <summary>The page size unit: 0 = inches, 1 = millimeters. Default: 0.</summary>
        [JsAccessPath("paperSizeUnit")]
        [JsonPropertyName("paperSizeUnit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? PaperSizeUnit { get; set; }

        /// <summary>The paper width in paper size units. Default: 8.5.</summary>
        [JsAccessPath("paperWidth")]
        [JsonPropertyName("paperWidth")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? PaperWidth { get; set; }

        /// <summary>The page content scaling factor: 1.0 = 100% = normal size. Default: 1.0.</summary>
        [JsAccessPath("scaling")]
        [JsonPropertyName("scaling")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Scaling { get; set; }

        /// <summary>Whether the page background colors should be shown. Default: false.</summary>
        [JsAccessPath("showBackgroundColors")]
        [JsonPropertyName("showBackgroundColors")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ShowBackgroundColors { get; set; }

        /// <summary>Whether the page background images should be shown. Default: false.</summary>
        [JsAccessPath("showBackgroundImages")]
        [JsonPropertyName("showBackgroundImages")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ShowBackgroundImages { get; set; }

        /// <summary>Whether the page content should shrink to fit the page width (overrides scaling). Default: true.</summary>
        [JsAccessPath("shrinkToFit")]
        [JsonPropertyName("shrinkToFit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ShrinkToFit { get; set; }

        /// <summary>The name of the file. May include optional .pdf extension.</summary>
        [JsAccessPath("toFileName")]
        [JsonPropertyName("toFileName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ToFileName { get; set; }
    }
}
