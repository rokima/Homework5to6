using Abc.Aids;
using Abc.Pages.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Pages.Extensions
{

    [TestClass]
    public class LinkTests : BaseTests
    {


        [TestInitialize] public virtual void TestInitialize() => type = typeof(Link);

        [TestMethod]
        public void DisplayNameTest()
        {
            var n = GetRandom.String();
            var o = new Link(n, null);
            Assert.AreEqual(n, o.DisplayName);
            Assert.IsNull(o.Url);
            Assert.AreEqual(n, o.PropertyName);
        }

        [TestMethod]
        public void UrlTest()
        {
            var n = GetRandom.String();
            var o = new Link(null, n);
            Assert.AreEqual(n, o.Url);
            Assert.IsNull(o.DisplayName);
            Assert.IsNull(o.PropertyName);
        }

        [TestMethod]
        public void PropertyNameTest()
        {
            var n = GetRandom.String();
            var o = new Link(null, null, n);
            Assert.AreEqual(n, o.PropertyName);
            Assert.IsNull(o.Url);
            Assert.IsNull(o.DisplayName);
        }

    }

}