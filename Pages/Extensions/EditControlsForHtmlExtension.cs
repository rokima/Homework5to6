﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Abc.Pages.Extensions
{
    public static class EditControlsForHtmlExtension
    {
        public static IHtmlContent EditControlsFor<TClassType, TPropertyType>(
            this IHtmlHelper<TClassType> htmlHelper, Expression<Func<TClassType, TPropertyType>> expression) {
            var s = HtmlString(htmlHelper,expression);
            return new HtmlContentBuilder(s);
        }

        internal static List<object> HtmlString<TClassType, TPropertyType>(IHtmlHelper<TClassType> htmlHelper, Expression<Func<TClassType, TPropertyType>> expression)
        {
           return new List<object> {
               new HtmlString("<div class=\"form-group\">"),
               htmlHelper.LabelFor(expression, new {@class = "text-dark"}),
               htmlHelper.EditorFor(expression, 
                   new {HtmlAttributes = new {@class = "form-control"}}),
               htmlHelper.ValidationMessageFor(expression, "", new {@class = "text-danger"}),
                   new HtmlString("</div>")
           };
        }
    }
}
