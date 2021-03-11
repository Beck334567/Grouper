using Grouper.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Grouper.DataAccess.Data.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<SelectListItem> GetCategoryListForDropDown();

        void Update(Category category);
    }
}