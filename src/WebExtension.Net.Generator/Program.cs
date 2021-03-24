using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace WebExtension.Net.Generator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var sourceUrls = new[]
            {
                "https://hg.mozilla.org/integration/autoland/raw-file/tip/browser/components/extensions/schemas/",
                "https://hg.mozilla.org/integration/autoland/raw-file/tip/toolkit/components/extensions/schemas/"
            };
            var rootDirectory = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..\\..\\WebExtension.Net\\Generated"));
            var rootNamespace = "WebExtension.Net";
            var rootApiDefinitionName = "WebExtensionAPI";
            var rootApiDefinitionDescription = "Web Extension API";
            var apiDefinitionClassNamePostfix = "API";
            var includeNamespaces = new List<string>()
            {
                "contentScripts",
                "events",
                "extensionTypes",
                "manifest",
                "notifications",
                "runtime",
                "storage",
                "tabs",
                "webNavigation",
                "webRequest",
                "windows"
            };
            var excludeNamespaces = new List<string>()
            {
                "activityLog",
                "alarms",
                "bookmarks",
                "browserAction",
                "browserSettings",
                "browsingData",
                "captivePortal",
                "clipboard",
                "commands",
                "contextMenus",
                "contextualIdentities",
                "cookies",
                "devtools",
                "devtools.inspectedWindow",
                "devtools.network",
                "devtools.panels",
                "dns",
                "downloads",
                "experiments",
                "extension",
                "find",
                "geckoProfiler",
                "history",
                "i18n",
                "identity",
                "idle",
                "management",
                "menus",
                "networkStatus",
                "normandyAddonStudy",
                "omnibox",
                "pageAction",
                "permissions",
                "pkcs11",
                "privacy",
                "privacy.network",
                "privacy.services",
                "privacy.websites",
                "proxy",
                "search",
                "sessions",
                "sidebarAction",
                "telemetry",
                "test",
                "theme",
                "topSites",
                "types",
                "urlbar",
                "userScripts"
            };
            var runInParallel = true;

            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddSimpleConsole(options => options.SingleLine = true);
            });
            var logger = loggerFactory.CreateLogger("Generator");
            if (logger is null)
            {
                throw new Exception("Failed to initialize logger");
            }

            using var httpClient = new HttpClient();
            var builder = new ApiDefinitionBuilder(httpClient, logger);
            var apiDefinitionRoot = builder.BuildRootFromSourceAsync(sourceUrls, runInParallel).GetAwaiter().GetResult();
            if (apiDefinitionRoot != null)
            {
                apiDefinitionRoot.Name = rootApiDefinitionName;
                apiDefinitionRoot.Description = rootApiDefinitionDescription;
                apiDefinitionRoot.DefinitionClassNamePostfix = apiDefinitionClassNamePostfix;
                apiDefinitionRoot.Directory = rootDirectory;
                apiDefinitionRoot.RootNamespace = rootNamespace;
                var writer = new ApiDefinitionWriter(logger, includeNamespaces, excludeNamespaces);
                writer.Write(apiDefinitionRoot).Wait();
            }
        }
    }
}
