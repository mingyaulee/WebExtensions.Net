using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebExtensions.Net.BrowserExtensionIntegrationTest;
using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddWebExtensions();
builder.Services.AddScoped<ITestFactory, TestFactory>();
builder.Services.AddScoped<ITestRunner, TestRunner>();

await builder.Build().RunAsync();
