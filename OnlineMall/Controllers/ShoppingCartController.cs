using Microsoft.AspNetCore.Mvc;
using OnlineMall.Models;
using OnlineMall.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using OnlineMall.Helpers;

namespace OnlineMall.Controllers
{
	public class ShoppingCartController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ShoppingCartController(ApplicationDbContext context)
		{
			_context = context;
		}
		
		public IActionResult Index()
		{
			var shoppingCart = SessionHelper.GetObjectFromJson<ShoppingCart>(HttpContext.Session, "shoppingCart");
			return View(shoppingCart);
		}

		public IActionResult Buy(int? id)
		{
			if(id == null)
			{
				return NotFound();
			}

			if(SessionHelper.GetObjectFromJson<ShoppingCart>(HttpContext.Session, "shoppingCart") == null)
			{
				ShoppingCart shoppingCart = new ShoppingCart() { ListOfItems = new List<Item>(), SumQuantity = 0, SumPrice = 0 };
				shoppingCart.ListOfItems.Add(new Item { Product = _context.Products.FirstOrDefault(p => p.Id == id), Quantity = 1 });
				shoppingCart.SumPrice = shoppingCart.ListOfItems.Sum(item => item.Product.Price);
				shoppingCart.SumQuantity = shoppingCart.ListOfItems.Sum(item => item.Quantity);

				SessionHelper.SetObjectAsJson(HttpContext.Session, "shoppingCart", shoppingCart);
			}
			else
			{
				ShoppingCart shoppingCart = SessionHelper.GetObjectFromJson<ShoppingCart>(HttpContext.Session, "shoppingCart");
				int index = getIdFromShoppingCart(id);
				if(index == -1)
				{
					shoppingCart.ListOfItems.Add(new Item { Product = _context.Products.FirstOrDefault(p => p.Id == id), Quantity = 1 });
				}
				else
				{
					shoppingCart.ListOfItems[index].Quantity++;
					shoppingCart.SumPrice = shoppingCart.ListOfItems.Sum(item => item.Product.Price);
					shoppingCart.SumQuantity = shoppingCart.ListOfItems.Sum(item => item.Quantity);
				}
				SessionHelper.SetObjectAsJson(HttpContext.Session, "shoppingCart", shoppingCart);
			}
		
			return RedirectToAction("Index");
		}

		private int getIdFromShoppingCart(int? id)
		{
			ShoppingCart shoppingCart = SessionHelper.GetObjectFromJson<ShoppingCart>(HttpContext.Session, "shoppingCart");

			for(int i =0; i< shoppingCart.ListOfItems.Count(); i++)
			{
				if (shoppingCart.ListOfItems[i].Product.Id == id)
				{
					return i;	
				}
			}
			return -1;
		}
	}
}
