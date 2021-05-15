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
    return outgoingArguments.map(outgoingArgument => {
      if (outgoingArgument instanceof Function) {
        return FunctionReferenceHandler.GetJSFunctionReference(outgoingArgument);
      }

      return outgoingArgument;
    });
  }
}