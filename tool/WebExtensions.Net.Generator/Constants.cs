namespace WebExtensions.Net.Generator;

public static class Constants
{
    public const string RelativeNamespaceToken = "$relativeNamespace";
    public const string ArrayTypeToken = "$arrayItemTypeName";
    
    public static class TypeMetadata
    {
        public const string ClassType = nameof(ClassType);
        public const string ApiNamespace = nameof(ApiNamespace);
        public const string StringFormat = nameof(StringFormat);
        public const string StringPattern = nameof(StringPattern);
    }

    public static class PropertyMetadata
    {
        public const string NestedApiProperty = nameof(NestedApiProperty);
        public const string EventProperty = nameof(EventProperty);
    }
}
