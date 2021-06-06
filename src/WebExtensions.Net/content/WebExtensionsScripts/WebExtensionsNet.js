(async () => {
  var WebExtensions = (await import("./Modules/WebExtensions.js")).default;
  globalThis.WebExtensionsNet = new WebExtensions();
})();