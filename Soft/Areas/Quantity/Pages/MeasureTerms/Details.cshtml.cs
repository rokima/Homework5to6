using System.Threading.Tasks;
using Abc.Domain.Quantity;
using Abc.Pages.Quantity;
using Microsoft.AspNetCore.Mvc;

namespace Abc.Soft.Areas.Quantity.Pages.MeasureTerms
{
    public class DetailsModel : MeasureTermsPage
    {
        public DetailsModel(IMeasureTermsRepository r, IMeasuresRepository m) : base(r, m) { }

        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue) {
            
            await getObject(id, fixedFilter, fixedValue);
            return Page();
        }
    }
}
