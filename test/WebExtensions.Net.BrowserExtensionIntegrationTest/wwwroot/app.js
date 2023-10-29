globalThis.BlazorBrowserExtension.StartBlazorBrowserExtension = false;

setTimeout(() => {
  globalThis.BlazorBrowserExtension.BrowserExtension.InitializeAsync({
    environment: "Production",
    configureRuntime: builder => builder.withConfig({
      // Disable integrity check for coverlet to inject the hits counter into the assembly which will change the integrity hash
      disableIntegrityCheck: true
    })
  });
}, 100);
