﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Abc.Aids;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Infra;
using Abc.Infra.Quantity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Infra
{
    [TestClass]
    public class SortedRepositoryTests : AbstractClassTests<SortedRepository<Measure, MeasureData>,
        BaseRepository<Measure, MeasureData>>
    {

        private class testClass : SortedRepository<Measure, MeasureData>
        {

            public testClass(DbContext c, DbSet<MeasureData> s) : base(c, s) { }

            protected internal override Measure toDomainObject(MeasureData d) => new Measure(d);

            protected override async Task<MeasureData> getData(string id)
            {
                await Task.CompletedTask;
                return new MeasureData();
            }

            protected override string getId(Measure entity) => entity?.Data?.Id;
        }

        [TestInitialize] public override void TestInitialize()
        {
            base.TestInitialize();
            var options = new DbContextOptionsBuilder<QuantityDbContext>().UseInMemoryDatabase("TestDb").Options;
            var c = new QuantityDbContext(options);
            obj = new testClass(c, c.Measures);
        }

        [TestMethod] public void SortOrderTest()
        {
            isNullableProperty(() => obj.SortOrder, x => obj.SortOrder = x);
        }

        [TestMethod] public void DescendingStringTest()
        {

            var propertyName = GetMember.Name<testClass>(x => x.DescendingString);
            isReadOnlyProperty(obj, propertyName, "_desc");
        }

        [TestMethod] public void SetSortingTest()
        {
            void test(IQueryable<MeasureData> d, string sortOrder)
            {
                obj.SortOrder = sortOrder + obj.DescendingString;
                var set = obj.addSorting(d);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set);
                var str = set.Expression.ToString();
                Assert.IsTrue(str
                    .Contains($"Abc.Data.Quantity.MeasureData]).OrderByDescending(x => Convert(x.{sortOrder}, Object))"));
                obj.SortOrder = sortOrder;
                set = obj.addSorting(d);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set);
                str = set.Expression.ToString();
                Assert.IsTrue(str.Contains($"Abc.Data.Quantity.MeasureData]).OrderBy(x => Convert(x.{sortOrder}, Object))"));
            }

            Assert.IsNull(obj.addSorting(null));
            IQueryable<MeasureData> data = obj.dbSet;
            obj.SortOrder = null;
            Assert.AreEqual(data, obj.addSorting(data));
            test(data, GetMember.Name<MeasureData>(x => x.Id));
            test(data, GetMember.Name<MeasureData>(x => x.Code));
            test(data, GetMember.Name<MeasureData>(x => x.Name));
            test(data, GetMember.Name<MeasureData>(x => x.Definition));
            test(data, GetMember.Name<MeasureData>(x => x.ValidFrom));
            test(data, GetMember.Name<MeasureData>(x => x.ValidTo));
        }

        [TestMethod] public void CreateExpressionTest()
        {
            string s;
            testCreateExpression(GetMember.Name<MeasureData>(x => x.ValidFrom));
            testCreateExpression(GetMember.Name<MeasureData>(x => x.ValidTo));
            testCreateExpression(GetMember.Name<MeasureData>(x => x.Id));
            testCreateExpression(GetMember.Name<MeasureData>(x => x.Name));
            testCreateExpression(GetMember.Name<MeasureData>(x => x.Code));
            testCreateExpression(GetMember.Name<MeasureData>(x => x.Definition));
            testCreateExpression(s = GetMember.Name<MeasureData>(x => x.ValidFrom), s + obj.DescendingString);
            testCreateExpression(s = GetMember.Name<MeasureData>(x => x.ValidTo), s + obj.DescendingString);
            testCreateExpression(s = GetMember.Name<MeasureData>(x => x.Id), s + obj.DescendingString);
            testCreateExpression(s = GetMember.Name<MeasureData>(x => x.Name), s + obj.DescendingString);
            testCreateExpression(s = GetMember.Name<MeasureData>(x => x.Code), s + obj.DescendingString);
            testCreateExpression(s = GetMember.Name<MeasureData>(x => x.Definition), s + obj.DescendingString);
            testNullExpression(GetRandom.String());
            testNullExpression(string.Empty);
            testNullExpression(null);
        }

        private void testNullExpression(string name)
        {
            obj.SortOrder = name;
            var lambda = obj.createExpression();
            Assert.IsNull(lambda);
        }

        private void testCreateExpression(string expected, string name = null)
        {
            name ??= expected;
            obj.SortOrder = name;
            var lambda = obj.createExpression();
            Assert.IsNotNull(lambda);
            Assert.IsInstanceOfType(lambda, typeof(Expression<Func<MeasureData, object>>));
            Assert.IsTrue(lambda.ToString().Contains(expected));
        }

        [TestMethod] public void LambdaExpressionTest()
        {
            var name = GetMember.Name<MeasureData>(x => x.ValidFrom);
            var property = typeof(MeasureData).GetProperty(name);
            var lambda = obj.lambdaExpression(property);
            Assert.IsNotNull(lambda);
            Assert.IsInstanceOfType(lambda, typeof(Expression<Func<MeasureData, object>>));
            Assert.IsTrue(lambda.ToString().Contains(name));
        }

        [TestMethod] public void FindPropertyTest()
        {
            string s;

            void test(PropertyInfo expected, string sortOrder)
            {
                obj.SortOrder = sortOrder;
                Assert.AreEqual(expected, obj.findProperty());
            }

            test(null, GetRandom.String());
            test(null, null);
            test(null, string.Empty);
            test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Name)), s);
            test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.ValidFrom)), s);
            test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.ValidTo)), s);
            test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Definition)), s);
            test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Code)), s);
            test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Id)), s);
            test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Name)), s + obj.DescendingString);
            test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.ValidFrom)), s + obj.DescendingString);
            test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.ValidTo)), s + obj.DescendingString);
            test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Definition)), s + obj.DescendingString);
            test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Code)), s + obj.DescendingString);
            test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Id)), s + obj.DescendingString);
        }

        [TestMethod] public void GetNameTest()
        {
            string s;

            void test(string expected, string sortOrder)
            {
                obj.SortOrder = sortOrder;
                Assert.AreEqual(expected, obj.getName());
            }

            test(s = GetRandom.String(), s);
            test(s = GetRandom.String(), s + obj.DescendingString);
            test(string.Empty, string.Empty);
            test(string.Empty, null);
        }

        [TestMethod] public void SetOrderByTest()
        {
            void test(IQueryable<MeasureData> d, Expression<Func<MeasureData, object>> e, string expected)
            {
                obj.SortOrder = GetRandom.String() + obj.DescendingString;
                var set = obj.addOrderBy(d, e);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set);
                Assert.IsTrue(set.Expression.ToString()
                    .Contains($"Abc.Data.Quantity.MeasureData]).OrderByDescending({expected})"));
                obj.SortOrder = GetRandom.String();
                set = obj.addOrderBy(d, e);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set);
                Assert.IsTrue(set.Expression.ToString().Contains($"Abc.Data.Quantity.MeasureData]).OrderBy({expected})"));
            }

            Assert.IsNull(obj.addOrderBy(null, null));
            IQueryable<MeasureData> data = obj.dbSet;
            Assert.AreEqual(data, obj.addOrderBy(data, null));
            test(data, x => x.Id, "x => x.Id");
            test(data, x => x.Code, "x => x.Code");
            test(data, x => x.Name, "x => x.Name");
            test(data, x => x.Definition, "x => x.Definition");
            test(data, x => x.ValidFrom, "x => Convert(x.ValidFrom, Object)");
            test(data, x => x.ValidTo, "x => Convert(x.ValidTo, Object)");
        }

        [TestMethod] public void IsDescendingTest()
        {
            void test(string sortOrder, bool expected)
            {
                obj.SortOrder = sortOrder;
                Assert.AreEqual(expected, obj.isDescending());
            }

            test(GetRandom.String(), false);
            test(GetRandom.String() + obj.DescendingString, true);
            test(string.Empty, false);
            test(null, false);
        }
    }
}
