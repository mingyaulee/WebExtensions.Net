using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using WebExtensions.Net.Generator.CodeGeneration;
using WebExtensions.Net.Generator.CodeGeneration.CodeConverters;
using WebExtensions.Net.Generator.Repositories;

namespace WebExtensions.Net.Generator
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
                try
                {
                    foreach (var directory in Directory.GetDirectories(options.RootDirectory))
                    {
                        logger.LogInformation("Deleting directory {Directory}", directory);
                        DeleteDirectory(directory);
                    }

                    foreach (var file in Directory.GetFiles(options.RootDirectory))
                    {
                        logger.LogInformation("Deleting file {File}", file);
                        DeleteFile(file);
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Failed to clean directory.");
                    throw;
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
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };
            foreach (var namespaceEntity in namespaceEntities)
            {
                var directoryPath = Path.Combine(options.RootDirectory, NormalizePath(namespaceEntity.FullFormattedName));
                if (Directory.Exists(directoryPath))
                {
                    var filePath = Path.Combine(directoryPath, $"{namespaceEntity.FullFormattedName}.json");
                    File.WriteAllText(filePath, JsonSerializer.Serialize(namespaceEntity.OriginalNamespaceDefinitions, jsonSerializerOptions));
                }
            }
        }

        private static void DeleteDirectory(string directory)
        {
            var attemptCount = 0;
            while (true)
            {
                try
                {
                    attemptCount++;
                    Directory.Delete(directory, true);
                    break;
                }
                catch (IOException)
                {
                    if (attemptCount == 3)
                    {
                        throw;
                    }
                }
                Thread.Sleep(1000);
            }
        }

        private static void DeleteFile(string file)
        {
            var attemptCount = 0;
            while (true)
            {
                try
                {
                    attemptCount++;
                    File.Delete(file);
                    break;
                }
                catch (IOException)
                {
                    if (attemptCount == 3)
                    {
                        throw;
                    }
                }
                Thread.Sleep(1000);
            }
        }

        private void WriteCodeFile(CodeFileConverter codeFileConverter)
        {
            var directoryPath = Path.Combine(options.RootDirectory, NormalizePath(codeFileConverter.CodeFile.RelativePath));
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
                logger.LogInformation("Creating directory {Directory}", directory);
                Directory.CreateDirectory(directory);
            }
        }

        private static string NormalizePath(string? path)
        {
            if (path is null)
            {
                return string.Empty;
            }

            return path.Replace('.', Path.DirectorySeparatorChar);
        }
    }
}
