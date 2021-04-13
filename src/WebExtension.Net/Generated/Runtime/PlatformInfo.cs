using System.Text.Json.Serialization;

namespace WebExtension.Net.Runtime
{
    // Type Class
    /// <summary>An object containing information about the current platform.</summary>
    public class PlatformInfo : BaseObject
    {
        private PlatformOs _os;
        private PlatformArch _arch;

        /// <summary>The operating system the browser is running on.</summary>
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

        /// <summary>The machine's processor architecture.</summary>
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
