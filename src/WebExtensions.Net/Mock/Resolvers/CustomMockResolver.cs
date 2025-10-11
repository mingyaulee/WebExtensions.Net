﻿namespace WebExtensions.Net.Mock.Resolvers;

/// <summary>
/// Custom mock resolver.
/// </summary>
internal class CustomMockResolver(ApiHandler apiHandler, ObjectReferenceHandler objectReferenceHandler) : IMockResolver
{
    private readonly ApiHandler apiHandler = apiHandler;
    private readonly ObjectReferenceHandler objectReferenceHandler = objectReferenceHandler;

    public bool TryInvokeApiHandler(string targetPath, object[] arguments, out object result)
    {
        if (apiHandler is not null)
        {
            return apiHandler.Invoke(targetPath, arguments, out result);
        }

        result = null;
        return false;
    }

    public bool TryInvokeObjectReferenceHandler(object objectReference, string targetPath, object[] arguments, out object result)
    {
        if (objectReferenceHandler is not null)
        {
            return objectReferenceHandler.Invoke(objectReference, targetPath, arguments, out result);
        }

        result = null;
        return false;
    }
}
