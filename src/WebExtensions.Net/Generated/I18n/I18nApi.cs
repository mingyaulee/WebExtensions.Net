using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.I18n
{
    /// <inheritdoc />
    public partial class I18nApi : BaseApi, II18nApi
    {
        /// <summary>Creates a new instance of <see cref="I18nApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public I18nApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "i18n"))
        {
        }

        /// <inheritdoc />
        public virtual ValueTask<Result> DetectLanguage(string text)
            => InvokeAsync<Result>("detectLanguage", text);

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<LanguageCode>> GetAcceptLanguages()
            => InvokeAsync<IEnumerable<LanguageCode>>("getAcceptLanguages");

        /// <inheritdoc />
        public virtual string GetMessage(string messageName, object substitutions = null)
            => Invoke<string>("getMessage", messageName, substitutions);

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<LanguageCode>> GetPreferredSystemLanguages()
            => InvokeAsync<IEnumerable<LanguageCode>>("getPreferredSystemLanguages");

        /// <inheritdoc />
        public virtual string GetUILanguage()
            => Invoke<string>("getUILanguage");
    }
}
