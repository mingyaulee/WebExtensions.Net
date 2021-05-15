using Microsoft.Extensions.Logging;
using System;
using System.IO;
using WebExtension.Net.Generator.Models;
using WebExtension.Net.Generator.CodeGeneration;
using WebExtension.Net.Generator.Repositories;
using Microsoft.Extensions.DependencyInjection;
using WebExtension.Net.Generator.ClrTypeTranslators;
using WebExtension.Net.Generator.CodeGeneration.CodeConverterFactories;
using WebExtension.Net.Generator.Models.Schema;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using WebExtension.Net.Generator.EntityRegistrars;

namespace WebExtension.Net.Generator
{
    public static class Program
    {
        public static void Main()
        {
            var configuration = GetConfiguration();
            var runInParallel = configuration.GetValue<bool>("runInParallel");
            var sources = configuration.GetSection("sources").Get<IEnumerable<ApiDefinitionSource>>();
            var additionalNamespaceSourceDefinitions = configuration.GetSection("additionalNamespaceSourceDefinitions").Get<IEnumerable<NamespaceSourceDefinition>>();
            var codeWriterOptions = configuration.GetSection("codeWriterOptions").Get<CodeWriterOptions>();
            codeWriterOptions.RootDirectory = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, codeWriterOptions.RootDirectory));
            var registrationOptions = configuration.GetSection("registrationOptions").Get<RegistrationOptions>();

            var services = new ServiceCollection();
            RegisterServices(services);
            services.AddSingleton(registrationOptions);
            services.AddSingleton(codeWriterOptions);

            var serviceProvicer = services.BuildServiceProvider();
            using var scope = serviceProvicer.CreateScope();

            var namespaceDefinitionsClient = scope.ServiceProvider.GetRequiredService<NamespaceDefinitionsClient>();
            var namespaceDefinitions = namespaceDefinitionsClient.GetNamespaceDefinitions(sources, additionalNamespaceSourceDefinitions, runInParallel).GetAwaiter().GetResult();

            var entitiesRegistrationManager = scope.ServiceProvider.GetRequiredService<EntitiesRegistrationManager>();
            var entityRegistrationResult = entitiesRegistrationManager.RegisterEntities(namespaceDefinitions);

            var clrTypeManager = scope.ServiceProvider.GetRequiredService<ClrTypeManager>();
            var clrTypes = clrTypeManager.TranslateToClrType(entityRegistrationResult.ClassEntities);

            var codeGenerator = scope.ServiceProvider.GetRequiredService<CodeGenerator>();
            var codeConverters = codeGenerator.GetCodeFileConverters(clrTypes);

            var filesManager = scope.ServiceProvider.GetRequiredService<FilesManager>();
            filesManager.CleanDirectory();
            filesManager.WriteCodeFiles(codeConverters);
            filesManager.WriteJsonFiles();
        }

        private static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", false)
               .Build();
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
            services.AddScoped<ClrTypeManager>();
            services.AddScoped<CodeGenerator>();
            services.AddScoped<FilesManager>();

            // entity registrars
            services.AddTransient<ClassEntityRegistrar>();
            services.AddTransient<EventRegistrar>();
            services.AddTransient<NamespaceEntityRegistrar>();
            services.AddTransient<TypeEntityRegistrar>();

            // clr type translators
            services.AddTransient<ClassEntityTranslator>();
            services.AddScoped<ClrTypeStore>();
            services.AddTransient<FunctionDefinitionTranslator>();
            services.AddTransient<PropertyDefinitionTranslator>();

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
