using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.ExtensionTypes
{
    // Enum Definition
    /// <summary>
    /// The soonest that the JavaScript or CSS will be injected into the tab.
    /// </summary>
    [JsonConverter(typeof(EnumStringConverter<RunAt>))]
    public enum RunAt
    {
        /// <summary>document_start</summary>
        [EnumValue("document_start")]
        Document_start,
        /// <summary>document_end</summary>
        [EnumValue("document_end")]
        Document_end,
        /// <summary>document_idle</summary>
        [EnumValue("document_idle")]
        Document_idle,
    }
}

