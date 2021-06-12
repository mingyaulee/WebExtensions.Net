using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Management
{
    // Type Class
    /// <summary>Information about an installed extension.</summary>
    public partial class ExtensionInfo : BaseObject
    {
        private string _description;
        private ExtensionDisabledReason? _disabledReason;
        private bool _enabled;
        private string _homepageUrl;
        private IEnumerable<string> _hostPermissions;
        private IEnumerable<IconInfo> _icons;
        private string _id;
        private ExtensionInstallType _installType;
        private bool _mayDisable;
        private string _name;
        private string _optionsUrl;
        private IEnumerable<string> _permissions;
        private string _shortName;
        private ExtensionType _type;
        private string _updateUrl;
        private string _version;
        private string _versionName;

        /// <summary>The description of this extension.</summary>
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Description
        {
            get
            {
                InitializeProperty("description", _description);
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        /// <summary>A reason the item is disabled.</summary>
        [JsonPropertyName("disabledReason")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ExtensionDisabledReason? DisabledReason
        {
            get
            {
                InitializeProperty("disabledReason", _disabledReason);
                return _disabledReason;
            }
            set
            {
                _disabledReason = value;
            }
        }

        /// <summary>Whether it is currently enabled or disabled.</summary>
        [JsonPropertyName("enabled")]
        public bool Enabled
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

        /// <summary>The URL of the homepage of this extension.</summary>
        [JsonPropertyName("homepageUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string HomepageUrl
        {
            get
            {
                InitializeProperty("homepageUrl", _homepageUrl);
                return _homepageUrl;
            }
            set
            {
                _homepageUrl = value;
            }
        }

        /// <summary>Returns a list of host based permissions.</summary>
        [JsonPropertyName("hostPermissions")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> HostPermissions
        {
            get
            {
                InitializeProperty("hostPermissions", _hostPermissions);
                return _hostPermissions;
            }
            set
            {
                _hostPermissions = value;
            }
        }

        /// <summary>A list of icon information. Note that this just reflects what was declared in the manifest, and the actual image at that url may be larger or smaller than what was declared, so you might consider using explicit width and height attributes on img tags referencing these images. See the <see href='manifest/icons'>manifest documentation on icons</see> for more details.</summary>
        [JsonPropertyName("icons")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<IconInfo> Icons
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

        /// <summary>The extension's unique identifier.</summary>
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

        /// <summary>How the extension was installed.</summary>
        [JsonPropertyName("installType")]
        public ExtensionInstallType InstallType
        {
            get
            {
                InitializeProperty("installType", _installType);
                return _installType;
            }
            set
            {
                _installType = value;
            }
        }

        /// <summary>Whether this extension can be disabled or uninstalled by the user.</summary>
        [JsonPropertyName("mayDisable")]
        public bool MayDisable
        {
            get
            {
                InitializeProperty("mayDisable", _mayDisable);
                return _mayDisable;
            }
            set
            {
                _mayDisable = value;
            }
        }

        /// <summary>The name of this extension.</summary>
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name
        {
            get
            {
                InitializeProperty("name", _name);
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>The url for the item's options page, if it has one.</summary>
        [JsonPropertyName("optionsUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string OptionsUrl
        {
            get
            {
                InitializeProperty("optionsUrl", _optionsUrl);
                return _optionsUrl;
            }
            set
            {
                _optionsUrl = value;
            }
        }

        /// <summary>Returns a list of API based permissions.</summary>
        [JsonPropertyName("permissions")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> Permissions
        {
            get
            {
                InitializeProperty("permissions", _permissions);
                return _permissions;
            }
            set
            {
                _permissions = value;
            }
        }

        /// <summary>A short version of the name of this extension.</summary>
        [JsonPropertyName("shortName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ShortName
        {
            get
            {
                InitializeProperty("shortName", _shortName);
                return _shortName;
            }
            set
            {
                _shortName = value;
            }
        }

        /// <summary>The type of this extension, 'extension' or 'theme'.</summary>
        [JsonPropertyName("type")]
        public ExtensionType Type
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

        /// <summary>The update URL of this extension.</summary>
        [JsonPropertyName("updateUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string UpdateUrl
        {
            get
            {
                InitializeProperty("updateUrl", _updateUrl);
                return _updateUrl;
            }
            set
            {
                _updateUrl = value;
            }
        }

        /// <summary>The <see href='manifest/version'>version</see> of this extension.</summary>
        [JsonPropertyName("version")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Version
        {
            get
            {
                InitializeProperty("version", _version);
                return _version;
            }
            set
            {
                _version = value;
            }
        }

        /// <summary>The <see href='manifest/version#version_name'>version name</see> of this extension if the manifest specified one.</summary>
        [JsonPropertyName("versionName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string VersionName
        {
            get
            {
                InitializeProperty("versionName", _versionName);
                return _versionName;
            }
            set
            {
                _versionName = value;
            }
        }
    }
}
