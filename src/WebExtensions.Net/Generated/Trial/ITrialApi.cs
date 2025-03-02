using JsBind.Net;
using WebExtensions.Net.Trial.Ml;

namespace WebExtensions.Net.Trial
{
    /// <summary></summary>
    [JsAccessPath("trial")]
    public partial interface ITrialApi
    {
        /// <summary>Use the trial ML API to run Machine Learning models requests from extensions pages or content scripts.<br />Requires manifest permission trialML.</summary>
        [JsAccessPath("ml")]
        IMlApi Ml { get; }
    }
}
