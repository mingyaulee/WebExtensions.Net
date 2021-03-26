using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Runtime
{
    // Enum Definition
    /// <summary>
    /// The machine's processor architecture.
    /// </summary>
    [JsonConverter(typeof(EnumStringConverter<PlatformArch>))]
    public enum PlatformArch
    {
        /// <summary>aarch64</summary>
        [EnumValue("aarch64")]
        Aarch64,
        /// <summary>arm</summary>
        [EnumValue("arm")]
        Arm,
        /// <summary>ppc64</summary>
        [EnumValue("ppc64")]
        Ppc64,
        /// <summary>s390x</summary>
        [EnumValue("s390x")]
        S390x,
        /// <summary>sparc64</summary>
        [EnumValue("sparc64")]
        Sparc64,
        /// <summary>x86-32</summary>
        [EnumValue("x86-32")]
        X86_32,
        /// <summary>x86-64</summary>
        [EnumValue("x86-64")]
        X86_64,
    }
}

