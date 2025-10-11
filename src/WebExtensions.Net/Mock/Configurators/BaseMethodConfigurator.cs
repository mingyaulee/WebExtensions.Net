using System;
using System.Collections.Generic;
using WebExtensions.Net.Mock.Handlers;

namespace WebExtensions.Net.Mock.Configurators;

/// <summary>
/// Base method configurator.
/// </summary>
/// <param name="mockHandlers">The list of mock handlers.</param>
/// <param name="mockHandler">The mock handler to configure</param>
public abstract class BaseMethodConfigurator(IList<IMockHandler> mockHandlers, IMockHandler mockHandler)
{
    private readonly IList<IMockHandler> mockHandlers = mockHandlers;
    private readonly IMockHandler mockHandler = mockHandler;

    /// <summary>
    /// Sets the delegate handler and add the handler to the mock handler list.
    /// </summary>
    /// <param name="delegateHandler"></param>
    protected void SetDelegateHandler(Delegate delegateHandler)
    {
        if (mockHandlers.Contains(mockHandler))
        {
            throw new InvalidOperationException("This instance of mock handler has been configured.");
        }

        mockHandler.DelegateHandler = delegateHandler;
        mockHandlers.Add(mockHandler);
    }
}
