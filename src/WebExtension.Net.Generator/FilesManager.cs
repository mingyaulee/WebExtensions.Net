using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using WebExtension.Net.Generator.CodeGeneration;
using WebExtension.Net.Generator.CodeGeneration.CodeConverters;
using WebExtension.Net.Generator.Repositories;

namespace WebExtension.Net.Generator
{
    public class FilesManager
    {
        private const string GENERATED_FILE_NAME = "generated.txt";
        private readonly ILogger logger;
        private readonly CodeWriterOptions options;
        private readonly EntitiesContext entitiesContext;

        public FilesManager(ILogger logger, CodeWriterOptions options, EntitiesContext entitiesContext)
        {
            this.logger = logger;
            this.options = options;
            this.entitiesContext = entitiesContext;
        }

        public void CleanDirectory()
        {
            if (File.Exists(Path.Combine(options.RootDirectory, GENERATED_FILE_NAME)))
            {
                foreach (var directory in Directory.GetDirectories(options.RootDirectory))
                {
                    logger.LogWarning($"Deleting directory {directory}");
                    Directory.Delete(directory, true);
                }

                foreach (var file in Directory.GetFiles(options.RootDirectory))
                {
                    logger.LogWarning($"Deleting file {file}");
                    File.Delete(file);
                }
            }
        }

        public void WriteCodeFiles(IEnumerable<CodeFileConverter> codeFileConverters)
        {
            var filePath = Path.Combine(options.RootDirectory, GENERATED_FILE_NAME);
            File.WriteAllText(filePath, $"This file is auto generated at {DateTime.UtcNow:s}");

            foreach (var codeFileConverter in codeFileConverters)
            {
                WriteCodeFile(codeFileConverter);
            }
        }

        public void WriteJsonFiles()
        {
            var namespaceEntities = entitiesContext.Namespaces.GetAllNamespaceEntities();
            var jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerConstant.Options)
            {
                WriteIndented = true,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault
            };
            foreach (var namespaceEntity in namespaceEntities)
            {
                var directoryPath = Path.Combine(options.RootDirectory, namespaceEntity.FormattedName);
                if (Directory.Exists(directoryPath))
                {
                    var filePath = Path.Combine(directoryPath, $"{namespaceEntity.FormattedName}.json");
                    File.WriteAllText(filePath, JsonSerializer.Serialize(namespaceEntity.NamespaceDefinitions, jsonSerializerOptions));
                }
            }
        }

        private void WriteCodeFile(CodeFileConverter codeFileConverter)
        {
            var directoryPath = Path.Combine(options.RootDirectory, codeFileConverter.CodeFile.RelativeNamespace);
            var filePath = Path.Combine(directoryPath, $"{codeFileConverter.CodeFile.FileName}.cs");

            CreateDirectoryIfNotExist(directoryPath);

            var codeWriter = new CodeFileWriter(filePath, codeFileConverter.CodeFile, options);
            codeFileConverter.WriteTo(codeWriter, options);
            codeWriter.Flush();
        }

        private void CreateDirectoryIfNotExist(string directory)
        {
            if (!Directory.Exists(directory))
            {
                logger.LogWarning($"Creating directory {directory}");
                Directory.CreateDirectory(directory);
            }
        }
    }
}
