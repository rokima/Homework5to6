using System.Threading.Tasks;
using Abc.Domain.Quantity;
using Abc.Pages.Quantity;

namespace Abc.Soft.Areas.Quantity.Pages.UnitTerms
{
    public class IndexModel : UnitTermsPage
    {

        public IndexModel(IUnitTermsRepository r, IUnitsRepository u) : base(r, u) { }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {

            await getList(sortOrder, currentFilter, searchString, pageIndex, fixedFilter, fixedValue);

        }
    }
}
