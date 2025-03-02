using JsBind.Net;

namespace WebExtensions.Net.Trial.Ml
{
    /// <summary>Use the trial ML API to run Machine Learning models requests from extensions pages or content scripts.</summary>
    [JsAccessPath("ml")]
    public partial interface IMlApi
    {
        /// <summary>Events from the inference engine.</summary>
        [JsAccessPath("onProgress")]
        OnProgressEvent OnProgress { get; }

        /// <summary>Prepare the inference engine</summary>
        /// <param name="CreateEngineRequest"></param>
        [JsAccessPath("createEngine")]
        void CreateEngine(CreateEngineRequest CreateEngineRequest);

        /// <summary>Delete the models the extension downloaded.</summary>
        [JsAccessPath("deleteCachedModels")]
        void DeleteCachedModels();

        /// <summary>Call the inference engine</summary>
        /// <param name="RunEngineRequest"></param>
        [JsAccessPath("runEngine")]
        void RunEngine(RunEngineRequest RunEngineRequest);
    }
}
