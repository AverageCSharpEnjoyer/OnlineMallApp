using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMall.Models
{
	public class ShoppingCart
	{
		[Range(1, 9999.99)]
		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(18, 2)")]
		public decimal SumPrice { get; set; }
		public int SumQuantity { get; set; }
		public List<Item> ListOfItems { get; set; }
	}
}
