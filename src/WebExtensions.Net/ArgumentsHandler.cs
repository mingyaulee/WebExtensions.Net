using System;
using System.Linq;
using System.Text.Json;

namespace WebExtension.Net
{
    /// <summary>
    /// Process incoming and outgoing arguments.
    /// </summary>
    internal static class ArgumentsHandler
    {
        /// <summary>
        /// Process incoming arguments.
        /// </summary>
        /// <param name="incomingArguments">The incoming arguments.</param>
        /// <param name="argumentTypes">The argument types.</param>
        /// <returns>The processed incoming arguments.</returns>
        public static object[] ProcessIncomingArguments(object[] incomingArguments, Type[] argumentTypes)
        {
            var index = 0;
            return argumentTypes.Select(argumentType =>
            {
                var incomingArgument = index < incomingArguments.Length ? incomingArguments[index] : GetDefaultValueForType(argumentType);

                if (incomingArgument is JsonElement jsonElementArg)
                {
                    if (jsonElementArg.ValueKind == JsonValueKind.Object && jsonElementArg.TryGetProperty("__isFunctionReference", out var isFunctionReference) && isFunctionReference.ValueKind == JsonValueKind.True)
                    {
                        return DelegateReferenceHandler.GetJSProxyDelegate(jsonElementArg.GetProperty("__id").GetGuid(), argumentType);
                    }

                    var json = jsonElementArg.GetRawText();
                    incomingArgument = JsonSerializer.Deserialize(json, argumentType);
                }

                index++;
                return incomingArgument;
            }).ToArray();
        }

        /// <summary>
        /// Process outgoing arguments.
        /// </summary>
        /// <param name="outgoingArguments">The outgoing arguments.</param>
        /// <returns>The processed outgoing arguments.</returns>
        public static object[] ProcessOutgoingArguments(object[] outgoingArguments)
        {
            return outgoingArguments.Select(outgoingArgument =>
            {
                if (outgoingArgument is Delegate delegateArgument)
                {
                    return DelegateReferenceHandler.GetDotNetDelegateReference(delegateArgument);
                }

                return outgoingArgument;
            }).ToArray();
        }

        private static object GetDefaultValueForType(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }

            return null;
        }
    }
}
