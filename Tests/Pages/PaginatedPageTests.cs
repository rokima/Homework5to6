using Abc.Aids;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Facade.Quantity;
using Abc.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Pages {

    [TestClass] public class PaginatedPageTests : AbstractPageTests<
        PaginatedPage<IMeasuresRepository, Measure, MeasureView, MeasureData>,
        CrudPage<IMeasuresRepository, Measure, MeasureView, MeasureData>> {

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = new testClass(db);
        }

        [TestMethod] public void ItemsTest() {
            isReadOnlyProperty(obj, nameof(obj.Items), null);
        }

        [TestMethod] public void PageIndexTest() {
            var i = GetRandom.UInt8(3);
            obj.PageIndex = i;
            Assert.AreEqual(i, db.PageIndex);
            Assert.AreEqual(i, obj.PageIndex);
        }

        [TestMethod] public void HasPreviousPageTest() {
            db.HasPreviousPage = GetRandom.Bool();
            isReadOnlyProperty(obj, nameof(obj.HasPreviousPage), db.HasPreviousPage);
        }

        [TestMethod] public void HasNextPageTest() {
            db.HasNextPage = GetRandom.Bool();
            isReadOnlyProperty(obj, nameof(obj.HasNextPage), db.HasNextPage);
        }

        [TestMethod] public void TotalPagesTest() {
            db.TotalPages = GetRandom.UInt8();
            isReadOnlyProperty(obj, nameof(obj.TotalPages), db.TotalPages);
        }

        [TestMethod] public void GetListTest() {
            Assert.IsNull(obj.Items);
            var sortOrder = GetRandom.String();
            var currentFilter = GetRandom.String();
            var searchString = GetRandom.String();
            var fixedFilter = GetRandom.String();
            var fixedValue = GetRandom.String();
            var pageIndex = GetRandom.UInt8();
            obj.getList(sortOrder, currentFilter, searchString, pageIndex, fixedFilter, fixedValue).GetAwaiter();
            Assert.IsNotNull(obj.Items);
            Assert.AreEqual(sortOrder, obj.SortOrder);
            Assert.AreEqual(searchString, obj.SearchString);
            Assert.AreEqual(fixedFilter, obj.FixedFilter);
            Assert.AreEqual(fixedValue, obj.FixedValue);
            Assert.AreEqual(1, obj.PageIndex);
        }

        [TestMethod] public void GetListNoArgumentsTest() {
            var l = obj.getList().GetAwaiter().GetResult();
            Assert.AreEqual(0, l.Count);

            for (var i = 0; i < GetRandom.UInt8(); i++) {
                var d = GetRandom.Object<MeasureData>();
                db.Add(new Measure(d)).GetAwaiter();
                l = obj.getList().GetAwaiter().GetResult();
                Assert.AreEqual(i + 1, l.Count);
            }
        }

    }

}
