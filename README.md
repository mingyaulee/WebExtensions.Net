# WebExtensions.Net
[![Nuget](https://img.shields.io/nuget/v/WebExtensions.Net?style=for-the-badge&color=blue)](https://www.nuget.org/packages/WebExtensions.Net/)
[![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/mingyaulee/WebExtensions.Net/WebExtensions.Net-Build.yml?branch=main&style=for-the-badge&color=blue)](https://github.com/mingyaulee/WebExtensions.Net/actions/workflows/WebExtensions.Net-Build.yml)
[![Sonar Tests](https://img.shields.io/sonar/tests/WebExtensions.Net?compact_message&server=https%3A%2F%2Fsonarcloud.io&style=for-the-badge)](https://sonarcloud.io/dashboard?id=WebExtensions.Net)
[![Sonar Quality Gate](https://img.shields.io/sonar/quality_gate/WebExtensions.Net?server=https%3A%2F%2Fsonarcloud.io&style=for-the-badge)](https://sonarcloud.io/dashboard?id=WebExtensions.Net)

A package for consuming WebExtensions API in a browser extension.

These API classes are generated based on the [Mozilla documentation for WebExtensions API](https://firefox-source-docs.mozilla.org/toolkit/components/extensions/webextensions/index.html).

- [toolkit](https://searchfox.org/mozilla-central/source/toolkit/components/extensions/ext-toolkit.json)
- [browser](https://searchfox.org/mozilla-central/source/browser/components/extensions/ext-browser.json)

## How to use this package

This package can be consumed in two methods.

### With Blazor (Recommended)
Create a browser extension using Blazor. Refer to the package [Blazor.BrowserExtension](https://github.com/mingyaulee/Blazor.BrowserExtension) to get started.

### Without Blazor
Create a standard browser extension using JavaScript and load the WebAssembly manually. The .Net source code can be compiled into wasm using Mono.

1. Install `WebExtensions.Net` (if you intend to use the API without dependency injection) or `WebExtensions.Net.Extensions.DependencyInjection` from Nuget.
2. Import the `JsBind.Net` scripts with `<script src="_content/JsBind.Net/JsBindNet.js"></script>`. If your project does not support Razor Class Library contents, add the property `<LinkJsBindAssets>true</LinkJsBindAssets>` to your project.
3. Import the [WebExtensions polyfill](https://github.com/mozilla/webextension-polyfill) by Mozilla for cross browser compatibility. This polyfill helps to convert the callback based Chrome extensions API to a Promise based API for asynchronous functions.
4. Consume the WebExtensions API by creating an instance of `WebExtensionsApi` as shown below.

```csharp
using JsBind.Net;
using JsBind.Net.Configurations;
using WebExtensions.Net;
...
var options = new JsBindOptionsConfigurator()
    .UseInProcessJsRuntime()
    .Options;
// iJsRuntime is an instance of MonoWebAssemblyJSRuntime
var jsRuntimeAdapter = new JsRuntimeAdapter(iJsRuntime, options);
var webExtensionsApi = new WebExtensionsApi(jsRuntimeAdapter);
// Use the WebExtensions API
var manifest = await webExtensionsApi.Runtime.GetManifest();
```

#### Debugging and testing
For the purpose of debugging and testing outside of the browser extension environment, there is a `MockJsRuntimeAdapter` class under the `WebExtensions.Net.Mock` namespace.
Initialize an instance of the mock API with:
```csharp
using WebExtensions.Net;
using WebExtensions.Net.Mock;
...
var jsRuntimeAdapter = new MockJsRuntimeAdapter();
var webExtensionsApi = new WebExtensionsApi(jsRuntimeAdapter);
```

To configure the behaviour of the mock API, you may use any combination of the following:
```csharp
MockResolvers.Configure(configure =>
{
    // configure a method without any argument
    configure.Api.Property(api => api.Runtime.Id).Returns(() => "MyExtensionId");
    // or
    configure.Api.Property(api => api.Runtime.Id).ReturnsForAnyArgs("MyExtensionId");

    // configure a method with one argument
    configure.Api.Method<string, string>(api => api.Runtime.GetURL).Returns(path => builder.HostEnvironment.BaseAddress + path);

    // configure a method that returns the same object regardless of the arguments
    configure.Api.Method<string, NotificationOptions, string>(api => api.Notifications.Create).ReturnsForAnyArgs("NotificationId");

    // configure an action to be invoked when an API is called
    configure.Api.Method<int?>(api => api.Tabs.GoForward).Invokes(tabId => { /* Do something with tabId */ });

    // configure a method on an object reference
    using var emptyJson = JsonDocument.Parse("{}");
    configure.ObjectReference(DefaultMockObjects.LocalStorage).Method<StorageAreaGetKeys, JsonElement>(storage => storage.Get).ReturnsForAnyArgs(emptyJson.RootElement.Clone());

    // configure an action to be invoked when a method on an object reference is called
    configure.ObjectReference(DefaultMockObjects.LocalStorage).Method(storage => storage.Clear).Invokes(() => { /* Do something */ });

    // configure a generic delegate to handle all the API calls
    bool apiHandler(string targetPath, object[] arguments, out object result)
    {
        if (targetPath == "runtime.id")
        {
            result = "MyExtensionId";
            return true;
        }
        result = null;
        return false;
    }
    configure.ApiHandler(apiHandler);

    // configure a generic delegate to handle all the invocations to object references
    bool objectReferenceHandler(object objectReference, string targetPath, object[] arguments, out object result)
    {
        if (objectReference == DefaultMockObjects.LocalStorage && targetPath == "get")
        {
            using var emptyJson = JsonDocument.Parse("{}");
            result = emptyJson.RootElement.Clone();
            return true;
        }
        result = null;
        return false;
    }
    configure.ObjectReferenceHandler(objectReferenceHandler);
});
```

**Note:** The sequence of mock registration matters.
Overall the more specific method `Returns` and `ReturnsForAnyArgs` is prioritized over the generic delegate `ApiHandler` and `ObjectReferenceHandler`.
If there exists registration that handles the same API or object reference call, the last registered handler will be used.
For example:
```csharp
MockResolvers.Configure(configure =>
{
    // when api.Runtime.GetId is called it will return "MyExtensionId2"
    configure.Api.Property(api => api.Runtime.Id).Returns(() => "MyExtensionId1");
    configure.Api.Property(api => api.Runtime.Id).Returns(() => "MyExtensionId2");
});
```
```csharp
MockResolvers.Configure(configure =>
{
    // when api.Runtime.GetId is called it will return "MyExtensionId1", even though the generic API handler is registered last, the more specific method registration is prioritized.
    configure.Api.Property(api => api.Runtime.Id).Returns(() => "MyExtensionId1");

    bool apiHandler(string targetPath, object[] arguments, out object result)
    {
        if (targetPath == "runtime.id")
        {
            result = "MyExtensionId2";
            return true;
        }
        result = null;
        return false;
    }
    configure.ApiHandler(apiHandler);
});
```

### API References
- [Chrome Extensions API Reference](https://developer.chrome.com/docs/extensions/reference/)
- [Firefox Browser Extensions JavaScript API](https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API)
