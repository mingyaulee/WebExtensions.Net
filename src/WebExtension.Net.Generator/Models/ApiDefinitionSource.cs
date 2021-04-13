namespace WebExtension.Net.Generator.Models
{
    public class ApiDefinitionSource
    {
        public ApiDefinitionSource(string baseUrl, string fileName, string schemaBaseUrl)
        {
            BaseUrl = baseUrl;
            FileName = fileName;
            SchemaBaseUrl = schemaBaseUrl;
        }

        public string BaseUrl { get; }
        public string FileName { get; }
        public string SchemaBaseUrl { get; }
    }
}
