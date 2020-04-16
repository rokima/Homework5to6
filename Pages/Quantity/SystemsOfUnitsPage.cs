using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Facade.Quantity;

namespace Abc.Pages.Quantity
{
    public  class SystemsOfUnitsPage : CommonPage<ISystemsOfUnitsRepository, SystemOfUnits, SystemOfUnitsView, SystemOfUnitsData>
    {

        protected internal SystemsOfUnitsPage(ISystemsOfUnitsRepository r) : base(r) {
            PageTitle = "Systems Of Units";
        }

        public override string ItemId => Item?.Id ?? string.Empty;

        protected internal override string getPageUrl() => "/Quantity/SystemsOfUnits";

        protected internal override SystemOfUnits toObject(SystemOfUnitsView view) => SystemOfUnitsViewFactory.Create(view);

        protected internal override SystemOfUnitsView toView(SystemOfUnits obj) => SystemOfUnitsViewFactory.Create(obj);
    }
}