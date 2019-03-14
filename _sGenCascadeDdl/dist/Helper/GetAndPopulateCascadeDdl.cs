using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sGenCascadeDdl.dist
{
    public class GetAndPopulateCascadeDdl
    {
        public JsonResult GetCitiesFromCountry(int id)
        {
            var dbList = _context.Cities.Where(m => m.Country.Id == id)
               .Select(c => new
               {
                   Id = c.Id,
                   Name = c.Name
               });

            return Json(dbList);
        }

        public JsonResult GetProductsFromCategory(int id)
        {
            var dbList = _context.Products.Where(m => m.Category.Id == id)
               .Select(c => new
               {
                   Id = c.Id,
                   Name = c.Name
               });

            return Json(dbList);
        }

    }
}
