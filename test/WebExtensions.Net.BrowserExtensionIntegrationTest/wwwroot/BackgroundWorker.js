// Import for the side effect of defining a global 'browser' variable
import * as _ from "/js/browser-polyfill.min.js";

browser.runtime.onInstalled.addListener(() => {
  const indexPageUrl = browser.runtime.getURL("options.html");
  browser.tabs.create({
    url: indexPageUrl
  });
});