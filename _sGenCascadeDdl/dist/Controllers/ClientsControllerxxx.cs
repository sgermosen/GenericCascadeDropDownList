using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenDdlSampleCoreMvc.wwwroot.lib.sGenCascadeDdl.dist
{
    public class OrderController
    {
        private readonly AppContext _context;

        public OrderController(AppContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            var countries = _context.Countries.OrderBy(p => p.Name).ToList();
            ViewBag.Countries = countries;

            var cities = new List<City>
            {
                new City { Id = 0, Name = "-- Choose a city --" }
            };

            ViewBag.Cities = cities;

            var categories = _context.Categories.OrderBy(p => p.Name).ToList();
            ViewBag.Categories = categories;

            var product = new List<Product>
            {
                new Product { Id = 0, Name = "-- Choose a product --" }
            };

            ViewBag.Products = product;

            return View();
        }

    }
}
