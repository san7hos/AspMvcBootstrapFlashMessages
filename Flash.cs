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
        public Flash(string severity, string message)
        {
            this.Severity = severity;
            this.Message = message;
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