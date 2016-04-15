namespace Santhos.Web.Mvc.BootstrapFlashMessages
{
    /// <summary>
    /// Flash message
    /// </summary>
    internal class Flash
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Flash"/> class.
        /// </summary>
        /// <param name="severity">The severity.</param>
        /// <param name="message">The message.</param>
        /// <param name="messageArgs">The message arguments.</param>
        public Flash(string severity, string message, params object[] messageArgs)
        {
            this.Severity = severity;
            this.Message = string.Format(message, messageArgs);
        }

        /// <summary>
        /// Gets the severity.
        /// </summary>
        /// <value>
        /// The severity.
        /// </value>
        public string Severity { get; private set; }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; private set; }
    }
}