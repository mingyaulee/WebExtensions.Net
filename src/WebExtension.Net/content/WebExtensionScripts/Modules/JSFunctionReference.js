/**
 * A JavaScript function reference to be invoked in DotNet.
 */
export default class JSFunctionReference {
  /**
   * Creates a new instance of the JSFunctionReference class.
   * @param {string} id The identifier.
   */
  constructor(id) {
    this.__id = id;
  }

  /**
   * @type {boolean} Indicate that this object is a JavaScript function reference.
   */
  __isFunctionReference = true;

  /**
   * @type {string} The identifier of this JavaScript function reference.
   */
  __id;
}