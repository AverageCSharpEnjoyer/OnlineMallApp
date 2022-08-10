using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineMall.Areas.Identity.Data;

namespace OnlineMall.Controllers
{
	public class ShoppingItemController : Controller
	{
		private readonly ApplicationDbContext _context;

        public ShoppingItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
		{
			return _context.ShoppingItems != null ?
				View(await _context.ShoppingItems.ToListAsync()) :
				Problem("Entity set 'ShoppingItems' is null.");
		}
	}
}
