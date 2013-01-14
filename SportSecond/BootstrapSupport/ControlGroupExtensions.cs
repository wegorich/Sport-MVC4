using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace BootstrapSupport
{
    public static class ControlGroupExtensions
    {
        public static IHtmlString BeginControlGroupFor<T>(this HtmlHelper<T> html,
                                                          Expression<Func<T, object>> modelProperty)
        {
            var controlGroupWrapper = new TagBuilder("div");
            controlGroupWrapper.AddCssClass("control-group");
            string partialFieldName = ExpressionHelper.GetExpressionText(modelProperty);
            string fullHtmlFieldName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(partialFieldName);
            if (!html.ViewData.ModelState.IsValidField(fullHtmlFieldName))
            {
                controlGroupWrapper.AddCssClass("error");
            }
            string openingTag = controlGroupWrapper.ToString(TagRenderMode.StartTag);
            return MvcHtmlString.Create(openingTag);
        }

        public static IHtmlString BeginControlGroupFor<T>(this HtmlHelper<T> html,
                                                          string propertyName)
        {
            var controlGroupWrapper = new TagBuilder("div");
            controlGroupWrapper.AddCssClass("control-group");
            string partialFieldName = propertyName;
            string fullHtmlFieldName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(partialFieldName);
            if (!html.ViewData.ModelState.IsValidField(fullHtmlFieldName))
            {
                controlGroupWrapper.AddCssClass("error");
            }
            string openingTag = controlGroupWrapper.ToString(TagRenderMode.StartTag);
            return MvcHtmlString.Create(openingTag);
        }

        public static IHtmlString EndControlGroup(this HtmlHelper html)
        {
            return MvcHtmlString.Create("</div>");
        }

        public static string PropName<T, TP>(this HtmlHelper html, Expression<Func<T, TP>> action) where T : class
        {
            var expression = (MemberExpression) action.Body;
            return expression.Member.Name;
        }

        public static object GetPropValue(this object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }

    public static class Alerts
    {
        public const string SUCCESS = "success";
        public const string ATTENTION = "attention";
        public const string ERROR = "error";
        public const string INFORMATION = "info";

        public static string[] ALL
        {
            get
            {
                return new[]
                    {
                        SUCCESS,
                        ATTENTION,
                        INFORMATION,
                        ERROR
                    };
            }
        }
    }
}