namespace OnlineMall.Models
{
	public class ShoppingCart
	{
		public int Id { get; set; }
		public int NumberOfItems { get; set; }
		public double PriceOfItems { get; set; }
		public List<Product> ListOfItems { get; set; }
	}
}
