import DotNetDelegateProxy from "./DotNetDelegateProxy.js";
import Guid from "./Guid.js";
import JSFunctionReference from "./JSFunctionReference.js";

/**
 * Handles passing function reference to be invoked in DotNet.
 */
export default class FunctionReferenceHandler {
  static _functionReferences = {};
  static _dotnetProxyFunctions = {};

  /**
   * Invoke a function reference from DotNet.
   * @param {string} id The identifier of the function.
   * @param {object[]} args The arguments to invoke the delegate.
   * @returns {object} The result of the function invocation.
   */
  static InvokeFunctionFromDotNet(id, args) {
    if (this._functionReferences[id]) {
      return this._functionReferences[id].apply(null, args);
    }

    throw new Error("Function reference does not exist.");
  }

  /**
   * Gets an instance of JSFunctionReference representing the function.
   * @param {Function} functionArgument The function.
   * @returns {JSFunctionReference} An instance of JSFunctionReference referencing the function argument.
   */
  static GetJSFunctionReference(functionArgument) {
    let functionReferenceId;
    if (Object.values(this._functionReferences).includes(functionArgument)) {
      functionReferenceId = Object.entries(this._functionReferences)
        .map(([key, value]) => { return { key, value }; })
        .find(({ value }) => value === functionArgument).key;
    } else {
      functionReferenceId = Guid.NewGuid();
      this._functionReferences[functionReferenceId] = functionArgument;
    }

    return new JSFunctionReference(functionReferenceId);
  }

  /**
   * Gets the proxy function to invoke the DotNet delegate.
   * @param {string} id The identifier of the delegate.
   * @returns {Function} A function, when invoked executes the DotNet delegate.
   */
  static GetDotnetProxyFunction(id) {
    if (this._dotnetProxyFunctions[id]) {
      return this._dotnetProxyFunctions[id];
    }

    const delegateProxy = new DotNetDelegateProxy(id);
    const proxyFunction = delegateProxy.getFunction();
    this._dotnetProxyFunctions[id] = proxyFunction;
    return proxyFunction;
  }
}