using Microsoft.AspNetCore.Mvc;

namespace OnlineMall.Controllers
{
	public class BasketController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
