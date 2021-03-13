/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Runtime
{
    /// Enum Definition
    /// <summary>The machine's processor architecture.</summary>
    [JsonConverter(typeof(EnumStringConverter<PlatformArch>))]
    public enum PlatformArch
    {
        [EnumValue("aarch64")]
        Aarch64,
        [EnumValue("arm")]
        Arm,
        [EnumValue("ppc64")]
        Ppc64,
        [EnumValue("s390x")]
        S390x,
        [EnumValue("sparc64")]
        Sparc64,
        [EnumValue("x86-32")]
        X86_32,
        [EnumValue("x86-64")]
        X86_64,
    }
}

