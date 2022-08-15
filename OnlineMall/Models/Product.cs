using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMall.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string? ShortName { get; set; }
		public string? FullName { get; set; }
        [Range(1,9999.99)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
		public decimal Price { get; set; }
		public int Size { get; set; }
		public string? Color { get; set; }
		public string? Description { get; set; }
		public string? ImgPath { get; set; }
	}
}
