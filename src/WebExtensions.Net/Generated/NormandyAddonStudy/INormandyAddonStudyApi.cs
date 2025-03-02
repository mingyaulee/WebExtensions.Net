using JsBind.Net;

namespace WebExtensions.Net.NormandyAddonStudy
{
    /// <summary>Normandy Study API</summary>
    [JsAccessPath("normandyAddonStudy")]
    public partial interface INormandyAddonStudyApi
    {
        /// <summary>Fired when a user unenrolls from a study but before the addon is uninstalled.</summary>
        [JsAccessPath("onUnenroll")]
        OnUnenrollEvent OnUnenroll { get; }

        /// <summary>Marks the study as ended and then uninstalls the addon.</summary>
        /// <param name="reason">The reason why the study is ending.</param>
        [JsAccessPath("endStudy")]
        void EndStudy(string reason);

        /// <summary>Returns an object with metadata about the client which may be required for constructing survey URLs.</summary>
        [JsAccessPath("getClientMetadata")]
        void GetClientMetadata();

        /// <summary>Returns a study object for the current study.</summary>
        [JsAccessPath("getStudy")]
        void GetStudy();
    }
}
