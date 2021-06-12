using System.Text.Json.Serialization;

namespace WebExtensions.Net.Runtime
{
    // Type Class
    /// <summary>An object containing information about the current platform.</summary>
    public partial class PlatformInfo : BaseObject
    {
        private PlatformArch _arch;
        private PlatformOs _os;

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
    }
}
