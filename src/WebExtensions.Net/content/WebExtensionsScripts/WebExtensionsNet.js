(async () => {
  var WebExtension = (await import("./Modules/WebExtension.js")).default;
  globalThis.WebExtensionNet = new WebExtension();
})();