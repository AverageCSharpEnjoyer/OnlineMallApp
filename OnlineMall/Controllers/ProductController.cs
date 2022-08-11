using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineMall.Areas.Identity.Data;
using OnlineMall.Models;

namespace OnlineMall.Controllers
{
	public class ProductController : Controller
	{
		private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
		{
			return _context.Products != null ?
				View(await _context.Products.ToListAsync()) :
				Problem("Entity set 'Products' is null.");
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,ShortName,FullName,Price,Size,Color,Description,ImgPath")] Product product)
		{
			product.ImgPath = "/img/marynarka1.webp";
			if (ModelState.IsValid)
			{
				_context.Add(product);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(product);
		}

	}
}
