using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.WebNavigation
{
    /// <inheritdoc />
    public class WebNavigationApi : BaseApi, IWebNavigationApi
    {
        /// <summary>Creates a new instance of <see cref="WebNavigationApi" />.</summary>
        /// <param name="webExtensionJSRuntime">Web Extension JS Runtime</param>
        public WebNavigationApi(WebExtensionJSRuntime webExtensionJSRuntime) : base(webExtensionJSRuntime, "webNavigation")
        {
        }

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> GetFrame(object details)
        {
            return InvokeAsync<JsonElement>("getFrame", details);
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<object>> GetAllFrames(object details)
        {
            return InvokeAsync<IEnumerable<object>>("getAllFrames", details);
        }
    }
}
