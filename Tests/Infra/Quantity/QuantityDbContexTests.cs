using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Abc.Aids;
using Abc.Data.Quantity;
using Abc.Infra.Quantity;
using Abc.Tests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Homework4.Tests.Infra.Quantity
{
    [TestClass]
    public class QuantityDbContextTests : BaseClassTests<QuantityDbContext, DbContext>
    {

        private DbContextOptions<QuantityDbContext> options;

        private class testClass : QuantityDbContext
        {

            public testClass(DbContextOptions<QuantityDbContext> o) : base(o) { }

            public ModelBuilder RunOnModelCreating()
            {
                var set = new ConventionSet();
                var mb = new ModelBuilder(set);
                OnModelCreating(mb);

                return mb;
            }

        }


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            options = new DbContextOptionsBuilder<QuantityDbContext>().UseInMemoryDatabase("TestDb").Options;
            obj = new QuantityDbContext(options);
        }

        [TestMethod]
        public void InitializeDbTablesTest()
        {
            static void TestKey<T>(IMutableEntityType entity, params Expression<Func<T, object>>[] values)
            {
                var key = entity.FindPrimaryKey();

                if (values is null) Assert.IsNull(key);
                else
                    foreach (var v in values)
                    {
                        var name = GetMember.Name(v);
                        Assert.IsNotNull(key.Properties.FirstOrDefault(x => x.Name == name));
                    }
            }

            static void TestEntity<T>(ModelBuilder b, params Expression<Func<T, object>>[] values)
            {
                var name = typeof(T).FullName ?? string.Empty;
                var entity = b.Model.FindEntityType(name);
                Assert.IsNotNull(entity, name);
                TestKey(entity, values);
            }

            QuantityDbContext.InitializeTables(null);
            var o = new testClass(options);
            var builder = o.RunOnModelCreating();
            QuantityDbContext.InitializeTables(builder);
            TestEntity<SystemOfUnitsData>(builder);
            TestEntity<MeasureTermData>(builder, x => x.TermId, x => x.MasterId);
            TestEntity<MeasureData>(builder);
            TestEntity<UnitData>(builder);
            TestEntity<UnitTermData>(builder, x => x.TermId, x => x.MasterId);
            TestEntity<UnitFactorData>(builder, x => x.UnitId, x => x.SystemOfUnitsId);
        }

        [TestMethod]
        public void MeasuresTest() =>
            isNullableProperty(obj, nameof(obj.Measures), typeof(DbSet<MeasureData>));

        [TestMethod] public void UnitsTest() => isNullableProperty(obj, nameof(obj.Units), typeof(DbSet<UnitData>));

        [TestMethod]
        public void SystemsOfUnitsTest() =>
            isNullableProperty(obj, nameof(obj.SystemsOfUnits), typeof(DbSet<SystemOfUnitsData>));

        [TestMethod]
        public void UnitFactorsTest() =>
            isNullableProperty(obj, nameof(obj.UnitFactors), typeof(DbSet<UnitFactorData>));

        [TestMethod]
        public void UnitTermsTest() =>
            isNullableProperty(obj, nameof(obj.UnitTerms), typeof(DbSet<UnitTermData>));

        [TestMethod]
        public void MeasureTermsTest() =>
            isNullableProperty(obj, nameof(obj.MeasureTerms), typeof(DbSet<MeasureTermData>));

    }
}
