// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Runtime
{
    // Class Definition
    /// <summary>
    /// An object containing information about the current platform.
    /// </summary>
    public class PlatformInfo
    {
        
        // Property Definition
        /// <summary>
        /// The operating system the browser is running on.
        /// </summary>
        [JsonPropertyName("os")]
        public PlatformOs Os { get; set; }
        
        // Property Definition
        /// <summary>
        /// The machine's processor architecture.
        /// </summary>
        [JsonPropertyName("arch")]
        public PlatformArch Arch { get; set; }
    }
}

