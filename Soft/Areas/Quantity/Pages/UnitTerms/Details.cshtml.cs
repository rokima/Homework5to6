using System.Threading.Tasks;
using Abc.Domain.Quantity;
using Abc.Pages.Quantity;
using Microsoft.AspNetCore.Mvc;

namespace Abc.Soft.Areas.Quantity.Pages.UnitTerms
{
    public class DetailsModel : UnitTermsPage
    {
        public DetailsModel(IUnitTermsRepository r, IUnitsRepository u) : base(r, u) { }

        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue) {
            
            await getObject(id, fixedFilter, fixedValue);
            return Page();
        }
    }
}
