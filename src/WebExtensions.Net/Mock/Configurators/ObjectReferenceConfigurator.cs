using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebExtensions.Net.Mock.Handlers;

namespace WebExtensions.Net.Mock.Configurators
{
    /// <summary>
    /// The API configurator.
    /// </summary>
    public class ObjectReferenceConfigurator<TObject> : BaseConfigurator<TObject>
    {
        private readonly TObject objectReference;

        /// <summary>
        /// Creates a new instance of ObjectReferenceConfigurator.
        /// </summary>
        /// <param name="webExtensionsApi">The web extension API.</param>
        /// <param name="mockHandlers">The mock handlers.</param>
        /// <param name="objectReference">The object reference configured.</param>
        internal ObjectReferenceConfigurator(IWebExtensionsApi webExtensionsApi, IList<IMockHandler> mockHandlers, TObject objectReference) : base(webExtensionsApi, mockHandlers)
        {
            if (objectReference is null)
            {
                throw new ArgumentNullException(nameof(objectReference));
            }

            this.objectReference = objectReference;
        }

        /// <inheritdoc />
        protected override IMockHandler CreateHandler(LambdaExpression expression)
        {
            MockConfigurationContext.ResetContext();
            InvokeExpression(expression);
            if (MockConfigurationContext.TryGetObjectReferenceInvoked(out var obj, out var targetPath))
            {
                if (!objectReference.Equals(obj))
                {
                    throw new InvalidOperationException("Object reference invoked is different from the object reference configured.");
                }

                return new MockObjectReferenceHandler()
                {
                    ObjectReference = obj,
                    TargetPath = targetPath
                };
            }

            throw new InvalidOperationException("There was no invocation on the object reference to mock.");
        }
    }
}
