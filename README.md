# WebExtensions.Net
[![Nuget](https://img.shields.io/nuget/v/WebExtensions.Net?style=flat-square&color=blue)](https://www.nuget.org/packages/WebExtensions.Net/)
[![GitHub Workflow Status](https://img.shields.io/github/workflow/status/mingyaulee/WebExtensions.Net/Build?style=flat-square&color=blue)](https://github.com/mingyaulee/WebExtensions.Net/actions/workflows/WebExtensions.Net-Build.yml)
[![Sonar Tests](https://img.shields.io/sonar/tests/WebExtensions.Net?compact_message&server=https%3A%2F%2Fsonarcloud.io&style=flat-square)](https://sonarcloud.io/dashboard?id=WebExtensions.Net)
[![Sonar Quality Gate](https://img.shields.io/sonar/quality_gate/WebExtensions.Net?server=https%3A%2F%2Fsonarcloud.io&style=flat-square)](https://sonarcloud.io/dashboard?id=WebExtensions.Net)

A package for consuming WebExtensions API in a browser extension.

These API classes are generated based on the [Mozilla documentation for WebExtensions API](https://firefox-source-docs.mozilla.org/toolkit/components/extensions/webextensions/index.html).

- [toolkit](https://searchfox.org/mozilla-central/source/toolkit/components/extensions/ext-toolkit.json)
- [browser](https://searchfox.org/mozilla-central/source/browser/components/extensions/ext-browser.json)

## How to use this package

> **Important for v0.\*.\*:**<br />
> This package is still in pre-release stage so the versioning does not comply with semantic versioning. Feature and bug fix increments the patch version and breaking change increments the minor version. So be sure to check the release note before upgrading between minor version.

This package can be consumed in two methods.

### With Blazor (Recommended)
Create a browser extension using Blazor. Refer to the package [Blazor.BrowserExtension](https://github.com/mingyaulee/Blazor.BrowserExtension) to get started.

### Without Blazor
Create a standard browser extension using JavaScript and load the WebAssembly manually. The .Net source code can be compiled into wasm using Mono.

1. Install `WebExtensions.Net` from Nuget.
2. A JavaScript file will be added to your project at the path `wwwroot/WebExtensionsScripts/WebExtensionsNet.js`. This `.js` file needs to be included in your  application, either by using a `<script>` element in HTML or using `import` from JavaScript code.
3. Import the [WebExtensions polyfill](https://github.com/mozilla/webextension-polyfill) by Mozilla for cross browser compatibility. This polyfill helps to convert the callback based Chrome extensions API to a Promise based API for asynchronous functions.
4. Consume the WebExtensions API by creating an instance of `WebExtensionsApi` as shown below.

```csharp
using WebExtensions.Net;
...
// iJsRuntime is an instance of MonoWebAssemblyJSRuntime
var webExtensionsJsRuntime = new WebExtensionsJSRuntime(iJsRuntime);
var webExtensionsApi = new WebExtensionsApi(webExtensionsJsRuntime);
var manifest = await webExtensionsApi.Runtime.GetManifest();
```

#### Debugging and testing
For the purpose of debugging and testing outside of the browser extension environment, there is a `MockWebExtensionsJSRuntime` class under the `WebExtensions.Net.Mock` namespace.
Initialize an instance of the mock API with:
```csharp
using WebExtensions.Net;
using WebExtensions.Net.Mock;
...
var webExtensionsJsRuntime = new MockWebExtensionsJSRuntime();
var webExtensionsApi = new WebExtensionsApi(webExtensionsJsRuntime);
```

To configure the behaviour of the mock API, you may use any combination of the following:
```csharp
MockResolvers.Configure(configure =>
{
    // configure a method without any argument
    configure.Api.Method<string>(api => api.Runtime.GetId).Returns(() => "MyExtensionId");
    // or
    configure.Api.Method<string>(api => api.Runtime.GetId).ReturnsForAnyArgs("MyExtensionId");

    // configure a method with one argument
    configure.Api.Method<string, string>(api => api.Runtime.GetURL).Returns(path => builder.HostEnvironment.BaseAddress + path);

    // configure a method that returns the same object regardless of the arguments
    configure.Api.Method<string, CreateNotificationOptions, string>(api => api.Notifications.Create).ReturnsForAnyArgs("NotificationId");

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
    configure.Api.Method<string>(api => api.Runtime.GetId).Returns(() => "MyExtensionId1");
    configure.Api.Method<string>(api => api.Runtime.GetId).Returns(() => "MyExtensionId2");
});
```
```csharp
MockResolvers.Configure(configure =>
{
    // when api.Runtime.GetId is called it will return "MyExtensionId1", even though the generic API handler is registered last, the more specific method registration is prioritized.
    configure.Api.Method<string>(api => api.Runtime.GetId).Returns(() => "MyExtensionId1");

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

## Limitations

- For callback functions with more than one parameter, only the first callback parameter is returned right now.
- The browser extension API namespaces that are enabled at the moment is 13 out of a total of 60.
- ~~Parameter callback is not supported.~~ __Since v0.4.*__
- ~~Event listener is not supported.~~ __Since v0.4.*__
- ~~Function invocation on returned object is not supported.~~ __Since v0.2.*__

## Customize build

The following MSBuild properties can be specified in your project file or when running `dotnet build` command.

| Property                  | Default value | Description                                                               |
| ------------------------- | ------------- | ------------------------------------------------------------------------- |
| WebExtensionsAssetsPath    | wwwroot       | The root folder where the JavaScript file should be added as link.        |
| IncludeWebExtensionsAssets | true          | If set to false, the JavaScript file will not be added as to the project. |