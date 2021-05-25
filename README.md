# WebExtension.Net
[![Nuget](https://img.shields.io/nuget/v/WebExtension.Net?style=flat-square&color=blue)](https://www.nuget.org/packages/WebExtension.Net/)
[![GitHub Workflow Status](https://img.shields.io/github/workflow/status/mingyaulee/WebExtension.Net/Build?style=flat-square&color=blue)](https://github.com/mingyaulee/WebExtension.Net/actions/workflows/WebExtension.Net-Build.yml)
[![Sonar Tests](https://img.shields.io/sonar/tests/WebExtension.Net?compact_message&server=https%3A%2F%2Fsonarcloud.io&style=flat-square)](https://sonarcloud.io/dashboard?id=WebExtension.Net)
[![Sonar Quality Gate](https://img.shields.io/sonar/quality_gate/WebExtension.Net?server=https%3A%2F%2Fsonarcloud.io&style=flat-square)](https://sonarcloud.io/dashboard?id=WebExtension.Net)

A package for consuming WebExtensions API in a browser extension.

These API classes are generated based on the [Mozilla documentation for WebExtension API](https://firefox-source-docs.mozilla.org/toolkit/components/extensions/webextensions/index.html).

- [toolkit](https://searchfox.org/mozilla-central/source/toolkit/components/extensions/ext-toolkit.json)
- [browser](https://searchfox.org/mozilla-central/source/browser/components/extensions/ext-browser.json)

## How to use this package
This package can be consumed in two methods.

### With Blazor (Recommended)
Create a browser extension using Blazor. Refer to the package [Blazor.BrowserExtension](https://github.com/mingyaulee/Blazor.BrowserExtension) to get started.

### Without Blazor
Create a standard browser extension using JavaScript and load the WebAssembly manually. The .Net source code can be compiled into wasm using Mono.

1. Install `WebExtension.Net` from Nuget.
2. A JavaScript file will be added to your project at the path `wwwroot/WebExtensionScripts/WebExtensionNet.js`. This `.js` file needs to be included in your  application, either by using a `<script>` element in HTML or using `import` from JavaScript code.
3. Import the [WebExtension polyfill](https://github.com/mozilla/webextension-polyfill) by Mozilla for cross browser compatibility. This polyfill helps to convert the callback based Chrome extensions API to a Promise based API for asynchronous functions.
4. Consume the WebExtension API by creating an instance of `WebExtensionApi` as shown below.

```csharp
// iJsRuntime is an instance of MonoWebAssemblyJSRuntime
var webExtensionJsRuntime = new WebExtensionJSRuntime(iJsRuntime);
var webExtensionApi = new WebExtensionApi(webExtensionJsRuntime);
var manifest = await webExtensionApi.Runtime.GetManifest();
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
| WebExtensionAssetsPath    | wwwroot       | The root folder where the JavaScript file should be added as link.        |
| IncludeWebExtensionAssets | true          | If set to false, the JavaScript file will not be added as to the project. |