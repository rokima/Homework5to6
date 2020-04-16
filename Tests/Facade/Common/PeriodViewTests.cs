using Abc.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Facade.Common
{
    [TestClass]
    public class PeriodViewTests : AbstractClassTests<PeriodView, object>
    {
        private class testClass : PeriodView { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }

        [TestMethod]
        public void ValidFromTest()
        {
            isNullableProperty(() => obj.ValidFrom, x => obj.ValidFrom = x);
        }

        [TestMethod]
        public void ValidToTest()
        {
            isNullableProperty(() => obj.ValidTo, x => obj.ValidTo = x);
        }
    }
}