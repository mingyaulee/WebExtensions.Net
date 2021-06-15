using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebExtensions.Net.Extension;

namespace WebExtensions.Net.Menus
{
    // Type Class
    /// <summary>Information sent when a context menu item is clicked.</summary>
    public partial class OnClickData : BaseObject
    {
        private string _bookmarkId;
        private int? _button;
        private bool? _checked;
        private bool _editable;
        private int? _frameId;
        private string _frameUrl;
        private string _linkText;
        private string _linkUrl;
        private string _mediaType;
        private OnClickDataMenuItemId _menuItemId;
        private IEnumerable<string> _modifiers;
        private string _pageUrl;
        private ParentMenuItemId _parentMenuItemId;
        private string _selectionText;
        private string _srcUrl;
        private int? _targetElementId;
        private ViewType? _viewType;
        private bool? _wasChecked;

        /// <summary>The id of the bookmark where the context menu was clicked, if it was on a bookmark.</summary>
        [JsonPropertyName("bookmarkId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string BookmarkId
        {
            get
            {
                InitializeProperty("bookmarkId", _bookmarkId);
                return _bookmarkId;
            }
            set
            {
                _bookmarkId = value;
            }
        }

        /// <summary>An integer value of button by which menu item was clicked.</summary>
        [JsonPropertyName("button")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Button
        {
            get
            {
                InitializeProperty("button", _button);
                return _button;
            }
            set
            {
                _button = value;
            }
        }

        /// <summary>A flag indicating the state of a checkbox or radio item after it is clicked.</summary>
        [JsonPropertyName("checked")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Checked
        {
            get
            {
                InitializeProperty("checked", _checked);
                return _checked;
            }
            set
            {
                _checked = value;
            }
        }

        /// <summary>A flag indicating whether the element is editable (text input, textarea, etc.).</summary>
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

        /// <summary>The id of the frame of the element where the context menu was clicked.</summary>
        [JsonPropertyName("frameId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? FrameId
        {
            get
            {
                InitializeProperty("frameId", _frameId);
                return _frameId;
            }
            set
            {
                _frameId = value;
            }
        }

        /// <summary> The URL of the frame of the element where the context menu was clicked, if it was in a frame.</summary>
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

        /// <summary>If the element is a link, the text of that link.</summary>
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

        /// <summary>If the element is a link, the URL it points to.</summary>
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

        /// <summary>One of 'image', 'video', or 'audio' if the context menu was activated on one of these types of elements.</summary>
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

        /// <summary>The ID of the menu item that was clicked.</summary>
        [JsonPropertyName("menuItemId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public OnClickDataMenuItemId MenuItemId
        {
            get
            {
                InitializeProperty("menuItemId", _menuItemId);
                return _menuItemId;
            }
            set
            {
                _menuItemId = value;
            }
        }

        /// <summary>An array of keyboard modifiers that were held while the menu item was clicked.</summary>
        [JsonPropertyName("modifiers")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> Modifiers
        {
            get
            {
                InitializeProperty("modifiers", _modifiers);
                return _modifiers;
            }
            set
            {
                _modifiers = value;
            }
        }

        /// <summary>The URL of the page where the menu item was clicked. This property is not set if the click occured in a context where there is no current page, such as in a launcher context menu.</summary>
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

        /// <summary>The parent ID, if any, for the item clicked.</summary>
        [JsonPropertyName("parentMenuItemId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ParentMenuItemId ParentMenuItemId
        {
            get
            {
                InitializeProperty("parentMenuItemId", _parentMenuItemId);
                return _parentMenuItemId;
            }
            set
            {
                _parentMenuItemId = value;
            }
        }

        /// <summary>The text for the context selection, if any.</summary>
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

        /// <summary>Will be present for elements with a 'src' URL.</summary>
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

        /// <summary>An identifier of the clicked element, if any. Use menus.getTargetElement in the page to find the corresponding element.</summary>
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

        /// <summary>The type of view where the menu is clicked. May be unset if the menu is not associated with a view.</summary>
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

        /// <summary>A flag indicating the state of a checkbox or radio item before it was clicked.</summary>
        [JsonPropertyName("wasChecked")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? WasChecked
        {
            get
            {
                InitializeProperty("wasChecked", _wasChecked);
                return _wasChecked;
            }
            set
            {
                _wasChecked = value;
            }
        }
    }
}
