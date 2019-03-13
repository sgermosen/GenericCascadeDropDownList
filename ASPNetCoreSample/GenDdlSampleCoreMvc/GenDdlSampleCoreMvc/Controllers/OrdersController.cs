using GenDdlSampleCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenDdlSampleCoreMvc.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppContext _context;

        public OrdersController(AppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.ToListAsync());
        }

        public IActionResult Create()
        {
            var countries = _context.Countries.OrderBy(p => p.Name).ToList();
            ViewBag.Countries = countries;

            var cities= new List<City>
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
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
    }
}
