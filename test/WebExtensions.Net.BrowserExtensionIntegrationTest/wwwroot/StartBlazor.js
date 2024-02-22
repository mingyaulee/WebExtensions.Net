Blazor.start({
  configureRuntime: builder => builder.withConfig({
    // Disable integrity check for coverlet to inject the hits counter into the assembly which will change the integrity hash
    disableIntegrityCheck: true
  })
});