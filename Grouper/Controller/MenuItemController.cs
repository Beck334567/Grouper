using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Grouper.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;

namespace Grouper.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MenuItemController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new {data = _unitOfWork.MenuItem.GetAll(null,null,"Category,FoodType")});
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var objFromDB = _unitOfWork.MenuItem.GetFirstOrDefault(u => u.Id == id);
                if (objFromDB == null)
                {
                    return Json(new { success = false, message = "delete fail " });
                }

                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, objFromDB.Image.TrimStart('\\'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                _unitOfWork.MenuItem.Remove(objFromDB);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "delete fail " });
            }
           
            return Json(new {success = true, message = "delete success"});
        }
    }
}
