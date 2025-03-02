using JsBind.Net;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class Images : BaseObject
    {
        /// <summary></summary>
        [JsAccessPath("additional_backgrounds")]
        [JsonPropertyName("additional_backgrounds")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<ImageDataOrExtensionUrl> Additional_backgrounds { get; set; }

        /// <summary></summary>
        [Obsolete("Unsupported images property, use 'theme.images.theme_frame', this alias is ignored in Firefox >= 70.")]
        [JsAccessPath("headerURL")]
        [JsonPropertyName("headerURL")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ImageDataOrExtensionUrl HeaderURL { get; set; }

        /// <summary></summary>
        [JsAccessPath("theme_frame")]
        [JsonPropertyName("theme_frame")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ImageDataOrExtensionUrl Theme_frame { get; set; }
    }
}
