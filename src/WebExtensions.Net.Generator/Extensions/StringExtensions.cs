using System.Text.RegularExpressions;

namespace WebExtensions.Net.Generator.Extensions
{
    public static class StringExtensions
    {
        public static string ToCamelCase(this string name)
        {
            if (name.Length > 1)
            {
                return name[0].ToString().ToLowerInvariant() + name[1..];
            }
            return name.ToUpperInvariant();
        }

        public static string ToCapitalCase(this string name)
        {
            if (name.Length > 1)
            {
                return name[0].ToString().ToUpperInvariant() + name[1..];
            }
            return name.ToUpperInvariant();
        }

        public static string ToXmlContent(this string? content)
        {
            if (content is not null)
            {
                return Regex.Replace(content, @"(?'mdash'&mdash;)|(?'ampersand'&)|(?'tag'</?\w+\s*(?'tagAttributes'([^>])*)>)", XmlContentMatchEvaluator);
            }
            return string.Empty;
        }

        private static string XmlContentMatchEvaluator(Match match)
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
                return "<br />";
            }
            if (match.Groups["tag"].Success)
            {
                var tag = match.Groups["tag"].Value;
                if (tag.EndsWith("/>"))
                {
                    // tag is self closing
                    return tag;
                }
                return tag switch
                {
                    // change block code to inline code
                    "<code>" => "<c>",
                    "</code>" => "</c>",
                    // change variable code to inline code
                    "<var>" => "<c>",
                    "</var>" => "</c>",
                    // allow <em>
                    "<em>" => "<em>",
                    "</em>" => "</em>",
                    // change line break to self closing line break
                    "<br>" => "<br />",
                    // convert paragraphs to line break
                    "<p>" => string.Empty,
                    "</p>" => "<br />",
                    // convert hyperlink tags
                    var tagValue when tagValue.StartsWith("<a ") => $"<see {match.Groups["tagAttributes"].Value}>",
                    "</a>" => "</see>",
                    _ => $"'{tag.Trim('<', '>')}'"
                };
            }
            return match.Value;
        }
    }
}
