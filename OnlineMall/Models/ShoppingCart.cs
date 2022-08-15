namespace OnlineMall.Models
{
	public class ShoppingCart
	{
		public double SumPrice { get; set; }
		public int SumQuantity { get; set; }
		public List<Item> ListOfItems { get; set; }
	}
}
