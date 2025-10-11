using System;
using System.Collections.Generic;
using WebExtensions.Net.Mock.Handlers;

namespace WebExtensions.Net.Mock.Configurators;

/// <summary>Mock action configurator.</summary>
public class MockActionConfigurator : BaseMethodConfigurator
{
    internal MockActionConfigurator(IList<IMockHandler> mockHandlers, IMockHandler mockHandler) : base(mockHandlers, mockHandler) { }

    /// <summary>Sets a delegate to handle invocation from this mock.</summary>
    /// <param name="action">The delegate to handle the invocation.</param>
    public void Invokes(Action action) => SetDelegateHandler(action);
}

/// <summary>Mock action configurator.</summary>
/// <typeparam name="T">The action argument type.</typeparam>
public class MockActionConfigurator<T> : BaseMethodConfigurator
{
    internal MockActionConfigurator(IList<IMockHandler> mockHandlers, IMockHandler mockHandler) : base(mockHandlers, mockHandler) { }

    /// <summary>Sets a delegate to handle invocation from this mock.</summary>
    /// <param name="action">The delegate to handle the invocation.</param>
    public void Invokes(Action<T> action) => SetDelegateHandler(action);
}

/// <summary>Mock action configurator.</summary>
/// <typeparam name="T1">The action argument 1 type.</typeparam>
/// <typeparam name="T2">The action argument 2 type.</typeparam>
public class MockActionConfigurator<T1, T2> : BaseMethodConfigurator
{
    internal MockActionConfigurator(IList<IMockHandler> mockHandlers, IMockHandler mockHandler) : base(mockHandlers, mockHandler) { }

    /// <summary>Sets a delegate to handle invocation from this mock.</summary>
    /// <param name="action">The delegate to handle the invocation.</param>
    public void Invokes(Action<T1, T2> action) => SetDelegateHandler(action);
}

/// <summary>Mock action configurator.</summary>
/// <typeparam name="T1">The action argument 1 type.</typeparam>
/// <typeparam name="T2">The action argument 2 type.</typeparam>
/// <typeparam name="T3">The action argument 3 type.</typeparam>
public class MockActionConfigurator<T1, T2, T3> : BaseMethodConfigurator
{
    internal MockActionConfigurator(IList<IMockHandler> mockHandlers, IMockHandler mockHandler) : base(mockHandlers, mockHandler) { }

    /// <summary>Sets a delegate to handle invocation from this mock.</summary>
    /// <param name="action">The delegate to handle the invocation.</param>
    public void Invokes(Action<T1, T2, T3> action) => SetDelegateHandler(action);
}

/// <summary>Mock action configurator.</summary>
/// <typeparam name="T1">The action argument 1 type.</typeparam>
/// <typeparam name="T2">The action argument 2 type.</typeparam>
/// <typeparam name="T3">The action argument 3 type.</typeparam>
/// <typeparam name="T4">The action argument 4 type.</typeparam>
public class MockActionConfigurator<T1, T2, T3, T4> : BaseMethodConfigurator
{
    internal MockActionConfigurator(IList<IMockHandler> mockHandlers, IMockHandler mockHandler) : base(mockHandlers, mockHandler) { }

    /// <summary>Sets a delegate to handle invocation from this mock.</summary>
    /// <param name="action">The delegate to handle the invocation.</param>
    public void Invokes(Action<T1, T2, T3, T4> action) => SetDelegateHandler(action);
}

/// <summary>Mock action configurator.</summary>
/// <typeparam name="T1">The action argument 1 type.</typeparam>
/// <typeparam name="T2">The action argument 2 type.</typeparam>
/// <typeparam name="T3">The action argument 3 type.</typeparam>
/// <typeparam name="T4">The action argument 4 type.</typeparam>
/// <typeparam name="T5">The action argument 5 type.</typeparam>
public class MockActionConfigurator<T1, T2, T3, T4, T5> : BaseMethodConfigurator
{
    internal MockActionConfigurator(IList<IMockHandler> mockHandlers, IMockHandler mockHandler) : base(mockHandlers, mockHandler) { }

    /// <summary>Sets a delegate to handle invocation from this mock.</summary>
    /// <param name="action">The delegate to handle the invocation.</param>
    public void Invokes(Action<T1, T2, T3, T4, T5> action) => SetDelegateHandler(action);
}
