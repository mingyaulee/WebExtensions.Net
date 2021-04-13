using Microsoft.Extensions.Logging;
using System;
using System.IO;
using WebExtension.Net.Generator.Models;
using WebExtension.Net.Generator.CodeGeneration;
using WebExtension.Net.Generator.Repositories;
using Microsoft.Extensions.DependencyInjection;
using WebExtension.Net.Generator.Translators;
using WebExtension.Net.Generator.CodeGeneration.CodeConverterFactories;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator
{
    public static class Program
    {
        public static void Main()
        {
            var runInParallel = true;
            var sources = new[]
            {
                new ApiDefinitionSource("https://hg.mozilla.org/mozilla-central/raw-file/tip/toolkit/components/extensions/", "ext-toolkit.json", "chrome://extensions/content/"),
                new ApiDefinitionSource("https://hg.mozilla.org/mozilla-central/raw-file/tip/browser/components/extensions/", "ext-browser.json", "chrome://browser/content/")
            };
            var additionalNamespaceSourceDefinitions = new[]
            {
                new NamespaceSourceDefinition()
                {
                    HttpUrl ="https://hg.mozilla.org/mozilla-central/raw-file/tip/toolkit/components/extensions/schemas/manifest.json"
                },
                new NamespaceSourceDefinition()
                {
                    HttpUrl ="https://hg.mozilla.org/mozilla-central/raw-file/tip/toolkit/components/extensions/schemas/events.json"
                }
            };

            var codeFileOptions = new CodeWriterOptions()
            {
                RootDirectory = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..\\..\\WebExtension.Net\\Generated")),
                RootNamespace = "WebExtension.Net"
            };

            var classOption = new RegistrationOption()
            {
                RootApiClassName = "WebExtensionApi",
                RootApiClassDescription = "Web Extension Api",
                ApiClassBaseClassName = "BaseApi",
                ApiClassNamePostfix = "Api",
                ObjectTypeClassBaseClassName = "BaseObject",
                StringFormatClassBaseClassName = "BaseStringFormat",
                ArrayClassBaseClassName = "List<$arrayItemTypeName>",
                IncludeNamespaces = new[]
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
                },
                ExcludeNamespaces = new[]
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
                }
            };

            var services = new ServiceCollection();
            RegisterServices(services);
            services.AddSingleton(classOption);
            services.AddSingleton(codeFileOptions);

            var serviceProvicer = services.BuildServiceProvider();
            using var scope = serviceProvicer.CreateScope();

            var namespaceDefinitionsClient = scope.ServiceProvider.GetRequiredService<NamespaceDefinitionsClient>();
            var namespaceDefinitions = namespaceDefinitionsClient.GetNamespaceDefinitions(sources, additionalNamespaceSourceDefinitions, runInParallel).GetAwaiter().GetResult();

            var entitiesRegistrationManager = scope.ServiceProvider.GetRequiredService<EntitiesRegistrationManager>();
            entitiesRegistrationManager.RegisterEntities(namespaceDefinitions);

            var codeGenerator = scope.ServiceProvider.GetRequiredService<CodeGenerator>();
            var codeConverters = codeGenerator.GetCodeFileConverters();

            var filesManager = scope.ServiceProvider.GetRequiredService<FilesManager>();
            filesManager.CleanDirectory();
            filesManager.WriteCodeFiles(codeConverters);
            filesManager.WriteJsonFiles();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddSimpleConsole(options => options.SingleLine = true);
            });
            var logger = loggerFactory.CreateLogger("Generator");
            services.AddSingleton(logger);
            services.AddScoped<NamespaceDefinitionsClient>();
            services.AddScoped<EntitiesContext>();
            services.AddScoped<EntitiesRegistrationManager>();
            services.AddScoped<CodeGenerator>();
            services.AddScoped<FilesManager>();

            // translators
            services.AddTransient<ClassEntityTranslator>();
            services.AddTransient<EnumEntityTranslator>();

            // code converter factories
            services.AddTransient<ApiCodeConverterFactory>();
            services.AddTransient<ApiRootCodeConverterFactory>();
            services.AddTransient<ArrayCodeConverterFactory>();
            services.AddTransient<EnumCodeConverterFactory>();
            services.AddTransient<MultitypeCodeConverterFactory>();
            services.AddTransient<StringFormatCodeConverterFactory>();
            services.AddTransient<TypeCodeConverterFactory>();
        }
    }
}
