using System.Threading.Tasks;
using Abc.Domain.Quantity;
using Abc.Pages.Quantity;

namespace Abc.Soft.Areas.Quantity.Pages.Measures
{
    public class IndexModel : MeasuresPage
    {
        public IndexModel(IMeasuresRepository r, IMeasureTermsRepository t) : base(r, t)
        {
        }

            public async Task OnGetAsync(string sortOrder, string id, string currentFilter,
            string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            SelectedId = id;
            await getList(sortOrder, currentFilter, searchString, pageIndex, fixedFilter, fixedValue);
        }
    }
}