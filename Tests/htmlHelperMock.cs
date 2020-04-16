﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Abc.Aids;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Abc.Tests
{

    internal class htmlHelperMock<TModel> : IHtmlHelper<TModel>
    {

        public IHtmlContent ActionLink(string linkText, string actionName, string controllerName, string protocol,
            string hostname,
            string fragment, object routeValues, object htmlAttributes) => new htmlContentMock("ActionLink");

        public IHtmlContent AntiForgeryToken() => new htmlContentMock("AntiForgeryToken");

        public MvcForm BeginForm(string actionName, string controllerName, object routeValues, FormMethod method,
            bool? antiforgery,
            object htmlAttributes) => null;

        public MvcForm BeginRouteForm(string routeName, object routeValues, FormMethod method, bool? antiforgery,
            object htmlAttributes) => null;

        public IHtmlContent CheckBox(string expression, bool? isChecked, object htmlAttributes)
            => new htmlContentMock("CheckBox");

        public IHtmlContent Display(string expression, string templateName, string htmlFieldName,
            object additionalViewData)
            => new htmlContentMock("Display");

        public string DisplayName(string expression) => "DisplayName";

        public string DisplayText(string expression) => "DisplayText";

        public IHtmlContent DropDownList(
            string expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes)
            => new htmlContentMock("DropDownList");

        public IHtmlContent Editor(string expression, string templateName, string htmlFieldName,
            object additionalViewData)
            => new htmlContentMock("Editor");

        string IHtmlHelper<TModel>.Encode(object value) => null;

        string IHtmlHelper<TModel>.Encode(string value) => null;

        public IHtmlContent HiddenFor<TResult>(Expression<Func<TModel, TResult>> expression, object htmlAttributes)
            => new htmlContentMock("HiddenFor");

        public string IdFor<TResult>(Expression<Func<TModel, TResult>> expression) => "IdFor";

        public IHtmlContent LabelFor<TResult>(Expression<Func<TModel, TResult>> e,
            string labelText, object htmlAttributes)
            => new htmlContentMock($"LabelFor{GetMember.Name(e)}");

        public IHtmlContent ListBoxFor<TResult>(
            Expression<Func<TModel, TResult>> e, IEnumerable<SelectListItem> selectList, object htmlAttributes)
            => new htmlContentMock("ListBoxFor");

        public string NameFor<TResult>(Expression<Func<TModel, TResult>> expression)
            => "NameFor";

        public IHtmlContent PasswordFor<TResult>(Expression<Func<TModel, TResult>> e, object htmlAttributes)
            => new htmlContentMock("PasswordFor");

        public IHtmlContent RadioButtonFor<TResult>(
            Expression<Func<TModel, TResult>> e, object value, object htmlAttributes)
            => new htmlContentMock("RadioButtonFor");

        IHtmlContent IHtmlHelper<TModel>.Raw(object value) => null;

        IHtmlContent IHtmlHelper<TModel>.Raw(string value) => null;

        public IHtmlContent TextAreaFor<TResult>(Expression<Func<TModel, TResult>> e, int rows, int columns,
            object htmlAttributes)
            => new htmlContentMock("TextAreaFor");

        public IHtmlContent TextBoxFor<TResult>(
            Expression<Func<TModel, TResult>> e, string format, object htmlAttributes)
            => new htmlContentMock("TextBoxFor");

        public IHtmlContent ValidationMessageFor<TResult>(
            Expression<Func<TModel, TResult>> e, string message, object htmlAttributes, string tag)
            => new htmlContentMock("ValidationMessageFor");

        public string ValueFor<TResult>(Expression<Func<TModel, TResult>> e, string format)
            => "ValueFor";

        public ViewDataDictionary<TModel> ViewData { get; } = new ViewDataDictionary<TModel>(new EmptyModelMetadataProvider(), new ModelStateDictionary());

        public IHtmlContent CheckBoxFor(Expression<Func<TModel, bool>> expression, object htmlAttributes)
            => new htmlContentMock("CheckBoxFor");

        public IHtmlContent DisplayFor<TResult>(Expression<Func<TModel, TResult>> expression, string templateName,
            string htmlFieldName,
            object additionalViewData)
            => new htmlContentMock("DisplayFor");

        public string DisplayNameForInnerType<TModelItem, TResult>(Expression<Func<TModelItem, TResult>> expression)
            => "DisplayNameForInnerType";

        public string DisplayNameFor<TResult>(Expression<Func<TModel, TResult>> expression)
            => "DisplayNameFor";

        public string DisplayTextFor<TResult>(Expression<Func<TModel, TResult>> expression)
            => "DisplayTextFor";

        public IHtmlContent DropDownListFor<TResult>(Expression<Func<TModel, TResult>> expression,
            IEnumerable<SelectListItem> selectList, string optionLabel,
            object htmlAttributes)
            => new htmlContentMock("DropDownListFor");

        public IHtmlContent EditorFor<TResult>(Expression<Func<TModel, TResult>> expression, string templateName,
            string htmlFieldName,
            object additionalViewData) => new htmlContentMock("EditorFor");

        string IHtmlHelper.Encode(object value) => null;

        string IHtmlHelper.Encode(string value) => null;

        public void EndForm() { }

        public string FormatValue(object value, string format) => "FormatValue";

        public string GenerateIdFromName(string fullName) => "GenerateIdFromName";

        public IEnumerable<SelectListItem> GetEnumSelectList(Type enumType) => null;

        public IEnumerable<SelectListItem> GetEnumSelectList<TEnum>() where TEnum : struct => null;

        public IHtmlContent Hidden(string expression, object value, object htmlAttributes)
            => new htmlContentMock("Hidden");

        public string Id(string expression) => "Id";

        public IHtmlContent Label(string expression, string labelText, object htmlAttributes)
            => new htmlContentMock("Label");

        public IHtmlContent ListBox(string expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
            => new htmlContentMock("ListBox");

        public string Name(string expression) => "Name";

        public async Task<IHtmlContent>
            PartialAsync(string partialViewName, object model, ViewDataDictionary viewData)
        {
            await Task.CompletedTask;

            return new htmlContentMock("PartialAsync");
        }

        public IHtmlContent Password(string expression, object value, object htmlAttributes)
            => new htmlContentMock("Password");

        public IHtmlContent RadioButton(string expression, object value, bool? isChecked, object htmlAttributes)
            => new htmlContentMock("RadioButton");

        IHtmlContent IHtmlHelper.Raw(object value) => new htmlContentMock("RawValue");

        IHtmlContent IHtmlHelper.Raw(string value) => new htmlContentMock("RawString");

        public async Task RenderPartialAsync(string partialViewName, object model, ViewDataDictionary viewData)
        {
            await Task.CompletedTask;
        }

        public IHtmlContent RouteLink(string linkText, string routeName, string protocol, string hostName,
            string fragment,
            object routeValues, object htmlAttributes)
            => new htmlContentMock("RouteLink");

        public IHtmlContent TextArea(string expression, string value, int rows, int columns, object htmlAttributes)
            => new htmlContentMock("TextArea");

        public IHtmlContent TextBox(string expression, object value, string format, object htmlAttributes)
            => new htmlContentMock("TextBox");

        public IHtmlContent ValidationMessage(string expression, string message, object htmlAttributes, string tag)
            => new htmlContentMock("ValidationMessage");

        public IHtmlContent ValidationSummary(bool excludePropertyErrors, string message, object htmlAttributes,
            string tag)
            => new htmlContentMock("ValidationSummary");

        public string Value(string expression, string format)
            => "Value";

        public Html5DateRenderingMode Html5DateRenderingMode { get; set; }
        public string IdAttributeDotReplacement { get; } = null;
        public IModelMetadataProvider MetadataProvider { get; } = null;
        public ITempDataDictionary TempData { get; } = null;
        public UrlEncoder UrlEncoder { get; } = null;
        public dynamic ViewBag { get; } = null;
        public ViewContext ViewContext { get; } = null;
        ViewDataDictionary IHtmlHelper.ViewData => ViewData;

    }

}