using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Abc.Pages.Extensions
{

    public static class HypertextLinkForHtmlExtension
    {

        public static IHtmlContent HypertextLinkFor(
            this IHtmlHelper htmlHelper, string text, params Link[] items)
        {
            var s = htmlStrings(text, items);

            return new HtmlContentBuilder(s);
        }

        internal static List<object> htmlStrings(string text, Link[] items)
        {
            var l = new List<object> {
                new HtmlString("<p>"),
                new HtmlString($"<a>{text}</a>")
            };

            l.AddRange(
                items.Select(item => new HtmlString($"<a> </a><a href=\"{item.Url}\">{item.DisplayName}</a>")));

            l.Add(new HtmlString("</p>"));

            return l;
        }

    }

}