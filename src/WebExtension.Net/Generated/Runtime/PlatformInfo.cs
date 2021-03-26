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
    public class PlatformInfo : BaseObject
    {
        
        // Property Definition
        private PlatformOs _os;
        /// <summary>
        /// The operating system the browser is running on.
        /// </summary>
        [JsonPropertyName("os")]
        public PlatformOs Os
        {
            get
            {
                InitializeProperty("os", _os);
                return _os;
            }
            set
            {
                _os = value;
            }
        }
        
        // Property Definition
        private PlatformArch _arch;
        /// <summary>
        /// The machine's processor architecture.
        /// </summary>
        [JsonPropertyName("arch")]
        public PlatformArch Arch
        {
            get
            {
                InitializeProperty("arch", _arch);
                return _arch;
            }
            set
            {
                _arch = value;
            }
        }
    }
}

