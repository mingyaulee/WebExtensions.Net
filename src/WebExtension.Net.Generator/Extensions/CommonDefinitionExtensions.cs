using System;
using WebExtension.Net.Generator.Models;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace WebExtension.Net.Generator.Extensions
{
    public static class CommonDefinitionExtensions
    {
        public static string GetName(this ICommonDefinition commonDefinition)
        {
            if (commonDefinition is TypeReference typeReference)
            {
                if (string.IsNullOrEmpty(commonDefinition.Name))
                {
                    throw new Exception($"Type reference has to be translated before calling GetName()");
                }
            }
            if (string.IsNullOrEmpty(commonDefinition.Name))
            {
                throw new Exception("Name cannot be null " + JsonSerializer.Serialize((object)commonDefinition));
            }
            if (commonDefinition.Name.Length > 1)
            {
                return commonDefinition.Name[0].ToString().ToUpperInvariant() + commonDefinition.Name.Substring(1);
            }
            return commonDefinition.Name.ToUpperInvariant();
        }

        public static string[] GetDescription(this ICommonDefinition commonDefinition)
        {
            var description = commonDefinition.Description ?? string.Empty;
            description = Regex.Replace(description, @"(?'mdash'&mdash;)|(?'ampersand'&)|(?'linebreak'<br>)|(?'allurls'<all_urls>)|(?'tag'<\w+>)(?'tagContent'([^<])+)(?'endTag'</\w+>)", match =>
            {
                if (match.Groups["mdash"].Success)
                {
                    return "-";
                }
                if (match.Groups["ampersand"].Success)
                {
                    return "&amp;";
                }
                if (match.Groups["linebreak"].Success)
                {
                    return Environment.NewLine;
                }
                if (match.Groups["allurls"].Success)
                {
                    return "all_urls";
                }
                if (match.Groups["tag"].Success && match.Groups["tag"].Value == "<code>")
                {
                    var tagContent = match.Groups["tagContent"].Value;
                    return $"<c>{tagContent}</c>";
                }
                return match.Value;
            });
            return description.Split(Environment.NewLine);
        }
    }
}
