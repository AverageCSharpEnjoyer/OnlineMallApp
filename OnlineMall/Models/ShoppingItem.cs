namespace OnlineMall.Models
{
	public class ShoppingItem
	{
		public int Id { get; set; }
		public string? ShortName { get; set; }
		public string? FullName { get; set; }
		public double? Price { get; set; }
		public int Size { get; set; }
		public string? Color { get; set; }
		public string? Description { get; set; }
		public string? ImgPath { get; set; }
	}
}
