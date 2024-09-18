using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddWebExtensions();
            builder.Services.AddScoped<ITestFactory, TestFactory>();
            builder.Services.AddScoped<ITestRunner, TestRunner>();

            await builder.Build().RunAsync();
        }
    }
}
