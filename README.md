# WebExtension.Net
A package for consuming WebExtensions API in a browser extension.

These API classes are generated from these Mozilla schema files:
- [toolkit](https://hg.mozilla.org/integration/autoland/raw-file/tip/toolkit/components/extensions/schemas/)
- [browser](https://hg.mozilla.org/integration/autoland/raw-file/tip/browser/components/extensions/schemas/)

## How to use this package
This package can be consumed in two ways

### With Blazor
Create a browser extension using Blazor. Refer to the package [Blazor.BrowserExtension](https://github.com/mingyaulee/Blazor.BrowserExtension) for more information.

### Without Blazor
Create a standard browser extension using JavaScript and load the WebAssembly on your own. The source code can be compiled into wasm using MONO.

**Caution**: This is not tested.

```csharp
var webExtensionJsRuntime = new WebExtensionJSRuntime(iJsRuntime);
var webExtensionApi = new WebExtensionAPI(webExtensionJsRuntime);
var manifest = await webExtensionApi.Runtime.GetManifest();
```

## Limitations

### v0.1.0
- For callback functions with more than one parameter, only the first callback parameter is returned right now.
- Parameter callback is not supported.
- The browser extension API namespaces that are enabled at the moment is 11 out of a total of 60.
- Event listener is not supported.
- Returned objects with function invocation is not supported.