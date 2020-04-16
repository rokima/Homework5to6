using System.Collections.Generic;
using Abc.Facade.Quantity;
using Abc.Pages.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Pages.Extensions
{
    [TestClass]
    public class DisabledControlsForHtmlExtensionTests:BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize() => type = typeof(DisabledControlsForHtmlExtension);

        [TestMethod]
        public void DisabledControlsForTest()
        {
            var obj = new htmlHelperMock<UnitView>().DisabledControlsFor(x => x.MeasureId);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }
        [TestMethod]
        public void HtmlStringTest()
        {
            var expected = new List<string> { "<div", "<fieldset disabled>", 
                "LabelFor", "EditorFor", "ValidationMessageFor", "</fieldset>", "</div>" };
            var actual = DisabledControlsForHtmlExtension.HtmlString(new htmlHelperMock<MeasureView>(), x => x.ValidFrom);
            TestHtml.Strings(actual, expected);
        }
    }
}