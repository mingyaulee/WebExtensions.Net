// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Windows
{
    // Enum Definition
    /// <summary>
    /// Specifies what type of browser window to create. The 'panel' and 'detached_panel' types create a popup unless the '--enable-panels' flag is set.
    /// </summary>
    [JsonConverter(typeof(EnumStringConverter<CreateType>))]
    public enum CreateType
    {
        /// <summary>normal</summary>
        [EnumValue("normal")]
        Normal,
        /// <summary>popup</summary>
        [EnumValue("popup")]
        Popup,
        /// <summary>panel</summary>
        [EnumValue("panel")]
        Panel,
        /// <summary>detached_panel</summary>
        [EnumValue("detached_panel")]
        Detached_panel,
    }
}

