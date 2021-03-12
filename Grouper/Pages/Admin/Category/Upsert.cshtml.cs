using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grouper.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Grouper.Pages.Admin.Category
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Models.Category CategoryObj { get; set; }
        public IActionResult OnGet(int? id)
        {
            CategoryObj = new Models.Category();
            if (id!=null)
            {
                CategoryObj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
                if (CategoryObj==null)
                {
                    return NotFound();
                }
            }

            return Page();
        }
    }
}
