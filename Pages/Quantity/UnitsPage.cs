using System;
using System.Collections.Generic;
using Abc.Aids;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Facade.Common;
using Abc.Facade.Quantity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Abc.Pages.Quantity
{

    public abstract class UnitsPage : CommonPage<IUnitsRepository, Unit, UnitView, UnitData>
    {

        protected internal readonly IUnitTermsRepository terms;
        protected internal readonly IUnitFactorsRepository factors;

        protected internal UnitsPage(IUnitsRepository r, IMeasuresRepository m,
            IUnitTermsRepository t, IUnitFactorsRepository f) : base(r) {
            PageTitle = "Units";
            Measures = createSelectList<Measure, MeasureData>(m);
            Terms=new List<UnitTermView>();
            Factors=new List<UnitFactorView>();
            terms = t;
            factors = f;

        }

        private static IEnumerable<SelectListItem> createMeasures(IMeasuresRepository r) {
            var list = new List<SelectListItem>();
            var measures = r.Get().GetAwaiter().GetResult();

            foreach (var m in measures) {
                list.Add(new SelectListItem(m.Data.Name, m.Data.Id));
            }
            return list;
        }

        public IEnumerable<SelectListItem> Measures { get; }
        public IList<UnitTermView> Terms { get; }
        public IList<UnitFactorView> Factors { get; }

        public override string ItemId => Item?.Id ?? string.Empty;

        protected internal override string getPageUrl() => "/Quantity/Units";

        protected internal override string getPageSubTitle() {
            return FixedValue is null
                ? base.getPageSubTitle()
                : $"For {GetMeasureName(FixedValue)}";
        }

        protected internal override Unit toObject(UnitView view)=> UnitViewFactory.Create(view);

        protected internal override UnitView toView(Unit obj)=> UnitViewFactory.Create(obj);
        
        public string GetMeasureName(string measureId) {
            foreach (var m in Measures)
                if (m.Value == measureId)
                    return m.Text;
            return "Unspecified";
        }

        public void LoadDetails(UnitView item)
        {
            loadTerms(item);
            loadFactors(item);
        }

        private void loadFactors(UniqueEntityView item)
        {
            Factors.Clear();
            if (item is null) return;
            factors.FixedFilter = GetMember.Name<UnitFactorData>(x => x.UnitId);
            factors.FixedValue = item.Id;
            var list = factors.Get().GetAwaiter().GetResult();
            foreach (var e in list)
            {
                Factors.Add(UnitFactorViewFactory.Create(e));
            }
        }

        private void loadTerms(UniqueEntityView item)
        {
            Terms.Clear();
            if (item is null) return;
            terms.FixedFilter = GetMember.Name<UnitTermData>(x => x.MasterId);
            terms.FixedValue = item.Id;
            var list = terms.Get().GetAwaiter().GetResult();
            foreach (var e in list)
            {
                Terms.Add(UnitTermViewFactory.Create(e));
            }
        }
    }
}