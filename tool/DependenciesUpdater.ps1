$relativeLibPath = "../test/WebExtensions.Net.BrowserExtensionIntegrationTest/wwwroot/js"
$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Definition
$libPath = Resolve-Path "$scriptPath/$relativeLibPath"

If (-Not(Test-Path -Path $libPath)) {
    Throw "Library path does not exist: $libPath"
}

Function UpdateBrowserPolyfill {
    $fileName = "browser-polyfill.min.js";
    Invoke-RestMethod -Uri "https://unpkg.com/webextension-polyfill/dist/$fileName" -OutFile "$libPath/$fileName"
}

UpdateBrowserPolyfill