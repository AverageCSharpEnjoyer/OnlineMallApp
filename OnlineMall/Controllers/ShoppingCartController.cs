using Microsoft.AspNetCore.Mvc;
using OnlineMall.Models;

namespace OnlineMall.Controllers
{
	public class ShoppingCartController : Controller
	{
		
		public IActionResult Index()
		{
			ShoppingCart shoppingCart = new ShoppingCart() { Id = 1, NumberOfItems = 0, ListOfItems = new List<Product>(), PriceOfItems = 0 };
			return View(shoppingCart);
		}
	}
}
