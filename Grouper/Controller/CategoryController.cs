using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grouper.DataAccess.Data.Repository.IRepository;

namespace Grouper.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new {data = _unitOfWork.Category.GetAll()});
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDB = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if (objFromDB==null)
            {
                return Json(new {success = false, message = "delete fail "});
            }
            _unitOfWork.Category.Remove(objFromDB);
            _unitOfWork.Save();
            return Json(new {success = true, message = "delete success"});
        }
    }
}
