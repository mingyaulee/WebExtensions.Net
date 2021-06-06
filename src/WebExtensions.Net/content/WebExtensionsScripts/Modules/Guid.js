export default class Guid {
  /**
   * Generates a new Guid.
   * @returns {string} A Guid string.
   */
  static NewGuid() {
    return (1e7.toString() + -1e3 + -4e3 + -8e3 + -1e11).replace(/[018]/g, c => {
      const d = parseInt(c);
      return (d ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> d / 4).toString(16);
    });
  }
}