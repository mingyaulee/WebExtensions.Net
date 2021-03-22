# WebExtension.Net
A package for consuming WebExtensions API in a browser extension.

These API classes are generated from these Mozilla schema files:
- [toolkit](https://hg.mozilla.org/integration/autoland/raw-file/tip/toolkit/components/extensions/schemas/)
- [browser](https://hg.mozilla.org/integration/autoland/raw-file/tip/browser/components/extensions/schemas/)

## How to use this package
This package can be consumed in two methods.

### With Blazor (Recommended)
Create a browser extension using Blazor. Refer to the package [Blazor.BrowserExtension](https://github.com/mingyaulee/Blazor.BrowserExtension) for more information.

### Without Blazor
Create a standard browser extension using JavaScript and load the WebAssembly on your own. The source code can be compiled into wasm using MONO.

1. Install `WebExtension.Net` from Nuget.
2. A JavaScript file will be added to your project at the path `wwwroot/WebExtensionScripts/WebExtensionNet.js`. This `.js` file needs to be included in your  application, either by using a `<script>` element in HTML or using `import` from JavaScript code.
3. Consume the WebExtension API by creating an instance of `WebExtensionAPI` as shown below.

```csharp
var webExtensionJsRuntime = new WebExtensionJSRuntime(iJsRuntime);
var webExtensionApi = new WebExtensionAPI(webExtensionJsRuntime);
var manifest = await webExtensionApi.Runtime.GetManifest();
```

#### Notes
- You should have an implementation of IJSRuntime to initialize an instance of WebExtensionJSRuntime.
- In JavaScript, you should have an interop API that invokes DotNet methods.

## Limitations

### v0.1.*
- For callback functions with more than one parameter, only the first callback parameter is returned right now.
- Parameter callback is not supported.
- The browser extension API namespaces that are enabled at the moment is 11 out of a total of 60.
- Event listener is not supported.
- Function invocation on returned object is not supported.

## Customize build

The following MSBuild properties can be specified in your project file or when running `dotnet build` command.

| Property                  | Default value | Description                                                               |
| ------------------------- | ------------- | ------------------------------------------------------------------------- |
| WebExtensionAssetsPath    | wwwroot       | The root folder where the JavaScript file should be added as link.        |
| IncludeWebExtensionAssets | true          | If set to false, the JavaScript file will not be added as to the project. |