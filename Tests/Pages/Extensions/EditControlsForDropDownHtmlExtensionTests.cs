using System;
using System.Collections.Generic;
using Abc.Core;
using Abc.Facade.Quantity;
using Abc.Pages.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Pages.Extensions
{

    [TestClass]
    public class EditControlsForDropDownHtmlExtensionTests : BaseTests
    {

        private readonly List<SelectListItem> items = new List<SelectListItem> { new SelectListItem("text", "value") };

        [TestInitialize] public virtual void TestInitialize() => type = typeof(EditControlsForDropDownHtmlExtension);

        [TestMethod]
        public void EditControlsForDropDownTest()
        {
            var obj = new htmlHelperMock<UnitView>().EditControlsForDropDown(x => x.MeasureId, items);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod]
        public void HtmlStringsTest()
        {
            var expected = new List<string> { "<div", "LabelFor", "DropDownListFor", "ValidationMessageFor", "</div>" };
            var actual = EditControlsForDropDownHtmlExtension.htmlStrings(new htmlHelperMock<UnitView>(),
                x => x.MeasureId, items);
            TestHtml.Strings(actual, expected);
        }


    }

}