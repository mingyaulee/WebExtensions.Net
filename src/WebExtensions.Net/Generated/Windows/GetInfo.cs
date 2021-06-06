using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Windows
{
    // Type Class
    /// <summary>Specifies whether the $(ref:windows.Window) returned should contain a list of the $(ref:tabs.Tab) objects.</summary>
    public class GetInfo : BaseObject
    {
        private bool? _populate;
        private IEnumerable<WindowType> _windowTypes;

        /// <summary>If true, the $(ref:windows.Window) returned will have a <c>tabs</c> property that contains a list of the $(ref:tabs.Tab) objects. The <c>Tab</c> objects only contain the <c>url</c>, <c>title</c> and <c>favIconUrl</c> properties if the extension's manifest file includes the <c>"tabs"</c> permission.</summary>
        [JsonPropertyName("populate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Populate
        {
            get
            {
                InitializeProperty("populate", _populate);
                return _populate;
            }
            set
            {
                _populate = value;
            }
        }

        /// <summary><c>windowTypes</c> is deprecated and ignored on Firefox.</summary>
        [Obsolete("This has been marked as deprecated without a description message. Please refer to the summary comment or the official API documentation.")]
        [JsonPropertyName("windowTypes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<WindowType> WindowTypes
        {
            get
            {
                InitializeProperty("windowTypes", _windowTypes);
                return _windowTypes;
            }
            set
            {
                _windowTypes = value;
            }
        }
    }
}
