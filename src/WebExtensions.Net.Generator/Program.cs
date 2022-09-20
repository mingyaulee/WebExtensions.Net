using System;
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
using WebExtensions.Net.Generator.NamespaceDefinitionsClients;
using WebExtensions.Net.Generator.Repositories;

namespace WebExtensions.Net.Generator
{
    public static class Program
    {
        public static void Main()
        {
            var configuration = GetConfiguration();
            var sourceOptions = configuration.GetSection("sourceOptions").Get<SourceOptions>();
            var codeWriterOptions = configuration.GetSection("codeWriterOptions").Get<CodeWriterOptions>();
            var registrationOptions = configuration.GetSection("registrationOptions").Get<RegistrationOptions>();
            var classTranslationOptions = configuration.GetSection("classTranslationOptions").Get<ClassTranslationOptions>();
            
            if (sourceOptions is null || codeWriterOptions is null || registrationOptions is null || classTranslationOptions is null)
            {
                throw new InvalidOperationException("Invalid appsettings file.");
            }

            sourceOptions.LocalDirectory = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, sourceOptions.LocalDirectory));
            codeWriterOptions.RootDirectory = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, codeWriterOptions.RootDirectory));

            var services = new ServiceCollection();
            RegisterServices(services);
            services.AddSingleton(sourceOptions);
            services.AddSingleton(codeWriterOptions);
            services.AddSingleton(registrationOptions);
            services.AddSingleton(classTranslationOptions);

            var serviceProvicer = services.BuildServiceProvider();
            using var scope = serviceProvicer.CreateScope();

            var namespaceDefinitionsManager = scope.ServiceProvider.GetRequiredService<NamespaceDefinitionsManager>();
            var namespaceDefinitions = namespaceDefinitionsManager.GetNamespaceDefinitions().GetAwaiter().GetResult();

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
            services.AddScoped<NamespaceDefinitionsManager>();
            services.AddScoped<EntitiesContext>();
            services.AddScoped<EntitiesRegistrationManager>();
            services.AddScoped<ClrTypeManager>();
            services.AddScoped<CodeGenerator>();
            services.AddScoped<FilesManager>();

            // namespace definition clients
            services.AddTransient<NamespaceDefinitionsClient>();

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
            services.AddTransient<EmptyClassEntityRegistrar>();

            services.AddTransient<RegistrarFactory>();
            services.AddTransient<AnonymousTypeProcessor>();
            services.AddTransient<AnonymousTypeRegistrar>();
            services.AddTransient<ClassEntityRegistrar>();
            services.AddTransient<CombinedCallbackParameterClassEntityRegistrar>();
            services.AddTransient<EventDefinitionToPropertyDefinitionConverter>();
            services.AddTransient<NamespaceApiToTypeDefinitionConverter>();
            services.AddTransient<NamespaceEntityRegistrar>();
            services.AddTransient<NamespaceRegistrationFilter>();
            services.AddTransient<TypeEntityRegistrar>();
            services.AddTransient<TypeUsageProcessor>();
            services.AddTransient<RegisteredClassEntityProcessor>();

            // clr type translators
            services.AddTransient<ClassEntityTranslator>();
            services.AddScoped<ClrTypeStore>();
            services.AddTransient<FunctionDefinitionTranslator>();
            services.AddTransient<PropertyDefinitionTranslator>();

            // code converter factories
            services.AddTransient<ApiCodeConverterFactory>();
            services.AddTransient<ApiRootCodeConverterFactory>();
            services.AddTransient<ArrayCodeConverterFactory>();
            services.AddTransient<CombinedCallbackParameterCodeConverterFactory>();
            services.AddTransient<EnumCodeConverterFactory>();
            services.AddTransient<MultitypeCodeConverterFactory>();
            services.AddTransient<StringFormatCodeConverterFactory>();
            services.AddTransient<TypeCodeConverterFactory>();
            services.AddTransient<EmptyCodeConverterFactory>();
        }
    }
}
