using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineMall.Areas.Identity.Data;

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
	}
}
