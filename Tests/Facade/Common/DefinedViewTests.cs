using Abc.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Facade.Common
{
    [TestClass]
    public class DefinedViewTests : AbstractClassTests<DefinedView, NamedView>
    {
        private class testClass : DefinedView { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }

        [TestMethod]
        public void DefinitionTest()
        {
            isNullableProperty(() => obj.Definition, x => obj.Definition = x);
        }
    }
}