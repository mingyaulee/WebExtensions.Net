namespace WebExtension.Net.Generator
{
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

        public static class MethodMetadata
        {
            public const string IsPropertyGetterMethod = nameof(IsPropertyGetterMethod);
        }
    }
}
