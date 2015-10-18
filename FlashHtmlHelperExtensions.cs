namespace Santhos.Web.Mvc.BootstrapFlashMessages
{
    using System.Text;
    using System.Web.Mvc;

    /// <summary>
    /// Flash HtmlHelper extensions
    /// </summary>
    public static class FlashHtmlHelperExtensions
    {
        /// <summary>
        /// Gets flash messages partial view
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="dismissible">If set to <c>true</c>, renders flash messages as dismissible.</param>
        /// <returns>Flash messages partial view</returns>
        public static MvcHtmlString FlashMessages(this HtmlHelper htmlHelper, bool dismissible = false)
        {
            var stringBuilder = new StringBuilder();
            foreach (Flash flash in GetFlashListFromTempData(htmlHelper))
            {
                var tagBuilder = new TagBuilder("div");
                tagBuilder.MergeAttribute("role", "alert");
                tagBuilder.AddCssClass("alert");
                tagBuilder.AddCssClass($"alert-{flash.Severity}");

                if (dismissible)
                {
                    tagBuilder.AddCssClass("alert-dismissible");
                    tagBuilder.InnerHtml =
                        "<button type=\"button\" class=\"close\" " +
                        "data-dismiss=\"alert\" aria-label=\"Close\">"+
                        "<span aria-hidden=\"true\">&times;</span></button>";
                }

                tagBuilder.InnerHtml += $"<span>{flash.Message}</span>";

                stringBuilder.AppendLine(tagBuilder.ToString());
            }

            return MvcHtmlString.Create(stringBuilder.ToString());
        }

        /// <summary>
        /// Gets the flash list from temporary data.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <returns>Flash list with flash messages</returns>
        private static FlashList GetFlashListFromTempData(HtmlHelper htmlHelper)
        {
            return htmlHelper.ViewContext.TempData[FlashControllerExtensions.FlashTempDataKey] as FlashList
                   ?? new FlashList();
        }
    }
}