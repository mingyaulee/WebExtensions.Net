namespace WebExtensions.Net.Mock.Resolvers;

internal interface IMockResolver
{
    bool TryInvokeApiHandler(string targetPath, object[] arguments, out object result);
    bool TryInvokeObjectReferenceHandler(object objectReference, string targetPath, object[] arguments, out object result);
}
