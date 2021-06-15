using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebExtensions.Net.Extension;
using WebExtensions.Net.Tabs;

namespace WebExtensions.Net.Menus
{
    // Type Class
    /// <summary></summary>
    public partial class CreateProperties : BaseObject
    {
        private bool? _checked;
        private string _command;
        private IEnumerable<ContextType> _contexts;
        private IEnumerable<string> _documentUrlPatterns;
        private bool? _enabled;
        private object _icons;
        private string _id;
        private Action<OnClickData, Tab> _onclick;
        private CreatePropertiesParentId _parentId;
        private IEnumerable<string> _targetUrlPatterns;
        private string _title;
        private ItemType? _type;
        private IEnumerable<ViewType> _viewTypes;
        private bool? _visible;

        /// <summary>The initial state of a checkbox or radio item: true for selected and false for unselected. Only one radio item can be selected at a time in a given group of radio items.</summary>
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

        /// <summary>Specifies a command to issue for the context click.  Currently supports internal commands _execute_page_action, _execute_browser_action and _execute_sidebar_action.</summary>
        [JsonPropertyName("command")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Command
        {
            get
            {
                InitializeProperty("command", _command);
                return _command;
            }
            set
            {
                _command = value;
            }
        }

        /// <summary>List of contexts this menu item will appear in. Defaults to ['page'] if not specified.</summary>
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

        /// <summary>Lets you restrict the item to apply only to documents whose URL matches one of the given patterns. (This applies to frames as well.) For details on the format of a pattern, see $(topic:match_patterns)[Match Patterns].</summary>
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

        /// <summary>Whether this context menu item is enabled or disabled. Defaults to true.</summary>
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

        /// <summary>The unique ID to assign to this item. Mandatory for event pages. Cannot be the same as another ID for this extension.</summary>
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Id
        {
            get
            {
                InitializeProperty("id", _id);
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        /// <summary>A function that will be called back when the menu item is clicked. Event pages cannot use this; instead, they should register a listener for $(ref:contextMenus.onClicked).</summary>
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

        /// <summary>The ID of a parent menu item; this makes the item a child of a previously added item.</summary>
        [JsonPropertyName("parentId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CreatePropertiesParentId ParentId
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

        /// <summary>Similar to documentUrlPatterns, but lets you filter based on the src attribute of img/audio/video tags and the href of anchor tags.</summary>
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

        /// <summary>The text to be displayed in the item; this is <em>required</em> unless <c>type</c> is 'separator'. When the context is 'selection', you can use <c>%s</c> within the string to show the selected text. For example, if this parameter's value is "Translate '%s' to Pig Latin" and the user selects the word "cool", the context menu item for the selection is "Translate 'cool' to Pig Latin".</summary>
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

        /// <summary>The type of menu item. Defaults to 'normal' if not specified.</summary>
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

        /// <summary>List of view types where the menu item will be shown. Defaults to any view, including those without a viewType.</summary>
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
