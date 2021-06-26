import FunctionReferenceHandler from "./FunctionReferenceHandler.js";

/**
 * Process incoming and outgoing arguments.
 */
export default class ArgumentsHandler {
  /**
   * Process incoming arguments.
   * @param {object[]} incomingArguments The incoming arguments.
   * @returns {object[]} The processed incoming arguments.
   */
  static ProcessIncomingArguments(incomingArguments) {
    return incomingArguments.map(incomingArgument => {
      if (incomingArgument && incomingArgument.__isDelegateReference) {
        return FunctionReferenceHandler.GetDotnetProxyFunction(incomingArgument.__id);
      }

      return incomingArgument;
    });
  }

  /**
   * Process outgoing arguments.
   * @param {object[]} outgoingArguments The outgoing arguments.
   * @returns {object[]} The processed outgoing arguments.
   */
  static ProcessOutgoingArguments(outgoingArguments) {
    return outgoingArguments.map(this.ProcessOutgoingArgument);
  }

  /**
   * Process outgoing argument.
   * @param {object} outgoingArgument The outgoing argument.
   * @returns {object} The processed outgoing argument.
   */
  static ProcessOutgoingArgument(outgoingArgument) {
    if (outgoingArgument === undefined || outgoingArgument === null) {
      return outgoingArgument;
    }

    if (outgoingArgument instanceof Function) {
      return FunctionReferenceHandler.GetJSFunctionReference(outgoingArgument);
    }

    if (outgoingArgument instanceof Window || outgoingArgument["window"] === outgoingArgument) {
      return this._ProcessWindowArgument(outgoingArgument);
    }

    return outgoingArgument;
  }

  /**
   * Process window argument.
   * @param {Window} windowObject The window object.
   * @returns {object} The processed window object.
   */
  static _ProcessWindowArgument(windowObject) {
    var processedWindowObject = {};
    for (const [key, value] of Object.entries(windowObject)) {
      if (value == windowObject) {
        continue;
      }
      processedWindowObject[key] = value;
    }
    return processedWindowObject;
  }
}