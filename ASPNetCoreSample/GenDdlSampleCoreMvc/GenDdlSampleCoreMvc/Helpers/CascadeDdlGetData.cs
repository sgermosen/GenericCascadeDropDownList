using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GenDdlSampleCoreMvc.Helpers
{
    public class CascadeDdlGetData
    {
        private readonly AppContext _context;
        public CascadeDdlGetData(AppContext context)
        {
            _context = context;

        }
        //public JsonResult GetCitiesFromCountry(int id)
        //{
        //    var dbList = _context.Cities.Where(m => m.Country.Id == id)
        //        .Select(c => new
        //        {
        //            Id = c.Id,
        //            Name = c.Name
        //        });

        //    return JsonResult(dbList);
        //}

        //public JsonResult GetProductsFromCategory(int id)
        //{
        //    var dbList = _context.Products.Where(m => m.Category.Id == id)
        //        .Select(c => new
        //        {
        //            Id = c.Id,
        //            Name = c.Name
        //        });

        //    return Json(dbList);
        //}
    }
}
