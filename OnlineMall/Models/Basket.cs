namespace OnlineMall.Models
{
	public class Basket
	{
		public int Id { get; set; }
		public int NumberOfItems { get; set; }
		public double PriceOfItems { get; set; }
		public List<ShoppingItem> ListOfItems { get; set; }
	}
}
