using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace WebExtensions.Net;

/// <summary>
/// Base class for types that has a format pattern
/// </summary>
public class BaseStringFormat
{
    /// <summary>
    /// Creates a new instance of the BaseStringFormat class
    /// </summary>
    /// <param name="value">The string value.</param>
    /// <param name="format">The string format.</param>
    /// <param name="pattern">The string pattern.</param>
    public BaseStringFormat(string value, string format, string pattern)
    {
        Value = value;

        if (!string.IsNullOrEmpty(pattern) && !IsValidPattern(value, pattern))
        {
            throw new ArgumentException($"The value '{value}' does not match the pattern '{pattern}' specified for type {GetType().Name}.");
        }

        if (!string.IsNullOrEmpty(format) && !IsValidFormat(value, format))
        {
            throw new ArgumentException($"The value '{value}' does not match the format '{format}' specified for type {GetType().Name}.");
        }
    }

    /// <summary>
    /// The value.
    /// </summary>
    public string Value { get; }

    /// <inheritdoc />
    public override string ToString() => Value;

    internal static bool IsValid(string value, Type type)
    {
#pragma warning disable S3011 // Reflection should not be used to increase accessibility of classes, methods, or fields
        var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Static);
#pragma warning restore S3011 // Reflection should not be used to increase accessibility of classes, methods, or fields
        string pattern = null;
        string format = null;

        foreach (var field in fields)
        {
            if (field.Name == "FORMAT")
            {
                format = (string)field.GetValue(null);
            }
            else if (field.Name == "PATTERN")
            {
                pattern = (string)field.GetValue(null);
            }
        }

        return
            (!string.IsNullOrEmpty(pattern) && IsValidPattern(value, pattern)) ||
            (!string.IsNullOrEmpty(format) && IsValidFormat(value, format));
    }

    internal static object TryCreate(string value, Type type)
        => IsValid(value, type) ? Activator.CreateInstance(type, value) : null;

    private static bool IsValidFormat(string value, string format)
    {
        if (format.Contains("url", StringComparison.OrdinalIgnoreCase))
        {
            try
            {
                _ = new Uri(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        if (format == "date")
        {
#pragma warning disable S6580 // Use a format provider when parsing date and time
            return DateTime.TryParse(value, out _);
#pragma warning restore S6580 // Use a format provider when parsing date and time
        }

        return true;
    }

    private static bool IsValidPattern(string value, string pattern)
        => Regex.IsMatch(value, pattern, RegexOptions.None, TimeSpan.FromSeconds(30));
}
