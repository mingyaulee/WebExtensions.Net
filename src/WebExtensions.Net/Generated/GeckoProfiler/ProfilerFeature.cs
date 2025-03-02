using System.Text.Json.Serialization;

namespace WebExtensions.Net.GeckoProfiler
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<ProfilerFeature>))]
    public enum ProfilerFeature
    {
        /// <summary>java</summary>
        [EnumValue("java")]
        Java,

        /// <summary>js</summary>
        [EnumValue("js")]
        Js,

        /// <summary>mainthreadio</summary>
        [EnumValue("mainthreadio")]
        Mainthreadio,

        /// <summary>fileio</summary>
        [EnumValue("fileio")]
        Fileio,

        /// <summary>fileioall</summary>
        [EnumValue("fileioall")]
        Fileioall,

        /// <summary>nomarkerstacks</summary>
        [EnumValue("nomarkerstacks")]
        Nomarkerstacks,

        /// <summary>screenshots</summary>
        [EnumValue("screenshots")]
        Screenshots,

        /// <summary>seqstyle</summary>
        [EnumValue("seqstyle")]
        Seqstyle,

        /// <summary>stackwalk</summary>
        [EnumValue("stackwalk")]
        Stackwalk,

        /// <summary>jsallocations</summary>
        [EnumValue("jsallocations")]
        Jsallocations,

        /// <summary>nostacksampling</summary>
        [EnumValue("nostacksampling")]
        Nostacksampling,

        /// <summary>nativeallocations</summary>
        [EnumValue("nativeallocations")]
        Nativeallocations,

        /// <summary>ipcmessages</summary>
        [EnumValue("ipcmessages")]
        Ipcmessages,

        /// <summary>audiocallbacktracing</summary>
        [EnumValue("audiocallbacktracing")]
        Audiocallbacktracing,

        /// <summary>cpu</summary>
        [EnumValue("cpu")]
        Cpu,

        /// <summary>notimerresolutionchange</summary>
        [EnumValue("notimerresolutionchange")]
        Notimerresolutionchange,

        /// <summary>cpuallthreads</summary>
        [EnumValue("cpuallthreads")]
        Cpuallthreads,

        /// <summary>samplingallthreads</summary>
        [EnumValue("samplingallthreads")]
        Samplingallthreads,

        /// <summary>markersallthreads</summary>
        [EnumValue("markersallthreads")]
        Markersallthreads,

        /// <summary>unregisteredthreads</summary>
        [EnumValue("unregisteredthreads")]
        Unregisteredthreads,

        /// <summary>processcpu</summary>
        [EnumValue("processcpu")]
        Processcpu,

        /// <summary>power</summary>
        [EnumValue("power")]
        Power,

        /// <summary>responsiveness</summary>
        [EnumValue("responsiveness")]
        Responsiveness,

        /// <summary>cpufreq</summary>
        [EnumValue("cpufreq")]
        Cpufreq,

        /// <summary>bandwidth</summary>
        [EnumValue("bandwidth")]
        Bandwidth,

        /// <summary>memory</summary>
        [EnumValue("memory")]
        Memory,

        /// <summary>tracing</summary>
        [EnumValue("tracing")]
        Tracing,

        /// <summary>sandbox</summary>
        [EnumValue("sandbox")]
        Sandbox,

        /// <summary>flows</summary>
        [EnumValue("flows")]
        Flows,
    }
}
