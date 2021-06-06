using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.JSInterop;

namespace WebExtensions.Net
{
    /// <summary>
    /// Handles passing delegate reference to be invoked in JavaScript.
    /// </summary>
    public static class DelegateReferenceHandler
    {
        private static readonly Dictionary<Guid, Delegate> delegateReferences = new();
        private static readonly Dictionary<Guid, Delegate> jsProxyDelegates = new();

        /// <summary>
        /// Invoke a delegate reference from JavaScript.
        /// </summary>
        /// <param name="id">The identifier of the delegate.</param>
        /// <param name="args">The arguments to invoke the delegate.</param>
        /// <returns>The result of the delegate invocation.</returns>
        [JSInvokable]
        public static object InvokeDelegateFromJS(Guid id, object[] args)
        {
            if (delegateReferences.TryGetValue(id, out var delegateInstance))
            {
                return InvokeDelegate(delegateInstance, args);
            }

            throw new InvalidOperationException("Delegate reference does not exist.");
        }

        /// <summary>
        /// Gets an instance of DotNetDelegateReference representing the delegate.
        /// </summary>
        /// <param name="delegateArgument">The delegate.</param>
        /// <returns>An instance of DotNetDelegateReference referencing the delegate argument.</returns>
        internal static DotNetDelegateReference GetDotNetDelegateReference(Delegate delegateArgument)
        {
            Guid delegateReferenceId;
            if (delegateReferences.ContainsValue(delegateArgument))
            {
                delegateReferenceId = delegateReferences.ToDictionary(p => p.Value, p => p.Key)[delegateArgument];
            }
            else
            {
                delegateReferenceId = Guid.NewGuid();
                delegateReferences.Add(delegateReferenceId, delegateArgument);
            }

            return new DotNetDelegateReference(delegateReferenceId);
        }

        /// <summary>
        /// Gets the proxy delegate to invoke the JavaScript function.
        /// </summary>
        /// <param name="id">The identifier of the function.</param>
        /// <param name="delegateType">The delegate type.</param>
        /// <returns>A delegate matching the signature of the delegate type, when invoked executes the JavaScript function.</returns>
        internal static Delegate GetJSProxyDelegate(Guid id, Type delegateType)
        {
            if (jsProxyDelegates.ContainsKey(id))
            {
                return jsProxyDelegates[id];
            }

            var functionProxy = new JSFunctionProxy(id);
            var proxyDelegate = functionProxy.GetDelegate(delegateType);
            jsProxyDelegates.Add(id, proxyDelegate);
            return proxyDelegate;
        }

        /// <summary>
        /// Invokes a delegate instance with the arguments.
        /// </summary>
        /// <param name="delegateInstance">The delegate.</param>
        /// <param name="args">The arguments to invoke the delegate.</param>
        /// <returns>The result of the delegate invocation.</returns>
        private static object InvokeDelegate(Delegate delegateInstance, object[] args)
        {
            var invokeMethod = delegateInstance.GetType().GetMethod("Invoke");
            var argumentTypes = invokeMethod.GetParameters().Select(p => p.ParameterType).ToArray();
            var processedArgs = ArgumentsHandler.ProcessIncomingArguments(args, argumentTypes);
            return invokeMethod.Invoke(delegateInstance, processedArgs.ToArray());
        }
    }
}
