/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Tabs
{
    /// Class Definition
    /// <summary>Defines the page settings to be used when saving a page as a pdf file.</summary>
    public class PageSettings
    {
        
        /// Property Definition
        /// <summary>The name of the file. May include optional .pdf extension.</summary>
        [JsonPropertyName("toFileName")]
        public string ToFileName { get; set; }
        
        /// Property Definition
        /// <summary>The page size unit: 0 = inches, 1 = millimeters. Default: 0.</summary>
        [JsonPropertyName("paperSizeUnit")]
        public int? PaperSizeUnit { get; set; }
        
        /// Property Definition
        /// <summary>The paper width in paper size units. Default: 8.5.</summary>
        [JsonPropertyName("paperWidth")]
        public double? PaperWidth { get; set; }
        
        /// Property Definition
        /// <summary>The paper height in paper size units. Default: 11.0.</summary>
        [JsonPropertyName("paperHeight")]
        public double? PaperHeight { get; set; }
        
        /// Property Definition
        /// <summary>The page content orientation: 0 = portrait, 1 = landscape. Default: 0.</summary>
        [JsonPropertyName("orientation")]
        public int? Orientation { get; set; }
        
        /// Property Definition
        /// <summary>The page content scaling factor: 1.0 = 100% = normal size. Default: 1.0.</summary>
        [JsonPropertyName("scaling")]
        public double? Scaling { get; set; }
        
        /// Property Definition
        /// <summary>Whether the page content should shrink to fit the page width (overrides scaling). Default: true.</summary>
        [JsonPropertyName("shrinkToFit")]
        public bool? ShrinkToFit { get; set; }
        
        /// Property Definition
        /// <summary>Whether the page background colors should be shown. Default: false.</summary>
        [JsonPropertyName("showBackgroundColors")]
        public bool? ShowBackgroundColors { get; set; }
        
        /// Property Definition
        /// <summary>Whether the page background images should be shown. Default: false.</summary>
        [JsonPropertyName("showBackgroundImages")]
        public bool? ShowBackgroundImages { get; set; }
        
        /// Property Definition
        /// <summary>The spacing between the left header/footer and the left edge of the paper (inches). Default: 0.</summary>
        [JsonPropertyName("edgeLeft")]
        public double? EdgeLeft { get; set; }
        
        /// Property Definition
        /// <summary>The spacing between the right header/footer and the right edge of the paper (inches). Default: 0.</summary>
        [JsonPropertyName("edgeRight")]
        public double? EdgeRight { get; set; }
        
        /// Property Definition
        /// <summary>The spacing between the top of the headers and the top edge of the paper (inches). Default: 0</summary>
        [JsonPropertyName("edgeTop")]
        public double? EdgeTop { get; set; }
        
        /// Property Definition
        /// <summary>The spacing between the bottom of the footers and the bottom edge of the paper (inches). Default: 0.</summary>
        [JsonPropertyName("edgeBottom")]
        public double? EdgeBottom { get; set; }
        
        /// Property Definition
        /// <summary>The margin between the page content and the left edge of the paper (inches). Default: 0.5.</summary>
        [JsonPropertyName("marginLeft")]
        public double? MarginLeft { get; set; }
        
        /// Property Definition
        /// <summary>The margin between the page content and the right edge of the paper (inches). Default: 0.5.</summary>
        [JsonPropertyName("marginRight")]
        public double? MarginRight { get; set; }
        
        /// Property Definition
        /// <summary>The margin between the page content and the top edge of the paper (inches). Default: 0.5.</summary>
        [JsonPropertyName("marginTop")]
        public double? MarginTop { get; set; }
        
        /// Property Definition
        /// <summary>The margin between the page content and the bottom edge of the paper (inches). Default: 0.5.</summary>
        [JsonPropertyName("marginBottom")]
        public double? MarginBottom { get; set; }
        
        /// Property Definition
        /// <summary>The text for the page's left header. Default: '&T'.</summary>
        [JsonPropertyName("headerLeft")]
        public string HeaderLeft { get; set; }
        
        /// Property Definition
        /// <summary>The text for the page's center header. Default: ''.</summary>
        [JsonPropertyName("headerCenter")]
        public string HeaderCenter { get; set; }
        
        /// Property Definition
        /// <summary>The text for the page's right header. Default: '&U'.</summary>
        [JsonPropertyName("headerRight")]
        public string HeaderRight { get; set; }
        
        /// Property Definition
        /// <summary>The text for the page's left footer. Default: '&PT'.</summary>
        [JsonPropertyName("footerLeft")]
        public string FooterLeft { get; set; }
        
        /// Property Definition
        /// <summary>The text for the page's center footer. Default: ''.</summary>
        [JsonPropertyName("footerCenter")]
        public string FooterCenter { get; set; }
        
        /// Property Definition
        /// <summary>The text for the page's right footer. Default: '&D'.</summary>
        [JsonPropertyName("footerRight")]
        public string FooterRight { get; set; }
    }
}

