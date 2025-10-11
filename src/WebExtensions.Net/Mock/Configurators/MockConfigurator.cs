using System.Collections.Generic;
using System.Linq;
using WebExtensions.Net.Mock.Handlers;
using WebExtensions.Net.Mock.Resolvers;

namespace WebExtensions.Net.Mock.Configurators;

/// <summary>
/// Mock configurator
/// </summary>
public class MockConfigurator : IMockConfigurator
{
    private readonly List<IMockHandler> apiHandlers;
    private readonly List<IMockHandler> objectReferenceHandlers;
    private readonly ApiConfigurator apiConfigurator;
    private readonly IWebExtensionsApi webExtensionsApi;

    /// <summary>
    /// Creates a new instance of MockConfigurator.
    /// </summary>
    public MockConfigurator(IWebExtensionsApi webExtensionsApi)
    {
        apiHandlers = [];
        objectReferenceHandlers = [];
        apiConfigurator = new ApiConfigurator(webExtensionsApi, apiHandlers);
        this.webExtensionsApi = webExtensionsApi;
    }

    /// <inheritdoc />
    public ApiConfigurator Api => apiConfigurator;

    /// <inheritdoc />
    public ObjectReferenceConfigurator<TObject> ObjectReference<TObject>(TObject objectReference)
        where TObject : BaseObject
        => new(webExtensionsApi, objectReferenceHandlers, objectReference);

    /// <inheritdoc />
    public void ApiHandler(ApiHandler apiHandler)
        => MockResolvers.Resolvers.Insert(1, new CustomMockResolver(apiHandler, null));

    /// <inheritdoc />
    public void ObjectReferenceHandler(ObjectReferenceHandler objectReferenceHandler)
        => MockResolvers.Resolvers.Insert(1, new CustomMockResolver(null, objectReferenceHandler));

    internal void MergeTo(IList<MockApiHandler> mockApiHandlers, IList<MockObjectReferenceHandler> mockObjectReferenceHandlers)
    {
        foreach (var apiHandler in apiHandlers.Cast<MockApiHandler>())
        {
            mockApiHandlers.Add(apiHandler);
        }

        foreach (var objectReferenceHandler in objectReferenceHandlers.Cast<MockObjectReferenceHandler>())
        {
            mockObjectReferenceHandlers.Add(objectReferenceHandler);
        }

        apiHandlers.Clear();
        objectReferenceHandlers.Clear();
    }
}
