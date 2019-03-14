using System.Collections.Generic;
using System.Linq;
using GenDdlSampleCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using GenDdlSampleCoreMvc.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GenDdlSampleCoreMvc.Controllers
{
    public class CitiesController : Controller
    {
        private readonly AppContext _context;
        private readonly GenericSelectList _genericSelectList;

        public CitiesController(AppContext context)
        {
            _context = context;
            _genericSelectList = new GenericSelectList();
        }


        public IEnumerable<SelectListItem> GetComboContries()
        {
            var list = _context.Products.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a country...)",
                Value = "0"
            });

            return list;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Cities.ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            var countries = new List<Country>
            {
                new Country
                {
                    Id = 0,
                    Name = "Choose one Country"
                }
            };
            // var countriesList = await _context.Countries.ToListAsync();

            countries.AddRange(await _context.Countries.ToListAsync());

            var model = new CityViewModel
            {
                Countries = _genericSelectList.CreateSelectList(countries, x => x.Id, x => x.Name)
            };

            //  ViewBag.Countries = _genericSelectList.CreateSelectList(countries, x => x.Id, x => x.Name);
            // city.Country = 

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CityViewModel model)
        {
            if (ModelState.IsValid)
            {
                var country = await _context.Countries.FindAsync(model.CountryId);

                var city = new City { Name = model.Name, Denomym = model.Denomym, Country = country };

                _context.Add(city);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


    }
}
