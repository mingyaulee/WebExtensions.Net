using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WebExtension.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtension.Net.BrowserExtensionIntegrationTest
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBrowserExtensionServices(options =>
            {
                options.ProjectNamespace = typeof(Program).Namespace;
            });
            builder.Services.AddScoped<ITestFactory, TestFactory>();
            builder.Services.AddScoped<ITestRunner, TestRunner>();

            await builder.Build().RunAsync();
        }
    }
}
