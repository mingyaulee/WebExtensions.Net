/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.ExtensionTypes
{
    /// Enum Definition
    /// <summary>The soonest that the JavaScript or CSS will be injected into the tab.</summary>
    [JsonConverter(typeof(EnumStringConverter<RunAt>))]
    public enum RunAt
    {
        [EnumValue("document_start")]
        Document_start,
        [EnumValue("document_end")]
        Document_end,
        [EnumValue("document_idle")]
        Document_idle,
    }
}

