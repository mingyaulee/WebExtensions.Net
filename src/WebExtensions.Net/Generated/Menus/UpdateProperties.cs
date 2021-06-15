using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebExtensions.Net.Extension;
using WebExtensions.Net.Tabs;

namespace WebExtensions.Net.Menus
{
    // Type Class
    /// <summary>The properties to update. Accepts the same values as the create function.</summary>
    public partial class UpdateProperties : BaseObject
    {
        private bool? _checked;
        private IEnumerable<ContextType> _contexts;
        private IEnumerable<string> _documentUrlPatterns;
        private bool? _enabled;
        private object _icons;
        private Action<OnClickData, Tab> _onclick;
        private UpdatePropertiesParentId _parentId;
        private IEnumerable<string> _targetUrlPatterns;
        private string _title;
        private ItemType? _type;
        private IEnumerable<ViewType> _viewTypes;
        private bool? _visible;

        /// <summary></summary>
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

        /// <summary></summary>
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
        [JsonPropertyName("documentUrlPatterns")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> DocumentUrlPatterns
        {
            get
            {
                InitializeProperty("documentUrlPatterns", _documentUrlPatterns);
                return _documentUrlPatterns;
            }
            set
            {
                _documentUrlPatterns = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("enabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Enabled
        {
            get
            {
                InitializeProperty("enabled", _enabled);
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("icons")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object Icons
        {
            get
            {
                InitializeProperty("icons", _icons);
                return _icons;
            }
            set
            {
                _icons = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("onclick")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Action<OnClickData, Tab> Onclick
        {
            get
            {
                InitializeProperty("onclick", _onclick);
                return _onclick;
            }
            set
            {
                _onclick = value;
            }
        }

        /// <summary>Note: You cannot change an item to be a child of one of its own descendants.</summary>
        [JsonPropertyName("parentId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UpdatePropertiesParentId ParentId
        {
            get
            {
                InitializeProperty("parentId", _parentId);
                return _parentId;
            }
            set
            {
                _parentId = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("targetUrlPatterns")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> TargetUrlPatterns
        {
            get
            {
                InitializeProperty("targetUrlPatterns", _targetUrlPatterns);
                return _targetUrlPatterns;
            }
            set
            {
                _targetUrlPatterns = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title
        {
            get
            {
                InitializeProperty("title", _title);
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ItemType? Type
        {
            get
            {
                InitializeProperty("type", _type);
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("viewTypes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<ViewType> ViewTypes
        {
            get
            {
                InitializeProperty("viewTypes", _viewTypes);
                return _viewTypes;
            }
            set
            {
                _viewTypes = value;
            }
        }

        /// <summary>Whether the item is visible in the menu.</summary>
        [JsonPropertyName("visible")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Visible
        {
            get
            {
                InitializeProperty("visible", _visible);
                return _visible;
            }
            set
            {
                _visible = value;
            }
        }
    }
}
