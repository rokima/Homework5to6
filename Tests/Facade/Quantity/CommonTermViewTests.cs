﻿using Abc.Facade.Common;
using Abc.Facade.Quantity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Facade.Quantity
{
    [TestClass]
    public class CommonTermViewTests:AbstractClassTests<CommonTermView, PeriodView>
    {
        private class testClass : CommonTermView { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }
        [TestMethod]
        public void TermIdTest() => isNullableProperty(() => obj.TermId, x => obj.TermId = x);
        [TestMethod]
        public void PowerTest() => isProperty(() => obj.Power, x => obj.Power = x);
    }
}
