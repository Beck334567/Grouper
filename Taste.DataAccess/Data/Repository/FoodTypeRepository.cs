using Grouper.DataAccess.Data.Repository.IRepository;
using Grouper.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Grouper.DataAccess.Data.Repository
{
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public FoodTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetFoodTypeListForDropDown()
        {
            return _db.FoodType.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(FoodType foodType)
        {
            var objFromDb = _db.FoodType.FirstOrDefault(s => s.Id == foodType.Id);
            objFromDb.Name = foodType.Name;
            _db.SaveChanges();
        }
    }
}