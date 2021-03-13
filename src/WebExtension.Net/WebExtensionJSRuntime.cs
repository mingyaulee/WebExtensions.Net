using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace WebExtension.Net
{
    public class WebExtensionJSRuntime
    {
        private readonly IJSRuntime jsRuntime;

        public WebExtensionJSRuntime(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public ValueTask<TValue> InvokeAsync<TValue>(params object[] args)
        {
            return jsRuntime.InvokeAsync<TValue>("WebExtensionNet.Execute", args);
        }

        public ValueTask InvokeVoidAsync(params object[] args)
        {
            return jsRuntime.InvokeVoidAsync("WebExtensionNet.Execute", args);
        }
    }
}
