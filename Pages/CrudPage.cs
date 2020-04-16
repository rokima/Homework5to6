using System.Threading.Tasks;
using Abc.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace Abc.Pages {

    public abstract class CrudPage<TRepository, TDomain, TView, TData> :
        BasePage<TRepository, TDomain, TView, TData>
        where TRepository : ICrudMethods<TDomain>, ISorting, IFiltering, IPaging {

        protected CrudPage(TRepository r) : base(r) { }

        [BindProperty]
        public TView Item { get; set; }

        protected internal async Task<bool> addObject(string fixedFilter, string fixedValue) {
            setFixedFilter(fixedFilter, fixedValue);

            try {
                if (!ModelState.IsValid) return false;
                await db.Add(toObject(Item));
            }
            catch { return false; }

            return true;
        }

        protected internal async Task<bool> updateObject(string fixedFilter, string fixedValue) {
            setFixedFilter(fixedFilter, fixedValue);

            try {
                if (!ModelState.IsValid) return false;
                await db.Update(toObject(Item));
            }
            catch { return false; }

            return true;
        }

        protected internal async Task<bool> updateObject(string id, string fixedFilter, string fixedValue)
        {
            setFixedFilter(fixedFilter, fixedValue);

            try
            {
                if (!ModelState.IsValid) return false;
                await db.Delete(id);
                await db.Add(toObject(Item));
            }
            catch { return false; }

            return true;
        }

        protected internal async Task getObject(string id, string fixedFilter, string fixedValue)
        {
            setFixedFilter(fixedFilter, fixedValue);
            var o = await db.Get(id);
            Item = toView(o);
        }

        protected internal async Task getObject(string id, string sortOrder, string searchString, int pageIndex, string fixedFilter, string fixedValue) {
            setPageValues(sortOrder, searchString, pageIndex);
            setFixedFilter(fixedFilter, fixedValue);
            var o = await db.Get(id);
            Item = toView(o);
        }

        protected internal async Task deleteObject(string id, string fixedFilter, string fixedValue) {
            setFixedFilter(fixedFilter, fixedValue);
            await db.Delete(id);
        }

        protected internal abstract TDomain toObject(TView view);

        protected internal abstract TView toView(TDomain obj);
    }
}