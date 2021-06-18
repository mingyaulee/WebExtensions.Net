import ArgumentsHandler from "./ArgumentsHandler.js";

/**
 * A DotNet delegate proxy to be invoked in JS.
 */
export default class DotNetDelegateProxy {
  _id;

  /**
   * Creates a new instance of the DotNetDelegateProxy class.
   * @param {string} id The delegate identifier.
   */
  constructor(id) {
    this._id = id;
  }

  /**
   * Gets the proxy function to invoke the DotNet delegate.
   * @returns {Function} A function, when invoked executes the DotNet delegate.
   */
  getFunction() {
    return this.dynamicInvoke.bind(this);
  }

  /**
   * Dynamically invoke the DotNet delegate synchronously.
   * @param  {...any} invokeArgs JSON-serializable arguments.
   * @returns {object} An object obtained by JSON-deserializing the return value.
   */
  dynamicInvoke(...invokeArgs) {
    const id = this._id;
    const processedInvokeArgs = ArgumentsHandler.ProcessOutgoingArguments(invokeArgs);
    return globalThis.DotNet.invokeMethod("WebExtensions.Net", "InvokeDelegateFromJS", id, processedInvokeArgs);
  }
}