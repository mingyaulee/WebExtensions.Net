using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebExtensions.Net.Generator.ClrTypeTranslators;
using WebExtensions.Net.Generator.CodeGeneration;
using WebExtensions.Net.Generator.CodeGeneration.CodeConverterFactories;
using WebExtensions.Net.Generator.EntitiesRegistration;
using WebExtensions.Net.Generator.EntitiesRegistration.ClassEntityRegistrars;
using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Models.Schema;
using WebExtensions.Net.Generator.Repositories;

namespace WebExtensions.Net.Generator
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
            var classTranslationOptions = configuration.GetSection("classTranslationOptions").Get<ClassTranslationOptions>();

            var services = new ServiceCollection();
            RegisterServices(services);
            services.AddSingleton(codeWriterOptions);
            services.AddSingleton(registrationOptions);
            services.AddSingleton(classTranslationOptions);

            var serviceProvicer = services.BuildServiceProvider();
            using var scope = serviceProvicer.CreateScope();

            var namespaceDefinitionsClient = scope.ServiceProvider.GetRequiredService<NamespaceDefinitionsClient>();
            var namespaceDefinitions = namespaceDefinitionsClient.GetNamespaceDefinitions(sources, additionalNamespaceSourceDefinitions, runInParallel).GetAwaiter().GetResult();

            var entitiesRegistrationManager = scope.ServiceProvider.GetRequiredService<EntitiesRegistrationManager>();
            var classEntities = entitiesRegistrationManager.RegisterEntities(namespaceDefinitions);

            var clrTypeManager = scope.ServiceProvider.GetRequiredService<ClrTypeManager>();
            var clrTypes = clrTypeManager.TranslateToClrType(classEntities);

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
            services.AddTransient<ApiClassEntityRegistrar>();
            services.AddTransient<ApiRootClassEntityRegistrar>();
            services.AddTransient<ArrayClassEntityRegistrar>();
            services.AddTransient<ClassEntityRegistrarFactory>();
            services.AddTransient<EnumClassEntityRegistrar>();
            services.AddTransient<EventTypeClassEntityRegistrar>();
            services.AddTransient<MultiTypeClassEntityRegistrar>();
            services.AddTransient<StringFormatClassEntityRegistrar>();
            services.AddTransient<TypeClassEntityRegistrar>();

            services.AddTransient<AnonymousTypeProcessor>();
            services.AddTransient<AnonymousTypeRegistrar>();
            services.AddTransient<ClassEntityRegistrar>();
            services.AddTransient<EventDefinitionToPropertyDefinitionConverter>();
            services.AddTransient<NamespaceApiToTypeDefinitionConverter>();
            services.AddTransient<NamespaceEntityRegistrar>();
            services.AddTransient<NamespaceRegistrationFilter>();
            services.AddTransient<TypeEntityRegistrar>();
            services.AddTransient<TypeUsageProcessor>();

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
