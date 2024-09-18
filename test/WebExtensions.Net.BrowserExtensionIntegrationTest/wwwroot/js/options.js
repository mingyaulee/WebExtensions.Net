document.getElementById("RunIntegrationTestsButton").onclick = function () {
  const testUrl = browser.runtime.getURL("tests.html?random=false");
  browser.tabs.create({
    active: true,
    url: testUrl
  });
};