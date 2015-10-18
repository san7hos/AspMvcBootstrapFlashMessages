namespace Santhos.Web.Mvc.BootstrapFlashMessages
{
    using System.Web.Mvc;

    /// <summary>
    /// Controller flash messages extensions
    /// </summary>
    public static class FlashControllerExtensions
    {
        /// <summary>
        /// Flash message container TempData key
        /// </summary>
        internal const string FlashTempDataKey = "FlashList";

        /// <summary>
        /// Flashes the success message
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="message">The message.</param>
        /// <param name="messageArgs">The message arguments.</param>
        public static void FlashSuccess(this Controller controller, string message, params object[] messageArgs)
        {
            Flash(controller, FlashSeverity.Success, string.Format(message, messageArgs));
        }

        /// <summary>
        /// Flashes the warning message
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="message">The message.</param>
        /// <param name="messageArgs">The message arguments.</param>
        public static void FlashWarning(this Controller controller, string message, params object[] messageArgs)
        {
            Flash(controller, FlashSeverity.Warning, message, messageArgs);
        }

        /// <summary>
        /// Flashes the danger message
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="message">The message.</param>
        /// <param name="messageArgs">The message arguments.</param>
        public static void FlashDanger(this Controller controller, string message, params object[] messageArgs)
        {
            Flash(controller, FlashSeverity.Danger, message, messageArgs);
        }

        /// <summary>
        /// Flashes the information message
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="message">The message.</param>
        /// <param name="messageArgs">The message arguments.</param>
        public static void FlashInfo(this Controller controller, string message, params object[] messageArgs)
        {
            Flash(controller, FlashSeverity.Info, message, messageArgs);
        }

        /// <summary>
        /// Flashes the specified message
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="severity">The severity.</param>
        /// <param name="message">The message.</param>
        /// <param name="messageArgs">The message arguments.</param>
        private static void Flash(Controller controller,  string severity, string message, params object[] messageArgs)
        {
            object flashList;
            if (controller.TempData.TryGetValue(FlashTempDataKey, out flashList))
            {
                ((FlashList)flashList).Add(new Flash(severity, string.Format(message, messageArgs)));

                controller.TempData.Keep(FlashTempDataKey);
            }
            else
            {
                controller.TempData[FlashTempDataKey] = new FlashList { new Flash(severity, message) };
            }
        }
    }
}