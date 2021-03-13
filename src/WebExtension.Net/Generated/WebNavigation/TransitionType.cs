/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.WebNavigation
{
    /// Enum Definition
    /// <summary>Cause of the navigation. The same transition types as defined in the history API are used. These are the same transition types as defined in the $(topic:transition_types)[history API] except with <code>"start_page"</code> in place of <code>"auto_toplevel"</code> (for backwards compatibility).</summary>
    [JsonConverter(typeof(EnumStringConverter<TransitionType>))]
    public enum TransitionType
    {
        [EnumValue("link")]
        Link,
        [EnumValue("typed")]
        Typed,
        [EnumValue("auto_bookmark")]
        Auto_bookmark,
        [EnumValue("auto_subframe")]
        Auto_subframe,
        [EnumValue("manual_subframe")]
        Manual_subframe,
        [EnumValue("generated")]
        Generated,
        [EnumValue("start_page")]
        Start_page,
        [EnumValue("form_submit")]
        Form_submit,
        [EnumValue("reload")]
        Reload,
        [EnumValue("keyword")]
        Keyword,
        [EnumValue("keyword_generated")]
        Keyword_generated,
    }
}

