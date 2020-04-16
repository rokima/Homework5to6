using System.Collections.Generic;
using Abc.Facade.Quantity;
using Abc.Pages.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Pages.Extensions
{
    [TestClass]
    public class EditControlsForHtmlExtensionTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize() => type = typeof(EditControlsForHtmlExtension);

        [TestMethod] public void EditControlsForTest() {
            var obj = new htmlHelperMock<UnitView>().EditControlsFor(x => x.MeasureId);
            Assert.IsInstanceOfType(obj,typeof(HtmlContentBuilder));
        }
        [TestMethod] public void HtmlStringTest() {
            var expected= new List<string>{ "<div", "LabelFor", "EditorFor", "ValidationMessageFor", "</div>"};
            var actual = EditControlsForHtmlExtension.HtmlString(new htmlHelperMock<MeasureView>(), x=>x.ValidFrom );
            TestHtml.Strings(actual, expected);
        }
    }
}