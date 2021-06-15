using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebExtensions.Net.Extension;

namespace WebExtensions.Net.Menus
{
    // Type Class
    /// <summary>Information about the context of the menu action and the created menu items. For more information about each property, see OnClickData. The following properties are only set if the extension has host permissions for the given context: linkUrl, linkText, srcUrl, pageUrl, frameUrl, selectionText.</summary>
    public partial class HasListenerCallbackInfo : BaseObject
    {
        private IEnumerable<ContextType> _contexts;
        private bool _editable;
        private string _frameUrl;
        private string _linkText;
        private string _linkUrl;
        private string _mediaType;
        private IEnumerable<HasListenerCallbackInfoMenuIdsArrayItem> _menuIds;
        private string _pageUrl;
        private string _selectionText;
        private string _srcUrl;
        private int? _targetElementId;
        private ViewType? _viewType;

        /// <summary>A list of all contexts that apply to the menu.</summary>
        [JsonPropertyName("contexts")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<ContextType> Contexts
        {
            get
            {
                InitializeProperty("contexts", _contexts);
                return _contexts;
            }
            set
            {
                _contexts = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("editable")]
        public bool Editable
        {
            get
            {
                InitializeProperty("editable", _editable);
                return _editable;
            }
            set
            {
                _editable = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("frameUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string FrameUrl
        {
            get
            {
                InitializeProperty("frameUrl", _frameUrl);
                return _frameUrl;
            }
            set
            {
                _frameUrl = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("linkText")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string LinkText
        {
            get
            {
                InitializeProperty("linkText", _linkText);
                return _linkText;
            }
            set
            {
                _linkText = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("linkUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string LinkUrl
        {
            get
            {
                InitializeProperty("linkUrl", _linkUrl);
                return _linkUrl;
            }
            set
            {
                _linkUrl = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("mediaType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string MediaType
        {
            get
            {
                InitializeProperty("mediaType", _mediaType);
                return _mediaType;
            }
            set
            {
                _mediaType = value;
            }
        }

        /// <summary>A list of IDs of the menu items that were shown.</summary>
        [JsonPropertyName("menuIds")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<HasListenerCallbackInfoMenuIdsArrayItem> MenuIds
        {
            get
            {
                InitializeProperty("menuIds", _menuIds);
                return _menuIds;
            }
            set
            {
                _menuIds = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("pageUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string PageUrl
        {
            get
            {
                InitializeProperty("pageUrl", _pageUrl);
                return _pageUrl;
            }
            set
            {
                _pageUrl = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("selectionText")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string SelectionText
        {
            get
            {
                InitializeProperty("selectionText", _selectionText);
                return _selectionText;
            }
            set
            {
                _selectionText = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("srcUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string SrcUrl
        {
            get
            {
                InitializeProperty("srcUrl", _srcUrl);
                return _srcUrl;
            }
            set
            {
                _srcUrl = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("targetElementId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TargetElementId
        {
            get
            {
                InitializeProperty("targetElementId", _targetElementId);
                return _targetElementId;
            }
            set
            {
                _targetElementId = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("viewType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ViewType? ViewType
        {
            get
            {
                InitializeProperty("viewType", _viewType);
                return _viewType;
            }
            set
            {
                _viewType = value;
            }
        }
    }
}
