using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Runtime
{
    // Type Class
    /// <summary>An object containing information about the current platform.</summary>
    [BindAllProperties]
    public partial class PlatformInfo : BaseObject
    {
        /// <summary>The machine's processor architecture.</summary>
        [JsonPropertyName("arch")]
        public PlatformArch Arch { get; set; }

        /// <summary>The operating system the browser is running on.</summary>
        [JsonPropertyName("os")]
        public PlatformOs Os { get; set; }
    }
}
