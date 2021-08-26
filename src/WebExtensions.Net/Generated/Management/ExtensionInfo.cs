using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Management
{
    // Type Class
    /// <summary>Information about an installed extension.</summary>
    [BindAllProperties]
    public partial class ExtensionInfo : BaseObject
    {
        /// <summary>The description of this extension.</summary>
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Description { get; set; }

        /// <summary>A reason the item is disabled.</summary>
        [JsonPropertyName("disabledReason")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ExtensionDisabledReason? DisabledReason { get; set; }

        /// <summary>Whether it is currently enabled or disabled.</summary>
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        /// <summary>The URL of the homepage of this extension.</summary>
        [JsonPropertyName("homepageUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string HomepageUrl { get; set; }

        /// <summary>Returns a list of host based permissions.</summary>
        [JsonPropertyName("hostPermissions")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> HostPermissions { get; set; }

        /// <summary>A list of icon information. Note that this just reflects what was declared in the manifest, and the actual image at that url may be larger or smaller than what was declared, so you might consider using explicit width and height attributes on img tags referencing these images. See the <see href='manifest/icons'>manifest documentation on icons</see> for more details.</summary>
        [JsonPropertyName("icons")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<IconInfo> Icons { get; set; }

        /// <summary>The extension's unique identifier.</summary>
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Id { get; set; }

        /// <summary>How the extension was installed.</summary>
        [JsonPropertyName("installType")]
        public ExtensionInstallType InstallType { get; set; }

        /// <summary>Whether this extension can be disabled or uninstalled by the user.</summary>
        [JsonPropertyName("mayDisable")]
        public bool MayDisable { get; set; }

        /// <summary>The name of this extension.</summary>
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name { get; set; }

        /// <summary>The url for the item's options page, if it has one.</summary>
        [JsonPropertyName("optionsUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string OptionsUrl { get; set; }

        /// <summary>Returns a list of API based permissions.</summary>
        [JsonPropertyName("permissions")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> Permissions { get; set; }

        /// <summary>A short version of the name of this extension.</summary>
        [JsonPropertyName("shortName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ShortName { get; set; }

        /// <summary>The type of this extension, 'extension' or 'theme'.</summary>
        [JsonPropertyName("type")]
        public ExtensionType Type { get; set; }

        /// <summary>The update URL of this extension.</summary>
        [JsonPropertyName("updateUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string UpdateUrl { get; set; }

        /// <summary>The <see href='manifest/version'>version</see> of this extension.</summary>
        [JsonPropertyName("version")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Version { get; set; }

        /// <summary>The <see href='manifest/version#version_name'>version name</see> of this extension if the manifest specified one.</summary>
        [JsonPropertyName("versionName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string VersionName { get; set; }
    }
}
