using GenDdlSampleCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using GenDdlSampleCoreMvc.Helpers;

namespace GenDdlSampleCoreMvc.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppContext _context;
        private readonly GenericSelectList _genericSelectList;

        
        public ProductsController(AppContext context)
        {
            _context = context;
            _genericSelectList = new GenericSelectList();
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _context.Categories.ToListAsync();

            var model = new ProductViewModel
            {
                Categories = _genericSelectList.CreateSelectList(categories, x => x.Id, x => x.Name)
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = await _context.Categories.FindAsync(model.CategoryId);

                var product = new Product {
                    Name = model.Name,
                    Stock = model.Stock,
                    Price = model.Price,
                    Category = category };

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
