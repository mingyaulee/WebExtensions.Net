using JsBind.Net;

namespace WebExtensions.Net.GeckoProfiler;

/// <summary>Exposes the browser's profiler.</summary>
[JsAccessPath("geckoProfiler")]
public partial interface IGeckoProfilerApi
{
    /// <summary>Fires when the profiler starts/stops running.</summary>
    [JsAccessPath("onRunning")]
    OnRunningEvent OnRunning { get; }

    /// <summary>Gathers the profile data from the current profiling session, and writes it to disk. The returned promise resolves to a path that locates the created file.</summary>
    /// <param name="fileName">The name of the file inside the profile/profiler directory</param>
    [JsAccessPath("dumpProfileToFile")]
    void DumpProfileToFile(string fileName);

    /// <summary>Gathers the profile data from the current profiling session.</summary>
    [JsAccessPath("getProfile")]
    void GetProfile();

    /// <summary>Gathers the profile data from the current profiling session. The returned promise resolves to an array buffer that contains a JSON string.</summary>
    [JsAccessPath("getProfileAsArrayBuffer")]
    void GetProfileAsArrayBuffer();

    /// <summary>Gathers the profile data from the current profiling session. The returned promise resolves to an array buffer that contains a gzipped JSON string.</summary>
    [JsAccessPath("getProfileAsGzippedArrayBuffer")]
    void GetProfileAsGzippedArrayBuffer();

    /// <summary>Gets the debug symbols for a particular library.</summary>
    /// <param name="debugName">The name of the library's debug file. For example, 'xul.pdb</param>
    /// <param name="breakpadId">The Breakpad ID of the library</param>
    [JsAccessPath("getSymbols")]
    void GetSymbols(string debugName, string breakpadId);

    /// <summary>Pauses the profiler, keeping any profile data that is already written.</summary>
    [JsAccessPath("pause")]
    void Pause();

    /// <summary>Resumes the profiler with the settings that were initially used to start it.</summary>
    [JsAccessPath("resume")]
    void Resume();

    /// <summary>Starts the profiler with the specified settings.</summary>
    /// <param name="settings"></param>
    [JsAccessPath("start")]
    void Start(Settings settings);

    /// <summary>Stops the profiler and discards any captured profile data.</summary>
    [JsAccessPath("stop")]
    void Stop();
}
