import ArgumentsHandler from "./ArgumentsHandler.js";
import FunctionReferenceHandler from "./FunctionReferenceHandler.js";

export default class WebExtension {
  /**
   * @type {object} The object references.
   */
  #objectReferences = {};

  /**
   * @type {number} The count of the object references.
   */
  #objectReferencesCount = 0;

  /**
   * Invoke on an object reference.
   * @param {object} invokeOption The option for invocation. 
   * @param {string} invokeOption.referenceId The identifier of the JavaScript object.
   * @param {string} invokeOption.targetPath The target path of the JavaScript object.
   * @param {boolean} invokeOption.isFunction The indicator if the target is a function.
   * @param {string} invokeOption.returnObjectReferenceId The identifier to be used as a key for the JavaScript object returned.
   * @returns {Promise<object>} The result of the invocation.
   */
  async InvokeOnObjectReference({ referenceId, targetPath, isFunction, returnObjectReferenceId }, ...args) {
    let targetObject = this.#objectReferences[referenceId];
    let targetMember = targetPath;
    if (referenceId === "browser") {
      targetObject = globalThis.browser;
    }
    const targetPaths = targetPath.split(".");
    for (let i = 0; i < targetPaths.length; i++) {
      if (i === targetPaths.length - 1) {
        targetMember = targetPaths[i];
      } else {
        targetObject = targetObject?.[targetPaths[i]];
      }
    }

    if (isFunction && !targetObject?.[targetMember]) {
      throw new Error(`Unable to find function ${targetPath} on object '${referenceId}'.`);
    }

    const processedArgs = ArgumentsHandler.ProcessIncomingArguments(args);
    try {
      let result = isFunction ? targetObject[targetMember].apply(targetObject, processedArgs) : targetObject?.[targetMember];
      if (result instanceof Promise) {
        result = await result;
      }

      result = ArgumentsHandler.ProcessOutgoingArgument(result);

      if (returnObjectReferenceId) {
        this.#objectReferencesCount++;
        this.#objectReferences[returnObjectReferenceId] = result;
      }

      return result;
    } catch (error) {
      console.error(referenceId, targetPath, processedArgs, targetObject, targetMember, args);
      throw new Error(`Failed to execute function ${targetPath} on object '${referenceId}': ${error.message}`);
    }
  }

  /**
   * Remove an object reference.
   * @param {object} invokeOption The option for invocation. 
   * @param {string} invokeOption.referenceId The identifier of the object reference. 
   */
  RemoveObjectReference({ referenceId }) {
    if (this.#objectReferences[referenceId] !== null) {
      this.#objectReferencesCount--;
      this.#objectReferences[referenceId] = null;
    }
  }

  /**
   * Gets the object references.
   * @returns {object} The object references.
   */
  GetObjectReferences() { return this.#objectReferences; }

  /**
   * Gets the count of the object references.
   * @returns {number} The count of the object references.
   */
  GetObjectReferencesCount() { return this.#objectReferencesCount; }

  /**
   * Invoke a function reference.
   * @param {object} invokeOption The option for invocation. 
   * @param {string} invokeOption.referenceId The identifier of the function. 
   * @param  {...any} args The arguments to invoke the delegate.
   * @returns {object} The result of the function invocation.
   */
  InvokeFunctionFromDotNet({ referenceId }, ...args) {
    return FunctionReferenceHandler.InvokeFunctionFromDotNet(referenceId, args);
  }
}