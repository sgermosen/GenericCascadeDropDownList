using GenDdlSampleCoreMvc.Helpers;
using GenDdlSampleCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sGenCascadeDdl.dist
{
    public class ClientsController : Controller
    {
        private readonly AppContext _context;
        private readonly GenericSelectList _genericSelectList;
        
        public ClientsController(AppContext context)
        {
            _context = context;
            _genericSelectList = new GenericSelectList();
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
         
            countries.AddRange(await _context.Countries.ToListAsync());

            var cities = new List<City>();

            var model = new ClientViewModel
            {
                Countries = _genericSelectList.CreateSelectList(countries, x => x.Id, x => x.Name),
                Cities = _genericSelectList.CreateSelectList(cities, x => x.Id, x => x.Name)
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var city = await _context.Cities.FindAsync(model.CityId);

                var client = new Client
                {
                    Name = model.Name,
                    Lastname = model.Lastname,
                    City = city
                };

                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}