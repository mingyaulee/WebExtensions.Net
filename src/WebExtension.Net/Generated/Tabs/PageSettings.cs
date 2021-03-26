using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Tabs
{
    // Class Definition
    /// <summary>
    /// Defines the page settings to be used when saving a page as a pdf file.
    /// </summary>
    public class PageSettings : BaseObject
    {
        
        // Property Definition
        private string _toFileName;
        /// <summary>
        /// The name of the file. May include optional .pdf extension.
        /// </summary>
        [JsonPropertyName("toFileName")]
        public string ToFileName
        {
            get
            {
                InitializeProperty("toFileName", _toFileName);
                return _toFileName;
            }
            set
            {
                _toFileName = value;
            }
        }
        
        // Property Definition
        private int? _paperSizeUnit;
        /// <summary>
        /// The page size unit: 0 = inches, 1 = millimeters. Default: 0.
        /// </summary>
        [JsonPropertyName("paperSizeUnit")]
        public int? PaperSizeUnit
        {
            get
            {
                InitializeProperty("paperSizeUnit", _paperSizeUnit);
                return _paperSizeUnit;
            }
            set
            {
                _paperSizeUnit = value;
            }
        }
        
        // Property Definition
        private double? _paperWidth;
        /// <summary>
        /// The paper width in paper size units. Default: 8.5.
        /// </summary>
        [JsonPropertyName("paperWidth")]
        public double? PaperWidth
        {
            get
            {
                InitializeProperty("paperWidth", _paperWidth);
                return _paperWidth;
            }
            set
            {
                _paperWidth = value;
            }
        }
        
        // Property Definition
        private double? _paperHeight;
        /// <summary>
        /// The paper height in paper size units. Default: 11.0.
        /// </summary>
        [JsonPropertyName("paperHeight")]
        public double? PaperHeight
        {
            get
            {
                InitializeProperty("paperHeight", _paperHeight);
                return _paperHeight;
            }
            set
            {
                _paperHeight = value;
            }
        }
        
        // Property Definition
        private int? _orientation;
        /// <summary>
        /// The page content orientation: 0 = portrait, 1 = landscape. Default: 0.
        /// </summary>
        [JsonPropertyName("orientation")]
        public int? Orientation
        {
            get
            {
                InitializeProperty("orientation", _orientation);
                return _orientation;
            }
            set
            {
                _orientation = value;
            }
        }
        
        // Property Definition
        private double? _scaling;
        /// <summary>
        /// The page content scaling factor: 1.0 = 100% = normal size. Default: 1.0.
        /// </summary>
        [JsonPropertyName("scaling")]
        public double? Scaling
        {
            get
            {
                InitializeProperty("scaling", _scaling);
                return _scaling;
            }
            set
            {
                _scaling = value;
            }
        }
        
        // Property Definition
        private bool? _shrinkToFit;
        /// <summary>
        /// Whether the page content should shrink to fit the page width (overrides scaling). Default: true.
        /// </summary>
        [JsonPropertyName("shrinkToFit")]
        public bool? ShrinkToFit
        {
            get
            {
                InitializeProperty("shrinkToFit", _shrinkToFit);
                return _shrinkToFit;
            }
            set
            {
                _shrinkToFit = value;
            }
        }
        
        // Property Definition
        private bool? _showBackgroundColors;
        /// <summary>
        /// Whether the page background colors should be shown. Default: false.
        /// </summary>
        [JsonPropertyName("showBackgroundColors")]
        public bool? ShowBackgroundColors
        {
            get
            {
                InitializeProperty("showBackgroundColors", _showBackgroundColors);
                return _showBackgroundColors;
            }
            set
            {
                _showBackgroundColors = value;
            }
        }
        
        // Property Definition
        private bool? _showBackgroundImages;
        /// <summary>
        /// Whether the page background images should be shown. Default: false.
        /// </summary>
        [JsonPropertyName("showBackgroundImages")]
        public bool? ShowBackgroundImages
        {
            get
            {
                InitializeProperty("showBackgroundImages", _showBackgroundImages);
                return _showBackgroundImages;
            }
            set
            {
                _showBackgroundImages = value;
            }
        }
        
        // Property Definition
        private double? _edgeLeft;
        /// <summary>
        /// The spacing between the left header/footer and the left edge of the paper (inches). Default: 0.
        /// </summary>
        [JsonPropertyName("edgeLeft")]
        public double? EdgeLeft
        {
            get
            {
                InitializeProperty("edgeLeft", _edgeLeft);
                return _edgeLeft;
            }
            set
            {
                _edgeLeft = value;
            }
        }
        
        // Property Definition
        private double? _edgeRight;
        /// <summary>
        /// The spacing between the right header/footer and the right edge of the paper (inches). Default: 0.
        /// </summary>
        [JsonPropertyName("edgeRight")]
        public double? EdgeRight
        {
            get
            {
                InitializeProperty("edgeRight", _edgeRight);
                return _edgeRight;
            }
            set
            {
                _edgeRight = value;
            }
        }
        
        // Property Definition
        private double? _edgeTop;
        /// <summary>
        /// The spacing between the top of the headers and the top edge of the paper (inches). Default: 0
        /// </summary>
        [JsonPropertyName("edgeTop")]
        public double? EdgeTop
        {
            get
            {
                InitializeProperty("edgeTop", _edgeTop);
                return _edgeTop;
            }
            set
            {
                _edgeTop = value;
            }
        }
        
        // Property Definition
        private double? _edgeBottom;
        /// <summary>
        /// The spacing between the bottom of the footers and the bottom edge of the paper (inches). Default: 0.
        /// </summary>
        [JsonPropertyName("edgeBottom")]
        public double? EdgeBottom
        {
            get
            {
                InitializeProperty("edgeBottom", _edgeBottom);
                return _edgeBottom;
            }
            set
            {
                _edgeBottom = value;
            }
        }
        
        // Property Definition
        private double? _marginLeft;
        /// <summary>
        /// The margin between the page content and the left edge of the paper (inches). Default: 0.5.
        /// </summary>
        [JsonPropertyName("marginLeft")]
        public double? MarginLeft
        {
            get
            {
                InitializeProperty("marginLeft", _marginLeft);
                return _marginLeft;
            }
            set
            {
                _marginLeft = value;
            }
        }
        
        // Property Definition
        private double? _marginRight;
        /// <summary>
        /// The margin between the page content and the right edge of the paper (inches). Default: 0.5.
        /// </summary>
        [JsonPropertyName("marginRight")]
        public double? MarginRight
        {
            get
            {
                InitializeProperty("marginRight", _marginRight);
                return _marginRight;
            }
            set
            {
                _marginRight = value;
            }
        }
        
        // Property Definition
        private double? _marginTop;
        /// <summary>
        /// The margin between the page content and the top edge of the paper (inches). Default: 0.5.
        /// </summary>
        [JsonPropertyName("marginTop")]
        public double? MarginTop
        {
            get
            {
                InitializeProperty("marginTop", _marginTop);
                return _marginTop;
            }
            set
            {
                _marginTop = value;
            }
        }
        
        // Property Definition
        private double? _marginBottom;
        /// <summary>
        /// The margin between the page content and the bottom edge of the paper (inches). Default: 0.5.
        /// </summary>
        [JsonPropertyName("marginBottom")]
        public double? MarginBottom
        {
            get
            {
                InitializeProperty("marginBottom", _marginBottom);
                return _marginBottom;
            }
            set
            {
                _marginBottom = value;
            }
        }
        
        // Property Definition
        private string _headerLeft;
        /// <summary>
        /// The text for the page's left header. Default: '&amp;T'.
        /// </summary>
        [JsonPropertyName("headerLeft")]
        public string HeaderLeft
        {
            get
            {
                InitializeProperty("headerLeft", _headerLeft);
                return _headerLeft;
            }
            set
            {
                _headerLeft = value;
            }
        }
        
        // Property Definition
        private string _headerCenter;
        /// <summary>
        /// The text for the page's center header. Default: ''.
        /// </summary>
        [JsonPropertyName("headerCenter")]
        public string HeaderCenter
        {
            get
            {
                InitializeProperty("headerCenter", _headerCenter);
                return _headerCenter;
            }
            set
            {
                _headerCenter = value;
            }
        }
        
        // Property Definition
        private string _headerRight;
        /// <summary>
        /// The text for the page's right header. Default: '&amp;U'.
        /// </summary>
        [JsonPropertyName("headerRight")]
        public string HeaderRight
        {
            get
            {
                InitializeProperty("headerRight", _headerRight);
                return _headerRight;
            }
            set
            {
                _headerRight = value;
            }
        }
        
        // Property Definition
        private string _footerLeft;
        /// <summary>
        /// The text for the page's left footer. Default: '&amp;PT'.
        /// </summary>
        [JsonPropertyName("footerLeft")]
        public string FooterLeft
        {
            get
            {
                InitializeProperty("footerLeft", _footerLeft);
                return _footerLeft;
            }
            set
            {
                _footerLeft = value;
            }
        }
        
        // Property Definition
        private string _footerCenter;
        /// <summary>
        /// The text for the page's center footer. Default: ''.
        /// </summary>
        [JsonPropertyName("footerCenter")]
        public string FooterCenter
        {
            get
            {
                InitializeProperty("footerCenter", _footerCenter);
                return _footerCenter;
            }
            set
            {
                _footerCenter = value;
            }
        }
        
        // Property Definition
        private string _footerRight;
        /// <summary>
        /// The text for the page's right footer. Default: '&amp;D'.
        /// </summary>
        [JsonPropertyName("footerRight")]
        public string FooterRight
        {
            get
            {
                InitializeProperty("footerRight", _footerRight);
                return _footerRight;
            }
            set
            {
                _footerRight = value;
            }
        }
    }
}

